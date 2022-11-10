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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
// При нажатии на кнопку добавлять данные в базу данных
// Сделать проверку на наличие схожего номера телефона в таблице, при удтверждении запретить создавать аккаунт с таким телефоном