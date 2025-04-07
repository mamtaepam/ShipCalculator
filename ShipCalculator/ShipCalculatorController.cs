using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ship.Cal.Application.ContractInfra;
using Ship.Cal.Application.DepandantService;
using Ship.Cal.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShipCalculator
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipCalculatorController : ControllerBase
    {

        private readonly IShipCalculatorService _shippingCalculatorService;
        private readonly IShippingRepo _shippingRepository;

        public ShipCalculatorController(IShipCalculatorService shippingCalculatorService, IShippingRepo shippingRepository)
        {
            _shippingCalculatorService = shippingCalculatorService;
            _shippingRepository = shippingRepository;
        }

        [HttpPost("calculate")]
        public ActionResult<ShippingResponse> CalculateShipping([FromBody] ShippingRequest request)
        {
            var products = _shippingRepository.GetProducts(request.ProductIds);
            var country = _shippingRepository.GetCountry(request.CountryId);

            if (country == null)
            {
                return NotFound("Country not found.");
            }

            ShippingResponse totalAmount = _shippingCalculatorService.CalculateTotal(products, request.Quantity, country);

            var response = new ShippingResponse
            {
                Subtotal = totalAmount.Subtotal,
                Taxes = totalAmount.Taxes,
                Shipping = totalAmount.Shipping,
                TotalAmountDue = totalAmount.TotalAmountDue
            };
            return Ok(response);
        }

        [HttpGet("products")]
        public  ActionResult<IEnumerable<Product>> GetProducts()
        {
            return  _shippingRepository.GetProducts();
        }

        // Endpoint to fetch countries
        [HttpGet("countries")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return  _shippingRepository.GetCountry();
        }
    }
}
