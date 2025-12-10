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
        public double Preis { get; set; }
        public string Zustand {  get; set; }
        public int Kilometerstand { get; set; }
        public int Türenanzahl {  get; set; }
        public int Baujahr { get; set; }
        public string Fahrzeugtyp {  get; set; }

        // abstrakte methode Info
        public abstract void Info();
    }
}
