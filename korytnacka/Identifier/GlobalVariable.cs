using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class GlobalVariable : Variable
    {
        public GlobalVariable(string name, int address) : base(name, address)
        {
        }

        public override double get(GlobalParameters globalParameters)
        {
            return globalParameters.globalMemory[address];
        }

        public override void set(double value, GlobalParameters globalParameters)
        {
            globalParameters.globalMemory[address] = value;
        }
    }
}
