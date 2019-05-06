using SpecianPRJ.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianPRJ.Cli.CliRender
{
    public static class SchemeRenderer
    {
        public static string RenderScheme(Scheme scheme)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Scheme rendering {scheme.Name}");

            sb.AppendLine(scheme.InputBlock.Name);
            sb.AppendLine(scheme.ContentBlock.Name);

            int offset = 0;
            foreach(var s in scheme.ContentBlock.ParalelBlocks)
            {
                offset = 1;
                Console.WriteLine("Offset: " + offset);
            }

            sb.AppendLine(scheme.OutputBlock.Name);

            return sb.ToString();
        }

    }
}
