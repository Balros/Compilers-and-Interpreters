using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class Braces : UnaryOperation
    {
        public Braces(Expression subExpressions) : base(subExpressions)
        {
        }

        public override double evaluate()
        {
            return subExpression.evaluate();
        }
    }
}
