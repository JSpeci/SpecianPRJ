using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecianPRJ.Distributions;
using SpecianPRJ.Interfaces;

namespace SpecianPRJ.Tests.Distributions
{
    [TestClass]
    public class ExponencialDistributuionTests
    {
        [TestMethod]
        public void Should_correctly_compute_varX_and_Ex()
        {
            IDistribution dist = new ExponencialDistribution(1 / 13.5);

            Assert.AreEqual(13.5, dist.Ex);
            Assert.AreEqual(182.25, dist.VarX);

            var lambdaFloored = Math.Round(1 / 13.5, 12);
            Assert.AreEqual(0.074074074074D, lambdaFloored);
        }

        [TestMethod]
        public void Should_return_correct_values_cumulative_prob()
        {
            IDistribution dist = new ExponencialDistribution(1 / 13.5);
            double prob = dist.CumulativeDistributionFunction(10);
            double floored = Math.Round(prob, 12);
            Assert.AreEqual(0.523239371331D, floored);

            double prob2 = dist.GetProbabilityXLowerThan(10);
            double floored2 = Math.Round(prob2, 12);
            Assert.AreEqual(floored, floored2);
        }


        [TestMethod]
        public void Should_return_correct_quantile_function()
        {
            IDistribution dist = new ExponencialDistribution(1 / 13.5);
            var floored = Math.Round(dist.QuantileFunction(0.9), 4);
            Assert.AreEqual(31.0849, floored);
        }
    }
}
