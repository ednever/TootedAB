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
    public partial class Form1 : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AppData\Tooted_AB.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter_toode, adapter_kat;
        
        public Form1()
        {
            InitializeComponent();
            Naita_Andmed();
        }

        public void Naita_Andmed()
        {
            connect.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("SELECT * FROM ToodeTable",connect);
            adapter_toode = new SqlDataAdapter(cmd);
            adapter_toode.Fill(dt);
            dataGridView1.DataSource = dt;

            Toode_pbox.Image = Image.FromFile("../../Images/nothing.png");
            
            Naita_kat();

            connect.Close();
        }

        private void lisa_kat_Click(object sender, EventArgs e)
        {
            connect.Open();
            cmd = new SqlCommand("INSERT INTO Kategooriatable (Kategooria_nimetus) VALUES (@kat)",connect);
            cmd.Parameters.AddWithValue("@kat", Kat_cbox.Text);
            cmd.ExecuteNonQuery();
            

            Kat_cbox.Items.Add(Kat_cbox.Text);
            connect.Close();
        }
        public void Naita_kat()
        {
            adapter_kat = new SqlDataAdapter("SELECT Kategooria_nimetus FROM Kategooriatable", connect);
            DataTable dt_kat = new DataTable();
            adapter_kat.Fill(dt_kat);
            foreach (DataRow nimetus in dt_kat.Rows)
            {
                Kat_cbox.Items.Add(nimetus["Kategooria_nimetus"]);
            }
        }

        private void Kustuta_btn_Click(object sender, EventArgs e)
        {
            Toode_txt.Text = "";
            Hind_txt.Text = "";
            Kogus_txt.Text = "";
        }
    }
}
