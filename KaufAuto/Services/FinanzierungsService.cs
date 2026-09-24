using System;

namespace KaufAuto.Services
{
    // Ergebnis einer Finanzierungsberechnung
    public class FinanzierungsErgebnis
    {
        public decimal Kreditbetrag { get; set; }
        public decimal Monatsrate { get; set; }
        public decimal Gesamtkosten { get; set; }
        public decimal Zinskosten { get; set; }
    }

    // Berechnet die Monatsrate einer Autofinanzierung (Annuitätendarlehen)
    public class FinanzierungsService
    {
        public FinanzierungsErgebnis Berechne(decimal preis, decimal anzahlung, int laufzeitMonate, decimal jahreszinsProzent)
        {
            if (preis <= 0)
                throw new ArgumentException("Preis muss größer als 0 sein.", nameof(preis));
            if (anzahlung < 0 || anzahlung >= preis)
                throw new ArgumentException("Anzahlung muss zwischen 0 und dem Preis liegen.", nameof(anzahlung));
            if (laufzeitMonate < 1)
                throw new ArgumentException("Laufzeit muss mindestens 1 Monat sein.", nameof(laufzeitMonate));
            if (jahreszinsProzent < 0)
                throw new ArgumentException("Zinssatz darf nicht negativ sein.", nameof(jahreszinsProzent));

            decimal kredit = preis - anzahlung;
            decimal rate;

            if (jahreszinsProzent == 0)
            {
                // ohne Zinsen: Kredit gleichmäßig aufteilen
                rate = kredit / laufzeitMonate;
            }
            else
            {
                // Annuitätenformel: Rate = K * q / (1 - (1 + q)^-n), q = Monatszins
                double q = (double)jahreszinsProzent / 100.0 / 12.0;
                rate = (decimal)((double)kredit * q / (1 - Math.Pow(1 + q, -laufzeitMonate)));
            }

            rate = Math.Round(rate, 2);
            decimal gesamt = rate * laufzeitMonate + anzahlung;

            return new FinanzierungsErgebnis
            {
                Kreditbetrag = kredit,
                Monatsrate = rate,
                Gesamtkosten = gesamt,
                Zinskosten = gesamt - preis
            };
        }
    }
}
