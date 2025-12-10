using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaufAuto.Models;


namespace KaufAuto.Models
{
    public class Transporter : Auto
    // Transporter klasse erbt von Auto
    {
        // überschreibt die Info Methode
        public override void Info()
        {
            // gibt die Informationen des Transporters aus
            Console.WriteLine(
                $"[Transporter] ID {Id} – {Marke} {Modell}, {MotorleistungPS} PS, {Getriebe}, Zustand: {Zustand}, " +
                $"{Kilometerstand} km, {Türenanzahl} Türen, Baujahr {Baujahr}, Preis {Preis} €"
            );

        }
    }
}
