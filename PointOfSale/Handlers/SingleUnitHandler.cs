﻿using PointOfSale.Exceptions;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale.Calculators
{
    public class SingleUnitHandler : IHandler
    {
        public void Handle(CalculationRequest request)
        {
            request.TotalPrice += request.NotCalculatedOrders.Select(x => x.Product.Price * x.Count).Sum();
        }

        public void Validate(List<IHandler> calculators)
        {
            if (calculators.Any(x => x is SingleUnitHandler))
            {
                throw new UnnableToAddHandlerException();
            }
        }
    }
}