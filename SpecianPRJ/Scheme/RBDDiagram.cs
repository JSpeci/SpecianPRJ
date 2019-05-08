using SpecianPRJ.Distributions;
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
        private SchemeCalculator SchemeCalculator;
        public SchemeHolder SchemeHolder { get; internal set; }
        public int ItemCounter { get; set; } = 0;

        public RBDDiagram()
        {
            SchemeHolder = new SchemeHolder();
            SchemeCalculator = new SchemeCalculator();
        }

        public double CalculateItself(double time)
        {
            return SchemeCalculator.CalculateScheme(this.SchemeHolder, time);
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

        public void setUpTestScheme()
        {
            SchemeHolder.Blocks.Add(new Blocks.Block() { Name = "Block1" });
            SchemeHolder.Blocks.Add(new Blocks.Block() { Name = "Block2" });
            SchemeHolder.Blocks.Add(new Blocks.Block() { Name = "Block3" });
            SchemeHolder.Blocks.Add(new Blocks.Block() { Name = "Block4" });
            SchemeHolder.Blocks.Add(new Blocks.Block() { Name = "Block5" });

            var block = SchemeHolder.Blocks.ElementAt(0);
            block.ParalelItems.Add(new Blocks.Item("name", new ExponencialDistribution(0.75D)) { NumberId = 0 });
            block.ParalelItems.Add(new Blocks.Item("name", new ExponencialDistribution(0.75D)) { NumberId = 1 });
            block.ParalelItems.Add(new Blocks.Item("name", new ExponencialDistribution(0.75D)) { NumberId = 2 });
            block.ParalelItems.Add(new Blocks.Item("name", new ExponencialDistribution(0.75D)) { NumberId = 3 });

            block = SchemeHolder.Blocks.ElementAt(1);
            block.ParalelItems.Add(new Blocks.Item("name", new ExponencialDistribution(0.75D)) { NumberId = 4 });
            block.ParalelItems.Add(new Blocks.Item("name", new ExponencialDistribution(0.75D)) { NumberId = 5 });

            block = SchemeHolder.Blocks.ElementAt(2);
            block.ParalelItems.Add(new Blocks.Item("name", new ExponencialDistribution(0.75D)) { NumberId = 6 });


            block = SchemeHolder.Blocks.ElementAt(3);
            block.ParalelItems.Add(new Blocks.Item("name", new ExponencialDistribution(0.75D)) { NumberId = 7 });
            block.ParalelItems.Add(new Blocks.Item("name", new ExponencialDistribution(0.75D)) { NumberId = 8 });
            block.ParalelItems.Add(new Blocks.Item("name", new ExponencialDistribution(0.75D)) { NumberId = 9 });
            block.ParalelItems.Add(new Blocks.Item("name", new ExponencialDistribution(0.75D)) { NumberId = 10 });
            block.ParalelItems.Add(new Blocks.Item("name", new ExponencialDistribution(0.75D)) { NumberId = 11 });


            block = SchemeHolder.Blocks.ElementAt(4);
            block.ParalelItems.Add(new Blocks.Item("name", new ExponencialDistribution(0.75D)) { NumberId = 12 });



        }
    }
}
