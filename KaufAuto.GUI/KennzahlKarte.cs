using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace KaufAuto.GUI
{
    // Dashboard-Karte mit Titel, großem Wert und kleinem Zusatztext
    public class KennzahlKarte : Control
    {
        private string titel = "TITEL";
        private string wert = "0";
        private string zusatz = "";
        private Color akzent = Color.FromArgb(201, 164, 92);

        [Category("Design")]
        public string Titel { get => titel; set { titel = value; Invalidate(); } }

        [Category("Design")]
        public string Wert { get => wert; set { wert = value; Invalidate(); } }

        [Category("Design")]
        public string Zusatz { get => zusatz; set { zusatz = value; Invalidate(); } }

        [Category("Design"), Description("Farbe des Streifens links.")]
        public Color Akzent { get => akzent; set { akzent = value; Invalidate(); } }

        public KennzahlKarte()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Size = new Size(262, 92);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Parent?.BackColor ?? Design.Hintergrund);

            var rechteck = new RectangleF(0.5f, 0.5f, Width - 1.5f, Height - 1.5f);
            using (GraphicsPath pfad = Design.Abgerundet(rechteck, 12))
            {
                using (var pinsel = new SolidBrush(Design.Flaeche))
                    g.FillPath(pinsel, pfad);
                using (var stift = new Pen(Design.Rahmen))
                    g.DrawPath(stift, pfad);
            }

            // Akzent-Streifen links
            using (var pinsel = new SolidBrush(akzent))
                g.FillRectangle(pinsel, 0, 20, 3, Height - 40);

            TextRenderer.DrawText(g, titel, Design.SchriftKlein, new Point(18, 14), Design.TextGedaempft);
            using (var wertSchrift = new Font("Segoe UI Semibold", 17F))
                TextRenderer.DrawText(g, wert, wertSchrift, new Point(16, 31), Design.Text);
            TextRenderer.DrawText(g, zusatz, Design.SchriftKlein, new Point(18, Height - 24), akzent);
        }
    }
}
