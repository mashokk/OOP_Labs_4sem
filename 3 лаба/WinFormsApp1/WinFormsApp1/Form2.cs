﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Data_rozhdeniya_monthCalendar.DateChanged += Data_rozhdeniya_monthCalendar_DateChanged;
            Familia_textBox.Text = "Ф";
            Imya_textBox.Text = "И";
            Otchestvo_textBox.Text = "О";
            Gorod_comboBox.Text = "-";
            seria_pasport_comboBox.Text = "-";
            nomer_pasport_textBox.Text = "-";
        }

        Vladelets vladelets = new Vladelets();

        private void Gotovo2_button_Click(object sender, EventArgs e)
        {
            this.Close();
            Bank.bank.vladelets = vladelets;
        }

        private void Familia_textBox_TextChanged(object sender, EventArgs e)
        {
            vladelets.Name = Familia_textBox.Text + " " + Imya_textBox.Text + " " + Otchestvo_textBox.Text + "\n";
        }

        private void Imya_textBox_TextChanged(object sender, EventArgs e)
        {
            vladelets.Name = Familia_textBox.Text + " " + Imya_textBox.Text + " " + Otchestvo_textBox.Text + "\n";
        }

        private void Otchestvo_textBox_TextChanged(object sender, EventArgs e)
        {
            var data = Otchestvo_textBox.Text;
            for (int i = 0; i < Otchestvo_textBox.Text.Length; i++)
            {
                if (Regex.IsMatch(Otchestvo_textBox.Text, @"^([a-z0-9_-]+\.)*[a-z0-9_-]+@(gmail?|yandex?|tut)+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$"))
                {
                    vladelets.Name = Familia_textBox.Text + " " + Imya_textBox.Text + " " + Otchestvo_textBox.Text + "\n";
                    Otchestvo_textBox.ForeColor = System.Drawing.Color.Green;
                }
                else Otchestvo_textBox.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void Gorod_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            vladelets.Gorod = Gorod_comboBox.Items[Gorod_comboBox.SelectedIndex].ToString();
        }

        private void seria_pasport_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            vladelets.Seria = seria_pasport_comboBox.Items[seria_pasport_comboBox.SelectedIndex].ToString();
        }

        private void nomer_pasport_textBox_TextChanged(object sender, EventArgs e)
        {
            vladelets.Nomer = nomer_pasport_textBox.Text + "\n";

        }

        private void Data_rozhdeniya_monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            //DateTime d = Data_rozhdeniya_monthCalendar.SelectionStart;
            //d = string.Format("{0}.{1}.{2}", d.Day, d.Month, d.Year);
            label9.Text = String.Format(e.Start.ToLongDateString());
            vladelets.d = label9.Text + "\n";
        }
    }
}
