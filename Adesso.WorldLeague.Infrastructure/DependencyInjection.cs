using Adesso.WorldLeague.Application.Common;
using Adesso.WorldLeague.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adesso.WorldLeague.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>((_, optionsBuilder) => 
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("Postgresql"),
                    options =>
                    {
                        options.CommandTimeout(10);
                    })
                .EnableSensitiveDataLogging()
        );
        
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        
        return services;
    }
}