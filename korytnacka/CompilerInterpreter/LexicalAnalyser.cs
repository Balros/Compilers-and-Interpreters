using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class LexicalAnalyser
    {
        public const int NOTHING = 0;
        public const int NUMBER = 1;
        public const int WORD = 2;
        public const int SYMBOL = 3;
        string lineOfCode;
        public int index { get; set; }
        char look;
        public string token { get; set; }
        public int position { get; set; }
        public int kind { get; set; }
        public LexicalAnalyser()
        {
            
        }
        public void initialize(string inputString)
        {
            lineOfCode = inputString;
            index = 0;
            next();
        }
        public void next()
        {
            if (index < lineOfCode.Length)
            {
                look = lineOfCode[index];
                index++;
            }
            else
            {
                look = '\0';
            }
        }
        public void scan()
        {
            token = "";
            kind = NOTHING;
            while (kind == NOTHING && look != '\0')
            {
                if (look == ' ' ||
                    look == '\r' ||
                    look == '\n')
                {
                    next();
                }
                //position = index - 1;

                else if (Char.IsDigit(look))
                {
                    while (Char.IsDigit(look))
                    {
                        token += look;
                        next();
                    }
                    if (look == '.')
                    {
                        while (Char.IsDigit(look))
                        {
                            token += look;
                            next();
                        }
                    }
                    kind = NUMBER;
                }
                else if (Char.IsLetter(look))
                {
                    while (Char.IsLetter(look))
                    {
                        token += look;
                        next();
                    }
                    kind = WORD;
                }
                else if (look == '/')
                {
                    next();
                    if (look == '/')
                    {
                        while (look != '\0'||
                               look != '\r')
                        {
                            next();
                            if (look == '\n')
                            {
                                next(); // endline is actually \r\n
                            }
                        }
                    }
                    else
                    {
                        token = "/";
                        kind = SYMBOL;
                    }
                }
                else if (look == '<'||
                         look == '>')
                {
                    token = look.ToString();
                    next();
                    if (look == '=')
                    {
                        token += look;
                        next();
                    }
                    kind = SYMBOL;
                }
                else
                {
                    token = look.ToString();
                    next();
                    kind = SYMBOL;
                }

            }
        }

    }
}
