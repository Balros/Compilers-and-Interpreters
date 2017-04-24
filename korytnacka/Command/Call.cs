using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class Call : Command
    {
        Subroutine sub;
        List<Expression> args;

        public Call(Subroutine sub, List<Expression> args)
        {
            this.sub = sub;
            this.args = args;
        }
        public override void execute(GlobalParameters globalParameters)
        {
            List<double> mem = new List<double>();
            List<double> old;
            for (int i = 0; i < sub.subroutineNamespace.Count; i++)
            {
                mem.Add(args[i].evaluate(globalParameters));
            }
            old = globalParameters.localMemory;
            globalParameters.localMemory = mem;
            sub.body.execute(globalParameters);
            globalParameters.localMemory = old;
        }
    }
}
