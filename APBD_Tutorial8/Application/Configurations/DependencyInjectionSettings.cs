using System.Data;
using APBD_Tutorial8.Domain.Interfaces;
using APBD_Tutorial8.Infrastructure.Repositories;
using APBD_Tutorial8.Infrastructure.Repository;
using MediatR;
using Microsoft.Data.SqlClient;

namespace APBD_Tutorial8.Application.Configurations;

public static class DependencyInjectionSettings
{
    public static IServiceCollection AddApplicationSettings(this IServiceCollection services,
        IConfiguration configuration)
    {
        //services.AddTransient<IDbConnection>(sp => new SqlConnection(configuration.GetConnectionString("DefaultConnection")));
        services.AddTransient<SqlConnection>(sp => new SqlConnection(configuration.GetConnectionString("DefaultConnection")));
        services.AddSingleton(sp =>
            sp.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection"));
        services.AddScoped<ITripRepository, TripRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddMediatR(typeof(Program));
        return services;
    }
}