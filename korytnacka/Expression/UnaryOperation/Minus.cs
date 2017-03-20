using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class Minus : UnaryOperation
    {
        public Minus(Expression subExpression) : base(subExpression)
        {
        }

        public override double evaluate()
        {
            return -subExpression.evaluate();
        }
    }
}
