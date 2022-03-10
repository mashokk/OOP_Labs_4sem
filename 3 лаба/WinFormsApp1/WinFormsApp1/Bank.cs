using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormsApp1
{
    public partial class Bank : Form
    {
        public Bank()
        {
            InitializeComponent();
            Balans_trackBar.Scroll += Balans_trackBar_Scroll;

            Random r = new Random();
            int x = r.Next(100000, 999999);
            Nomer_scheta_textBox.Text = x.ToString();

            Tip_vklada_comboBox.Text = "-";
        }

        public static Class1 bank = new Class1();

        private void Bank_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new Form2();
            form.Show();
        }

        private void Nomer_scheta_textBox_TextChanged(object sender, EventArgs e) //рандомный номер счета
        {
            bank.Number = Nomer_scheta_textBox.Text;
        }

        private void Tip_vklada_comboBox_SelectedIndexChanged(object sender, EventArgs e) //тип вклада комбо бокс
        {
            bank.Vklad = Tip_vklada_comboBox.Items[Tip_vklada_comboBox.SelectedIndex].ToString();
        }

        private void Balans_trackBar_Scroll(object sender, EventArgs e)
        {
            label9.Text = String.Format("{0}", Balans_trackBar.Value);
        }

        private void podkluchenieSMS_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox podkluchenieSMS_checkBox = (CheckBox)sender;
            if (podkluchenieSMS_checkBox.Checked == true)
            {
                podkluchenieSMS_checkBox.Text = String.Format("Да");
            }
            else
            {
                podkluchenieSMS_checkBox.Text = String.Format("Нет");
            }
        }

        private void podkluchenieIB_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox podkluchenieIB_checkBox = (CheckBox)sender;
            if (podkluchenieIB_checkBox.Checked == true)
            {
                podkluchenieIB_checkBox.Text = String.Format("Да");
            }
            else
            {
                podkluchenieIB_checkBox.Text = String.Format("Нет");
            }
        }
        private void Gotovo1_button_Click(object sender, EventArgs e) //КНОПКА КОТОРАЯ ВЫВОДИТ РЕЗУЛЬТАТ
        {
            try
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = bank.Number; // столбец банковский номер
                dataGridView1.Rows[n].Cells[1].Value = bank.Vklad; // банковский вклад
                dataGridView1.Rows[n].Cells[2].Value = label9.Text; // баланс
                dataGridView1.Rows[n].Cells[3].Value = Data_otkritiya_dateTimePicker.Value; //дата открытия
                dataGridView1.Rows[n].Cells[4].Value = podkluchenieSMS_checkBox.Checked; //смс-оповещения
                dataGridView1.Rows[n].Cells[5].Value = podkluchenieIB_checkBox.Checked; //интернет-банкинг
                dataGridView1.Rows[n].Cells[6].Value = bank.vladelets.Name; //ФИО
                dataGridView1.Rows[n].Cells[7].Value = bank.vladelets.d; //дата рождения
                dataGridView1.Rows[n].Cells[8].Value = bank.vladelets.Seria + bank.vladelets.Nomer; //серия и номер паспорта

                Nomer_scheta_textBox.Clear();
                Random r = new Random();
                int x = r.Next(10000, 99999);
                Nomer_scheta_textBox.Text = x.ToString();
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Заполните все поля.", "Ошибка.");
            }
            try
            {
                DataSet ds = new DataSet(); // создаем пока что пустой кэш данных
                DataTable dt = new DataTable(); // создаем пока что пустую таблицу данных
                dt.TableName = "BANK"; // название таблицы
                dt.Columns.Add("NOMER"); // название колонок
                dt.Columns.Add("BALANS");
                dt.Columns.Add("VKLAD");

                dt.Columns.Add("D_OPEN");
                dt.Columns.Add("SMS");
                dt.Columns.Add("IB");
                dt.Columns.Add("FIO");
                dt.Columns.Add("D_BDAY");
                dt.Columns.Add("PASSPORT");
                ds.Tables.Add(dt); //в ds создается таблица, с названием и колонками, созданными выше

                foreach (DataGridViewRow r in dataGridView1.Rows) // пока в dataGridView1 есть строки
                {
                    DataRow row = ds.Tables["BANK"].NewRow(); // создаем новую строку в таблице, занесенной в ds
                    row["NOMER"] = r.Cells[0].Value;  //в столбец этой строки заносим данные из первого столбца dataGridView1
                    row["BALANS"] = r.Cells[1].Value; // то же самое со вторыми столбцами
                    row["VKLAD"] = r.Cells[2].Value; //то же самое с третьими столбцами

                    row["D_OPEN"] = r.Cells[3].Value;
                    row["SMS"] = r.Cells[4].Value;
                    row["IB"] = r.Cells[5].Value;
                    row["FIO"] = r.Cells[6].Value;
                    row["D_BDAY"] = r.Cells[7].Value;
                    row["PASSPORT"] = r.Cells[8].Value;

                    ds.Tables["BANK"].Rows.Add(row); //добавление всей этой строки в таблицу ds.
                }
                ds.WriteXml(@"C:\Study\2 курс\4 семестр\ООП\сами лабы\3 лаба\Data.xml");
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить XML файл.", "Ошибка.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //о программе
        {
            MessageBox.Show("Версия: 1.3\nРазработчик: маш ок", "О программе");
        }

        private void button2_Click(object sender, EventArgs e) //кнопка СОХРАНИТЬ в XML
        {
            
        }

        private void button3_Click(object sender, EventArgs e) //    очистить таблицу
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Таблица пустая.", "Ошибка.");
            }
        }


        private void button1_Click_1(object sender, EventArgs e) //        ПОИСК
        {
            Form f = new Search();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e) //         SORT но не сорт!!!!! временно
        {
                if (File.Exists(@"C:\Study\2 курс\4 семестр\ООП\сами лабы\3 лаба\Data.xml")) // если существует данный файл
                {
                    DataSet ds = new DataSet(); // создаем новый пустой кэш данных
                    ds.ReadXml(@"C:\Study\2 курс\4 семестр\ООП\сами лабы\3 лаба\Data.xml"); // записываем в него XML-данные из файла

                    foreach (DataRow item in ds.Tables["BANK"].Rows)
                    {
                        int n = dataGridView1.Rows.Add(); // добавляем новую сроку в dataGridView1
                        dataGridView1.Rows[n].Cells[0].Value = item["NOMER"]; // заносим в первый столбец созданной строки данные из первого столбца таблицы ds.
                        dataGridView1.Rows[n].Cells[1].Value = item["BALANS"]; // то же самое со вторым столбцом
                        dataGridView1.Rows[n].Cells[2].Value = item["VKLAD"]; // то же самое с третьим столбцом

                        dataGridView1.Rows[n].Cells[3].Value = item["D_OPEN"]; //дата открытия
                        dataGridView1.Rows[n].Cells[4].Value = item["SMS"]; //смс-оповещения
                        dataGridView1.Rows[n].Cells[5].Value = item["IB"]; //интернет-банкинг
                        dataGridView1.Rows[n].Cells[6].Value = item["FIO"]; //ФИО
                        dataGridView1.Rows[n].Cells[7].Value = item["D_BDAY"]; //дата рождения
                        dataGridView1.Rows[n].Cells[8].Value = item["PASSPORT"]; //серия и номер паспорта
                    }
                }
                else
                {
                    MessageBox.Show("XML файл не найден.", "Ошибка.");
                }
        }
    }
}
