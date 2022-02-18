using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1._2
{
    public partial class Form1 : Form
    {

        private List<Students> list = new List<Students>();
        private delegate List<Students> Comparator(Comparison<Students> condition);

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) //generate button click
        {
            this.list.Clear();
            Random random = new Random();
            for (int i = 0; i < Convert.ToInt32(numericUpDown1.Value); i++) //size input
                this.list.Add(new Students(random.Next(99) + 1));

            this.PrintList(this.list);
        }

        private void button1_Click(object sender, EventArgs e) // asc
        {
            Comparator comparator;
            comparator = this.ListSorting;
            comparator((el1, el2) =>
            {
                if (el1.EdgeSize > el2.EdgeSize) return 1;
                else if (el1.EdgeSize == el2.EdgeSize) return 0;
                else return -1;
            });
            this.PrintList(this.list);
        }

        private void button3_Click(object sender, EventArgs e) //desc
        {
            Comparator comparator;
            comparator = this.ListSorting;
            comparator((el1, el2) =>
            {
                if (el1.EdgeSize < el2.EdgeSize) return 1;
                else if (el1.EdgeSize == el2.EdgeSize) return 0;
                else return -1;
            });
            this.PrintList(this.list);
        }

        private List<Students> ListSorting(Comparison<Students> condition)
        {
            list.Sort(condition);
            return list;
        }
        private void PrintList(List<Students> list)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < list.Count; i++)
                listBox1.Items.Add(list[i].ToString());
        }
        private void PrintList2(List<Students> list)
        {
            listBox2.Items.Clear();
            for (int i = 0; i < list.Count; i++)
                listBox2.Items.Add(list[i].ToString());
        }

        ///////////////////////////////////////////////////////////////////////////

        private void button4_Click(object sender, EventArgs e) //1
        {
            if (this.list.Count == 0) return;
            Students getMinimalElement = (from square in this.list select square).Min();
            listBox2.Items.Clear();
            listBox2.Items.Add((string)getMinimalElement.ToString());
        }

        private void button5_Click(object sender, EventArgs e) //2
        {
            if (this.list.Count == 0) return;
            Students getMaximalElement = (from square in this.list select square).Max();
            listBox2.Items.Clear();
            listBox2.Items.Add((string)getMaximalElement.ToString());
        }

        private void button6_Click(object sender, EventArgs e) //3
        {
            if (this.list.Count == 0) return;

            (int min, int max) range = (10, 44);                                    //
            List<Students> getElementsInRange = (from square in this.list
                                               where (square.EdgeSize >= range.min) && (square.EdgeSize <= range.max)
                                               select square).ToList();
            this.PrintList2(getElementsInRange);
        }
    }
}
