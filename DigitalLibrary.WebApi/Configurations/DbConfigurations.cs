using DigitalLibrary.WebApi.Literals;
using DigitalLibrary.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.WebApi.Configurations;

public static class DbConfigurations
{
    public static IServiceCollection SetDatabaseConfiguration(this IServiceCollection services) 
    {
        var connectionString = Environment.GetEnvironmentVariable(DigitalLibraryLiterals.CONNECTION_STRING);
        
        services.AddDbContext<DigitalLibraryAppDbContext>(options =>
            options.UseSqlServer(connectionString));
        return services; 
    }
}
