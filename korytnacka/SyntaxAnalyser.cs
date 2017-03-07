using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class SyntaxAnalyser
    {
        LexicalAnalyser lexi;
        Turtle turtle;
        Form1 form;
        public SyntaxAnalyser(Turtle turtle, Form1 form)
        {
            lexi = new LexicalAnalyser();
            this.turtle = turtle;
            this.form = form;
        }
        public void startInterpreter(string commandString)
        {
            lexi.insertText(commandString);
            lexi.scan();
            interpreter();
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
        public int number() {
            int num = int.MinValue;
            num = int.Parse(lexi.token);
            lexi.scan();
            return num;
        }

        public int addsub()
        {
            int result = 0;
            result = muldiv();
            while (lexi.token == "+" ||
                    lexi.token == "-")
            {
                if (lexi.token == "+")
                {
                    lexi.scan();
                    result += muldiv();
                }
                else if(lexi.token == "-")
                {
                    lexi.scan();
                    result -= muldiv();
                }
            }
            return result;
        }
        public int muldiv()
        {
            int result = 0;
            result = sqrt();
            while (lexi.token == "*" ||
                    lexi.token == "/")
            {
                if (lexi.token == "*")
                {
                    lexi.scan();
                    result *= sqrt();
                }
                else if (lexi.token == "/")
                {
                    lexi.scan();
                    result /= sqrt();
                }
            }
            return result;
        }
        public int braces()
        {
            if (lexi.token != "(")
                return number();
            else
            {
                lexi.scan();
                int result = addsub();
                if (lexi.token == ")")
                    lexi.scan();
                return result;
            }
        }
        public string evaluate(string inputText)
        {
            lexi.insertText(inputText);
            lexi.scan();
            return compare().ToString();
        }
        public int minus()
        {
            if (lexi.token != "-")
                return braces();
            else
            {
                lexi.scan();
                return -braces();
            }

        }

        public int sqrt()
        {
            int result = 0;
            result = minus();
            while (lexi.token == "^")
            {
                lexi.scan();
                result = (int) Math.Pow(result, minus());
            }
            return result;
        }
        public bool compare()
        {
            int result = 0;
            result = addsub();
            bool returnBool = false;
            while (lexi.token == "<" ||
                    lexi.token == ">" ||
                    lexi.token == "<=" ||
                    lexi.token == ">=")
            {
                if (lexi.token == "<")
                {
                    lexi.scan();
                    if (result < addsub())
                        return true;
                    else
                        return false;
                }
                else if (lexi.token == ">")
                {
                    lexi.scan();
                    if (result > addsub())
                        return true;
                    else
                        return false;
                }
                else if (lexi.token == "<=")
                {
                    lexi.scan();
                    if (result <= addsub())
                        return true;
                    else
                        return false;
                }
                else if (lexi.token == ">=")
                {
                    lexi.scan();
                    if (result >= addsub())
                        return true;
                    else
                        return false;
                }
            }
            return returnBool;
        }

    }
}
