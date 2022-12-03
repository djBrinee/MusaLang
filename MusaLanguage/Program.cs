using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusaLanguage.Clases;
using System.IO;
using Antlr4.Runtime.Misc;

namespace MusaLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            Visitor visitor = new Visitor();
            ImmediateErrorListener errListener = ImmediateErrorListener.Instance;

            var input = CharStreams.fromPath("input.musa");
            var lexer = new musaLexer(input);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new musaParser(tokenStream);
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errListener);
            string fuente = "";
            bool ok = false;
            do
            {
                try
                {
                    var tree = parser.musa(); //Ejecucion de regla inicial
                    fuente = visitor.Visit(tree);
                    File.WriteAllText("traduccion.cs", fuente);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Traduccion generada, presione ENTER para cerrar la consola...");
                    Console.ResetColor();
                    Console.ReadLine();
                    ok = true;
                }
                catch (ParseCanceledException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                    Console.WriteLine("Debe seguir las reglas del lenguaje musa! Presione ENTER para cerrar la consola y arregle sus errores");
                    fuente = e.Message;
                    File.WriteAllText("traduccion.cs", fuente);
                    Console.ReadLine();
                    break;
                }
            } while (!ok);
            
            
        }
    }

    internal class ImmediateErrorListener: BaseErrorListener
    {
        
            static Lazy<ImmediateErrorListener> instance = new Lazy<ImmediateErrorListener>(() => new ImmediateErrorListener());

            public static ImmediateErrorListener Instance
            {
                get { return instance.Value; }
            }

            public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
            {
                throw new Antlr4.Runtime.Misc.ParseCanceledException($"Error en la línea {line} columna {charPositionInLine}: {msg}");
            }
        
    }

}
