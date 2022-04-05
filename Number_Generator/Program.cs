using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Number_Generator
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainNumberForm());
            using(StreamWriter text= new StreamWriter("debug.txt",true))
            {
                foreach(Number n in Numbers.Real_Numbers)
                {
                    text.WriteLine(n.ToString());
                }
            }
        }
    }
}
