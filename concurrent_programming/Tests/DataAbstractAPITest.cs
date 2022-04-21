using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace Tests
{
    [TestClass]
    public class DataAbstractAPITest
    {
        
        [TestMethod]
        public void ConnectExceptionTest()
        {
            Assert.ThrowsException<System.NotImplementedException>(() => DataAbstractAPI.CreateAPI().Connect());
        }
    }
}