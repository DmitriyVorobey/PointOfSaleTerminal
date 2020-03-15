using PointOfSale.Models;
using System.Collections.Generic;

namespace PointOfSale.Calculators
{
    public interface IHandler
    {
        void Handle(CalculationRequest request);
    }
}
