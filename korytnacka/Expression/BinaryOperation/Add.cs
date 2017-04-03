using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class Add : BinaryOperation
    {
        public Add(Expression left, Expression right) : base(left, right)
        {
        }

        public override double evaluate(GlobalParameters globalParameters)
        {
            return left.evaluate(globalParameters) + right.evaluate(globalParameters);
        }
    }
}
