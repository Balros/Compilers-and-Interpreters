using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class While : Command
    {
        Expression Test;
        Commands Body;
        public While(Expression Test, Commands Body)
        {
            this.Test = Test;
            this.Body = Body;
        }
        public override void execute(GlobalParameters globalParameters)
        {
            while (Test.evaluate(globalParameters) != 0)
            {
                Body.execute(globalParameters);
            }
        }
    }
}
