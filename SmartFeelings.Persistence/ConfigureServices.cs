using Microsoft.Extensions.DependencyInjection;
using SmartFeelings.Application.Interfaces.Persistence;
using SmartFeelings.Persistence.Repositories;

namespace SmartFeelings.Persistence;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<SmartFeelingsDbContext>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

        return services;
    }
}