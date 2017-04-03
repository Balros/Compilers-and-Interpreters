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
        public TurtleCommand(Expression param)
        {
            this.param = param;
        }
    }
}
