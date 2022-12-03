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

        public override string VisitCondicion([NotNull] musaParser.CondicionContext context)
        {
            string ifVariable = context.GetText().Split(' ')[0];
            string ifCondition = context.GetText().Split(' ')[1];

            fuente += $"{ifVariable} ({ifCondition})\n{{\n";
            base.VisitCondicion(context);
            if(!context.GetText().Contains("else"))
                fuente += "}\n";
            return "Done";
        }

        public override string VisitElse([NotNull] musaParser.ElseContext context)
        {
            string elseVariable = context.GetText().Split(' ')[0];

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
            var tmp = context.GetText().Replace("<-", "=");
            var asignacion = tmp.Split(' ');

            if (variables.Contains(asignacion[0]))
                fuente += string.Join(" ", asignacion) + "\n";
            else
            {
                variables.Add(asignacion[0]);
                asignacion[0] = $"int {asignacion[0]}";
                fuente += string.Join(" ", asignacion) + "\n";
            }

            return base.VisitInt(context);
        }

        public override string VisitLoopFor([NotNull] musaParser.LoopForContext context)
        {
            string forVariableRaw = context.GetText().Split(';')[0]; //[for(variable,condicion,incremento)[comando]], tomo for(variable
            string forVariable = forVariableRaw.Split('(')[1]; //[for,variable], tomo la variable
            string variable = forVariable.Split('<')[0]; //[identificador, -valor], tomo el identificador
            string condicion = context.GetText().Split(';')[1];
            string incremento = context.GetText().Split(';')[2].Split(')')[0];
            if (variables.Contains(variable))
            {
                fuente += $"for ({variable}; {condicion};{incremento})\n{{\n";
            }
            else
            {
                fuente += $"for (int {variable}; {condicion};{incremento})\n{{\n";
            }
            base.VisitLoopFor(context);
            fuente += "}" + "\n";
            return "Done";
        }

        public override string VisitLoopWhile([NotNull] musaParser.LoopWhileContext context)
        {
            string whileCondicion = context.GetText().Split('(')[1]; //[while(condicion)[comando]], tomo condicion)[comando]
            string condicion = whileCondicion.Split(')')[0]; //[condicion,[comando]], tomo la condicion
            fuente += $"while({condicion})\n{{\n";            
            base.VisitLoopWhile(context);
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
            var tmp = context.GetText().Replace("<-", "=");
            var asignacion = tmp.Split(' ');

            if (variables.Contains(asignacion[0]))
                fuente += string.Join(" ", asignacion) + "\n";
            else
            {
                variables.Add(asignacion[0]);
                asignacion[0] = $"string {asignacion[0]}";
                fuente += string.Join(" ", asignacion) + "\n";
            }

            return base.VisitString(context);
        }

    }
}
