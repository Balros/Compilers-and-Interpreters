using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class Subroutine : Identifier
    {
        public Dictionary<string, LocalVariable> subroutineNamespace { get; set; }
        public Commands body { get; set; }
        public Subroutine(string name)
        {
            this.name = name;
            subroutineNamespace = new Dictionary<string, LocalVariable>();
        }
    }
}
