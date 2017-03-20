﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class Div : BinaryOperation
    {
        public Div(Expression left, Expression right) : base(left, right)
        {
        }

        public override double evaluate()
        {
            return left.evaluate() / right.evaluate();
        }
    }
}
