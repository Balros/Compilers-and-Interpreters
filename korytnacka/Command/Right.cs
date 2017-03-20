using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class Right : TurtleCommand
    {
        public Right(Expression param, Turtle turtle) : base(param, turtle)
        {
        }

        public override void execute()
        {
            turtle.right(param.evaluate());
        }
    }
}
