using Ship.Cal.Application.ContractInfra;
using Ship.Cal.Application.DepandantService;
using Ship.Cal.Domain;
using Ship.Cal.Domain.Contract;
using Ship.Cal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship.Cal.Application.Implementation
{
    public class ShipCalculatorService : IShipCalculatorService
    {

        private readonly IShippingCalculator _shippingCalculator;

        public ShipCalculatorService(IShippingCalculator shippingCalculator) 
        {
            _shippingCalculator = shippingCalculator;
        }

        public ShippingResponse CalculateTotal(ShippingRequest request)
        {
            var Response =_shippingCalculator.CalculateTotal(request);
            return Response;
        }


    }
}
