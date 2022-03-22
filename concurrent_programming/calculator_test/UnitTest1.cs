using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace concurrent_programming
{
    [TestClass]
    public class UnitTest1
    {
        Calculator calculator = new Calculator();

        [TestMethod]
        public void AddTest()
        {
            double result = calculator.Add(1, 2);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void SubstractTest()
        {
            double result = calculator.Substract(1, 2);
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void MultiplyTest()
        {
            double result = calculator.Multiply(2, 3);
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void DivideTest()
        {
            double result = calculator.Divide(3, 2);
            Assert.AreEqual(result, 1.5);
        }

        [TestMethod]
        public void DivideByZeroTest()
        {
            Assert.ThrowsException<System.ArgumentException>(() => calculator.Divide(3, 0));
        }
    }
}