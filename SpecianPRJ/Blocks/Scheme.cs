using SpecianPRJ.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianPRJ.Blocks
{
    public class Scheme
    {
        public Block InputBlock { get; set; }
        public Block OutputBlock { get; set; }
        public Block ContentBlock { get; set; }
        public string Name { get; set; }


        public Scheme()
        {
            InputBlock = new Block()
            {
                ComputedDistribution = new IdentityDistribution(),
                Name = "InputBlock",
                InputBlock = null,
                OutputBlock = null,
            };
            OutputBlock = new Block()
            {
                ComputedDistribution = new IdentityDistribution(),
                Name = "OutputBlock",
                InputBlock = null,
                OutputBlock = null,
            };
        }
    }
}
