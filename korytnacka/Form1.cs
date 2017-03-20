using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurtleLanguage
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Turtle turtle;
        SyntaxAnalyser syntaxAnalyser;
        public Form1()
        {
            InitializeComponent();
            graphics = drawingArea.CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            turtle = new Turtle(drawingArea.Width/2, drawingArea.Height/2, graphics);
            syntaxAnalyser = new SyntaxAnalyser(turtle, this);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                graphics.Clear(Color.White);
                //textBox1.Text = syntaxAnalyser.evaluate(textBox1.Text);
                //syntaxAnalyser.startInterpreter(textBox1.Text);
                String program = "opakuj 4 [dopredu 100 vpravo 90]";
                syntaxAnalyser.startInterpreter(program);
            }
        }

        internal void drawTurtle()
        {
            graphics.DrawLine(turtle.pen, (float)turtle.previousX, (float)turtle.previousY, (float)turtle.X, (float)turtle.Y);
        }
    }
}
