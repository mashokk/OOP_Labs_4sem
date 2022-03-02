using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Bank : Form
    {
        public Bank()
        {
            InitializeComponent();
            Balans_trackBar.Scroll += Balans_trackBar_Scroll;
            Nomer_scheta_textBox.Text = "-";
            Tip_vklada_comboBox.Text = "-";
        }

        public static Class1 bank = new Class1();



        //String repeatedString = new String("a", 10);

        private void Bank_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new Form2();
            form.Show();
        }

        private void Nomer_scheta_textBox_TextChanged(object sender, EventArgs e)
        {

            bank.Number = "Номер счёта: " + Nomer_scheta_textBox.Text + "\n";
        }

        private void Tip_vklada_comboBox_SelectedIndexChanged(object sender, EventArgs e)
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
        /*bool allTextBoxesIsNotEmpty()
        {
            bool AllIsOk = true;
            if (label9.Text == "не выбрана" || label9.Text == "" || bank.vladelets.Name == "" || bank.vladelets.Seria == "" || bank.vladelets.Nomer == "")
            {
                AllIsOk = false;
                //Ничего не добавляем
            }
            foreach (Control C in this.Controls)
            {
                if (C.GetType() == typeof(TextBox))
                    AllIsOk &= ((TextBox)C).TextLength > 0;
                else
                {
                    AllIsOk = false;
                }
            }
            foreach (Control C in this.Controls)
            {
                if (C.GetType() == typeof(ComboBox))
                    AllIsOk &= ((ComboBox)C).Text == "";
                else
                {
                    AllIsOk = false;
                }
            }
            if (AllIsOk == false)
            {
                Gotovo1_button.Enabled = false;
            }
            return AllIsOk;
        }*/

        private void Gotovo1_button_Click(object sender, EventArgs e) //КНОПКА КОТОРАЯ ВЫВОДИТ РЕЗУЛЬТАТ
        {
            //Gotovo1_button.Enabled = allTextBoxesIsNotEmpty();
            //if (bank.vladelets.d == "" || bank.vladelets.Name == "" || bank.vladelets.Seria == "" || bank.vladelets.Nomer == "" || bank.Number == "" || bank.Vklad == "" || bank.vladelets.Name == "" || bank.vladelets.Seria == "" || bank.vladelets.Nomer == "")
            //{
            //    richTextBox.Text = "Все поля являются обязательными для ввода!";
            //}
            //else
            //{
            try { 
            richTextBox.Text = "БАНКОВСКИЙ ЧЕК" + "\n\n";
            richTextBox.Text += "---------------------------------" + "\n\n";
            richTextBox.Text += bank.Number + "\n";

            richTextBox.Text += "Тип вклада: " + bank.Vklad + "\n";
            richTextBox.Text += "Баланс: " + label9.Text + "$" + "\n";
            richTextBox.Text += "Дата открытия: " + Data_otkritiya_dateTimePicker.Value + "\n";
            richTextBox.Text += "Смс-оповещения подключены: " + podkluchenieSMS_checkBox.Text + "\n";
            richTextBox.Text += "Интернет-банкинг подключен: " + podkluchenieIB_checkBox.Text + "\n\n";


            richTextBox.Text += "ФИО владельца: " + bank.vladelets.Name;
            richTextBox.Text += "Дата рождения: " + bank.vladelets.d;
            richTextBox.Text += "Серия и номер паспорта: " + bank.vladelets.Seria + bank.vladelets.Nomer;
            }
            catch (NullReferenceException)
            {
                richTextBox.Text = "какая то гавна";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
            }
        }

    }
}
