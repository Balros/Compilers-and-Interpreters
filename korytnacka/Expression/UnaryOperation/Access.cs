using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class Access : Expression
    {
        string Name;
        
        public Access(string Name, Dictionary<string, double> variables)
        {
            this.Name = Name;
        }
        public override double evaluate(GlobalParameters globalParameters)
        {
            return globalParameters.variables[Name];
        }
    }
}
