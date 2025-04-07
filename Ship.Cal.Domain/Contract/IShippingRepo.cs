using Ship.Cal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship.Cal.Application.ContractInfra
{
    public interface IShippingRepo
    {
        List<Product> GetProducts(List<int> productIds);
        Country GetCountry(int countryId);
        List<Product> GetProducts();
        List<Country> GetCountry();
    }
}
