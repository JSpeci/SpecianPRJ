using SpecianPRJ.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianPRJ.Cli.CliRender
{
    public static class SchemeRender
    {
        public static string RenderScheme(Scheme scheme)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Scheme rendering {scheme.Name}");


            return sb.ToString();
        }

    }
}
