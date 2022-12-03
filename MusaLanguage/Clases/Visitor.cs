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
        public override string VisitComando([NotNull] musaParser.ComandoContext context)
        {
            return base.VisitComando(context);
        }

        public override string VisitCondicion([NotNull] musaParser.CondicionContext context)
        {
            return base.VisitCondicion(context);
        }

        public override string VisitFactorSolo([NotNull] musaParser.FactorSoloContext context)
        {
            return base.VisitFactorSolo(context);
        }

        public override string VisitIdentificador([NotNull] musaParser.IdentificadorContext context)
        {
            return base.VisitIdentificador(context);
        }

        public override string VisitImpresion([NotNull] musaParser.ImpresionContext context)
        {
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

        public override string VisitMulODiv([NotNull] musaParser.MulODivContext context)
        {
            return base.VisitMulODiv(context);
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

        public override string VisitSubexpresion([NotNull] musaParser.SubexpresionContext context)
        {
            return base.VisitSubexpresion(context);
        }

        public override string VisitSumORes([NotNull] musaParser.SumOResContext context)
        {
            return base.VisitSumORes(context);
        }

        public override string VisitTerminoSolo([NotNull] musaParser.TerminoSoloContext context)
        {
            return base.VisitTerminoSolo(context);
        }
    }
}
