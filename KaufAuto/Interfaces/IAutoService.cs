using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaufAuto.Models;

namespace KaufAuto.Interfaces
{
    public interface IAutoService
    {
        // interface methoden für auto service
        void Hinzufuegen();
        bool Loeschen(int id);
        void Bearbeiten(int id, Auto neueDaten);
        List<Auto> AlleAutos();
        List<Auto> SucheNachMarke(string marke);
        (int gesamt, int neu, int gebraucht, double kmPkw, double kmTransporter) ErstelleAuswertungen();
    }
}
