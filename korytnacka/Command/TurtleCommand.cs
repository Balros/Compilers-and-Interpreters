using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    abstract class TurtleCommand : Command
    {
        protected Expression param;
        protected Turtle turtle;
        public TurtleCommand(Expression param, Turtle turtle)
        {
            this.param = param;
            this.turtle = turtle;
        }
    }
}
