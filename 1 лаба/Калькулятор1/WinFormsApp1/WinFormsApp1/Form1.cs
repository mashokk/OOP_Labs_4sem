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
    public partial class Form1 : Form
    {
        public string D; //действие
        public string DM;
        public string N1; 
        public bool N2; //набор второго числа

        public double memory = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (N2)
            {
                N2 = false;
                textBox1.Text = "0";
            }
            Button B = (Button)sender; //та кнопка на кот. нажали
            if (textBox1.Text == "0") //если 0 в начале то стирается
                textBox1.Text = B.Text;
            else
                textBox1.Text = textBox1.Text + B.Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            Button B = (Button)sender;
            D = B.Text;

            N1 = textBox1.Text;
            N2 = true; //надо стереть перед началом набора
        }

        private void button22_Click(object sender, EventArgs e)
        {
            double DN1, DN2, result; //переменные которые хранят значения + result
            result = 0;
            DN1 = Convert.ToDouble(N1); //конвертирование
            DN2 = Convert.ToDouble(textBox1.Text);
            if (D=="+")
            {
                result = DN1 + DN2;
            }
            if (D == "-")
            {
                result = DN1 - DN2;
            }
            if (D == "x")
            {
                result = DN1 * DN2;
            }
            if (D == "/")
            {
                result = DN1 / DN2;
            }
            if (D == "%")
            {
                result = DN1 % DN2;
            }
            D = "=";
            N2 = true;
            textBox1.Text = result.ToString();

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double DN, result;
            DN = Convert.ToDouble(textBox1.Text);
            result = -DN;
            textBox1.Text = result.ToString();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Contains(","))
                textBox1.Text = textBox1.Text + ",";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            if (textBox1.Text == "")
                textBox1.Text = "0";
        }

        private void button10_Click(object sender, EventArgs e)
        {
   
        }

        private void button2_Click_1(object sender, EventArgs e) // MRC
        {
            textBox1.Text = memory.ToString();

        }

        private void button2_Click_2(object sender, EventArgs e) //M-
        {

        }

        private void button3_Click(object sender, EventArgs e) //M+
        {
            memory = int.Parse(textBox1.Text);
        }
    }
}
