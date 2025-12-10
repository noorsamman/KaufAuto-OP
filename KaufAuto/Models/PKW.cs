using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaufAuto.Models;

namespace KaufAuto.Models
{
    public class PKW : Auto
    // PKW klasse erbt von Auto
    {
        public override void Info()
        {
            // gibt die Informationen des PKWs aus

            Console.WriteLine(
                $"[PKW] ID {Id} – {Marke} {Modell}, {MotorleistungPS} PS, {Getriebe}, Zustand: {Zustand}, " +
                $"{Kilometerstand} km, {Türenanzahl} Türen, Baujahr {Baujahr}, Preis {Preis} €" 
            );

        }
    }
}
