using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaufAuto.Models
{
    // abstrakte klasse Auto
    public abstract class Auto
    {
        //properties
        public int Id { get; set; } 
        public string Marke { get; set; }
        public string Modell { get; set; }
        public int MotorleistungPS { get; set; }
        public string Getriebe { get; set; }
        public decimal Preis { get; set; }
        public string Zustand {  get; set; }
        public int Kilometerstand { get; set; }
        public int Türenanzahl {  get; set; }
        public int Baujahr { get; set; }
        public string Fahrzeugtyp {  get; set; }
        public string Kraftstoff { get; set; }

        // Verkaufsdaten
        public bool Verkauft { get; set; }
        public string Kaeufer { get; set; }
        public DateTime? Verkaufsdatum { get; set; }
        public decimal? Verkaufspreis { get; set; }

        // Anzeige-Text für Tabellen (wird nicht in JSON gespeichert)
        public string Status => Verkauft ? "Verkauft" : "Verfügbar";
        public bool ShouldSerializeStatus() => false;

        // abstrakte methode Info
        public abstract void Info();

        // gemeinsamer Text für Info() in PKW, SUV und Transporter
        protected string BasisInfo()
        {
            string text =
                $"ID {Id} – {Marke} {Modell}, {MotorleistungPS} PS, {Kraftstoff ?? "-"}, {Getriebe}, Zustand: {Zustand}, " +
                $"{Kilometerstand} km, {Türenanzahl} Türen, Baujahr {Baujahr}, Preis {Preis:N2} €";

            if (Verkauft)
            {
                text += $"\n      VERKAUFT an {Kaeufer} am {Verkaufsdatum:dd.MM.yyyy} für {Verkaufspreis:N2} €";
            }

            return text;
        }
    }
}
