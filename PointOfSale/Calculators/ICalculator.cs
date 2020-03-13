using PointOfSale.Models;
using System.Collections.Generic;

namespace PointOfSale.Calculators
{
    public interface ICalculator
    {
        void Calculate(CalculationRequest request);

        // Can calculator be used with existing calculators?
        void Validate(List<ICalculator> calculators);
    }
}
