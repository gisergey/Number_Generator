using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
namespace Number_Generator
{
    public partial class MainNumberForm : Form
    {
        PrivateFontCollection fonts;
        public MainNumberForm()
        {
            InitializeComponent();
        }
       
 

        private void MainForm_Load(object sender, EventArgs e)
        {
            int high = 110;
            fonts = new PrivateFontCollection();
            fonts.AddFontFile("SAAS.ttf");
            LeftLabel.Font = new Font(fonts.Families[0], high);
            MiddleLabel.Font = new Font(fonts.Families[0], high);
            RigthLabel.Font = new Font(fonts.Families[0], high);
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
            string numer = Numbers.Real_Numbers.Last().ToString();
            LeftLabel.Text = numer[0].ToString() + numer[1].ToString();
            MiddleLabel.Text = numer[2].ToString() + numer[3].ToString();
            RigthLabel.Text = numer[4].ToString() + numer[5].ToString();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
