using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class Mul : BinaryOperation
    {
        public Mul(Expression left, Expression right) : base(left, right)
        {
        }

        public override double evaluate()
        {
            return left.evaluate() * right.evaluate();
        }
    }
}
