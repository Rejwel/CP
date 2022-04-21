using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ViewModel;

namespace Tests
{
    [TestClass]
    public class PoolViewModelTest
    {
        PoolViewModel poolViewModel = new PoolViewModel();

        [TestMethod]
        public void constructorTest()
        {
            Assert.AreEqual(640,poolViewModel.WindowHeight);
            Assert.AreEqual(1230, poolViewModel.WindowWidth);
        }
    }
}
