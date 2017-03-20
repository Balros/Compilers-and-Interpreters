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
        public double X { get; set; }
        public double Y { get; set; }
        public double previousX { get; set; }
        public double previousY { get; set; }
        double angle { get; set; }
        public Pen pen { get; set; }
        Graphics graphics { get; set; }
        public Turtle(double x, double y, Graphics graphics)
        {
            this.X = x;
            this.Y = y;
            this.graphics = graphics;
            angle = 0;
            pen = new Pen(Color.Black);
        }

        public void forward(double steps)
        {
            previousX = X;
            previousY = Y;

            double dx = Convert.ToDouble(Math.Sin(angle * Math.PI / 180)) * steps;
            double dy = -Convert.ToDouble(Math.Cos(angle * Math.PI / 180)) * steps;

            X += dx;
            Y += dy;
            graphics.DrawLine(pen, (float)previousX, (float)previousY, (float)X, (float)Y);
        }    
        public void left(double inputAngle)
        {
            angle += inputAngle;
        }
        public void right(double inputAngle)
        {
            angle -= inputAngle;
        }
    }
}
