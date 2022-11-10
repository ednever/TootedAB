using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data;


namespace TootedAB
{
    public class Toode
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AppData\Tooted_AB.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter_toode;
        Random random = new Random();
        DataTable dt;

        string toodeNimi, pilt;
        double kogus, hind;
        int id, kategooria_id;

        List<string> toodeNimed = new List<string>();

        public Toode() {}
        //public void input_Andmed()
        //{
        //    connect.Open();

        //    dt = new DataTable();
        //    cmd = new SqlCommand("SELECT Toodenimetus FROM ToodeTable", connect);
        //    adapter_toode = new SqlDataAdapter(cmd);
        //    adapter_toode.Fill(dt);
        //    foreach (DataRow nimetus in dt.Rows)
        //    {
        //        toodeNimed.Add(nimetus.ToString());
        //    }
        //    connect.Close();
        //}
    }
}
// Класс принимает информацию с базы данных и преобразует её в переменные группированные по спискам
// Дальше ипользую нужную переменную класса в форме для взятия информации
// Работаю в форме с этой переменной с последующим сохранением
// 