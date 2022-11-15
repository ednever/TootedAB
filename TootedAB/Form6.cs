using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TootedAB
{
    public partial class Form6 : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AppData\Tooted_AB.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> fail_list = new List<string>();
            SqlDataAdapter adapter_tel = new SqlDataAdapter("SELECT Telefon FROM Kliendid", connect);
            DataTable tel = new DataTable();
            adapter_tel.Fill(tel);
            foreach (DataRow fail in tel.Rows)
            {
                fail_list.Add(fail["Telefon"].ToString());
            }
            
            

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && fail_list.Contains(textBox3.Text) == false)
            {
                try
                {
                    connect.Open();
                    cmd = new SqlCommand("INSERT INTO Kliendid (Nimi, Perekonnanimi, Telefon, Password) VALUES (@nimi, @perenimi, @tel, @parool)", connect);
                    cmd.Parameters.AddWithValue("@nimi", textBox1.Text);
                    cmd.Parameters.AddWithValue("@perenimi", textBox2.Text);
                    cmd.Parameters.AddWithValue("@tel", textBox3.Text);
                    cmd.Parameters.AddWithValue("@parool", textBox4.Text);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("Olete registreeritud!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Andmebaasiga viga!");
                }
            }
            else
            {
                MessageBox.Show("Kõik andmed pole sisestatud või Te olete juba registreeritud numbri järgi!");
            }
            this.Close();
        }
    }
}
//Проблема с добавлением в базу данных