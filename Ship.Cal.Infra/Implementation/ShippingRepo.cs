using Microsoft.EntityFrameworkCore;
using Ship.Cal.Application.ContractInfra;
using Ship.Cal.Domain.Model;
using Ship.Cal.Infra.DbRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship.Cal.Infra.Implementation
{
    public class ShippingRepo : IShippingRepo
    {

        private readonly ShippingContext _context;

        public ShippingRepo(ShippingContext context)
        {
            _context = context;
        }
        public Country GetCountry(int countryId)
        {
            return _context.Countries.FirstOrDefault(c => c.Id == countryId);
        }

        public List<Country> GetCountry()
        {
            return _context.Countries.ToList();
        }

        public List<Product> GetProducts(List<int> productIds)
        {
            return _context.Products.Where(p => productIds.Contains(p.Id)).ToList();
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
    }
}
