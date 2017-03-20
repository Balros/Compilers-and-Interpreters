﻿using System;
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
            //interpreter();
            Commands program = compile();
            program.execute();

        }
        public Commands compile()
        {
            Commands result = new Commands(new List<Command>());

            while (true)
            {
                if (lexi.token == "dopredu")
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
                else
                    return result;
            }
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
        public Const number() {
            Const constant = new Const(int.Parse(lexi.token));
            lexi.scan();
            return constant;
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
        public Expression braces()
        {
            if (lexi.token != "(")
                return number();
            else
            {
                lexi.scan();
                Expression result = addsub();
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
        public Expression minus()
        {
            if (lexi.token != "-")
                return braces();
            else
            {
                lexi.scan();
                Expression result = new Minus(braces());
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

    }
}