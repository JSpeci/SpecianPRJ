using SpecianPRJ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianPRJ.Distributions
{

    /// <summary>
    /// Object represents exponencial distribution calculator, with fixed lambda
    /// Source of knowledge http://www2.ef.jcu.cz/~rost/courses/stata/data/exponencialni%20rozdeleni.pdf
    /// </summary>
    public class ExponencialDistribution : IDistribution
    {
        public ExponencialDistribution(double lambda)
        {
            Lambda = lambda;
        }

        public double Lambda { get; set; }

        public double Ex
        {
            get
            {
                return 1 / Lambda;
            }
        }

        public double VarX
        {
            get
            {
                return 1 / (Lambda * Lambda);
            }
        }

        /// <summary>
        /// P(X v x)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public double GetProbabilityXLowerThan(double input)
        {
            return CumulativeDistributionFunction(input);
        }

        public double GetProbabilityXGreaterThan(double input)
        {
            return 1 - CumulativeDistributionFunction(input);

        }

        /// <summary>
        /// Distribucni fuknce
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public double CumulativeDistributionFunction(double t)
        {
            return 1 - (Math.Exp(-1 * t * Lambda));
        }

        /// <summary>
        /// P(0 v X v t) = q
        /// </summary>
        /// <param name=""></param>
        public double QuantileFunction(double q)
        {
            if (q < 0 || q > 1)
            {
                return 0D;
            }
            else
            {
                return (-1 * Math.Log(-1 * (q - 1))) * Ex;
            }
        }
    }
}
