using System;
using System.Windows.Forms;

namespace KaufAuto.GUI
{
    internal static class Program
    {
        // Startpunkt der GUI-Anwendung
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
