using PointOfSale.Models;
using System.Collections.Generic;

namespace PointOfSale.Calculators
{
    public interface IHandler
    {
        void Handle(CalculationRequest request);

        // Can calculator be used with existing calculators?
        void Validate(List<IHandler> calculators);
    }
}
