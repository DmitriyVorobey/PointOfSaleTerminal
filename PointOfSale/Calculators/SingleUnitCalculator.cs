using PointOfSale.Exceptions;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale.Calculators
{
    public class SingleUnitCalculator : ICalculator
    {
        public void Calculate(CalculationRequest request)
        {
            request.TotalPrice += request.NotCalculatedOrders.Select(x => x.Product.Price * x.Count).Sum();
        }

        public void Validate(List<ICalculator> calculators)
        {
            if (calculators.Any(x => x is SingleUnitCalculator))
            {
                throw new UnnableToAddCalculatorException();
            }
        }
    }
}
