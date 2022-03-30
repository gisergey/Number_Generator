using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Generator
{
    static class Numbers
    {
        public static List<Number> Real_Numbers = new List<Number>(53144100);

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
            while (Real_Numbers.Contains(n))
            {
                n++;
            }
            Real_Numbers.Add(n);
        }
        

    }
}
