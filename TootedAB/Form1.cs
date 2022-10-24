﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace TootedAB
{
    public partial class Form1 : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AppData\Tooted_AB.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter_toode, adapter_kat;  
        Random random = new Random();
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
            if (Kat_cbox.Text != null)
            {
                connect.Open();
                cmd = new SqlCommand("INSERT INTO Kategooriatable (Kategooria_nimetus) VALUES (@kat)", connect);
                cmd.Parameters.AddWithValue("@kat", Kat_cbox.Text);
                cmd.ExecuteNonQuery();

                Kat_cbox.Items.Add(Kat_cbox.Text);
                connect.Close();
                Kat_cbox.SelectedItem = null;
            }
            else
            {
                MessageBox.Show("Sisesta andmed!");
            }
        }
        void Kustuta_btn_Click(object sender, EventArgs e)
        {
            //if (Kat_cbox.Text != null)
            //{
            //    using (SqlCommand deleteRecord = new SqlCommand($"DELETE FROM Kategooriatable WHERE Kategooria_nimetus = @kat", connect))
            //    {
            //        connect.Open();
            //        deleteRecord.Parameters.AddWithValue("@kat", Kat_cbox.Text);
            //        deleteRecord.ExecuteNonQuery();
            //        connect.Close();                    
            //    }
            //    Kat_cbox.SelectedItem = null;
            //}

            if (dataGridView1.SelectedRows.Count == 0)
            {
                string sql = "DELETE FROM Toodetable WHERE Id = @rowID";

                using (SqlCommand deleteRecord = new SqlCommand(sql, connect))
                {
                    connect.Open();

                    int selectedIndex = dataGridView1.SelectedRows[0].Index;
                    int rowID = Convert.ToInt32(dataGridView1[0, selectedIndex].Value);

                    deleteRecord.Parameters.Add("@rowID", SqlDbType.Int).Value = rowID;
                    deleteRecord.ExecuteNonQuery();

                    dataGridView1.Rows.RemoveAt(selectedIndex);
                    connect.Close();
                }
            }                        
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
            if (Toode_txt.Text != null && Kogus_nud != null && Hind_nud != null && Kat_cbox.SelectedItem != null)
            {
                connect.Open();
                cmd = new SqlCommand("UPDATE * FROM ToodeTable SET (Toodenimetus = @toode, Kogus = @kogus, Hind = @hind, Pilt = @pilt, Kategooria_id WHERE Id = @Id)", connect);
                cmd.Parameters.AddWithValue("@toode", Toode_txt.Text);
                cmd.Parameters.AddWithValue("@kogus", Kogus_nud.Value);
                cmd.Parameters.AddWithValue("@hind", Hind_nud.Value);
                cmd.Parameters.AddWithValue("@pilt", Toode_txt.Text + ".jpg"); // + format
                cmd.Parameters.AddWithValue("@kat", Kat_cbox.SelectedIndex + 1); // + ID andmebaasist võtta
                cmd.ExecuteNonQuery();
                connect.Close();
                Kustuta_Andmed();
                Naita_Andmed();
                connect.Close();
            }            
        }
        void Vali_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = Path.GetFullPath(@"..\..\Images");
            FileInfo open_info = new FileInfo(@"C:\Users\opilane.TTHK\Pictures" + open.FileName);

            if (open.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(open.FileName);
                Toode_pbox.Load(open.FileName);
                Bitmap finalImg = new Bitmap(Toode_pbox.Image, Toode_pbox.Width, Toode_pbox.Height);
                Toode_pbox.Image = finalImg;
                Toode_pbox.Show();
                string destinationFile;
                try
                {
                    destinationFile = @"..\..\Images\" + Toode_txt.Text + ext;
                    File.Copy(open.FileName, destinationFile);
                }
                catch (Exception)
                {
                    destinationFile = @"..\..\Images\" + Toode_txt.Text + random.Next(1, 99999).ToString() + ext;
                    File.Copy(open.FileName, destinationFile);
                }
            }            
        }

        void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); //kui andmed puuduvad reas siis on viga
            Toode_txt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Kogus_nud.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Hind_nud.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            try
            {
                Toode_pbox.Image = Image.FromFile(@"..\..\Images\" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Sellist faili pole kaustis","Error");
                Toode_pbox.Image = Image.FromFile(@"..\..\Images\nothing.png");
            }            
            Kat_cbox.SelectedIndex = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()) - 1;
        }
    }
}