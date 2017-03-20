using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class Const : Expression
    {
        double value;
        public Const(double value)
        {
            this.value = value;
        }
        public override double evaluate()
        {
            return value;
        }
        
    }
}
