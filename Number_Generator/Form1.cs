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
            bool a = false;
            ReverseButton.Enabled = a;
            NextButton.Enabled = a;
            RandomButton.Enabled = a;
            CloseButton.Enabled = a;
            PreviousButton.Enabled = a;
            randomgenerationtimer.Interval = 5;
            randomgenerationtimer.Start();

            S();
        }
  
        private void MainForm_Load(object sender, EventArgs e)
        {

            pictureBox1.BackgroundImage = Properties.Resources.carNumber;

            string path = Environment.CurrentDirectory.Replace(@"bin\Debug", @"Fonts\");

            Normalfont.AddFontFile(path + "SAAS.ttf");

            normalFonts = new Font(Normalfont.Families[0], high);

            Normalfont.AddFontFile(path + "SAASLastCreated.ttf");
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
            Button button = sender as Button;
            if (isreversed)
            {
                button.Text = "Адаптировать";
                LeftLabel.Font = normalFonts;
                MiddleLabel.Font = normalFonts;
                RigthLabel.Font = normalFonts;
                pictureBox1.BackgroundImage = Properties.Resources.carNumber;
            }
            else
            {
                button.Text = "Обратно";
                LeftLabel.Font = reversedFonts;
                MiddleLabel.Font = reversedFonts;
                RigthLabel.Font = reversedFonts;
                pictureBox1.BackgroundImage = Properties.Resources.ReversCarNumber1;

            }
            isreversed = !isreversed;

            S();

        }
        int a = 1000;
        private void randomgenerationtimer_Tick(object sender, EventArgs e)
        {
            randomgenerationtimer.Interval=randomgenerationtimer.Interval+randomgenerationtimer.Interval/3;
            Random rnd = new Random();
            int[] numers = new int[2];
            for (int i = 0; i < 2; i++)
            {
                numers[i] = rnd.Next(0, 10);
            }
            char[] letters = new char[4];
            for (int i = 0; i < 4; i++)
            {
                letters[i] = (char)((int)'A' + rnd.Next(0, 26));
            }
            Number n = new Number(numers, letters);
            string numer = n.ToString();
            LeftLabel.Text = numer[0].ToString() + numer[1].ToString();
            MiddleLabel.Text = numer[2].ToString() + numer[3].ToString();
            RigthLabel.Text = numer[4].ToString() + numer[5].ToString();
            if (randomgenerationtimer.Interval > 700)
            {
                bool a = true;
                ReverseButton.Enabled = a;
                NextButton.Enabled = a;
                RandomButton.Enabled = a;
                CloseButton.Enabled = a;
                PreviousButton.Enabled = a;
                randomgenerationtimer.Stop();
            }


        }
    }
}
