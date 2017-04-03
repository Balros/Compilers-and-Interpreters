using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class Repeat : Command
    {
        Expression repetition;
        Commands commands;
        public Repeat(Expression repetition, Commands commands)
        {
            this.repetition = repetition;
            this.commands = commands;
        }

        public override void execute(GlobalParameters globalParameters)
        {
            double repetitionNumber = repetition.evaluate(globalParameters);
            for (int i = 0; i < repetitionNumber; i++)
            {
                commands.execute(globalParameters);
            }
        }
    }
}
