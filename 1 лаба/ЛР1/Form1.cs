using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЛР1
{
  
    public partial class Form1 : Form
    {
        double a;
        double memory;
        double b;
              public Form1()
        {
            InitializeComponent();
        }
        private delegate void Calculate();
        Calculate Calc;
        private void button11_Click(object sender, EventArgs e)
        {
            
                b = double.Parse(textBox1.Text);
                Calc();
                textBox1.Clear();
                label1.Text = "";
                a = double.Parse(label2.Text);
           

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
                textBox1.Text = textBox1.Text + 9;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 2;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (label2.Text == "")
            {
                a = double.Parse(textBox1.Text);
            }
            textBox1.Clear();
            label1.Text = a.ToString() + "/";
            Calc = Divis;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label1.Text = "";
            label2.Text = "";

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            label2.Text = "";
            textBox1.Text = textBox1.Text + 1;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            textBox1.Text = textBox1.Text + 0;
        }

        private void button17_Click(object sender, EventArgs e)
        { if (label2.Text == "")
            {
                a = double.Parse(textBox1.Text);
               }
            textBox1.Clear();
            label1.Text = a.ToString() + "%";
            Calc = Mod;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            textBox1.Text = memory.ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (label2.Text == "")
            {
                memory = double.Parse(textBox1.Text);
            }
            else
            {
                memory = double.Parse(label2.Text);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (label2.Text == "")
            {
                a = double.Parse(textBox1.Text);
            }
            textBox1.Clear();
            label1.Text = a.ToString() + "*";
            Calc =Mult;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (label2.Text == "")
            {
                a = double.Parse(textBox1.Text);
            }
            textBox1.Clear();
           label1.Text = a.ToString() + "+";
            Calc = Plus;

        }

      

        private void button10_Click(object sender, EventArgs e)
        {
            if (label2.Text == "")
            {
                a = double.Parse(textBox1.Text);
            }
            textBox1.Clear();
            label1.Text = a.ToString() + "-";
           Calc =Minus;
        }
        private void Minus()
        {
            double res;
           res = a - double.Parse(textBox1.Text);
            label2.Text = res.ToString();
        }
      private void Plus()
        {
            double res;
            res = a + double.Parse(textBox1.Text);
            label2.Text = res.ToString();
        }
        private void Mult()
        {
            double res;
            res = a * double.Parse(textBox1.Text);
            label2.Text = res.ToString();
        }
        private void Divis()
        {
                double res;
                res = a / (double.Parse(textBox1.Text));
                label2.Text = res.ToString();
            

        }
        private void Mod()
        {
            double res;
            res = a % double.Parse(textBox1.Text);
            label2.Text = res.ToString();
        }
      
        private void button7_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            textBox1.Text = textBox1.Text + 3;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            textBox1.Text = textBox1.Text + 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            textBox1.Text = textBox1.Text + 5;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 6;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            textBox1.Text = textBox1.Text + 7;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            textBox1.Text = textBox1.Text + 8;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
        }
       
        
    }
}
