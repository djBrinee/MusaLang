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
        List<string> variables = new List<string>();
        List<char> arrows = new List<char>()
        {
            '<',
            '-'
        };

        char[] separator = { '<', '-' };

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
            string writeLine = context.GetText();
            writeLine = writeLine.Replace("monta", "Console.WriteLine");
            fuente += writeLine;
            return base.VisitImpresion(context);
        }

        public override string VisitInt([NotNull] musaParser.IntContext context)
        {
            var tmp = context.GetText().Replace("<-", "=");
            var asignacion = tmp.Split(' ');

            if (variables.Contains(asignacion[0]))
                fuente += string.Join(" ", asignacion);
            else
            {
                variables.Add(asignacion[0]);
                asignacion[0] = $"int {asignacion[0]}";
                fuente += string.Join(" ", asignacion);
            }
            
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
            base.VisitMusa(context);
            return fuente;
        }

        public override string VisitNumero([NotNull] musaParser.NumeroContext context)
        {
            return base.VisitNumero(context);
        }

        public override string VisitString([NotNull] musaParser.StringContext context)
        {
            var tmp = context.GetText().Replace("<-", "=");
            var asignacion = tmp.Split(' ');

            if (variables.Contains(asignacion[0]))
                fuente += string.Join(" ", asignacion);
            else
            {
                variables.Add(asignacion[0]);
                asignacion[0] = $"string {asignacion[0]}";
                fuente += string.Join(" ", asignacion);
            }

            return base.VisitString(context);
        }

    }
}
