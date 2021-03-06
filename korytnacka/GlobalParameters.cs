﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class GlobalParameters
    {
        public Turtle turtle { get; set; }
        public Dictionary<string, double> variables { get; set; }
        public System.Windows.Forms.TextBox textBox { get; set; }
        public List<double> globalMemory { get; set; }
        public List<double> localMemory { get; set; }
        public GlobalParameters(Turtle turtle, System.Windows.Forms.TextBox textBox)
        {
            this.turtle = turtle;
            this.variables = new Dictionary<string, double> { };
            this.textBox = textBox;
            this.globalMemory = new List<double> { };
            this.localMemory = new List<double> { };
        }
    }
}
