using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianPRJ.Scheme
{
    public class SchemeCalculator
    {
        //params
        public double CalculateScheme(SchemeHolder scheme, double time)
        {
            double probOfScheme = 1D;
            foreach (var block in scheme.Blocks)
            {
                //calculate probability of serial items
                if (block.ParalelItems.Count > 0)
                {
                    double probabilityOfFailureOfBlock = 1D;
                    foreach (var item in block.ParalelItems)
                    {
                        probabilityOfFailureOfBlock *= (item.Distribution.CumulativeDistributionFunction(time));
                    }

                    probOfScheme *= (1 - probabilityOfFailureOfBlock);
                }
            }
            var resultRounded = Math.Round(((probOfScheme * 100D) % 1) * 100D) / 100D;
            resultRounded += Math.Round(probOfScheme * 100D);
            //by rounding can be sometimes result 101 - false result.
            if (resultRounded / 100D > 100D) { return 100D; }

            return resultRounded / 100D;
        }
    }
}
