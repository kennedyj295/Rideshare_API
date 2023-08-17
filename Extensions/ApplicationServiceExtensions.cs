using Rideshare_API.Interfaces;

namespace Rideshare_API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) 
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
