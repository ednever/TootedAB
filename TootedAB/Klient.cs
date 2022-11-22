using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TootedAB
{
    public class Klient
    {
        
        //SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AppData\Tooted_AB.mdf;Integrated Security=True");
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Edgar Neverovski TARpv21\TootedAB\TootedAB\TootedAB\bin\Debug\AppData\Tooted_AB.mdf;Integrated Security=True");
        SqlCommand cmd;
        string telefon, parool;

        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }

        public string Parool
        {
            get { return parool; }
            set { parool = value; }
        }

        public bool kontrolli_vastust()
        {
            connect.Open();
            cmd = new SqlCommand("SELECT Id FROM Kliendid where Telefon = @tel and Password = @pas", connect);
            cmd.Parameters.AddWithValue("@tel", telefon);
            cmd.Parameters.AddWithValue("@pas", parool);
            object result = cmd.ExecuteScalar();
            connect.Close();
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}