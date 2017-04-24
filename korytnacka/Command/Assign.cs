using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class Assign : Command
    {
        //string Name;
        Variable variable;
        Expression expr;

        //public Assign(string Name, Expression Expr)
        //{
        //    this.Name = Name;
        //    this.Expr = Expr;
        //}
        public Assign(Variable variable, Expression expr)
        {
            this.variable = variable;
            this.expr = expr;
        }

        public override void execute(GlobalParameters globalParameters)
        {
            variable.set(expr.evaluate(globalParameters),globalParameters);
        }

        //public override void execute(GlobalParameters globalParameters)
        //{
        //    if (globalParameters.variables.ContainsKey(Name))
        //        globalParameters.variables[Name] = Expr.evaluate(globalParameters);
        //    else
        //        globalParameters.variables.Add(Name, Expr.evaluate(globalParameters)); 
        //}
    }
}
