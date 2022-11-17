using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TootedAB
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2()); 
            //Form1 - Tooded >>>
            //Form2 - Kassa >>> 
            //Form3 - Login >>> DONE
            //Form4 - Omaniku vorm >>> DONE
            //Form5 - Kliendikaardid >>> 
            //Form6 - Registreerimine >>> 
            //Form7 - Admin panel >>> DONE
        }
    }
}