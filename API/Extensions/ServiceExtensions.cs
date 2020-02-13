using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseMySql(configuration.GetConnectionString("DefaultConnection"));
            });
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(opt => 
            {
                opt.AddPolicy("CorsPolicy", policy => 
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });
        }
    }
}