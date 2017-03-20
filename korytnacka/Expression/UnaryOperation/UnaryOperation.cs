using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    abstract class UnaryOperation :  Expression
    {
        protected Expression subExpression;
        public UnaryOperation(Expression subExpression)
        {
            this.subExpression = subExpression;
        }
    }
}
