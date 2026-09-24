using System;
using System.Windows.Forms;
using KaufAuto.Models;

namespace KaufAuto.GUI
{
    // Fenster zum Verkaufen eines Autos: Käufer und Verkaufspreis eingeben
    public partial class VerkaufenForm : Form
    {
        private readonly Auto auto;

        public string Kaeufer => txtKaeufer.Text.Trim();
        public decimal Verkaufspreis => nudPreis.Value;

        public VerkaufenForm(Auto auto)
        {
            InitializeComponent();
            Design.Dialog(this, btnOk, btnAbbrechen);
            lblRabatt.ForeColor = Design.Erfolg;
            this.auto = auto;

            lblAuto.Text = $"{auto.Marke} {auto.Modell} (ID {auto.Id})\nListenpreis: {auto.Preis:N2} €";
            nudPreis.Value = Math.Min(nudPreis.Maximum, auto.Preis);
        }

        // Rabatt anzeigen, wenn der Verkaufspreis unter dem Listenpreis liegt
        private void nudPreis_ValueChanged(object sender, EventArgs e)
        {
            decimal rabatt = auto.Preis - nudPreis.Value;
            lblRabatt.Text = rabatt > 0 && auto.Preis > 0
                ? $"Rabatt: {rabatt:N2} € ({rabatt / auto.Preis:P1})"
                : "";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Kaeufer == "")
            {
                MessageBox.Show("Bitte den Namen des Käufers eingeben.", "Hinweis",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKaeufer.Focus();
                return;
            }

            if (Verkaufspreis <= 0)
            {
                MessageBox.Show("Der Verkaufspreis muss größer als 0 sein.", "Hinweis",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
