using KaufAuto.Interfaces;
using KaufAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

            // Preis eingeben
            double preis;
            Console.WriteLine("Preis eingeben:");
            while (!double.TryParse(Console.ReadLine(), out preis) || preis <= 0)
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

            autos.Remove(gefundenesAuto);

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

            // Preis bearbeiten
            Console.WriteLine($"Aktueller Preis: {auto.Preis}");
            Console.Write("Neuen Preis eingeben (Enter = keine Änderung): ");
            string preisEingabe = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(preisEingabe))
            {
                double neuerPreis;
                while (!double.TryParse(preisEingabe, out neuerPreis) || neuerPreis <= 0)
                {
                    Console.WriteLine("Ungültige Eingabe! Preis muss eine Zahl und größer als 0 sein.");
                    Console.Write("Bitte Preis erneut eingeben: ");
                    preisEingabe = Console.ReadLine();
                }
                auto.Preis = neuerPreis;
            }

            // Kilometer bearbeiten
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

            Console.WriteLine("Neue Fahrzeugdaten:");
            auto.Info();
            Console.WriteLine("--------------------------------");
        }

        // Alle Autos anzeigen (und zurückgeben)
        public List<Auto> AlleAutos()
        {
            if (autos.Count == 0)
            {
                Console.WriteLine("Keine Autos im System vorhanden.");
                return new List<Auto>();
            }

            Console.WriteLine("Aktueller Fahrzeugbestand:");
            AnzeigenAlsTabelle(autos);

            return autos;
        }

        // Autos nach Marke suchen
        public List<Auto> SucheNachMarke(string marke)
        {
            if (string.IsNullOrWhiteSpace(marke))
            {
                Console.WriteLine("Keine gültige Marke eingegeben.");
                return new List<Auto>();
            }

            string suchbegriff = marke.ToLower();

            var gefundene = autos
                .Where(a => a.Marke != null && a.Marke.ToLower().Contains(suchbegriff))
                .ToList();

            if (gefundene.Count == 0)
            {
                Console.WriteLine("Keine Autos gefunden für diese Marke.");
                return new List<Auto>();
            }

            Console.WriteLine("Gefundene Autos:");
            AnzeigenAlsTabelle(gefundene);

            return gefundene;
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

        // Autos als Tabelle anzeigen (für AlleAutos, Suche, Sortierungen …)
        public void AnzeigenAlsTabelle(List<Auto> liste)
        {
            if (liste == null || liste.Count == 0)
            {
                Console.WriteLine("Keine Autos vorhanden.");
                return;
            }

            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine(
                $"{"ID",-3} {"Marke",-10} {"Modell",-12} {"Baujahr",-7} {"PS",-5} {"KM",-10} {"Getriebe",-12} {"Zustand",-10} {"Türen",-5} {"Preis",-10}"
            );
            Console.WriteLine("---------------------------------------------------------------------------------------------");

            foreach (var a in liste)
            {
                Console.WriteLine(
                    $"{a.Id,-3} {a.Marke,-10} {a.Modell,-12} {a.Baujahr,-7} {a.MotorleistungPS,-5} {a.Kilometerstand,-10} {a.Getriebe,-12} {a.Zustand,-10} {a.Türenanzahl,-5} {a.Preis,-10}"
                );
            }

            Console.WriteLine("---------------------------------------------------------------------------------------------");
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