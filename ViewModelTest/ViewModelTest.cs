using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel;

namespace ViewModelTest
{
    [TestClass]
    public class ViewModelTest
    {
        private PoolViewModel ViewModel = new();
        
        [TestMethod]
        public void CountTest()
        {
            Assert.AreEqual(ViewModel.Circles.Count, 0);
        }
        [TestMethod]
        public void HeightTest()
        {
            Assert.AreEqual(ViewModel.WindowHeight, 640);
        }
        [TestMethod]
        public void WidthTest()
        {
            Assert.AreEqual(ViewModel.WindowWidth, 1230);
        }
        
        
    }
}