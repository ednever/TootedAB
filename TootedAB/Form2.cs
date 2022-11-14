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

namespace TootedAB
{
    public partial class Form2 : Form
    {
        SqlConnection connect;
        //SqlCommand cmd;
        SqlDataAdapter adapter_toode, adapter_hind, adapter;
        DataTable dt_toode, dt_hind, dt;
        string hind;
        List<string> text = new List<string>();
        List<Object> hinned = new List<Object>();
        string[] paring = new string[2] {"Toodenimetus","Hind"};
        public Form2()
        {
            InitializeComponent();
            connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AppData\Tooted_AB.mdf;Integrated Security=True");
            connect.Open();

            //for (int i = 0; i < paring.Length; i++)
            //{
            //    adapter = new SqlDataAdapter("SELECT " + paring[i] + " FROM Toodetable", connect);
            //    dt = new DataTable();
            //    adapter.Fill(dt);
            //    if (true)
            //    {

            //    }
            //}

            adapter_toode = new SqlDataAdapter("SELECT Toodenimetus FROM Toodetable", connect);
            dt_toode = new DataTable();
            adapter_toode.Fill(dt_toode);
            foreach (DataRow nimetus in dt_toode.Rows)
            {
                comboBox1.Items.Add(nimetus["Toodenimetus"]);
            }

            adapter_hind = new SqlDataAdapter("SELECT Hind FROM Toodetable", connect);
            dt_hind = new DataTable();
            adapter_hind.Fill(dt_hind);
            foreach (DataRow nimetus in dt_hind.Rows)
            {
                hinned.Add(nimetus["Hind"]);
            }
            connect.Close();
        }
        int i, k;

        void button1_Click(object sender, EventArgs e)
        {
            //i++;
            //PdfDocument document = new PdfDocument();
            //PdfPage page = document.AddPage();

            ////For drawing in PDF Page you will nedd XGraphics Object
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
            if (comboBox1.SelectedItem != null)
            {
                try
                {
                    text.Add(label2.Text + " " + comboBox1.SelectedItem.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("Sisesta andmed!", "Error");
                }
            }                       
        }
        void button3_Click(object sender, EventArgs e)
        {
            new Form5().Show();
        }

        void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {            
            if (comboBox1.SelectedItem != null)
            {
                label2.Text = "€ " + hind + " x " + numericUpDown1.Value.ToString() + " = " + Convert.ToDecimal(hind) * numericUpDown1.Value;
            }            
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Object nimetus in comboBox1.Items)
            {
                if (comboBox1.SelectedItem == nimetus)
                {
                    hind = hinned[comboBox1.SelectedIndex].ToString();
                    numericUpDown1.Value = 1;
                    label2.Text = "€ " + hind + " x " + numericUpDown1.Value.ToString() + " = " + Convert.ToDecimal(hind) * numericUpDown1.Value;                    
                }
            }          
        }
    }
}
// <<< Дополнительные задания для развития формы >>>
// 1.
// Купленные товары отнимаются от общего количество товаров -> Добавить Kogus -- num max value

// 2.
// Наглядный вариант кассы(сетка картинок) -> полностью переделать кассу -->
//     1. TabControl - один из возможных вариантов для создания вкладок категорий с иконками и текстом
//     2. Создание класса товар, который принимает за свойства значения с базы данных
