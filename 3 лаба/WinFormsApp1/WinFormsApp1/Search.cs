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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();


            if (File.Exists(@"C:\Study\2 курс\4 семестр\ООП\сами лабы\3 лаба\Data.xml")) // если существует данный файл
            {
                DataSet ds = new DataSet(); // создаем новый пустой кэш данных
                ds.ReadXml(@"C:\Study\2 курс\4 семестр\ООП\сами лабы\3 лаба\Data.xml"); // записываем в него XML-данные из файла

                foreach (DataRow item in ds.Tables["BANK"].Rows)
                {
                    int n = dataGridView2.Rows.Add(); // добавляем новую сроку в dataGridView1
                    dataGridView2.Rows[n].Cells[0].Value = item["NOMER"]; // заносим в первый столбец созданной строки данные из первого столбца таблицы ds.
                    dataGridView2.Rows[n].Cells[1].Value = item["BALANS"]; // то же самое со вторым столбцом
                    dataGridView2.Rows[n].Cells[2].Value = item["VKLAD"]; // то же самое с третьим столбцом
                                
                    dataGridView2.Rows[n].Cells[3].Value = item["D_OPEN"]; //дата открытия
                    dataGridView2.Rows[n].Cells[4].Value = item["SMS"]; //смс-оповещения
                    dataGridView2.Rows[n].Cells[5].Value = item["IB"]; //интернет-банкинг
                    dataGridView2.Rows[n].Cells[6].Value = item["FIO"]; //ФИО
                    dataGridView2.Rows[n].Cells[7].Value = item["D_BDAY"]; //дата рождения
                    dataGridView2.Rows[n].Cells[8].Value = item["PASSPORT"]; //серия и номер паспорта
                }
            }
            else
            {
                MessageBox.Show("XML файл не найден.", "Ошибка.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // НОМЕР СЧЕТА ПОИСК
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //ОТМЕНА (закрытие окошка)
        {
            this.Close();
        }
    }
}
