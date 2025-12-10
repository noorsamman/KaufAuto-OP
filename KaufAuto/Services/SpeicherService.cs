using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using KaufAuto.Models;
using KaufAuto.Interfaces;


namespace KaufAuto.Services
{
    // Service class for saving and loading car data
    public class SpeicherService : ISpeicherService
    {
        private string dateiPfad = "autos.json";
        public void Speichern(List<Auto> autos)
        {
            string json = JsonConvert.SerializeObject(autos, Formatting.Indented);
            File.WriteAllText(dateiPfad, json);

            Console.WriteLine("Daten wurden erfolgreich gespeichert.");
        }
        // Load car data from JSON file

        public List<Auto> Laden()
        {
            // Datei existiert nicht → leere Liste

            if (!File.Exists(dateiPfad))
                return new List<Auto>();

            string json = File.ReadAllText(dateiPfad);

            // Datei existiert aber leer

            if (string.IsNullOrWhiteSpace(json))
                return new List<Auto>();

            // JSON parsen

            JArray array;

            try
            {
                array = JArray.Parse(json);
            }
            catch
            {
                Console.WriteLine("Fehler beim Lesen der JSON-Datei. Datei ist beschädigt.");
                return new List<Auto>();
            }

            var liste = new List<Auto>();

            // Jede JSON-Zeile ein Auto

            foreach (var item in array)
            {
                string typ = item["Fahrzeugtyp"]?.ToString();
                Auto auto = null;

                switch (typ)
                {
                    case "PKW":
                        auto = item.ToObject<PKW>();
                        break;

                    case "SUV":
                        auto = item.ToObject<SUV>();
                        break;

                    case "Transporter":
                        auto = item.ToObject<Transporter>();
                        break;

                    default:
                        Console.WriteLine("Unbekannter Fahrzeugtyp in JSON gefunden.");
                        break;
                }

                if (auto != null)
                    liste.Add(auto);
            }

            return liste;
        }



    }
}
