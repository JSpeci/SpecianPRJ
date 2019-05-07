using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecianPRJ.Distributions;

namespace SpecianPRJ.Tests.Distributions
{
    [TestClass]
    public class IdentityDistributionTest
    {
        [TestMethod]
        public void TestCase1()
        {
            var idist = new IdentityDistribution();

            Assert.AreEqual(1.0, idist.GetProbabilityXGreaterThan(111D));
        }
    }
}
