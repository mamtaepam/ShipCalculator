using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship.Cal.Domain.Model
{
    public class ShippingResponse
    {
        public decimal Subtotal { get; set; }
        public decimal Taxes { get; set; }
        public decimal TotalAmountDue { get; set; }
        public decimal Shipping { get; set; }
    }
}
