using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    abstract class BinaryOperation : Expression
    {
        protected Expression left;
        protected Expression right;
        public BinaryOperation(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

    }
}
