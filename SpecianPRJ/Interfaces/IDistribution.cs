using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianPRJ.Interfaces
{
    public interface IDistribution
    {
        double Lambda { get; set; }
        double Ex { get; }
        double VarX { get; }
        double GetProbabilityXLowerThan(double input);
        double GetProbabilityXGreaterThan(double input);
        double CumulativeDistributionFunction(double x);
        double QuantileFunction(double q);
    }
}
