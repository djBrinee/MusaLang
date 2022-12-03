using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusaLanguage.Clases;
using System.IO;

namespace MusaLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            Visitor visitor = new Visitor();
            var input = CharStreams.fromPath("input.musa");
            var lexer = new musaLexer(input);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new musaParser(tokenStream);
            var tree = parser.musa(); //Ejecucion de regla inicial
            string fuente = visitor.Visit(tree);
            File.WriteAllText("traduccion.cs", fuente);
            Console.WriteLine("Traduccion generada, presione ENTER para cerrar la consola...");
            Console.ReadLine();
        }
    }
}
