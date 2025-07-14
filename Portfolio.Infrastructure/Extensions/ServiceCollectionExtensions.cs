using Microsoft.Extensions.DependencyInjection;
using Portfolio.DB.Repositories;
using Portfolio.Service;
using Portfolio.Service.Concretes;

namespace Portfolio.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddSingleton<IPortfolioRepository, InMemoryPortfolioRepository>();
        services.AddScoped<IAssetService, AssetService>();
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<IPortfolioService, PortfolioService>();
        services.AddScoped<IPerformanceService, PerformanceService>();

        return services;
    }
}
