using System.Collections.Generic;

namespace PointOfSale.Models
{
    public class CalculationRequest
    {
        public List<Order> NotCalculatedOrders { get; }

        public double TotalPrice { get; set; } = 0;

        public CalculationRequest(List<Order> orders)
        {
            NotCalculatedOrders = orders;
        }
    }
}
