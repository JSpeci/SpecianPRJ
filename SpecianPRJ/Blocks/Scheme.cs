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
        Block InputBlock { get; set; }
        Block OutputBlock { get; set; }
        Block ContentBlock { get; set; }

        public Scheme()
        {
            InputBlock = new Block()
            {
                Distribution = new IdentityDistribution(),
                Name = "InputBlock",
                InputBlock = null,
                OutputBlock = null,
            };
            OutputBlock = new Block()
            {
                Distribution = new IdentityDistribution(),
                Name = "OutputBlock",
                InputBlock = null,
                OutputBlock = null,
            };
        }
    }
}
