using System;
using System.Windows.Forms;

namespace GeheimLauncher
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm()); // Hier wird das Hauptformular gestartet
        }
    }
}
