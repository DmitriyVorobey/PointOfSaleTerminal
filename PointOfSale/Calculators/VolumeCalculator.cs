using PointOfSale.Exceptions;
using PointOfSale.Models;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale.Calculators
{
    public class VolumeCalculator : ICalculator
    {
        private int _volume { get; }
        private double _price { get; }
        public Product Product { get; }

        public VolumeCalculator(int volume, double price, Product product)
        {
            _volume = volume;
            _price = price;
            Product = product;
        }

        public void Calculate(CalculationRequest request)
        {
            var productsOrder = request.NotCalculatedOrders.FirstOrDefault(x => x.Product == Product);
            if (productsOrder == null)
            {
                return;
            }
            else if(productsOrder.Count >= _volume)
            {
                productsOrder.Count = productsOrder.Count - _volume;
                request.TotalPrice +=  _price;
            }
        }

        public void Validate(List<ICalculator> calculators)
        {
            // There could only be a single volume discount per product.
            if (calculators.Any(x => (x as VolumeCalculator)?.Product == Product))
            {
                throw new UnnableToAddCalculatorException();
            }
        }
    }
}
