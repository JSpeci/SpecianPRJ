using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianPRJ.Scheme
{
    /// <summary>
    /// Core object represents RBD Diagram with values
    /// </summary>
    public class RBDDiagram
    {
        public SchemeCalculator SchemeCalculator { get; internal set; }
        public SchemeHolder SchemeHolder { get; internal set; }

        public RBDDiagram()
        {
            SchemeHolder = new SchemeHolder();
            SchemeCalculator = new SchemeCalculator();
        }

        public override string ToString()
        {
            return RenderScheme(SchemeHolder);
        }

        public static string RenderScheme(SchemeHolder scheme)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var block in scheme.Blocks)
            {
                sb.Append(block.Name + "(");
                foreach (var i in block.ParalelItems)
                {
                    sb.AppendLine();
                    sb.Append("   ");
                    sb.Append(i.Name + "( ");
                    sb.Append(i.Distribution.Lambda);
                    sb.Append(" ) ");
                }
                sb.Append(") ");
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
