using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship.Cal.Domain.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TaxRate { get; set; }
        public decimal BaseShippingCost { get; set; }
        public decimal FreeShippingThreshold { get; set; }
    }

}
