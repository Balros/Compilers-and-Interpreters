using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class Less : BinaryOperation
    {
        public Less(Expression left, Expression right) : base(left, right)
        {
        }

        public override double evaluate()
        {
            if (left.evaluate() < right.evaluate())
                return 1;
            else
                return 0;
            //TODO return true/false, not 0/1
        }
    }
}
