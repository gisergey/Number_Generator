using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Number_Generator
{
    static class Numbers
    {
               
        public static List<Number> Real_Numbers = new List<Number>(53144100);
        static private int maxnumbers = (int)(100 * Math.Pow(26, 4));
        public static bool IsWeCreateAlreadythisNumber(Number n)
        {
            foreach(Number num in Real_Numbers)
            {
                if (num.Equals(n)) return true;
            }
            return false;
        }
        public static void Random()
        {
            Random rnd = new Random();
            int[] numers = new int[2];
            for(int i = 0; i < 2; i++)
            {
                numers[i] = rnd.Next(0, 10);
            }
            char[] letters = new char[4];
            for(int i = 0; i < 4; i++)
            {
                letters[i] = (char)((int)'A' + rnd.Next(0, 26));
            }
            Number n = new Number(numers, letters);
            int j = 0;
            while (Real_Numbers.Contains(n)||j>maxnumbers)
            {
                j++;
                n++;
            }
            if (j > maxnumbers)
            {
                MessageBox.Show("Больше нет свободных номеров");
            }
            else { Real_Numbers.Add(n); }
        }
        

    }
}
