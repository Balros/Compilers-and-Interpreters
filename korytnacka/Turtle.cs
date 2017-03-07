using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class Turtle
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float previousX { get; set; }
        public float previousY { get; set; }
        int angle { get; set; }
        public Pen pen { get; set; }
        public Turtle(float x, float y)
        {
            this.X = x;
            this.Y = y;
            angle = 0;
            pen = new Pen(Color.Black);
        }

        public void forward(int steps)
        {
            previousX = X;
            previousY = Y;

            float dx = Convert.ToSingle(Math.Sin(angle * Math.PI / 180)) * steps;
            float dy = -Convert.ToSingle(Math.Cos(angle * Math.PI / 180)) * steps;

            X += dx;
            Y += dy;
        }    
        public void left(int inputAngle)
        {
            angle += inputAngle;
        }
        public void right(int inputAngle)
        {
            angle -= inputAngle;
        }
    }
}
