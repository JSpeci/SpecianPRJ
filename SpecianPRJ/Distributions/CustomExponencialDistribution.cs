using SpecianPRJ.Blocks;
using SpecianPRJ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianPRJ.Distributions
{
    public class CustomExponencialDistribution : IDistributionWithCumulativeDF
    {
        private List<IDistributionWithCumulativeDF> itemsInParalel;
        private Block block;

        public CustomExponencialDistribution(List<IDistributionWithCumulativeDF> itemsInParalel, Block block)
        {
            this.itemsInParalel = itemsInParalel;
            this.block = block;
        }

        public double CumulativeDistributionFunction(double t)
        {
            double probabilityOfFailureOfBlock = 1D;
            foreach (var item in block.ParalelItems)
            {
                probabilityOfFailureOfBlock *= (item.Distribution.CumulativeDistributionFunction(t));
            }
            return probabilityOfFailureOfBlock;
        }

        public double QuantileFunction(double q)
        {
            if (q < 0 || q > 1)
            {
                return 0D;
            }
            else
            {
                double d = 0D;
                while(CumulativeDistributionFunction(d) <= q)
                {
                    d += 0.001D;
                    ;
                }
                return d;
            }
        }
    }
}
