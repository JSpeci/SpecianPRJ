using SpecianPRJ.Blocks;
using SpecianPRJ.Scheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianPRJ.Cli.CliRender
{
    public static class SchemeRenderer
    {
        public static string RenderScheme(SchemeHolder scheme)
        {
            StringBuilder sb = new StringBuilder();

            foreach(var block in scheme.Blocks)
            {
                sb.Append(block.Name + "(");
                foreach(var i in block.ParalelItems)
                {
                    sb.Append(i.Name);
                }
                sb.Append(")");
            }

            return sb.ToString();
        }
    }
}
