using KaufAuto.Interfaces;
using KaufAuto.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace KaufAuto.Services
{
    public class AutoManager : IAutoService
    {
        // Liste aller Autos im System
        private List<Auto> autos = new List<Auto>();

        // nächste freie ID
        private int naechsteId = 1;

        // true, wenn seit dem letzten Speichern/Laden etwas geändert wurde
        public bool HatUngespeicherteAenderungen { get; private set; }

        // nach dem Speichern aufrufen
        public void MarkiereAlsGespeichert()
        {
            HatUngespeicherteAenderungen = false;
        }

        // Finanzierungsrechner
        private readonly FinanzierungsService finanzierung = new FinanzierungsService();

        // mögliche Kraftstoffarten
        private static readonly string[] Kraftstoffe = { "Benzin", "Diesel", "Elektro", "Hybrid" };

        // Zahl lesen: akzeptiert "25000", "25.000", "24999,99" und "24999.99" (>= 0)
        private static bool VersucheZahlZuLesen(string eingabe, out decimal zahl)
        {
            zahl = 0;
            if (string.IsNullOrWhiteSpace(eingabe))
                return false;

            string text = eingabe.Trim().Replace("€", "").Replace("%", "").Replace(" ", "");
            var deutsch = CultureInfo.GetCultureInfo("de-DE");

            bool ok;
            if (text.Contains(","))
            {
                // Komma = Dezimaltrennzeichen (deutsches Format)
                ok = decimal.TryParse(text, NumberStyles.Number, deutsch, out zahl);
            }
            else if (Regex.IsMatch(text, @"^\d{1,3}(\.\d{3})+$"))
            {
                // z. B. 25.000 → Punkt ist Tausendertrennzeichen
                ok = decimal.TryParse(text, NumberStyles.Number, deutsch, out zahl);
            }
            else
            {
                // z. B. 25000 oder 24999.99
                ok = decimal.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out zahl);
            }

            return ok && zahl >= 0;
        }

        // Preis lesen (muss größer als 0 sein)
        private static bool VersuchePreisZuLesen(string eingabe, out decimal preis)
        {
            return VersucheZahlZuLesen(eingabe, out preis) && preis > 0;
        }

        // j/n-Abfrage
        private static bool FrageJaNein(string frage)
        {
            Console.Write($"{frage} (j/n): ");
            string antwort = Console.ReadLine()?.Trim().ToLower();
            return antwort == "j" || antwort == "ja";
        }

        // Kraftstoff auswählen; mitLeer = true erlaubt Enter (gibt null zurück)
        private static string KraftstoffAuswaehlen(bool mitLeer)
        {
            Console.Write("Kraftstoff: 1 = Benzin, 2 = Diesel, 3 = Elektro, 4 = Hybrid");
            Console.WriteLine(mitLeer ? " (Enter = keine Änderung)" : "");

            while (true)
            {
                string eingabe = Console.ReadLine()?.Trim();
                if (mitLeer && string.IsNullOrWhiteSpace(eingabe))
                    return null;

                if (int.TryParse(eingabe, out int nr) && nr >= 1 && nr <= Kraftstoffe.Length)
                    return Kraftstoffe[nr - 1];

                Console.WriteLine("Ungültige Eingabe. Bitte 1, 2, 3 oder 4 eingeben.");
            }
        }

        // Auto über ID finden (Hilfsmethode)
        private Auto FindeAutoById(int id)
        {
            foreach (var auto in autos)
            {
                if (auto.Id == id)
                {
                    return auto;
                }
            }

            return null;
        }

        // Autos von außen setzen (z.B. nach Laden aus JSON)
        public void SetAutos(List<Auto> liste)
        {
            if (liste == null)
                autos = new List<Auto>();
            else
                autos = liste;

            if (autos.Count > 0)
            {
                naechsteId = autos.Max(a => a.Id) + 1;
            }
            else
            {
                naechsteId = 1;
            }

            // frisch geladene Daten gelten als gespeichert
            HatUngespeicherteAenderungen = false;
        }

        // Autos von JSON laden
        public void LadeAutosVonJson(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                Console.WriteLine("Keine JSON-Daten zum Laden vorhanden.");
                return;
            }

            JArray arr;
            try
            {
                arr = JArray.Parse(json);
            }
            catch (Exception)
            {
                Console.WriteLine("Fehler beim Parsen der JSON-Daten.");
                return;
            }

            var result = new List<Auto>();
            foreach (var item in arr)
            {
                string typ = item["Fahrzeugtyp"]?.ToString();
                switch (typ)
                {
                    case "PKW": result.Add(item.ToObject<PKW>()); break;
                    case "SUV": result.Add(item.ToObject<SUV>()); break;
                    case "Transporter": result.Add(item.ToObject<Transporter>()); break;
                    default: /* log/skip */ break;
                }
            }

            SetAutos(result);
            Console.WriteLine($"{result.Count} Autos wurden erfolgreich geladen.");
        }

        // Auto hinzufügen (mit Eingaben über Konsole)
        public void Hinzufuegen()
        {
            // Fahrzeugtyp auswählen (PKW, SUV oder Transporter)
            Console.WriteLine("Bitte Fahrzeugtyp auswählen:");
            Console.WriteLine("1 = PKW ");
            Console.WriteLine("2 = SUV ");
            Console.WriteLine("3 = Transporter ");

            int auswahl;
            while (!int.TryParse(Console.ReadLine(), out auswahl) || (auswahl < 1 || auswahl > 3))
            {
                Console.WriteLine("Ungültige Eingabe. Bitte 1, 2 oder 3 eingeben.");
            }

            Auto neuesAuto;

            switch (auswahl)
            {
                case 1:
                    neuesAuto = new PKW();
                    break;
                case 2:
                    neuesAuto = new SUV();
                    break;
                case 3:
                    neuesAuto = new Transporter();
                    break;
                default:
                    return;
            }

            // automatische ID & Typ setzen
            neuesAuto.Id = GeneriereId();
            neuesAuto.Fahrzeugtyp = neuesAuto.GetType().Name;

            // Marke und Modell abfragen
            Console.WriteLine("Marke eingeben:");
            neuesAuto.Marke = Console.ReadLine();

            Console.WriteLine("Modell eingeben:");
            neuesAuto.Modell = Console.ReadLine();

            // Motorleistung (PS) eingeben
            int ps;
            Console.WriteLine("PS eingeben:");
            while (!int.TryParse(Console.ReadLine(), out ps) || ps < 1)
            {
                Console.WriteLine("Ungültige Eingabe! PS muss mindestens 1 sein.");
                Console.WriteLine("PS erneut eingeben:");
            }
            neuesAuto.MotorleistungPS = ps;

            // Getriebe auswählen: 1 = Automatik, 2 = Schaltgetriebe
            Console.WriteLine("Getriebe auswählen: 1 = Automatik, 2 = Schaltgetriebe");
            int getriebeAuswahl;
            while (!int.TryParse(Console.ReadLine(), out getriebeAuswahl) || (getriebeAuswahl < 1 || getriebeAuswahl > 2))
            {
                Console.WriteLine("Ungültige Eingabe. Bitte 1 oder 2 eingeben.");
            }
            if (getriebeAuswahl == 1)
            {
                neuesAuto.Getriebe = "Automatik";
            }
            else
            {
                neuesAuto.Getriebe = "Schaltgetriebe";
            }

            // Kraftstoff auswählen
            neuesAuto.Kraftstoff = KraftstoffAuswaehlen(false);

            // Preis eingeben
            decimal preis;
            Console.WriteLine("Preis eingeben (z. B. 25.000 oder 24999,99):");
            while (!VersuchePreisZuLesen(Console.ReadLine(), out preis))
            {
                Console.WriteLine("Ungültige Eingabe! Preis muss größer als 0 sein.");
                Console.WriteLine("Preis erneut eingeben:");
            }
            neuesAuto.Preis = preis;

            // Baujahr eingeben
            int baujahr;
            Console.WriteLine("Baujahr eingeben (z. B. 2015):");
            while (!int.TryParse(Console.ReadLine(), out baujahr)
                   || baujahr < 1900
                   || baujahr > DateTime.Now.Year)
            {
                Console.WriteLine("Ungültiges Baujahr! Bitte korrektes Jahr eingeben:");
            }
            neuesAuto.Baujahr = baujahr;

            // Zustand auswählen: Neu oder Gebraucht
            Console.WriteLine("Zustand auswählen: 1 = Neu, 2 = Gebraucht");
            int zustandAuswahl;
            while (!int.TryParse(Console.ReadLine(), out zustandAuswahl) || (zustandAuswahl < 1 || zustandAuswahl > 2))
            {
                Console.WriteLine("Ungültige Eingabe. Bitte 1 oder 2 eingeben.");
            }

            if (zustandAuswahl == 1)
            {
                neuesAuto.Zustand = "Neu";
                neuesAuto.Kilometerstand = 0;
                Console.WriteLine("Kilometerstand wird auf 0 gesetzt (Neuwagen).");
            }
            else
            {
                neuesAuto.Zustand = "Gebraucht";
                int km;
                Console.WriteLine("Kilometerstand eingeben:");
                while (!int.TryParse(Console.ReadLine(), out km) || km < 0)
                {
                    Console.WriteLine("Ungültige Eingabe! Kilometerstand muss mindestens 0 sein.");
                    Console.WriteLine("Kilometerstand erneut eingeben:");
                }
                neuesAuto.Kilometerstand = km;
            }

            // Türenanzahl eingeben
            int tueren;
            Console.WriteLine("Anzahl der Türen eingeben (z. B. 2, 3, 4 oder 5):");
            while (!int.TryParse(Console.ReadLine(), out tueren) || (tueren < 2 || tueren > 5))
            {
                Console.WriteLine("Ungültige Eingabe! Anzahl der Türen muss zwischen 2 und 5 liegen.");
                Console.WriteLine("Anzahl der Türen erneut eingeben:");
            }
            neuesAuto.Türenanzahl = tueren;

            // Auto speichern
            if (neuesAuto != null)
            {
                autos.Add(neuesAuto);
                HatUngespeicherteAenderungen = true;
                Console.WriteLine("Fahrzeug erfolgreich hinzugefügt!");
                neuesAuto.Info();
                Console.WriteLine("-------------------------------------");
            }
        }

        // Auto löschen
        public bool Loeschen(int id)
        {
            Auto gefundenesAuto = autos.FirstOrDefault(a => a.Id == id);

            if (gefundenesAuto == null)
            {
                Console.WriteLine("Kein Auto mit dieser ID gefunden.");
                return false;
            }

            Console.WriteLine("Auto gefunden:");
            gefundenesAuto.Info();
            Console.WriteLine("--------------------------------------");

            // Sicherheitsabfrage vor dem Löschen
            if (!FrageJaNein("Wirklich löschen?"))
            {
                Console.WriteLine("Löschen abgebrochen.");
                return false;
            }

            autos.Remove(gefundenesAuto);
            HatUngespeicherteAenderungen = true;

            Console.WriteLine("Auto erfolgreich gelöscht.");
            Console.WriteLine("-------------------------------------");

            return true;
        }

        // Auto bearbeiten
        public void Bearbeiten(int id, Auto neueDaten)
        {
            Auto auto = FindeAutoById(id);

            if (auto == null)
            {
                Console.WriteLine("Kein Auto mit dieser ID gefunden.");
                return;
            }

            Console.WriteLine("Auto gefunden:");
            auto.Info();
            Console.WriteLine("----------------------------------------");

            // Marke bearbeiten
            Console.WriteLine($"Aktuelle Marke: {auto.Marke}");
            Console.Write("Neue Marke eingeben (Enter = keine Änderung): ");
            string neueMarke = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(neueMarke))
            {
                auto.Marke = neueMarke;
            }

            // Baujahr bearbeiten
            Console.WriteLine($"Aktuelles Baujahr: {auto.Baujahr}");
            Console.Write("Neues Baujahr eingeben (Enter = keine Änderung): ");
            string baujahrEingabe = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(baujahrEingabe))
            {
                int neuesBaujahr;
                while (!int.TryParse(baujahrEingabe, out neuesBaujahr)
                       || neuesBaujahr < 1900
                       || neuesBaujahr > DateTime.Now.Year)
                {
                    Console.WriteLine("Ungültige Eingabe! Bitte korrektes Jahr eingeben:");
                    baujahrEingabe = Console.ReadLine();
                }
                auto.Baujahr = neuesBaujahr;
            }

            // Modell bearbeiten
            Console.WriteLine($"Aktuelles Modell: {auto.Modell}");
            Console.Write("Neues Modell eingeben (Enter = keine Änderung): ");
            string neuesModell = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(neuesModell))
            {
                auto.Modell = neuesModell;
            }

            // PS bearbeiten
            Console.WriteLine($"Aktuelle PS: {auto.MotorleistungPS}");
            Console.Write("Neue PS eingeben (Enter = keine Änderung): ");
            string psEingabe = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(psEingabe))
            {
                int neuePs;
                while (!int.TryParse(psEingabe, out neuePs) || neuePs < 1)
                {
                    Console.WriteLine("Ungültige Eingabe! PS muss mindestens 1 sein.");
                    Console.Write("Bitte PS erneut eingeben: ");
                    psEingabe = Console.ReadLine();
                }
                auto.MotorleistungPS = neuePs;
            }

            // Getriebe bearbeiten
            Console.WriteLine($"Aktuelles Getriebe: {auto.Getriebe}");
            Console.Write("Neues Getriebe: 1 = Automatik, 2 = Schaltgetriebe (Enter = keine Änderung): ");
            string getriebeEingabe = Console.ReadLine()?.Trim();
            while (!string.IsNullOrWhiteSpace(getriebeEingabe) && getriebeEingabe != "1" && getriebeEingabe != "2")
            {
                Console.Write("Ungültige Eingabe. Bitte 1, 2 oder Enter eingeben: ");
                getriebeEingabe = Console.ReadLine()?.Trim();
            }
            if (getriebeEingabe == "1")
            {
                auto.Getriebe = "Automatik";
            }
            else if (getriebeEingabe == "2")
            {
                auto.Getriebe = "Schaltgetriebe";
            }

            // Kraftstoff bearbeiten
            Console.WriteLine($"Aktueller Kraftstoff: {auto.Kraftstoff ?? "-"}");
            string neuerKraftstoff = KraftstoffAuswaehlen(true);
            if (neuerKraftstoff != null)
            {
                auto.Kraftstoff = neuerKraftstoff;
            }

            // Preis bearbeiten
            Console.WriteLine($"Aktueller Preis: {auto.Preis:N2} €");
            Console.Write("Neuen Preis eingeben (Enter = keine Änderung): ");
            string preisEingabe = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(preisEingabe))
            {
                decimal neuerPreis;
                while (!VersuchePreisZuLesen(preisEingabe, out neuerPreis))
                {
                    Console.WriteLine("Ungültige Eingabe! Preis muss eine Zahl und größer als 0 sein.");
                    Console.Write("Bitte Preis erneut eingeben: ");
                    preisEingabe = Console.ReadLine();
                }
                auto.Preis = neuerPreis;
            }

            // Zustand bearbeiten
            Console.WriteLine($"Aktueller Zustand: {auto.Zustand}");
            Console.Write("Neuer Zustand: 1 = Neu, 2 = Gebraucht (Enter = keine Änderung): ");
            string zustandEingabe = Console.ReadLine()?.Trim();
            while (!string.IsNullOrWhiteSpace(zustandEingabe) && zustandEingabe != "1" && zustandEingabe != "2")
            {
                Console.Write("Ungültige Eingabe. Bitte 1, 2 oder Enter eingeben: ");
                zustandEingabe = Console.ReadLine()?.Trim();
            }
            if (zustandEingabe == "1")
            {
                auto.Zustand = "Neu";
            }
            else if (zustandEingabe == "2")
            {
                auto.Zustand = "Gebraucht";
            }

            // Kilometer bearbeiten (Neuwagen haben immer 0 km)
            if (auto.Zustand == "Neu")
            {
                if (auto.Kilometerstand != 0)
                {
                    auto.Kilometerstand = 0;
                    Console.WriteLine("Kilometerstand wird auf 0 gesetzt (Neuwagen).");
                }
            }
            else
            {
                Console.WriteLine($"Aktueller Kilometerstand: {auto.Kilometerstand}");
                Console.Write("Neuen Kilometerstand eingeben (Enter = keine Änderung): ");
                string kmEingabe = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(kmEingabe))
                {
                    int neuerKm;
                    while (!int.TryParse(kmEingabe, out neuerKm) || neuerKm < 0)
                    {
                        Console.WriteLine("Ungültige Eingabe! Kilometerstand muss eine Zahl und >= 0 sein.");
                        Console.Write("Bitte Kilometer erneut eingeben: ");
                        kmEingabe = Console.ReadLine();
                    }
                    auto.Kilometerstand = neuerKm;
                }
            }

            // Türen bearbeiten
            Console.WriteLine($"Aktuelle Anzahl Türen: {auto.Türenanzahl}");
            Console.Write("Neue Anzahl Türen (2-5) eingeben (Enter = keine Änderung): ");
            string tuerenEingabe = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(tuerenEingabe))
            {
                int neueTueren;
                while (!int.TryParse(tuerenEingabe, out neueTueren) || neueTueren < 2 || neueTueren > 5)
                {
                    Console.WriteLine("Ungültige Eingabe! Anzahl der Türen muss zwischen 2 und 5 liegen.");
                    Console.Write("Bitte Anzahl Türen erneut eingeben: ");
                    tuerenEingabe = Console.ReadLine();
                }
                auto.Türenanzahl = neueTueren;
            }

            HatUngespeicherteAenderungen = true;

            Console.WriteLine("Neue Fahrzeugdaten:");
            auto.Info();
            Console.WriteLine("--------------------------------");
        }

        // Alle Autos zurückgeben (Anzeige übernimmt AnzeigenAlsTabelle)
        public List<Auto> AlleAutos()
        {
            return autos;
        }

        // Autos nach Marke suchen (Anzeige übernimmt AnzeigenAlsTabelle)
        public List<Auto> SucheNachMarke(string marke)
        {
            if (string.IsNullOrWhiteSpace(marke))
            {
                return new List<Auto>();
            }

            string suchbegriff = marke.ToLower();

            return autos
                .Where(a => a.Marke != null && a.Marke.ToLower().Contains(suchbegriff))
                .ToList();
        }

        // Auswertungen erstellen
        public (int gesamt, int neu, int gebraucht, double kmPkw, double kmTransporter) ErstelleAuswertungen()
        {
            int gesamt = autos.Count;
            int neu = autos.Count(a => a.Zustand == "Neu");
            int gebraucht = autos.Count(a => a.Zustand == "Gebraucht");

            double kmPkw = autos.Where(a => a is PKW).Sum(a => a.Kilometerstand);
            double kmTransporter = autos.Where(a => a is Transporter).Sum(a => a.Kilometerstand);

            return (gesamt, neu, gebraucht, kmPkw, kmTransporter);
        }

        // Verkaufs-Auswertung: Anzahl verkauft, Umsatz, Wert des Restbestands
        public (int verkauft, decimal umsatz, int verfuegbar, decimal bestandswert) ErstelleVerkaufsAuswertung()
        {
            var verkaufte = autos.Where(a => a.Verkauft).ToList();
            var verfuegbare = autos.Where(a => !a.Verkauft).ToList();

            decimal umsatz = verkaufte.Sum(a => a.Verkaufspreis ?? a.Preis);
            decimal bestandswert = verfuegbare.Sum(a => a.Preis);

            return (verkaufte.Count, umsatz, verfuegbare.Count, bestandswert);
        }

        // Auto verkaufen
        public bool Verkaufen(int id)
        {
            Auto auto = FindeAutoById(id);

            if (auto == null)
            {
                Console.WriteLine("Kein Auto mit dieser ID gefunden.");
                return false;
            }

            auto.Info();
            Console.WriteLine("----------------------------------------");

            if (auto.Verkauft)
            {
                Console.WriteLine("Dieses Auto wurde bereits verkauft.");
                return false;
            }

            // Käufer eingeben
            Console.Write("Name des Käufers: ");
            string kaeufer = Console.ReadLine()?.Trim();
            while (string.IsNullOrWhiteSpace(kaeufer))
            {
                Console.Write("Bitte einen Namen eingeben: ");
                kaeufer = Console.ReadLine()?.Trim();
            }

            // Verkaufspreis (Enter = Listenpreis)
            Console.Write($"Verkaufspreis (Enter = Listenpreis {auto.Preis:N2} €): ");
            string preisEingabe = Console.ReadLine();
            decimal verkaufspreis = auto.Preis;
            if (!string.IsNullOrWhiteSpace(preisEingabe))
            {
                while (!VersuchePreisZuLesen(preisEingabe, out verkaufspreis))
                {
                    Console.Write("Ungültiger Preis. Bitte erneut eingeben: ");
                    preisEingabe = Console.ReadLine();
                }
            }

            if (verkaufspreis < auto.Preis)
            {
                decimal rabatt = auto.Preis - verkaufspreis;
                Console.WriteLine($"Rabatt: {rabatt:N2} € ({rabatt / auto.Preis:P1})");
            }

            if (!FrageJaNein($"Auto an {kaeufer} für {verkaufspreis:N2} € verkaufen?"))
            {
                Console.WriteLine("Verkauf abgebrochen.");
                return false;
            }

            auto.Verkauft = true;
            auto.Kaeufer = kaeufer;
            auto.Verkaufspreis = verkaufspreis;
            auto.Verkaufsdatum = DateTime.Today;
            HatUngespeicherteAenderungen = true;

            Console.WriteLine("Auto erfolgreich verkauft!");
            auto.Info();
            return true;
        }

        // Finanzierung für ein Auto berechnen
        public void FinanzierungBerechnen(int id)
        {
            Auto auto = FindeAutoById(id);

            if (auto == null)
            {
                Console.WriteLine("Kein Auto mit dieser ID gefunden.");
                return;
            }

            auto.Info();
            Console.WriteLine("----------------------------------------");

            if (auto.Verkauft)
            {
                Console.WriteLine("Dieses Auto ist bereits verkauft.");
                return;
            }

            // Anzahlung (Enter = 0)
            decimal anzahlung = 0;
            Console.Write("Anzahlung in € (Enter = 0): ");
            string eingabe = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(eingabe))
            {
                while (!VersucheZahlZuLesen(eingabe, out anzahlung) || anzahlung >= auto.Preis)
                {
                    Console.Write($"Ungültig! Anzahlung muss zwischen 0 und {auto.Preis:N2} € liegen: ");
                    eingabe = Console.ReadLine();
                }
            }

            // Laufzeit
            int monate;
            Console.Write("Laufzeit in Monaten (12 - 96): ");
            while (!int.TryParse(Console.ReadLine(), out monate) || monate < 12 || monate > 96)
            {
                Console.Write("Ungültig! Bitte 12 bis 96 Monate eingeben: ");
            }

            // Zinssatz (Enter = 4,9 %)
            decimal zins = 4.9m;
            Console.Write("Zinssatz pro Jahr in % (Enter = 4,9): ");
            eingabe = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(eingabe))
            {
                while (!VersucheZahlZuLesen(eingabe, out zins) || zins > 30)
                {
                    Console.Write("Ungültig! Bitte einen Zinssatz zwischen 0 und 30 eingeben: ");
                    eingabe = Console.ReadLine();
                }
            }

            FinanzierungsErgebnis ergebnis = finanzierung.Berechne(auto.Preis, anzahlung, monate, zins);

            Console.WriteLine();
            Console.WriteLine("========== FINANZIERUNG ==========");
            Console.WriteLine($"Fahrzeugpreis:    {auto.Preis,14:N2} €");
            Console.WriteLine($"Anzahlung:        {anzahlung,14:N2} €");
            Console.WriteLine($"Kreditbetrag:     {ergebnis.Kreditbetrag,14:N2} €");
            Console.WriteLine($"Laufzeit:         {monate,14} Monate");
            Console.WriteLine($"Zinssatz:         {zins,14:N2} %");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Monatsrate:       {ergebnis.Monatsrate,14:N2} €");
            Console.WriteLine($"Zinskosten:       {ergebnis.Zinskosten,14:N2} €");
            Console.WriteLine($"Gesamtkosten:     {ergebnis.Gesamtkosten,14:N2} €");
            Console.WriteLine("==================================");
        }

        // Autos als Tabelle anzeigen (für AlleAutos, Suche, Sortierungen …)
        public void AnzeigenAlsTabelle(List<Auto> liste)
        {
            if (liste == null || liste.Count == 0)
            {
                Console.WriteLine("Keine Autos vorhanden.");
                return;
            }

            string linie = new string('-', 124);

            Console.WriteLine(linie);
            Console.WriteLine(
                $"{"ID",-3} {"Marke",-10} {"Modell",-12} {"Baujahr",-7} {"PS",-5} {"KM",-8} {"Kraftstoff",-10} {"Getriebe",-14} {"Zustand",-9} {"Türen",-5} {"Preis",14} {"Status",-10}"
            );
            Console.WriteLine(linie);

            foreach (var a in liste)
            {
                string status = a.Verkauft ? "Verkauft" : "Verfügbar";
                Console.WriteLine(
                    $"{a.Id,-3} {a.Marke,-10} {a.Modell,-12} {a.Baujahr,-7} {a.MotorleistungPS,-5} {a.Kilometerstand,-8} {a.Kraftstoff ?? "-",-10} {a.Getriebe,-14} {a.Zustand,-9} {a.Türenanzahl,-5} {a.Preis,12:N2} € {status,-10}"
                );
            }

            Console.WriteLine(linie);
        }

        // Sortierung nach Preis
        public void SortNachPreis()
        {
            var sortiert = autos.OrderByDescending(a => a.Preis).ToList();

            Console.WriteLine("Autos sortiert nach Preis (absteigend):");
            AnzeigenAlsTabelle(sortiert);
        }

        // Sortierung nach Baujahr
        public void SortNachBaujahr()
        {
            var sortiert = autos.OrderByDescending(a => a.Baujahr).ToList();

            Console.WriteLine("Autos sortiert nach Baujahr (neueste zuerst):");
            AnzeigenAlsTabelle(sortiert);
        }

        // Sortierung nach PS
        public void SortNachPS()
        {
            var sortiert = autos.OrderByDescending(a => a.MotorleistungPS).ToList();

            Console.WriteLine("Autos sortiert nach PS (absteigend):");
            AnzeigenAlsTabelle(sortiert);
        }

        // neue ID generieren
        private int GeneriereId()
        {
            return naechsteId++;
        }

        // Autos in Datei speichern (hilfsweise; Pfad validieren)
        public void Speichern(string dateiPfad)
        {
            if (string.IsNullOrWhiteSpace(dateiPfad))
                throw new ArgumentException("dateiPfad darf nicht leer sein.", nameof(dateiPfad));

            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            string json = JsonConvert.SerializeObject(autos, Formatting.Indented, settings);
            File.WriteAllText(dateiPfad, json);
        }

        // Autos aus Datei laden (hilfsweise; Pfad validieren)
        public void Laden(string dateiPfad)
        {
            if (string.IsNullOrWhiteSpace(dateiPfad))
            {
                Console.WriteLine("Kein Dateipfad angegeben.");
                return;
            }

            if (!File.Exists(dateiPfad))
            {
                Console.WriteLine("Datei nicht gefunden!");
                return;
            }

            string json = File.ReadAllText(dateiPfad);
            if (string.IsNullOrWhiteSpace(json))
            {
                Console.WriteLine("Datei ist leer.");
                SetAutos(new List<Auto>());
                return;
            }

            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            List<Auto> geladeneAutos;
            try
            {
                geladeneAutos = JsonConvert.DeserializeObject<List<Auto>>(json, settings) ?? new List<Auto>();
            }
            catch (Exception)
            {
                Console.WriteLine("Fehler beim Deserialisieren der Datei.");
                return;
            }

            SetAutos(geladeneAutos);

            Console.WriteLine($"{geladeneAutos.Count} Autos wurden erfolgreich geladen.");
        }
    }
}