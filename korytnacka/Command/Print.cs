using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurtleLanguage
{
    class Print : Command
    {
        Expression Expr;
        TextBox textBox;
        public Print(Expression Expr, TextBox textBox)
        {
            this.Expr = Expr;
            this.textBox = textBox;
        }
        public override void execute(GlobalParameters globalParameters)
        {
            globalParameters.textBox.AppendText(Expr.evaluate(globalParameters).ToString() + Environment.NewLine);
        }
    }
}
