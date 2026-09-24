using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KaufAuto.GUI
{
    // Zentrale Farben und Stile – hier ändern, dann ändert sich die ganze App.
    // Luxus-Design: dunkles Anthrazit mit Champagner-Gold als Akzent.
    internal static class Design
    {
        // Hintergründe (von dunkel nach hell)
        public static readonly Color Hintergrund = Hex("#0E0E12");
        public static readonly Color Flaeche = Hex("#16161D");
        public static readonly Color ZeileAbwechselnd = Hex("#1A1A22");
        public static readonly Color Flaeche2 = Hex("#1E1E27");
        public static readonly Color Hover = Hex("#2A2A35");
        public static readonly Color Rahmen = Hex("#2C2C38");

        // Schrift
        public static readonly Color Text = Hex("#F4F4F6");
        public static readonly Color TextGedaempft = Hex("#8E8E9E");

        // Akzente
        public static readonly Color Gold = Hex("#C9A45C");
        public static readonly Color GoldHell = Hex("#DDBE7E");
        public static readonly Color GoldDunkel = Hex("#2E2718");
        public static readonly Color Erfolg = Hex("#4CC38A");
        public static readonly Color Gefahr = Hex("#EF5A5F");
        public static readonly Color GefahrDunkel = Hex("#3A1C20");

        public static readonly Font Schrift = new Font("Segoe UI", 9.5F);
        public static readonly Font SchriftFett = new Font("Segoe UI Semibold", 9.5F);
        public static readonly Font SchriftKlein = new Font("Segoe UI Semibold", 8F);

        private static Color Hex(string farbe)
        {
            return ColorTranslator.FromHtml(farbe);
        }

        // ---------------- Buttons ----------------

        // Hauptaktion: Gold mit dunkler Schrift
        public static void PrimaerButton(Button button)
        {
            ButtonFarben(button, Gold, Hex("#141414"), GoldHell, Color.Empty);
        }

        // normale Aktion: dunkel mit feinem Rahmen
        public static void NormalerButton(Button button)
        {
            ButtonFarben(button, Flaeche2, Text, Hover, Rahmen);
        }

        // gefährliche Aktion wie Löschen: rote Schrift
        public static void GefahrButton(Button button)
        {
            ButtonFarben(button, Flaeche2, Gefahr, GefahrDunkel, Hex("#5A2A30"));
        }

        private static void ButtonFarben(Button button, Color hintergrund, Color schrift, Color hover, Color rahmen)
        {
            button.BackColor = hintergrund;
            button.ForeColor = schrift;
            button.Font = SchriftFett;
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;

            if (button is ModernButton modern)
            {
                modern.HoverFarbe = hover;
                modern.RahmenFarbe = rahmen;
                modern.Invalidate();
            }
        }

        // ---------------- Tabelle ----------------

        public static void Tabelle(DataGridView tabelle)
        {
            tabelle.BorderStyle = BorderStyle.None;
            tabelle.BackgroundColor = Flaeche;
            tabelle.GridColor = Rahmen;
            tabelle.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            tabelle.RowTemplate.Height = 42;

            // Kopfzeile: klein, gedämpft, GROSSBUCHSTABEN
            tabelle.EnableHeadersVisualStyles = false;
            tabelle.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            tabelle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tabelle.ColumnHeadersHeight = 44;
            tabelle.ColumnHeadersDefaultCellStyle.BackColor = Flaeche2;
            tabelle.ColumnHeadersDefaultCellStyle.ForeColor = TextGedaempft;
            tabelle.ColumnHeadersDefaultCellStyle.Font = SchriftKlein;
            tabelle.ColumnHeadersDefaultCellStyle.SelectionBackColor = Flaeche2;
            tabelle.ColumnHeadersDefaultCellStyle.SelectionForeColor = TextGedaempft;
            tabelle.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 10, 0);
            foreach (DataGridViewColumn spalte in tabelle.Columns)
            {
                spalte.HeaderText = spalte.HeaderText.ToUpper();
            }

            // Zeilen
            tabelle.DefaultCellStyle.BackColor = Flaeche;
            tabelle.DefaultCellStyle.ForeColor = Text;
            tabelle.DefaultCellStyle.Font = Schrift;
            tabelle.DefaultCellStyle.SelectionBackColor = GoldDunkel;
            tabelle.DefaultCellStyle.SelectionForeColor = Text;
            tabelle.DefaultCellStyle.Padding = new Padding(10, 0, 10, 0);
            tabelle.AlternatingRowsDefaultCellStyle.BackColor = ZeileAbwechselnd;
        }

        // ---------------- Eingabefelder und Dialoge ----------------

        // alle Labels, Textfelder, Listen und Zahlenfelder dunkel einfärben
        public static void Eingabefelder(Control container)
        {
            foreach (Control c in container.Controls)
            {
                switch (c)
                {
                    case Label label:
                        label.ForeColor = label.Font.Bold ? Text : TextGedaempft;
                        break;
                    case TextBox textBox:
                        textBox.BackColor = Flaeche2;
                        textBox.ForeColor = Text;
                        textBox.BorderStyle = BorderStyle.FixedSingle;
                        break;
                    case ComboBox comboBox:
                        comboBox.FlatStyle = FlatStyle.Flat;
                        comboBox.BackColor = Flaeche2;
                        comboBox.ForeColor = Text;
                        break;
                    case NumericUpDown zahl:
                        zahl.BackColor = Flaeche2;
                        zahl.ForeColor = Text;
                        zahl.BorderStyle = BorderStyle.FixedSingle;
                        break;
                    case GroupBox gruppe:
                        gruppe.ForeColor = Gold;
                        Eingabefelder(gruppe);
                        break;
                    case Panel panel:
                        Eingabefelder(panel);
                        break;
                }
            }
        }

        // Dialogfenster: dunkel, OK in Gold, Abbrechen normal
        public static void Dialog(Form form, Button ok, Button abbrechen)
        {
            form.BackColor = Flaeche;
            form.ForeColor = Text;
            Eingabefelder(form);
            if (ok != null)
                PrimaerButton(ok);
            if (abbrechen != null)
                NormalerButton(abbrechen);
            DunkleTitelleiste(form);
        }

        // ---------------- Windows-Titelleiste dunkel ----------------

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr fenster, int attribut, ref int wert, int groesse);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        private const int DWMWA_CAPTION_COLOR = 35;

        public static void DunkleTitelleiste(Form form)
        {
            void Anwenden()
            {
                try
                {
                    int an = 1;
                    DwmSetWindowAttribute(form.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref an, sizeof(int));

                    // Windows erwartet die Farbe als 0x00BBGGRR
                    Color c = form.BackColor;
                    int farbe = c.R | (c.G << 8) | (c.B << 16);
                    DwmSetWindowAttribute(form.Handle, DWMWA_CAPTION_COLOR, ref farbe, sizeof(int));
                }
                catch (Exception)
                {
                    // ältere Windows-Versionen: normale Titelleiste
                }
            }

            if (form.IsHandleCreated)
                Anwenden();
            else
                form.HandleCreated += (s, e) => Anwenden();
        }

        // ---------------- Zeichnen ----------------

        // Rechteck mit abgerundeten Ecken
        public static GraphicsPath Abgerundet(RectangleF rechteck, float radius)
        {
            float d = radius * 2;
            var pfad = new GraphicsPath();
            pfad.AddArc(rechteck.X, rechteck.Y, d, d, 180, 90);
            pfad.AddArc(rechteck.Right - d, rechteck.Y, d, d, 270, 90);
            pfad.AddArc(rechteck.Right - d, rechteck.Bottom - d, d, d, 0, 90);
            pfad.AddArc(rechteck.X, rechteck.Bottom - d, d, d, 90, 90);
            pfad.CloseFigure();
            return pfad;
        }
    }
}
