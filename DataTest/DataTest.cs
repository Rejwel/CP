using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTest
{
    [TestClass]
    public class DataTest
    {
        private DataAbstractAPI TestingAPI = DataAbstractAPI.CreateAPI();

        [TestMethod]
        public void CircleCreationTest()
        {
            TestingAPI.CreatePoolWithBalls(10, 1000, 1000);
            Assert.AreEqual(TestingAPI.GetCircles().Count, 10);
        }
        
        [TestMethod]
        public void GetWidthTest()
        {
            TestingAPI.CreatePoolWithBalls(10, 500, 1000);
            Assert.AreEqual(TestingAPI.GetPoolWidth(), 500);
        }
        
        [TestMethod]
        public void GetHeightTest()
        {
            TestingAPI.CreatePoolWithBalls(10, 500, 1000);
            Assert.AreEqual(TestingAPI.GetPoolHeight(), 1000);
        }

        [TestMethod]
        public void CirclePosTest()
        {
            Circle c = new(10, 15);
            Assert.AreEqual(c.XPos, 10);
            Assert.AreEqual(c.YPos, 15);
        }
        
    }
}