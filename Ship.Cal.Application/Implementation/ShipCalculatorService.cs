using Ship.Cal.Application.DepandantService;
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
        public ShippingResponse CalculateTotal(List<Product> products, int quantity, Country country)
        {
            decimal subtotal = products.Sum(p => p.Price * quantity);
            decimal taxes = subtotal * country.TaxRate / 100;

            decimal totalWeight = products.Sum(p => p.Weight) * quantity;
            decimal shipping = country.BaseShippingCost;

            if (totalWeight > 5)
            {
                shipping += (totalWeight - 5) * 2; // Add surcharge for weight over 5kg
            }

            if (subtotal >= country.FreeShippingThreshold)
            {
                shipping = 0; // Free shipping
            }

            ShippingResponse response = new ShippingResponse
            {
                Shipping = shipping,
                Taxes = taxes,
                TotalAmountDue = totalWeight,
                Subtotal = subtotal
            };
            

            return response;
        }
    }
}
