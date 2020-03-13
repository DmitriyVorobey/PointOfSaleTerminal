using PointOfSale.Calculators;
using PointOfSale.Exceptions;
using PointOfSale.Models;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale
{
    public class PointOfSaleTerminal
    {
        private List<Product> _products = new List<Product>();
        private List<ICalculator> _calculators = new List<ICalculator>();

        private string _line = string.Empty;

        public void SetPricing(Product product)
        {
            if (_products.Any(x => x.Code == product.Code))
            {
                throw new ProductAlreadyExistException();
            }

            _products.Add(product);
        }

        public void SetCalculator(ICalculator calculator)
        {
            calculator.Validate(_calculators);
            _calculators.Add(calculator);
        }

        public void Scan(string productCodes)
        {
            productCodes.ToList().ForEach(productCode =>
            {
                if (!_products.Any(x => x.Code == productCode)) throw new ProductNotFoundException();
                _line += productCode;
            });
        }

        public double CalculateTotal()
        {
            var orders = _line.GroupBy(x => x)
                .Select(x => new Order
                {
                    Product = _products.First(p => p.Code == x.Key),
                    Count = x.Count()
                }).ToList();

            var calculationRequest = new CalculationRequest(orders);
            _calculators.ForEach(x => x.Calculate(calculationRequest));

            return calculationRequest.TotalPrice;
        }
    }
}
