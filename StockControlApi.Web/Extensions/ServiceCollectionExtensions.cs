using Microsoft.EntityFrameworkCore;
using StockControlApi.Application.Services;
using StockControlApi.Application.Contracts;
using StockControlApi.Core.Interfaces;
using StockControlApi.Infrastructure.Data;
using StockControlApi.Infrastructure.Repositories;

namespace StockControlApi.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {

        // Registrar os repositórios
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        // Registrar o serviço
        services.AddScoped<IStockService, StockService>();


        return services;
    }
}