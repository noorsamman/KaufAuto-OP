using System;
using System.Windows.Forms;
using KaufAuto.Models;
using KaufAuto.Services;

namespace KaufAuto.GUI
{
    // Finanzierungsrechner: Ergebnis wird bei jeder Änderung sofort neu berechnet
    public partial class FinanzierungForm : Form
    {
        private readonly Auto auto;
        private readonly FinanzierungsService finanzierung = new FinanzierungsService();

        public FinanzierungForm(Auto auto)
        {
            InitializeComponent();
            Design.Dialog(this, null, btnSchliessen);
            lblRate.ForeColor = Design.Gold;
            lblKredit.ForeColor = Design.Text;
            lblZinskosten.ForeColor = Design.Text;
            lblGesamt.ForeColor = Design.Text;
            this.auto = auto;

            lblAuto.Text = $"{auto.Marke} {auto.Modell} (ID {auto.Id})\nPreis: {auto.Preis:N2} €";

            // Anzahlung muss kleiner als der Preis sein
            nudAnzahlung.Maximum = Math.Max(0, auto.Preis - 0.01m);

            Berechnen();
        }

        private void Eingabe_Changed(object sender, EventArgs e)
        {
            // Events aus InitializeComponent ignorieren (Auto noch nicht gesetzt)
            if (auto != null)
                Berechnen();
        }

        private void Berechnen()
        {
            try
            {
                FinanzierungsErgebnis ergebnis = finanzierung.Berechne(
                    auto.Preis, nudAnzahlung.Value, (int)nudLaufzeit.Value, nudZins.Value);

                lblKredit.Text = $"{ergebnis.Kreditbetrag:N2} €";
                lblRate.Text = $"{ergebnis.Monatsrate:N2} €";
                lblZinskosten.Text = $"{ergebnis.Zinskosten:N2} €";
                lblGesamt.Text = $"{ergebnis.Gesamtkosten:N2} €";
            }
            catch (ArgumentException ex)
            {
                lblKredit.Text = "";
                lblRate.Text = "–";
                lblZinskosten.Text = "";
                lblGesamt.Text = ex.Message;
            }
        }
    }
}
