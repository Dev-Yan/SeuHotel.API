using Microsoft.EntityFrameworkCore;
using SeuHotel.Infrastructure.Context;

namespace SeuHotel.API.Configurations
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SeuHotelContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("SeuHotelDatabase")));
            services.BuildServiceProvider().GetRequiredService<SeuHotelContext>();

            return services;
        }
    }
}