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

        public override string VisitComando([NotNull] musaParser.ComandoContext context)
        {
            return base.VisitComando(context);
        }

        public override string VisitStandardFor([NotNull] musaParser.StandardForContext context)
        {
            string variable = context.asignacion().GetText();
            string condicion = context.comp().GetText();
            string incremento = context.incremento().GetText();
            if (variables.Contains(variable))
            {
                fuente += $"for ({variable} {condicion}; {incremento})\n{{\n";
            }
            else
            {
                fuente += $"for (int {variable} {condicion}; {incremento})\n{{\n";
            }
            base.VisitStandardFor(context);
            fuente += "}" + "\n";
            return "Done";           
        }
        public override string VisitBooleanFor([NotNull] musaParser.BooleanForContext context)
        {
            string variable = context.asignacion().GetText();
            string condicion = context.BOOLEAN().GetText().ToLower();
            string incremento = context.incremento().GetText();
            if (variables.Contains(variable))
            {
                fuente += $"for ({variable} {condicion};{incremento})\n{{\n";
            }
            else
            {
                fuente += $"for (int {variable} {condicion};{incremento})\n{{\n";
            }
            base.VisitBooleanFor(context);
            fuente += "}" + "\n";
            return "Done";
        }


        public override string VisitCondicion([NotNull] musaParser.CondicionContext context)
        {
            string ifCondition = context.comp().GetText();
            fuente += $"if ({ifCondition})\n{{\n";
            base.VisitCondicion(context);
            if(!context.GetText().Contains("else"))
                fuente += "}\n";
            return "Done";
        }

        public override string VisitElse([NotNull] musaParser.ElseContext context)
        {
            fuente += $"}}\nelse\n{{\n";
            base.VisitElse(context);
            fuente += "}\n";
            return "Done";
        }

        public override string VisitImpresion([NotNull] musaParser.ImpresionContext context)
        {
            string writeLine = context.GetText();
            writeLine = writeLine.Replace("monta", "Console.WriteLine");
            fuente += writeLine + "\n";
            return base.VisitImpresion(context);
        }

        public override string VisitInt([NotNull] musaParser.IntContext context)
        {
            string id = context.ID().GetText();
            string expresion = context.expresion().GetText();
            if (variables.Contains(context.ID().GetText()))
                fuente += $"{id} = {expresion};" + "\n";
            else
            {
                variables.Add(context.ID().GetText());
                fuente += $"int {id} = {expresion};" + "\n";
            }
            return base.VisitInt(context);
        }

        public override string VisitConditionWhile([NotNull] musaParser.ConditionWhileContext context)
        {
            string condicion = context.comp().GetText();
            fuente += $"while({condicion})\n{{\n";
            base.VisitConditionWhile(context);
            fuente += "}\n";
            return "Done";
        }
        public override string VisitBooleanWhile([NotNull] musaParser.BooleanWhileContext context)
        {
            string condicion = context.BOOLEAN().GetText().ToLower();
            fuente += $"while({condicion})\n{{\n";
            VisitBooleanWhile(context);
            fuente += "}\n";
            return "Done";
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
            string id = context.ID().GetText();
            string sentencia = context.SENT().GetText();
            if (variables.Contains(context.ID().GetText()))
                fuente += $"{id} = {sentencia};" + "\n";
            else
            {
                variables.Add(context.ID().GetText());
                fuente += $"string {id} = {sentencia};" + "\n";
            }
            return base.VisitString(context);
        }

    }
}
