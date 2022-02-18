using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1._2
{
    public class Students : IComparable
    {
        public int EdgeSize { get; set; }

        public Students(int edgeSize = 0)
        {
            EdgeSize = edgeSize;
        }
        

        public override string ToString()
        {

                return $"Сколько нервных клеток осталось у студента №: {this.EdgeSize}";
            
        }

        public int CompareTo(object obj)
        {
            Students other = obj as Students;
            if (other == null) return -1;

            if (this.EdgeSize == other.EdgeSize) return 0;
            else if (this.EdgeSize > other.EdgeSize) return 1;
            else return -1;
        }
    }
}
