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
    public partial class MainNumberForm : Form
    {
       
        public MainNumberForm()
        {
            InitializeComponent();
        }
       
 

        private void MainForm_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 8; i++)
            {

            }
            Numbers.Random();
    
            S();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            Number n = new Number(Numbers.Real_Numbers.Last().Num, Numbers.Real_Numbers.Last().letters);
            
            n++;
            while (Numbers.IsWeCreateAlreadythisNumber(n))
            {
               n++;
            }
            Numbers.Real_Numbers.Add(new Number(n.Num, n.letters));
            S();
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            Number n = new Number(Numbers.Real_Numbers.Last().Num, Numbers.Real_Numbers.Last().letters);
            n--;
            while (Numbers.IsWeCreateAlreadythisNumber(n))
            {
            
               n--;
              
            }
            Numbers.Real_Numbers.Add(new Number(n.Num,n.letters));
            S();
        }
        private void S()
        {
            label1.Text = Numbers.Real_Numbers.Last().ToString().Insert(2, "*").Insert(5, "*");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
