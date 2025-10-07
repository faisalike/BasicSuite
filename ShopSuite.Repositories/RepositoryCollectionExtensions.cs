using Microsoft.Extensions.DependencyInjection;
using ShopSuite.Repositories.Interfaces;
using ShopSuite.Repositories.Implementations;

namespace ShopSuite.Repositories
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddShopSuiteRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}