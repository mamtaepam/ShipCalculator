using Ship.Cal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship.Cal.Domain.Contract
{
    public interface IShippingCalculator
    {
        ShippingResponse CalculateTotal(ShippingRequest request);
    }
}
