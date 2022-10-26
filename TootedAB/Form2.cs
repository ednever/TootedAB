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
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;

namespace TootedAB
{
    public partial class Form2 : Form
    {
        SqlConnection connect;
        SqlCommand cmd;
        SqlDataAdapter adapter_toode, adapter_hind;
        DataTable dt_toode, dt_hind;
        public Form2()
        {
            InitializeComponent();
            connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AppData\Tooted_AB.mdf;Integrated Security=True");
            adapter_toode = new SqlDataAdapter("SELECT Toodenimetus FROM Toodetable", connect);
            dt_toode = new DataTable();
            adapter_toode.Fill(dt_toode);
            foreach (DataRow nimetus in dt_toode.Rows)
            {
                comboBox1.Items.Add(nimetus["Toodenimetus"]);
            }
        }
        int i;
        private void button1_Click(object sender, EventArgs e)
        {
            i++;
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();

            //For drawing in PDF Page you will nedd XGraphics Object
            XGraphics gfx = XGraphics.FromPdfPage(page);

            //For Test you will have to define font to be used
            XFont font = new XFont("Miriam Mono CLM", 14.25, XFontStyle.Bold);

            //Finally use XGraphics & font object to draw text in PDF Page
            gfx.DrawString("Kviitung", font, XBrushes.Black, new XRect(0, 0, 200, 50), XStringFormats.Center);
            gfx.DrawString(label2.Text, font, XBrushes.Black, new XRect(0, 50, 200, 50), XStringFormats.Center);

            string filename = @"..\..\Arved\tsekk" + i.ToString() + ".pdf";
            document.Save(filename);
            Process.Start(filename);            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {            
            if (comboBox1.SelectedIndex == 0)
            {
                label2.Text = "€ 1.5 x " + numericUpDown1.Value.ToString();
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            adapter_hind = new SqlDataAdapter("SELECT Hind FROM Toodetable", connect);
            dt_hind = new DataTable();
            adapter_hind.Fill(dt_hind);
            
            if (comboBox1.SelectedIndex == 0)
            {
                label2.Text += "1.5";
            }
            numericUpDown1.Value = 1;
        }
    }
}
