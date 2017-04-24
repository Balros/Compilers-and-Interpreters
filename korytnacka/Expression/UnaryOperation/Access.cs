using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class Access : Expression
    {
        //string Name;
        Variable variable;
        
        //public Access(string Name, Dictionary<string, double> variables)
        //{
        //    //this.Name = Name;
        //}
        public Access(Variable variable)
        {
            this.variable = variable;
        }
        public override double evaluate(GlobalParameters globalParameters)
        {
            return variable.get(globalParameters);
        }
        //public override double evaluate(GlobalParameters globalParameters)
        //{
        //    //return globalParameters.variables[Name];
        //}
    }
}
