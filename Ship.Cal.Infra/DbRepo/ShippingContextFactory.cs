using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Ship.Cal.Infra.DbRepo;
using System.IO;

public class ShippingContextFactory : IDesignTimeDbContextFactory<ShippingContext>
{
    public ShippingContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())  // Set base path to current directory
            .AddJsonFile("appsettings.json")               // Add your appsettings.json file
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<ShippingContext>();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(connectionString);

        return new ShippingContext(optionsBuilder.Options);
    }
}
