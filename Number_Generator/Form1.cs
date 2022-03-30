using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Number_Generator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

 

        private void MainForm_Load(object sender, EventArgs e)
        {
            Numbers.Random();
        
            S();
        }  

        private void NextButton_Click(object sender, EventArgs e)
        {
            Number n = Numbers.Real_Numbers.Last();
            while (Numbers.Real_Numbers.Contains(n))
            {
               
               n++;
                
                
            }
            Numbers.Real_Numbers.Add(new Number(n.Num, n.letters));
            S();
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            Number n = Numbers.Real_Numbers.Last();
            while (Numbers.Real_Numbers.Contains(n))
            {
            
               n--;
              
            }
            Numbers.Real_Numbers.Add(new Number(n.Num,n.letters));
            S();
        }
        private void S()
        {
            label1.Text = Numbers.Real_Numbers.Last().ToString()[0].ToString();
            label2.Text = Numbers.Real_Numbers.Last().ToString()[1].ToString();
            label3.Text = Numbers.Real_Numbers.Last().ToString()[2].ToString();
            label4.Text = Numbers.Real_Numbers.Last().ToString()[3].ToString();
            label5.Text = Numbers.Real_Numbers.Last().ToString()[4].ToString();
            label6.Text = Numbers.Real_Numbers.Last().ToString()[5].ToString();
        }
    }
}
