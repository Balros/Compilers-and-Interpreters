using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class Sqrt : BinaryOperation
    {
        public Sqrt(Expression left, Expression right) : base(left, right)
        {
        }

        public override double evaluate(GlobalParameters globalParameters)
        {
            return Math.Pow(left.evaluate(globalParameters), right.evaluate(globalParameters));
        }
    }
}
