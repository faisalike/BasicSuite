using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopSuite.Repositories;
using ShopSuite.Services.Implementations;
using ShopSuite.Services.Interfaces;
using ShopSuite.Services.Settings;

namespace ShopSuite.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddShopSuiteServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShopSuite.Domain.Data.ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.Configure<JwtSettings>(configuration.GetSection("Jwt"));

            services.AddShopSuiteRepositories();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}