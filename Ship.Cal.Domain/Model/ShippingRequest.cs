using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship.Cal.Domain.Model
{
    public class ShippingRequest
    {
        public Products ProdDetails { get; set; }
        public int CountryId { get; set; }
        public int Quantity { get; set; }
    }

    public class Products
    {
        public List<int> ProductIds { get; set; }     // List of product IDs
        public List<int> Quantities { get; set; }
    }
}
