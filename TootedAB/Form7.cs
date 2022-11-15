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
    public partial class Form7 : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AppData\Tooted_AB.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter;
        int Id;
        public Form7()
        {
            InitializeComponent();
            Naita_Andmed();
        }

        void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                try
                {
                    connect.Open();
                    cmd = new SqlCommand("INSERT INTO Kliendid (Nimi, Perekonnanimi, Telefon, Password) VALUES (@nimi, @perenimi, @tel, @parool)", connect);
                    cmd.Parameters.AddWithValue("@nimi", textBox1.Text);
                    cmd.Parameters.AddWithValue("@perenimi", textBox2.Text);
                    cmd.Parameters.AddWithValue("@tel", textBox3.Text);
                    cmd.Parameters.AddWithValue("@parool", textBox4.Text);
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
                MessageBox.Show("Sisestage andmed!");
            }
        }

        void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                connect.Open();
                cmd = new SqlCommand("UPDATE Kliendid SET Nimi = @nimi, Perekonnanimi = @perenimi, Telefon = @tel, Password = @parool WHERE Id = @ID", connect);
                cmd.Parameters.AddWithValue("@nimi", textBox1.Text);
                cmd.Parameters.AddWithValue("@perenimi", textBox2.Text);
                cmd.Parameters.AddWithValue("@tel", textBox3.Text);
                cmd.Parameters.AddWithValue("@parool", textBox4.Text);
                cmd.Parameters.AddWithValue("@ID", Id);
                cmd.ExecuteNonQuery();
                connect.Close();
                Kustuta_Andmed();
                Naita_Andmed();
                MessageBox.Show("Andmed uuendatud!");
            }
            else
            {
                MessageBox.Show("Sisesta andmed!");
            }
        }
        void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            string sql = "DELETE FROM Kliendid WHERE Id = @rowID";

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
        public void Naita_Andmed()
        {
            connect.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("SELECT * FROM Kliendid", connect);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connect.Close();
        }
        public void Kustuta_Andmed()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Lisage andmed!");
            }
        }
    }
}