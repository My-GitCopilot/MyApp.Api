using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Interfaces;
using MyApp.Infrastructure.Data;
using MyApp.Infrastructure.Repositories;

namespace MyApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            // Register infrastructure services here
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Server=.;Database=MyAppDb;User=sa;Password=admin@123;Encrypt=True;TrustServerCertificate=True;");
                // Configure your DbContext here, e.g., options.UseSqlServer("YourConnectionString");
            });
            services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            return services;

        }
    }
}
