using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCoreExamples.Services.Helpers;

namespace NetCoreExample.Tests.MathTests
{
    [TestClass]
    public class MathTests
    {
        [TestMethod]
        public void Add_TwoPlusTwo_ShouldEqualToFour()
        {
            var result = Math.Add(2, 2);

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Add_ThreePlusSix_ShouldNotEqualToTwelve()
        {
            var result = Math.Add(3, 6);
            Assert.AreNotEqual(12, result);
        }

        [TestMethod]
        public void Subtract_TwoMinusTwo_ShouldEqualToZero()
        {
            var result = Math.Subtract(2, 2);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Subtract_OneMinusFive_ShouldEqualToMinusFour()
        {
            var result = Math.Subtract(1, 5);
            Assert.AreEqual(-4, result);
        }
    }
}