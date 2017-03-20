using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class Forward : TurtleCommand
    {
        public Forward(Expression param, Turtle turtle) : base(param, turtle)
        {
        }

        public override void execute()
        {
            turtle.forward(param.evaluate());
        }
    }
}
