using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.SQLite;
namespace Number_Generator
{
    static class Program
    {
        static void runproram()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainNumberForm());
        }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                DataTable dt = new DataTable();
                string sqlcommand = "SELECT* FROM REALNUMBERS";
                string pathsqlDB = "data source=";
                pathsqlDB += Environment.CurrentDirectory.Replace(@"bin\Debug", "") + "NumberDB.db";
                SQLiteConnection connect = new SQLiteConnection(pathsqlDB);
                connect.Open();
                SQLiteCommand command = new SQLiteCommand(sqlcommand, connect);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(dt);
                foreach (DataRow DR in dt.Rows)
                {
                    try
                    {
                        string cell = (string)DR.ItemArray[0];
                        if (Number.IsNumber(cell))
                        {
                            Numbers.Real_Numbers.Add(new Number(cell));
                        }
                    }
                    catch { MessageBox.Show("Есть Ошибка"); }
                }
                int previouslength = Numbers.Real_Numbers.Count();
                runproram();
                sqlcommand = "INSERT INTO REALNUMBERS(Number)VALUES('')";
                for (int i = previouslength; i < Numbers.Real_Numbers.Count; i++)
                {
                    command = new SQLiteCommand(sqlcommand.Insert(39, Numbers.Real_Numbers[i].ToString()), connect);
                    command.ExecuteNonQuery();

                }

                
                connect.Close();

            }
            catch
            {
                
                MessageBox.Show("Возникла ошибка при работе с бд, приносим свои извенения");
                runproram();
            }
 
  
        }
    }
}
