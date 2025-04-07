using Ship.Cal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship.Cal.Application.DepandantService
{
    public interface IShipCalculatorService
    {
        public ShippingResponse CalculateTotal(List<Product> products, int quantity, Country country);
    }
}
