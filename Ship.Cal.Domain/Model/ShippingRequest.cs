using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship.Cal.Domain.Model
{
    public class ShippingRequest
    {
        public List<int> ProductIds { get; set; }
        public int CountryId { get; set; }
        public int Quantity { get; set; }
    }
}
