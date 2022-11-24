using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TootedAB
{
    public partial class Form5 : Form
    {
        Klient klient = new Klient();
        Form2 form2 = new Form2();

        public Form5()
        {
            InitializeComponent();
        }

        void button1_Click(object sender, EventArgs e)
        {
            klient.Telefon = textBox1.Text;
            klient.Parool = textBox2.Text;

            if (klient.kontrolli_vastust())
            {
                //kassa_klient(true);
                form2.Tulemus = true;
                //tulemus = 
                //this.Close();
            }
            else
            {
                //kassa_klient(false);
                form2.Tulemus = false;
                //tulemus = false;
                MessageBox.Show("Vigad andmed!", "Error");
            }
        }
        void button2_Click(object sender, EventArgs e)
        {
            new Form6().Show();
        }
    }
}