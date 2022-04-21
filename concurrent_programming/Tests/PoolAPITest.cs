using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using Logic;
using System.Collections.ObjectModel;

namespace Tests
{
    [TestClass]
    internal class PoolAPITest
    {
        PoolAbstractAPI _poolAPI = PoolAbstractAPI.CreateLayer();

        [TestMethod]
        public void CreateLayerNullTest()
        {
            Assert.AreEqual(_poolAPI, PoolAbstractAPI.CreateLayer(null));
        }

        DataAbstractAPI _layer = DataAbstractAPI.CreateAPI();
        

        [TestMethod]
        public void CreateLayerTest()
        {
            Assert.AreEqual(_poolAPI, PoolAbstractAPI.CreateLayer(_layer));
        }

        ObservableCollection<Circle> _newCircles = new();
        Circle _circle1 = new(12,1,2);
        Circle _circle2 = new(11,4,1);

        [TestMethod]
        public void CreateCirclesTest()
        {
            Assert.AreEqual(3, _poolAPI.CreateCircles(100, 100, 3).Count);
        }

        [TestMethod]
        public void UpdateCirclesTest()
        {
            _newCircles.Add(_circle1);
            _newCircles.Add(_circle2);
            Assert.AreEqual(2, _poolAPI.UpdateCirlcePosition(100, 100, _newCircles).Count);
        }
    }
}
