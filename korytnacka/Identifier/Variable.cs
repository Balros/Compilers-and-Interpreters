using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    abstract class Variable : Identifier
    {
        protected int address;
        public Variable(string name, int address)
        {
            this.name = name;
            this.address = address;
        }
        public abstract double get(GlobalParameters globalParameters);
        public abstract void set(double value, GlobalParameters globalParameters);
    }
}
