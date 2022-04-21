using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DataAbstractAPITest
    {
        
        [TestMethod]
        public void ConnectExceptionTest()
        {
            Assert.ThrowsException<System.NotImplementedException>(() => Data.DataAbstractAPI.CreateAPI().Connect());
        }
    }
}