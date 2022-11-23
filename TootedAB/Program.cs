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
            //Form5 - Kliendikaardid >>> DONE
            //Form6 - Registreerimine >>> 
            //Form7 - Admin panel >>> DONE
        }
    }
}
//Коннекты к базе данных прописаны в Form1, Form2, Form6, Form7, Klient, Toode