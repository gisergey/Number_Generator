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
        static PrivateFontCollection Normalfont = new PrivateFontCollection();

        public MainNumberForm()
        {
            InitializeComponent();
        }
        Font normalFonts;
        Font reversedFonts;

        bool isreversed = false;
        int high = 120;

        private void RandomButtonClick(object sender, EventArgs e)
        {
            Numbers.Random();
            S();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

            pictureBox1.BackgroundImage = Properties.Resources.carNumber;


            Normalfont.AddFontFile("SAAS.ttf");

            normalFonts = new Font(Normalfont.Families[0], high);

            Normalfont.AddFontFile("SAASLastCreated.ttf");
            reversedFonts = new Font(Normalfont.Families[0], high);

            LeftLabel.Font = normalFonts;
            MiddleLabel.Font = normalFonts;
            RigthLabel.Font = normalFonts;

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
            Numbers.Real_Numbers.Add(new Number(n.Num, n.letters));
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

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ReverseButton_Click(object sender, EventArgs e)
        {
            if (isreversed)
            {
                LeftLabel.Font = normalFonts;
                MiddleLabel.Font = normalFonts;
                RigthLabel.Font = normalFonts;
                pictureBox1.BackgroundImage = Properties.Resources.carNumber;
            }
            else
            {

                LeftLabel.Font = reversedFonts;
                MiddleLabel.Font = reversedFonts;
                RigthLabel.Font = reversedFonts;
                pictureBox1.BackgroundImage = Properties.Resources.ReversCarNumber1;

            }
            isreversed = !isreversed;



            //Button Button = sender as Button;
            //Button.Visible = false;
            //Button.Enabled = false;


            S();

        }
    }
}
