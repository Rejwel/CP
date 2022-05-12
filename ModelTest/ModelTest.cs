using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace ModelTest
{
    [TestClass]
    public class ModelTest
    {
        private PoolModel Model = new (1000, 1000);
        
        [TestMethod]
        public void AnimatingStartTest()
        {
            Assert.AreEqual(Model.Animating, false);
            Model.GetStartingCirclePositions(10);
            Assert.AreEqual(Model.Animating, true);
        }
        
        [TestMethod]
        public void AnimatingFalseTest()
        {
            Assert.AreEqual(Model.Animating, false);
        }
        
    }
}