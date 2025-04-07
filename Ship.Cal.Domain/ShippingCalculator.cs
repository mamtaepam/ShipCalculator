using Ship.Cal.Application.ContractInfra;
using Ship.Cal.Domain.Contract;
using Ship.Cal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship.Cal.Domain
{
    public class ShippingCalculator : IShippingCalculator
    {
        private readonly IShippingRepo _shippingRepo;

        public ShippingCalculator(IShippingRepo shippingRepo)
        {
                _shippingRepo = shippingRepo;
        }
        public ShippingResponse CalculateTotal(ShippingRequest request)
        {
            var productList = _shippingRepo.GetProducts(request.ProdDetails.ProductIds);

            var selectedProducts = productList.Where(p => request.ProdDetails.ProductIds.Contains(p.Id)).ToList();

            var country = _shippingRepo.GetCountry(request.CountryId);

            decimal subtotal = 0;
            for (int i = 0; i < selectedProducts.Count; i++)
            {

                var product = selectedProducts[i];
                var quantity = request.ProdDetails.Quantities[i];
                subtotal += product.Price * quantity;
            }


            decimal taxes = subtotal * country.TaxRate;


            decimal totalWeight = 0;
            for (int i = 0; i < selectedProducts.Count; i++)
            {
                var product = selectedProducts[i];
                var quantity = request.ProdDetails.Quantities[i];
                totalWeight += product.Weight * quantity;
            }

            decimal shipping = country.BaseShippingCost;

            if (totalWeight > 5)
            {
                shipping += (totalWeight - 5) * 2;
            }

            decimal totalAmountDue = subtotal + taxes + shipping;

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
