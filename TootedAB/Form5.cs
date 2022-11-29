using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TootedAB
{
    public partial class Form5 : Form
    {
        //SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AppData\Tooted_AB.mdf;Integrated Security=True");
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Edgar Neverovski TARpv21\TootedAB\TootedAB\AppData\Tooted_AB.mdf;Integrated Security=True");

        Klient klient = new Klient();
        Form2 form2;

        bool tulemus;

        public bool Tulemus
        {
            get { return tulemus; }
            set { tulemus = value; }
        }

        public Form5(Form2 owner)
        {
            form2 = owner;
            InitializeComponent();
        }

        void button1_Click(object sender, EventArgs e)
        {
            klient.Telefon = textBox1.Text;
            klient.Parool = textBox2.Text;

            if (klient.kontrolli_vastust())
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("SELECT Nimi, Perekonnanimi, Boonus FROM Kliendid WHERE Telefon = " + textBox1.Text, connect);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow nimetus in dt.Rows)
                {
                    form2.label1.Text = nimetus["Nimi"].ToString() + " " + nimetus["Perekonnanimi"].ToString();
                    form2.label2.Text = "Boonus: ";
                    form2.label3.Text = nimetus["Boonus"].ToString();
                    form2.label4.Text = "!";
                    form2.label5.Text = "Tere, ";
                }
                connect.Close();


                this.Hide();
            }
            else
            {
                form2.label1.Text = "";
                MessageBox.Show("Vigad andmed!", "Error");
            }
        }
        void button2_Click(object sender, EventArgs e)
        {
            new Form6().Show();
        }
    }
}