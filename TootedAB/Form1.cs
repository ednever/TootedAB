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

namespace TootedAB
{
    public partial class Form1 : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AppData\Tooted_AB.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter_toode, adapter_kat;  
        Random random = new Random();
        OpenFileDialog open = new OpenFileDialog();
        int Id;
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
            Toode_pbox.Image = Image.FromFile("../../Images/Nothing.png");

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
            if (Kat_cbox.Text != "")
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
                MessageBox.Show("Sisestage andmed!");
            }
        }
        void Lisa_btn_Click(object sender, EventArgs e)
        {
            if (Toode_txt.Text.Trim() != String.Empty && Kogus_nud.Value != 0 && Hind_nud.Value != 0 && Kat_cbox.SelectedItem != null)
            {
                try
                {
                    connect.Open();
                    cmd = new SqlCommand("INSERT INTO Toodetable (Toodenimetus, Kogus, Hind, Pilt, Kategooria_id) VALUES (@toode,@kogus,@hind,@pilt,@kat)", connect);
                    cmd.Parameters.AddWithValue("@toode", Toode_txt.Text);
                    cmd.Parameters.AddWithValue("@kogus", Kogus_nud.Value);
                    cmd.Parameters.AddWithValue("@hind", Hind_nud.Value);
                    cmd.Parameters.AddWithValue("@pilt", Toode_txt.Text + ".png");
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
                MessageBox.Show("Sisestage andmed!");
            }
        }
        void Vali_btn_Click(object sender, EventArgs e)
        {
            open.InitialDirectory = Path.GetFullPath(@"..\..\Images");
            //FileInfo open_info = new FileInfo(@"C:\Users\opilane.TTHK\Pictures\" + open.FileName);

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
        void Kustuta_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            string sql = "DELETE FROM ToodeTable WHERE Id = @rowID";

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
        void Kustuta_kat_btn_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT Id FROM Kategooriatable WHERE Kategooria_nimetus = @kat", connect);
            connect.Open();
            cmd.Parameters.AddWithValue("@kat", Kat_cbox.Text);
            cmd.ExecuteNonQuery();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            connect.Close();
            if (Id != 0)
            {
                cmd = new SqlCommand("DELETE FROM Kategooriatable WHERE Id = @id", connect);
                connect.Open();
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.ExecuteNonQuery();
                Kustuta_Andmed();
                Naita_Andmed();
                connect.Close();
                MessageBox.Show("Kategooria on kustutatud!");
            }
            else
            {
                MessageBox.Show("Sellist kategooriat pole!");
            }
        }
        void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); //kui andmed puuduvad reas siis on viga
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
                    Toode_pbox.Image = Image.FromFile(@"..\..\Images\Nothing.png");
                }            
                Kat_cbox.SelectedIndex = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()) - 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Lisage andmed!");
            }                    
        }
        void Uuenda_btn_Click(object sender, EventArgs e)
        {
            if (Toode_txt.Text != "" && Kogus_nud.Value != 0 && Hind_nud.Value != 0 && Kat_cbox.SelectedItem != null)
            {
                connect.Open();
                cmd = new SqlCommand("UPDATE Toodetable SET Toodenimetus = @toode, Kogus = @kogus, Hind = @hind, Pilt = @pilt, Kategooria_id = @kat WHERE Id = @ID", connect);
                cmd.Parameters.AddWithValue("@toode", Toode_txt.Text);
                cmd.Parameters.AddWithValue("@kogus", Kogus_nud.Value);
                cmd.Parameters.AddWithValue("@hind", Hind_nud.Value);
                cmd.Parameters.AddWithValue("@pilt", Toode_txt.Text + ".png"); // + format
                cmd.Parameters.AddWithValue("@kat", Kat_cbox.SelectedIndex + 1); // + ID andmebaasist võtta
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
    }
}

// <<< Исправление ошибок >>>

// 1. Добавление
//     1.1 Сделать проверку на форматы
//     1.2 При добавлении товара обязательно открывать картинку с помощью кнопки Vali fail для внесения картинки в базу данных --
// Также надо учитывать, что название картинки создаётся с нового наименования товара + его расширения
//     1.4 Исправить добавление копированных категорий при добавлении товара в таблицу
//     1.5 Исправить ошибку с сохранением товаров в базу данных при добавлении их в таблицу

// 2. Добавление категорий
//     2.1 При добавлении категорий сделать проверку на заполненность поля чтобы предотвратить создание пустых категорий
//     2.2 Исправить ошибку с сохранением категории в базу данных после добавления категории

// 3. Обновление
//     3.1 Сделать проверку на форматы
//     3.2 Исправить проблемы с картинками при запуске запроса на обновление
//     3.3 Исправить добавление копированных категорий при обновлении товара

// 4. Удаление
//     4.1 Исправить добавление копированных категорий при удалении товара

// 5. Удаление категорий
//     5.1 Исправить добавление копированных категорий при удалении категорий