﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLanguage
{
    abstract class Command
    {
        public abstract void execute(GlobalParameters globalParameters);
    }
}
