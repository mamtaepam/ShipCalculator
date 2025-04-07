


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ship.Cal.Application.ContractInfra;
using Ship.Cal.Application.DepandantService;
using Ship.Cal.Application.Implementation;
using Ship.Cal.Infra.DbRepo;
using Ship.Cal.Infra.Implementation;

namespace ShipCalculator
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
           _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ShippingContext>(options =>
        options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));


            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder.AllowAnyOrigin()    // Allow any origin
                           .AllowAnyHeader()    // Allow any headers
                           .AllowAnyMethod());  // Allow any HTTP method (GET, POST, etc.)
            });


            //services.AddScoped<ShippingCalculator>();

            services.AddScoped<IShipCalculatorService, ShipCalculatorService>();
            services.AddScoped<IShippingRepo, ShippingRepo>();
            services.AddSwaggerGen();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ShippingContext>();
                ShippingContext.SeedData(context);
            }
            app.UseRouting();

            app.UseCors();
            app.UseSwagger();

            // Enable Swagger UI (you can access Swagger UI at the root URL)
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shipping Cost Calculator API v1");
                c.RoutePrefix = string.Empty;  // Set Swagger UI to be served at the root (http://localhost:5000)
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Automatically map controllers
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
