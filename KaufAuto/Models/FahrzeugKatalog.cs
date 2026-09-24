using System;
using System.Collections.Generic;
using System.Linq;

namespace KaufAuto.Models
{
    // Vorschläge für Marken und Modelle, sortiert nach Fahrzeugtyp.
    // Neue Marken/Modelle einfach unten in die Listen eintragen.
    public static class FahrzeugKatalog
    {
        private static readonly Dictionary<string, Dictionary<string, string[]>> katalog =
            new Dictionary<string, Dictionary<string, string[]>>(StringComparer.OrdinalIgnoreCase)
        {
            ["PKW"] = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase)
            {
                ["Audi"] = new[] { "A1", "A3", "A4", "A5", "A6", "A8", "e-tron GT" },
                ["BMW"] = new[] { "1er", "2er", "3er", "4er", "5er", "7er", "i4", "i5" },
                ["Fiat"] = new[] { "500", "Panda", "Tipo" },
                ["Ford"] = new[] { "Fiesta", "Focus", "Mondeo", "Mustang" },
                ["Hyundai"] = new[] { "i10", "i20", "i30", "Ioniq 6" },
                ["Kia"] = new[] { "Picanto", "Rio", "Ceed" },
                ["Mercedes"] = new[] { "A-Klasse", "C-Klasse", "E-Klasse", "S-Klasse", "CLA" },
                ["Opel"] = new[] { "Corsa", "Astra", "Insignia" },
                ["Peugeot"] = new[] { "208", "308", "508" },
                ["Renault"] = new[] { "Clio", "Megane" },
                ["Seat"] = new[] { "Ibiza", "Leon" },
                ["Skoda"] = new[] { "Fabia", "Octavia", "Superb" },
                ["Tesla"] = new[] { "Model 3", "Model S" },
                ["Toyota"] = new[] { "Yaris", "Corolla", "Camry", "Prius" },
                ["VW"] = new[] { "Polo", "Golf", "Passat", "Arteon", "ID.3" },
            },
            ["SUV"] = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase)
            {
                ["Audi"] = new[] { "Q2", "Q3", "Q4 e-tron", "Q5", "Q7", "Q8" },
                ["BMW"] = new[] { "X1", "X2", "X3", "X5", "X7", "iX" },
                ["Dacia"] = new[] { "Duster" },
                ["Ford"] = new[] { "Puma", "Kuga", "Explorer" },
                ["Hyundai"] = new[] { "Kona", "Tucson", "Santa Fe" },
                ["Kia"] = new[] { "Stonic", "Sportage", "Sorento", "EV9" },
                ["Mercedes"] = new[] { "GLA", "GLC", "GLE", "GLS", "G-Klasse" },
                ["Porsche"] = new[] { "Macan", "Cayenne" },
                ["Skoda"] = new[] { "Kamiq", "Karoq", "Kodiaq" },
                ["Tesla"] = new[] { "Model Y", "Model X" },
                ["Toyota"] = new[] { "C-HR", "RAV4", "Land Cruiser" },
                ["Volvo"] = new[] { "XC40", "XC60", "XC90" },
                ["VW"] = new[] { "T-Roc", "Tiguan", "Touareg", "ID.4" },
            },
            ["Transporter"] = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase)
            {
                ["Citroën"] = new[] { "Berlingo", "Jumpy", "Jumper" },
                ["Fiat"] = new[] { "Doblo", "Ducato" },
                ["Ford"] = new[] { "Transit Connect", "Transit Custom", "Transit" },
                ["Iveco"] = new[] { "Daily" },
                ["Mercedes"] = new[] { "Citan", "Vito", "Sprinter" },
                ["Opel"] = new[] { "Combo", "Vivaro", "Movano" },
                ["Peugeot"] = new[] { "Partner", "Expert", "Boxer" },
                ["Renault"] = new[] { "Kangoo", "Trafic", "Master" },
                ["Toyota"] = new[] { "Proace" },
                ["VW"] = new[] { "Caddy", "Transporter", "Crafter", "ID. Buzz" },
            },
        };

        // alle Marken für einen Fahrzeugtyp (alphabetisch)
        public static string[] Marken(string fahrzeugtyp)
        {
            if (fahrzeugtyp == null || !katalog.TryGetValue(fahrzeugtyp, out var marken))
                return new string[0];

            return marken.Keys.OrderBy(m => m).ToArray();
        }

        // alle Modelle einer Marke für einen Fahrzeugtyp (leer, wenn unbekannt)
        public static string[] Modelle(string fahrzeugtyp, string marke)
        {
            if (fahrzeugtyp == null || marke == null || !katalog.TryGetValue(fahrzeugtyp, out var marken))
                return new string[0];

            return marken.TryGetValue(marke.Trim(), out var modelle) ? modelle : new string[0];
        }

        // Marke in der Schreibweise aus dem Katalog (z. B. "bmw" → "BMW"), sonst unverändert
        public static string MarkeNormalisieren(string fahrzeugtyp, string marke)
        {
            if (string.IsNullOrWhiteSpace(marke))
                return marke;

            string gefunden = Marken(fahrzeugtyp)
                .FirstOrDefault(m => string.Equals(m, marke.Trim(), StringComparison.OrdinalIgnoreCase));
            return gefunden ?? marke.Trim();
        }
    }
}
