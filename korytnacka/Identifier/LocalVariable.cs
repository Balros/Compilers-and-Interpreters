using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class LocalVariable : Variable
    {
        public LocalVariable(string name, int address) : base(name, address)
        {
        }

        public override double get(GlobalParameters globalParameters)
        {
            return globalParameters.localMemory[address];
        }

        public override void set(double value, GlobalParameters globalParameters)
        {
            globalParameters.localMemory[address] = value;
        }
    }
}
