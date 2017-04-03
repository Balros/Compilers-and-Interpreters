using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurtleLanguage
{
    class SyntaxAnalyser
    {
        LexicalAnalyser lexi;
        Turtle turtle;
        TextBox textBox;
        Form1 form;
        Dictionary<string, double> variables;
        GlobalParameters globalParameters;

        public SyntaxAnalyser(Turtle turtle, Form1 form, TextBox textBox)
        {
            lexi = new LexicalAnalyser();
            this.turtle = turtle;
            this.form = form;
            this.textBox = textBox;
            globalParameters = new GlobalParameters(turtle, textBox);
            variables = new Dictionary<string, double>();
        }
        public void startInterpreter(string commandString)
        {
            lexi.initialize(commandString);
            lexi.scan();
            //interpreter();
            Commands program = compile();
            program.execute(globalParameters);

        }
        public Commands compile()
        {
            Commands result = new Commands(new List<Command>());

            while (lexi.kind == LexicalAnalyser.WORD)
            {
                if (lexi.token == "vypis")
                {
                    lexi.scan();
                    result.add(new Print(expr(), textBox)); //WTF
                }
                else if (lexi.token == "dopredu")
                {
                    lexi.scan();
                    result.add(new Forward(addsub(), turtle));
                }
                else if (lexi.token == "vlavo")
                {
                    lexi.scan();
                    result.add(new Left(addsub(), turtle));
                }
                else if (lexi.token == "vpravo")
                {
                    lexi.scan();
                    result.add(new Right(addsub(), turtle));
                }
                else if (lexi.token == "opakuj")
                {
                    lexi.scan();
                    Expression count = addsub();

                    if (lexi.token == "[")
                    {
                        lexi.scan();
                        Commands body = compile();
                        if (lexi.token == "]")
                            lexi.scan();
                        result.add(new Repeat(count, body));
                    }
                }
                else if (lexi.token == "kym")
                {
                    lexi.scan();
                    Expression test = expr();

                    if (lexi.token != "[")
                    {
                        MessageBox.Show("Chyba lava zatvorka \"[\" pre prikaz kym.");
                    }
                    else
                    {
                        lexi.scan();
                        result.add(new While(test, compile()));
                        if (lexi.token != "]")
                            MessageBox.Show("Chyba prava zatvorka \"]\" pre prikaz kym.");
                        else
                            lexi.scan();
                    }
                }
                else
                {
                    string name = lexi.token;
                    lexi.scan();
                    if (lexi.token != "=")
                    {
                        MessageBox.Show("Neznamy prikaz.");

                    }
                    lexi.scan();
                    result.add(new Assign(name, expr())); //WTF
                    variables[name] = 0;
                }
            }
            return result;
        }
        public void interpreter()
        {
            while (true)
            {
                if (lexi.token == "dopredu")
                {
                    lexi.scan();
                    int numberInput = 0;
                    if (int.TryParse(lexi.token, out numberInput))
                    {
                        turtle.forward(numberInput);
                        form.drawTurtle();
                    }
                    else
                    {
                        break;
                    }
                    lexi.scan();
                }
                else if (lexi.token == "vlavo")
                {
                    lexi.scan();
                    int numberInput = 0;
                    if (int.TryParse(lexi.token, out numberInput))
                    {
                        turtle.left(numberInput);
                    }
                    else
                    {
                        break;
                    }
                    lexi.scan();
                }
                else if (lexi.token == "vpravo")
                {
                    lexi.scan();
                    int numberInput = 0;
                    if (int.TryParse(lexi.token, out numberInput))
                    {
                        turtle.right(numberInput);
                    }
                    else
                    {
                        break;
                    }
                    lexi.scan();
                }
                else if (lexi.token == "opakuj")
                {
                    lexi.scan();
                    int count = 0;
                    if (int.TryParse(lexi.token, out count))
                    {
                        lexi.scan();
                        if (lexi.token == "[")
                        {
                            lexi.scan();
                            int start = lexi.position;
                            for (int i = 0; i < count; i++)
                            {
                                lexi.index = start;
                                lexi.next();
                                lexi.scan();
                                interpreter();
                            }
                        }
                        if (lexi.token == "]")
                        {
                            lexi.scan();
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        public Expression operand()
        {
            Expression result = null;
            if (lexi.kind == LexicalAnalyser.NUMBER)
            {
                result = new Const(int.Parse(lexi.token));
                lexi.scan();
            }
            else if (lexi.kind == LexicalAnalyser.WORD)
            {
                if (!variables.ContainsKey(lexi.token))
                {
                    MessageBox.Show("Unassigned variable: " + lexi.token);
                }
                result = new Access(lexi.token, variables);
                lexi.scan();
            }
            else if (lexi.token == "(") {
                lexi.scan();
                result = expr();
                if (lexi.token != ")")
                {
                    MessageBox.Show("Missing \")\"");
                    lexi.scan();
                }
            }
            else
            {
                MessageBox.Show("Number or variable name");
            }
            return result;
        }
        public Expression minus()
        {
            if (lexi.token != "-")
                return operand();
            else
            {
                lexi.scan();
                Expression result = new Minus(operand());
                return result;
            }
        }
        public Expression sqrt()
        {
            Expression result = minus();
            while (lexi.token == "^")
            {
                lexi.scan();
                result = new Sqrt(result, minus());
            }
            return result;
        }
        public Expression muldiv()
        {
            Expression result = sqrt();
            while (lexi.token == "*" ||
                    lexi.token == "/")
            {
                if (lexi.token == "*")
                {
                    lexi.scan();
                    result = new Mul(result, sqrt());
                }
                else if (lexi.token == "/")
                {
                    lexi.scan();
                    result = new Div(result, sqrt());
                }
            }
            return result;
        }
        public Expression addsub()
        {
            Expression result = muldiv();
            while (lexi.token == "+" ||
                    lexi.token == "-")
            {
                if (lexi.token == "+")
                {
                    lexi.scan();
                    result = new Add(result, muldiv());
                }
                else if(lexi.token == "-")
                {
                    lexi.scan();
                    result = new Sub(result, muldiv());
                }
            }
            return result;
        }
        public Expression compare()
        {
            Expression result = addsub();
            
            while (lexi.token == "<" ||
                    lexi.token == ">" ||
                    lexi.token == "<=" ||
                    lexi.token == ">=")
            {
                if (lexi.token == "<")
                {
                    lexi.scan();
                    return new Less(result, addsub());
                }
                else if (lexi.token == ">")
                {
                    lexi.scan();
                    return new Greater(result, addsub());
                }
                else if (lexi.token == "<=")
                {
                    lexi.scan();
                    return new LessEquals(result, addsub());
                }
                else if (lexi.token == ">=")
                {
                    lexi.scan();
                    return new GreaterEquals(result, addsub());
                }
            }
            return result;
        }
        public string evaluate(string inputText)
        {
            lexi.initialize(inputText);
            lexi.scan();
            return compare().ToString();
        }
        public Expression expr()
        {
            Expression result = compare();
            while (lexi.token == "or")
            {
                lexi.scan();
                result = new Or(result, compare());
            }
            return result;
        }
    }
}
