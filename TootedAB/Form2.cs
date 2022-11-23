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
using System.IO;
//using PdfSharp.Drawing;
//using PdfSharp.Pdf;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace TootedAB
{
    public partial class Form2 : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AppData\Tooted_AB.mdf;Integrated Security=True"); 
        //SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Edgar Neverovski TARpv21\TootedAB\TootedAB\TootedAB\AppData\Tooted_AB.mdf;Integrated Security=True");

        SqlCommand cmd;
        SqlDataAdapter adapter_kat, failinimi_adap, adapter_toode;
        PictureBox pictureBox;

        //TableLayoutPanel tlp;

        DataTable dt_toode, dt_hind;
        string hind;
        List<string> text = new List<string>();
        List<Object> hinned = new List<Object>();

        public Form2()
        {
            InitializeComponent();
            Kategooria();
            //connect.Open();

            //adapter_toode = new SqlDataAdapter("SELECT Toodenimetus FROM Toodetable", connect);
            //dt_toode = new DataTable();
            //adapter_toode.Fill(dt_toode);
            //foreach (DataRow nimetus in dt_toode.Rows)
            //{
            //    comboBox1.Items.Add(nimetus["Toodenimetus"]);
            //}

            //adapter_hind = new SqlDataAdapter("SELECT Hind FROM Toodetable", connect);
            //dt_hind = new DataTable();
            //adapter_hind.Fill(dt_hind);
            //foreach (DataRow nimetus in dt_hind.Rows)
            //{
            //    hinned.Add(nimetus["Hind"]);
            //}

            //connect.Close();
        }

        int kat_Id;
        List<string> fail_list;
        public List<string> Failid_KatId(int kat_id)
        {
            fail_list = new List<string>();
            failinimi_adap = new SqlDataAdapter("SELECT Pilt FROM Toodetable WHERE Kategooria_id=" + kat_Id, connect);
            DataTable failid = new DataTable();
            failinimi_adap.Fill(failid);
            foreach (DataRow fail in failid.Rows)
            {
                fail_list.Add(fail["Pilt"].ToString());
            }
            return fail_list;
        }
        void Kategooria()
        {
            TabControl kategooriad = new TabControl();
            kategooriad.Name = "Kategooriad";
            kategooriad.Dock = DockStyle.Left;
            kategooriad.Width = this.Width;
            kategooriad.Height = this.Height;

            connect.Open();
            adapter_kat = new SqlDataAdapter("SELECT Id, Kategooria_nimetus FROM Kategooriatable", connect);

            DataTable dt_kat = new DataTable();
            adapter_kat.Fill(dt_kat);
            ImageList iconsList = new ImageList();
            iconsList.ColorDepth = ColorDepth.Depth32Bit;
            iconsList.ImageSize = new Size(25, 25);

            int j = 0;
            foreach (DataRow nimetus in dt_kat.Rows)
            {
                kategooriad.TabPages.Add((string)nimetus["Kategooria_nimetus"]);
                iconsList.Images.Add(Image.FromFile(@"..\..\Kat_pildid\" + (string)nimetus["Kategooria_nimetus"] + ".png"));
                kategooriad.TabPages[j].ImageIndex = j;
                j++;
                kat_Id = (int)nimetus["Id"];
                fail_list = Failid_KatId(kat_Id);
                int r = 0;
                int c = 0;
                foreach (var fail in fail_list)
                {
                    pictureBox = new PictureBox();
                    pictureBox.Image = Image.FromFile(@"..\..\Images\" + fail);
                    pictureBox.Width = pictureBox.Height = 100;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Location = new Point(c, r);
                    pictureBox.Click += PictureBox_Click;
                    pictureBox.Name = fail;
                    c = c + 102;
                    kategooriad.TabPages[j - 1].Controls.Add(pictureBox);
                }
            }
            kategooriad.ImageList = iconsList;
            connect.Close();
            this.Controls.Add(kategooriad);
        }

        void PictureBox_Click(object sender, EventArgs e) //Проверить kogus
        {
            try
            {
                PictureBox pika = (PictureBox)sender;
                cmd = new SqlCommand("SELECT Toodenimetus, Hind, Kogus=(SELECT Kogus FROM Ostukorv) FROM Toodetable WHERE Pilt = @nimi", connect);
                cmd.Parameters.AddWithValue("@nimi", pika.Name);
                adapter_toode = new SqlDataAdapter(cmd);
                dt_toode = new DataTable();
                adapter_toode.Fill(dt_toode);
                dataGridView1.DataSource = dt_toode;

                //cmd = new SqlCommand("SELECT Kogus FROM Toodetable WHERE Pilt = @nimi", connect);
                //cmd.Parameters.AddWithValue("@nimi", pika.Name);
                //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //adapter.Fill(dt);
                //foreach (DataRow nimetus in dt.Rows)
                //{
                //    numericUpDown1.Maximum = decimal.Parse(nimetus["Kogus"].ToString());
                //}

                numericUpDown1.Value = 1;
                dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[2].Value = numericUpDown1.Value;

                hind = dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[1].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Selline toode on juba korvis", "Error");
            }
            
        }

        int i, k;
        void button1_Click(object sender, EventArgs e) //Проверить работоспособность
        {
            //i++;
            //PdfDocument document = new PdfDocument();
            //PdfPage page = document.AddPage();

            ////For drawing in PDF Page you will need XGraphics Object
            //XGraphics gfx = XGraphics.FromPdfPage(page);

            ////For Test you will have to define font to be used
            //XFont font = new XFont("Miriam Mono CLM", 14.25, XFontStyle.Bold);

            ////Finally use XGraphics & font object to draw text in PDF Page
            //gfx.DrawString("Kviitung", font, XBrushes.IndianRed, new XRect(0, 0, 200, 50), XStringFormats.Center);
            //for (int j = 25; j <= text.Count * 25; j += 25)
            //{
            //    gfx.DrawString(text[k], font, XBrushes.Black, new XRect(0, j, 200, 50), XStringFormats.Center);
            //    k++;
            //}
            //string filename = @"..\..\Arved\tsekk" + i.ToString() + ".pdf";
            //document.Save(filename);
            //Process.Start(filename);
        }
        void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0)
            {
                text.Add(
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[0].Value.ToString() + " " +
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[2].Value.ToString() + " " +
                    dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[1].Value.ToString() + " €");

                connect.Open();
                cmd = new SqlCommand("INSERT INTO Ostukorv (Toodenimetus, Kogus, Hind) VALUES (@toodenimetus, @kogus, @hind)", connect);
                cmd.Parameters.AddWithValue("@toodenimetus", dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[0].Value.ToString());
                cmd.Parameters.AddWithValue("@kogus", dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[2].Value);
                cmd.Parameters.AddWithValue("@hind", dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[1].Value);
                cmd.ExecuteNonQuery();


                cmd = new SqlCommand("SELECT Toodenimetus, Kogus, Hind FROM Ostukorv", connect);
                adapter_toode = new SqlDataAdapter(cmd);
                dt_toode = new DataTable();
                adapter_toode.Fill(dt_toode);
                dataGridView1.DataSource = dt_toode;
                connect.Close();
            }
            else
            {
                MessageBox.Show("Sisesta kogus!", "Error");
            }
        }
        void button3_Click(object sender, EventArgs e)
        {
            new Form5().Show();
        }

        void numericUpDown1_ValueChanged(object sender, EventArgs e) //Не видит hind
        {
            dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[2].Value = numericUpDown1.Value;
            //dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[1].Value = decimal.Parse(hind) * numericUpDown1.Value;
        }

        //void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    foreach (Object nimetus in comboBox1.Items)
        //    {
        //        if (comboBox1.SelectedItem == nimetus)
        //        {
        //            hind = hinned[comboBox1.SelectedIndex].ToString();
        //            numericUpDown1.Value = 1;
        //            label2.Text = "€ " + hind + " x " + numericUpDown1.Value.ToString() + " = " + Convert.ToDecimal(hind) * numericUpDown1.Value;
        //        }
        //    }
        //}
    }
}

// <<< Дополнительные задания для развития формы >>>
// 1.
// Купленные товары отнимаются от общего количество товаров -> Добавить Kogus -- num max value