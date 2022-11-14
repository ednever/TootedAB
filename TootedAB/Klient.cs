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
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AppData\Tooted_AB.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter_telefon, adapter_parool;
        DataTable dt_telefon, dt_parool;

        string telefon, parool;
        List<string> telefonid = new List<string>();
        List<string> paroolid = new List<string>();

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

        public void input_Andmed()
        {
            connect.Open();

            dt_parool = new DataTable();
            cmd = new SqlCommand("SELECT Password FROM Kliendid", connect);
            adapter_parool = new SqlDataAdapter(cmd);
            adapter_parool.Fill(dt_parool);
            foreach (DataRow nimetus in dt_parool.Rows)
            {
                paroolid.Add(nimetus["Password"].ToString());
            }

            dt_telefon = new DataTable();
            cmd = new SqlCommand("SELECT Telefon FROM Kliendid", connect);
            adapter_telefon = new SqlDataAdapter(cmd);
            adapter_telefon.Fill(dt_telefon);
            foreach (DataRow nimetus in dt_telefon.Rows)
            {
                telefonid.Add(nimetus["Telefon"].ToString());
            }

            connect.Close();
        }

        public bool kontrolli_vastust()
        {
            if (telefonid.IndexOf(telefon) == paroolid.IndexOf(parool))
                return false;
            else
                return true;
        }
    }
}