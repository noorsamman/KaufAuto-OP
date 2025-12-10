using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaufAuto.Models;

namespace KaufAuto.Models
{
    public class SUV : Auto
    {
        // überschreibt die Info Methode
        public override void Info()
        {
            // gibt die Informationen des SUVs aus
            Console.WriteLine(
                $"[SUV] ID {Id} – {Marke} {Modell}, {MotorleistungPS} PS, {Getriebe}, Zustand: {Zustand}, " +
                $"{Kilometerstand} km, {Türenanzahl} Türen, Baujahr {Baujahr}, Preis {Preis} €"
            );

        }

    }
}
