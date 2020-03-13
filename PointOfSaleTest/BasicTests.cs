using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointOfSale;
using PointOfSale.Calculators;
using PointOfSale.Exceptions;
using PointOfSale.Models;

namespace PointOfSaleTest
{
    [TestClass]
    public class BasicTests
    {

        [TestMethod]
        public void SetPricing_Success()
        {
            // arrange
            var posTerminal = new PointOfSaleTerminal();

            // act
            posTerminal.SetPricing(new Product('A', 1));

        }

        [TestMethod]
        [ExpectedException(typeof(ProductAlreadyExistException))]
        public void SetPricing_ProductAlreadyExistException()
        {
            // arrange
            var posTerminal = new PointOfSaleTerminal();
            posTerminal.SetPricing(new Product('A', 1));

            // act
            // assert
            posTerminal.SetPricing(new Product('A', 2));
        }

        [TestMethod]
        public void Scan_Success()
        {
            // arrange
            var posTerminal = new PointOfSaleTerminal();
            posTerminal.SetPricing(new Product('A', 1));

            // act
            // assert
            posTerminal.Scan("A");
        }

        [TestMethod]
        [ExpectedException(typeof(ProductNotFoundException))]
        public void Scan_ProductNotFoundException()
        {
            // arrange
            var posTerminal = new PointOfSaleTerminal();

            // act
            // assert
            posTerminal.Scan("A");
        }

        [TestMethod]
        [ExpectedException(typeof(UnnableToAddCalculatorException))]
        public void SetCalculator_SingleUnitCalculatorAddTwice_Exception()
        {
            // arrange
            var posTerminal = new PointOfSaleTerminal();

            // act
            // assert
            posTerminal.SetCalculator(new SingleUnitCalculator());
            posTerminal.SetCalculator(new SingleUnitCalculator());
        }

        [TestMethod]
        [ExpectedException(typeof(UnnableToAddCalculatorException))]
        public void SetCalculator_VolumeCalculatorAddTwiceForOneProduct_Exception()
        {
            // arrange
            var posTerminal = new PointOfSaleTerminal();
            var product = new Product('A', 1);

            // act
            // assert
            posTerminal.SetCalculator(new VolumeCalculator(5, 2, product));
            posTerminal.SetCalculator(new VolumeCalculator(6, 3, product));
        }
    }
}
