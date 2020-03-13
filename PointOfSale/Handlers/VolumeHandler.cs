using PointOfSale.Exceptions;
using PointOfSale.Models;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale.Calculators
{
    public class VolumeHandler : IHandler
    {
        private int _quantity { get; }
        private double _price { get; }
        public Product Product { get; }

        public VolumeHandler(int quantity, double price, Product product)
        {
            _quantity = quantity;
            _price = price;
            Product = product;
        }

        public void Handle(CalculationRequest request)
        {
            var productsOrder = request.NotCalculatedOrders.FirstOrDefault(x => x.Product == Product);

            if(productsOrder?.Count >= _quantity)
            {
                productsOrder.Count = productsOrder.Count - _quantity;
                request.TotalPrice +=  _price;
            }
        }

        public void Validate(List<IHandler> calculators)
        {
            // There could only be a single volume discount per product.
            if (calculators.Any(x => (x as VolumeHandler)?.Product == Product))
            {
                throw new UnnableToAddHandlerException();
            }
        }
    }
}
