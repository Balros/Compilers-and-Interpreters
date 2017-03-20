using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class Commands : Command
    {
        List<Command> items;

        public Commands(List<Command> items)
        {
            this.items = items;
        }
        public override void execute()
        {
            foreach (Command item in items)
            {
                item.execute();
            }
        }
        public void add(Command command)
        {
            items.Add(command);
        }

    }
}
