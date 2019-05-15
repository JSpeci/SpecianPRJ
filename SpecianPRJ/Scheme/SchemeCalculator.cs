using SpecianPRJ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianPRJ.Scheme
{
    public class SchemeCalculator : IDistributionWithCumulativeDF
    {
        public SchemeHolder Scheme { get; set; }

        public SchemeCalculator(SchemeHolder scheme)
        {
            Scheme = scheme;
        }

        public double CalculateReliabilityOfSchemeRoundedTwoDecimalPlaces(double time)
        {
            double probOfScheme = CalculateReliabilityOfSchemeNotRounded(time);
            var resultRounded = Math.Round(((probOfScheme * 100D) % 1) * 100D) / 100D;
            resultRounded += Math.Round(probOfScheme * 100D);
            //by rounding can be sometimes result 101 - false result.
            if (resultRounded / 100D > 100D) { return 100D; }

            return resultRounded / 100D;
        }

        public double CalculateReliabilityOfSchemeNotRounded(double time)
        {
            double probOfScheme = 1D;
            foreach (var block in Scheme.Blocks)
            {
                //calculate probability of serial items
                if (block.ParalelItems.Count > 0)
                {
                    double probabilityOfFailureOfBlock = 1D;
                    //foreach (var item in block.ParalelItems)
                    //{
                    //    probabilityOfFailureOfBlock *= (item.Distribution.CumulativeDistributionFunction(time));
                    //}

                    probabilityOfFailureOfBlock *= block.Distribution.CumulativeDistributionFunction(time);

                    probOfScheme *= (1- probabilityOfFailureOfBlock);
                }
            }
            return probOfScheme;
        }

        public double CumulativeDistributionFunction(double x)
        {
            return 1D - CalculateReliabilityOfSchemeNotRounded(x);
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
                while (CumulativeDistributionFunction(d) <= q)
                {
                    d += 0.001D;
                    ;
                }
                return d;
            }
        }
    }
}
