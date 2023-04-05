using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace iot.Data.Configurations
{
    public static class Configuration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                   options.UseSqlServer(connectionString));

            return services;
        }

    }

}