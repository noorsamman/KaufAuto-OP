using KaufAuto.Services;
using System;
using System.Collections.Generic;
using KaufAuto.Models;

namespace KaufAuto
{
    internal class Program
    {      // Hauptmethode
        static void Main(string[] args)
        {
            AutoManager manager = new AutoManager();
            SpeicherService speicher = new SpeicherService();

            // Autos beim Start laden (null-sicher)
            var geladeneAutos = speicher.Laden() ?? new List<Auto>();
            manager.SetAutos(geladeneAutos);

            if (geladeneAutos != null && geladeneAutos.Count > 0)
            {
                Console.WriteLine($"{geladeneAutos.Count} Autos wurden aus der JSON-Datei geladen.");
            }

            //Loop für das Menü
            bool running = true;

            while (running)
            {
                Console.WriteLine("===============================");
                Console.WriteLine("      AUTO VERWALTUNG");
                Console.WriteLine("===============================");
                Console.WriteLine("1 - Auto hinzufügen");
                Console.WriteLine("2 - Auto löschen");
                Console.WriteLine("3 - Auto bearbeiten");
                Console.WriteLine("4 - Alle Autos anzeigen");
                Console.WriteLine("5 - Suche nach Marke");
                Console.WriteLine("6 - Auswertungen anzeigen");
                Console.WriteLine("7 - Autos speichern");
                Console.WriteLine("8 - Autos laden");
                Console.WriteLine("9 - Autos nach Preis sortieren");
                Console.WriteLine("10 - Autos nach Baujahr sortieren");
                Console.WriteLine("11 - Autos nach PS sortieren");
                Console.WriteLine("0 - Programm beenden");
                Console.WriteLine("===============================");
                Console.Write("Auswahl eingeben: ");

                // Benutzereingabe lesen (null-sicher)
                string auswahl = Console.ReadLine()?.Trim();
                Console.Clear();

                // Menüauswahl verarbeiten
                switch (auswahl ?? string.Empty)
                {
                    // Verschiedene Fälle für jede Menüoption
                    //Hinzufügen
                    case "1":
                        manager.Hinzufuegen();
                        break;

                    //Löschen
                    case "2":
                        Console.Write("ID eingeben zum Löschen: ");
                        var delInput = Console.ReadLine()?.Trim();
                        if (!string.IsNullOrWhiteSpace(delInput) && int.TryParse(delInput, out int idLoeschen))
                        {
                            manager.Loeschen(idLoeschen);
                        }
                        else
                        {
                            Console.WriteLine("Ungültige ID. Bitte eine numerische ID eingeben.");
                        }
                        break;

                    //Bearbeiten
                    case "3":
                        Console.Write("ID eingeben zum Bearbeiten: ");
                        var editInput = Console.ReadLine()?.Trim();
                        if (!string.IsNullOrWhiteSpace(editInput) && int.TryParse(editInput, out int idBearbeiten))
                        {
                            manager.Bearbeiten(idBearbeiten, null);
                        }
                        else
                        {
                            Console.WriteLine("Ungültige ID. Bitte eine numerische ID eingeben.");
                        }
                        break;

                    //Alle anzeigen
                    case "4":
                        manager.AnzeigenAlsTabelle(manager.AlleAutos());
                        break;

                    //Suche nach Marke
                    case "5":
                        Console.Write("Marke eingeben zum Suchen: ");
                        string marke = Console.ReadLine()?.Trim();
                        if (string.IsNullOrWhiteSpace(marke))
                        {
                            Console.WriteLine("Ungültige Marke eingegeben.");
                        }
                        else
                        {
                            List<Auto> autos = manager.SucheNachMarke(marke);
                            manager.AnzeigenAlsTabelle(autos);
                        }
                        break;

                    //Auswertungen
                    case "6":
                        var adaten = manager.ErstelleAuswertungen();
                        Console.WriteLine("Auswertungen:");
                        Console.WriteLine($"Gesamtanzahl Autos: {adaten.gesamt}");
                        Console.WriteLine($"Anzahl Neuwagen: {adaten.neu}");
                        Console.WriteLine($"Anzahl Gebrauchtwagen: {adaten.gebraucht}");
                        Console.WriteLine($"Summe Kilometer PKW: {adaten.kmPkw:F2}");
                        Console.WriteLine($"Summe Kilometer Transporter: {adaten.kmTransporter:F2}");
                        break;

                    //Speichern
                    case "7":
                        try
                        {
                            speicher.Speichern(manager.AlleAutos());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Fehler beim Speichern: {ex.Message}");
                        }
                        break;

                    //Laden
                    case "8":
                        try
                        {
                            var neuGeladene = speicher.Laden() ?? new List<Auto>();
                            manager.SetAutos(neuGeladene);
                            Console.WriteLine($"{neuGeladene.Count} Autos wurden neu geladen.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Fehler beim Laden: {ex.Message}");
                        }
                        break;

                    // Sortieroptionen
                    //Nach Preis
                    case "9":
                        manager.SortNachPreis();
                        Console.WriteLine("Autos nach Preis sortiert.");
                        break;

                    //Nach Baujahr
                    case "10":
                        manager.SortNachBaujahr();
                        Console.WriteLine("Autos nach Baujahr sortiert.");
                        break;

                    //Nach PS
                    case "11":
                        manager.SortNachPS();
                        Console.WriteLine("Autos nach PS sortiert.");
                        break;

                    //Beenden
                    case "0":
                        running = false;
                        break;

                    //ungültige Auswahl
                    default:
                        Console.WriteLine("Ungültige Auswahl. Bitte erneut versuchen.");
                        break;
                }

                // Warten auf Benutzereingabe bevor das Menü neu angezeigt wird
                Console.WriteLine("\nWeiter mit Enter...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}