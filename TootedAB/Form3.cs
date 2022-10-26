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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            comboBox1.Items.Add("Müüja");
            comboBox1.Items.Add("Omanik");
        }

        void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && textBox1 != null)
            {
                if (comboBox1.SelectedIndex == 0 && textBox1.Text == "supermuuja")
                {                    
                    new Form2().Show();
                }
                else if (comboBox1.SelectedIndex == 1 && textBox1.Text == "admin")
                {
                    new Form4().Show();
                }
                else
                {
                    MessageBox.Show("Vale parool!");
                    textBox1.Text = null;
                }
            }
            else
            {
                MessageBox.Show("Sisestage andmed!");
            }
        }
    }
}
