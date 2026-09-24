using System;
using System.Windows.Forms;
using KaufAuto.Models;

namespace KaufAuto.GUI
{
    // Fenster zum Hinzufügen (auto == null) oder Bearbeiten eines Autos
    public partial class AutoForm : Form
    {
        private readonly Auto bestehendesAuto;

        // nach "Speichern": das neue bzw. bearbeitete Auto
        public Auto ErgebnisAuto { get; private set; }

        public AutoForm(Auto auto)
        {
            InitializeComponent();
            Design.Dialog(this, btnOk, btnAbbrechen);
            bestehendesAuto = auto;
            nudBaujahr.Maximum = DateTime.Now.Year;

            if (auto == null)
            {
                Text = "Neues Auto hinzufügen";
                cmbTyp.SelectedIndex = 0;
                cmbGetriebe.SelectedIndex = 0;
                cmbKraftstoff.SelectedIndex = 0;
                cmbZustand.SelectedIndex = 1;
                nudBaujahr.Value = DateTime.Now.Year;
            }
            else
            {
                Text = $"Auto bearbeiten (ID {auto.Id})";

                // Typ kann nachträglich nicht geändert werden
                cmbTyp.SelectedItem = auto.Fahrzeugtyp;
                cmbTyp.Enabled = false;

                cmbMarke.Text = auto.Marke;
                cmbModell.Text = auto.Modell;
                SetzeWert(nudPS, auto.MotorleistungPS);
                cmbGetriebe.SelectedItem = auto.Getriebe;
                cmbKraftstoff.SelectedItem = auto.Kraftstoff;
                SetzeWert(nudPreis, auto.Preis);
                SetzeWert(nudBaujahr, auto.Baujahr);
                cmbZustand.SelectedItem = auto.Zustand;
                SetzeWert(nudKm, auto.Kilometerstand);
                SetzeWert(nudTueren, auto.Türenanzahl);
            }
        }

        // Wert setzen, ohne Fehler wenn er außerhalb von Min/Max liegt
        private static void SetzeWert(NumericUpDown feld, decimal wert)
        {
            feld.Value = Math.Min(feld.Maximum, Math.Max(feld.Minimum, wert));
        }

        // für welche Marke die Modell-Liste gerade gefüllt ist
        private string modellListeFuer;

        // Fahrzeugtyp geändert → passende Marken vorschlagen
        private void cmbTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListeFuellen(cmbMarke, FahrzeugKatalog.Marken(cmbTyp.Text));
            modellListeFuer = null;
            ModelleAktualisieren();
        }

        // Marke geändert → passende Modelle vorschlagen
        private void cmbMarke_TextChanged(object sender, EventArgs e)
        {
            ModelleAktualisieren();
        }

        private void ModelleAktualisieren()
        {
            string[] modelle = FahrzeugKatalog.Modelle(cmbTyp.Text, cmbMarke.Text);

            // nur neu füllen, wenn sich die Marke wirklich geändert hat
            string schluessel = modelle.Length > 0 ? cmbTyp.Text + "|" + cmbMarke.Text.Trim().ToLower() : "";
            if (schluessel == modellListeFuer)
                return;

            modellListeFuer = schluessel;
            ListeFuellen(cmbModell, modelle);
        }

        // Einträge einer ComboBox ersetzen, eingegebenen Text behalten
        private static void ListeFuellen(ComboBox liste, string[] eintraege)
        {
            string text = liste.Text;
            liste.BeginUpdate();
            liste.Items.Clear();
            liste.Items.AddRange(eintraege);
            liste.EndUpdate();
            liste.Text = text;
        }

        // Neuwagen: Kilometerstand immer 0
        private void cmbZustand_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool neu = cmbZustand.Text == "Neu";
            if (neu)
                nudKm.Value = 0;
            nudKm.Enabled = !neu;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Eingaben prüfen
            string fehler = "";
            if (string.IsNullOrWhiteSpace(cmbMarke.Text))
                fehler += "- Bitte eine Marke eingeben.\n";
            if (string.IsNullOrWhiteSpace(cmbModell.Text))
                fehler += "- Bitte ein Modell eingeben.\n";
            if (cmbGetriebe.SelectedIndex < 0)
                fehler += "- Bitte ein Getriebe auswählen.\n";
            if (cmbKraftstoff.SelectedIndex < 0)
                fehler += "- Bitte einen Kraftstoff auswählen.\n";
            if (cmbZustand.SelectedIndex < 0)
                fehler += "- Bitte einen Zustand auswählen.\n";
            if (nudPreis.Value <= 0)
                fehler += "- Der Preis muss größer als 0 sein.\n";

            if (fehler != "")
            {
                MessageBox.Show(fehler, "Bitte Eingaben prüfen",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // neues Auto passend zum Typ erstellen oder bestehendes ändern
            Auto auto = bestehendesAuto;
            if (auto == null)
            {
                switch (cmbTyp.Text)
                {
                    case "SUV": auto = new SUV(); break;
                    case "Transporter": auto = new Transporter(); break;
                    default: auto = new PKW(); break;
                }
            }

            // "bmw" wird zu "BMW" (Schreibweise aus dem Katalog)
            auto.Marke = FahrzeugKatalog.MarkeNormalisieren(cmbTyp.Text, cmbMarke.Text);
            auto.Modell = cmbModell.Text.Trim();
            auto.MotorleistungPS = (int)nudPS.Value;
            auto.Getriebe = cmbGetriebe.Text;
            auto.Kraftstoff = cmbKraftstoff.Text;
            auto.Preis = nudPreis.Value;
            auto.Baujahr = (int)nudBaujahr.Value;
            auto.Zustand = cmbZustand.Text;
            auto.Kilometerstand = (int)nudKm.Value;
            auto.Türenanzahl = (int)nudTueren.Value;

            ErgebnisAuto = auto;
            DialogResult = DialogResult.OK;
        }
    }
}
