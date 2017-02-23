using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cvicenie1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int wordCounter = 0;
            int spaceCounter = 0;
            int otherCounter = 0;
            label2.Text = "";

            bool word = false;
            bool special = false;

            string wholeString = textBox1.Text;

            foreach (char character in wholeString)
            {
                if (character == ' ')
                {
                    word = false;
                    special = false;
                    spaceCounter++;
                }
                else if (special)
                {
                    continue;
                }
                else if ((character >= 'a' && character <= 'z') ||
                            (character >= 'A' && character <= 'Z'))
                {
                    if (!word)
                    {
                        word = true;
                        wordCounter++;
                    }
                }
                else if(character == '/')
                {
                    special = true;
                }
                else if(character >= '!' && character <= '@')
                {
                    word = false;
                    otherCounter++;
                    label2.Text += Convert.ToByte(character);
                    label2.Text += Environment.NewLine;
                }
            }
            label1.Text = wordCounter.ToString() + " slov " +
                        spaceCounter.ToString() + " medzier " +
                        otherCounter.ToString() + " ine znaky";
        }
    }
}
