using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Generator
{
    class Number
    {
        public Number()
        {
            for(int i = 0; i < 4; i++)
            {
                letters[i] = 'A';
            }
        }
        public Number(string str)
        {
          
        }
        public Number(int[] num, char[] letters)
        {
           for(int i = 0; i < 4;i++)
           {
               this.letters[i] = letters[i];
           }
           for(int i = 0; i < 2; i++)
           {
                Num[i] = num[i];
           }
        
        
        }
        public char[] letters = new char[4];
        public int[] Num=new int[2];
        public override string ToString()
        {
            return letters[0].ToString() + letters[1].ToString()+Num[1].ToString()+Num[0].ToString()+letters[2].ToString()+letters[3].ToString();
        }
        public static Number operator++(Number n)
        {
            Number num = new Number(n.Num, n.letters);
            int i = 0;
            int j = 0;
            if (num.Num[0] == 9)
            {
                i++;
                if (num.Num[1] == 9)
                {
                    i++;
                    while (j<4&&num.letters[j] == 'Z')
                    {
                        j++;
                    }
                }
            }
            for(int h = 0; h < i; h++)
            {
                num.Num[h] = 0;
            }
            if (i < 2)
            {
                num.Num[i] += 1;
            }
            else   if (j < 4)
            {
                num.letters[j] = (char)(num.letters[j] + 1);
            }

            for(int h = 0; h < j; h++)
            {
                num.letters[h] = 'A';
            }
            return num;
        }
        static public Number operator--(Number n)
        {
            Number num = new Number(n.Num, n.letters);
            int i = 0;
            int j = 0;
            if (num.Num[0] == 0)
            {
                i++;
                if (num.Num[1] == 0)
                {
                    i++;
                    while (j < 4 && num.letters[j] == 'A')
                    {
                        j++;
                    }
                }
            }
            for (int h = 0; h < i; h++)
            {
                num.Num[h] = 9;
            }
            if (i < 2)
            {
                num.Num[i] -= 1;
            }
            else if (j < 4)
            {
                num.letters[j] = (char)(num.letters[j] - 1);
            }

            for (int h = 0; h < j; h++)
            {
                num.letters[h] = 'Z';
            }
            return num;
        }
        public override bool Equals(object obj)
        {
            if(obj is Number)
            {
                Number num = obj as Number;
                for(int i = 0; i < 2; i++)
                {
                    if (Num[i] != num.Num[i]) return false;
                }
                for(int i = 0; i < 4; i++)
                {
                    if (letters[i] != num.letters[i])  return false; 
                }
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
