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

            adapter_kat = new SqlDataAdapter("SELECT Kategooria_nimetus FROM Kategooriatable", connect);
            DataTable dt_kat = new DataTable();
            adapter_kat.Fill(dt_kat);
            foreach (DataRow nimetus in dt_kat.Rows)
            {
                Kat_cbox.Items.Add(nimetus["Kategooria_nimetus"]);
            }

            connect.Close();
        }
        public void Kustuta_Andmed()
        {
            Toode_txt.Text = "";
            Hind_nud.Value = 0;
            Kogus_nud.Value = 0;
            Kat_cbox.SelectedItem = null;
        }
        void lisa_kat_Click(object sender, EventArgs e)
        {
            connect.Open();
            cmd = new SqlCommand("INSERT INTO Kategooriatable (Kategooria_nimetus) VALUES (@kat)",connect);
            cmd.Parameters.AddWithValue("@kat", Kat_cbox.Text);
            cmd.ExecuteNonQuery();
            

            Kat_cbox.Items.Add(Kat_cbox.Text);
            connect.Close();
        }
        void Kustuta_btn_Click(object sender, EventArgs e)
        {
            Kustuta_Andmed();
        }
        void Lisa_btn_Click(object sender, EventArgs e)
        {
            if (Toode_txt.Text != null && Kogus_nud != null && Hind_nud != null && Kat_cbox.SelectedItem != null)
            {
                try
                {
                    connect.Open();
                    cmd = new SqlCommand("INSERT INTO Toodetable (Toodenimetus, Kogus, Hind, Pilt, Kategooria_id) VALUES (@toode,@kogus,@hind,@pilt,@kat)", connect);
                    cmd.Parameters.AddWithValue("@toode", Toode_txt.Text);
                    cmd.Parameters.AddWithValue("@kogus", Kogus_nud.Value);
                    cmd.Parameters.AddWithValue("@hind", Hind_nud.Value);
                    cmd.Parameters.AddWithValue("@pilt", Toode_txt.Text + ".jpg"); // + format
                    cmd.Parameters.AddWithValue("@kat", Kat_cbox.SelectedIndex + 1); // + ID andmebaasist võtta
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    Kustuta_Andmed();
                    Naita_Andmed();
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Andmebaasiga viga!");
                }
            }
            else
            {
                MessageBox.Show("Sisesta andmed!");
            }
        }
        void Uuenda_btn_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("UPDATE * FROM ToodeTable", connect);
        }
        void Vali_btn_Click(object sender, EventArgs e)
        {

        }
    }
}