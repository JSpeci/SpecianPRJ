using SpecianPRJ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianPRJ.Distributions
{
    public class IdentityDistribution : IDistribution
    {
        public double Lambda { get; set; } = 1.0D;

        double IDistribution.Ex => throw new NotImplementedException();

        double IDistribution.VarX => throw new NotImplementedException();

        public double Ex { get; } = 1.0D;

        public double VarX { get; } = 1.0D;

        public double CumulativeDistributionFunction(double x)
        {
            return 1.0D;
        }

        public double GetProbabilityXGreaterThan(double input)
        {
            return 1.0D;
        }

        public double GetProbabilityXLowerThan(double input)
        {
            return 1.0D;
        }

        public double QuantileFunction(double q)
        {
            return 1.0D;
        }
    }
}
