using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusaLanguage.Clases
{
    class Visitor : musaBaseVisitor<string>
    {
        string fuente = "";
        public override string VisitComando([NotNull] musaParser.ComandoContext context)
        {
            return base.VisitComando(context);
        }

        public override string VisitCondicion([NotNull] musaParser.CondicionContext context)
        {
            return base.VisitCondicion(context);
        }

        public override string VisitImpresion([NotNull] musaParser.ImpresionContext context)
        {
            string writeLine = context.GetText(); // monta(string);
            writeLine = writeLine.Replace("monta", "Console.WriteLine");
            Console.WriteLine(writeLine);
            return base.VisitImpresion(context);
        }

        public override string VisitInt([NotNull] musaParser.IntContext context)
        {
            return base.VisitInt(context);
        }

        public override string VisitLoopFor([NotNull] musaParser.LoopForContext context)
        {
            return base.VisitLoopFor(context);
        }

        public override string VisitLoopWhile([NotNull] musaParser.LoopWhileContext context)
        {
            return base.VisitLoopWhile(context);
        }

        public override string VisitMusa([NotNull] musaParser.MusaContext context)
        {
            return base.VisitMusa(context);
        }

        public override string VisitNumero([NotNull] musaParser.NumeroContext context)
        {
            return base.VisitNumero(context);
        }

        public override string VisitString([NotNull] musaParser.StringContext context)
        {
            return base.VisitString(context);
        }

    }
}
