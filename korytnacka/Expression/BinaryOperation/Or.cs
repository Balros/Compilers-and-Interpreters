using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class Or : BinaryOperation
    {
        public Or(Expression left, Expression right) : base(left, right)
        {
        }

        public override double evaluate(GlobalParameters globalParameters)
        {
            if (left.evaluate(globalParameters) == 1 ||
                right.evaluate(globalParameters) == 1)
                return 1;
            else
                return 0;
        }
    }
}
