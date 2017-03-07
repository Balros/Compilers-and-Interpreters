using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    class LexicalAnalyser
    {
        string lineOfCode;
        public int index { get; set; }
        char look;
        public string token { get; set; }
        public int position { get; set; }
        public LexicalAnalyser()
        {
            
        }
        public void insertText(string inputString)
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
            while (look == ' ')
            {
                next();
            }
            token = "";
            position = index - 1;
            if (Char.IsLetter(look))
            {
                while (Char.IsLetter(look))
                {
                    token += look;
                    next();
                }
            }
            else if (Char.IsDigit(look))
            {
                while (Char.IsDigit(look))
                {
                    token += look;
                    next();
                }
            }
            else if (look == '<')
            {
                token += look;
                next();
                if (look == '=')
                {
                    token += look;
                    next();
                }
            }
            else if (look == '>')
            {
                token += look;
                next();
                if (look == '=')
                {
                    token += look;
                    next();
                }
            }

            else if(look != '\0')
            {
                token = look.ToString();
                next();
            }
        }

    }
}
