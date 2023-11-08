using Microsoft.Extensions.DependencyInjection;
using SmartFeelings.Application.Interfaces.Persistence.CosmosDb;
using SmartFeelings.Persistence.CosmosDb;
using SmartFeelings.Persistence.CosmosDb.Repositories;

namespace SmartFeelings.Persistence;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<SmartFeelingsDbContext>();
        services.AddScoped<IPatientRepository, PatientRepository>();

        return services;
    }
}