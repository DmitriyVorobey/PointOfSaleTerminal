using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointOfSale;
using PointOfSale.Calculators;
using PointOfSale.Models;

namespace PointOfSaleTests
{
    [TestClass]
    public class ComplexTests
    {
        private PointOfSaleTerminal _posTerminal;

        [TestInitialize()]
        public void TestInitialize() 
        {
            _posTerminal = new PointOfSaleTerminal();

            var productA = new Product('A', 1.25);
            _posTerminal.SetPricing(productA);
            _posTerminal.SetHandler(new VolumeHandler(3, 3.00 ,productA));

            var productB = new Product('B', 4.25);
            _posTerminal.SetPricing(productB);

            var productC = new Product('C', 1.00);
            _posTerminal.SetPricing(productC);
            _posTerminal.SetHandler(new VolumeHandler(6, 5.00, productC));

            var productD = new Product('D', 0.75);
            _posTerminal.SetPricing(productD);

            _posTerminal.SetHandler(new SingleUnitHandler());
        }

        [TestMethod]
        public void TestCase1()
        {
            // arrange
            _posTerminal.Scan("ABCDABA");

            // act, assert
            Assert.AreEqual(13.25, _posTerminal.CalculateTotal());
        }

        [TestMethod]
        public void TestCase2()
        {
            // arrange
            _posTerminal.Scan("CCCCCCC");

            // act, assert
            Assert.AreEqual(6.00, _posTerminal.CalculateTotal());
        }

        [TestMethod]
        public void TestCase3()
        {
            // arrange
            _posTerminal.Scan("ABCD");

            // act, assert
            Assert.AreEqual(7.25, _posTerminal.CalculateTotal());
        }
    }
}
