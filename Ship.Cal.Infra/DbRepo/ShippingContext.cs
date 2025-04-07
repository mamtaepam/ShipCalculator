using Microsoft.EntityFrameworkCore;
using Ship.Cal.Domain.Model;
using System.Linq;

namespace Ship.Cal.Infra.DbRepo
{

    public class ShippingContext :DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Country> Countries { get; set; }

        public static void SeedData(ShippingContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "Product A", Price = 20.00m, Weight = 1 },
                    new Product { Name = "Product B", Price = 15.00m, Weight = 0 },
                    new Product { Name = "Product C", Price = 50.00m, Weight = 2 }
                );
                context.SaveChanges();
            }

            if (!context.Countries.Any())
            {
                context.Countries.AddRange(
                    new Country { Name = "Canada", TaxRate = 5, BaseShippingCost = 25.00m },
                    new Country { Name = "USA", TaxRate = 8, BaseShippingCost = 30.00m }
                );
                context.SaveChanges();
            }
        }
        public ShippingContext(DbContextOptions<ShippingContext> options) : base(options) { }
    }

}
