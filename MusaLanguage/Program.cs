﻿using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusaLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = CharStreams.fromPath("input.txt");
            var lexer = new musaLexer(input);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new musaParser(tokenStream);
            var tree = parser.musa(); //Ejecucion de regla inicial

        }
    }
}
