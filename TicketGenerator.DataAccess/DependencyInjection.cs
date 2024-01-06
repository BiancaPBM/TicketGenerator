using Microsoft.Extensions.DependencyInjection;
using TicketGenerator.DataAccess.Interfaces;
using TicketGenerator.Repository.Repository;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ITicketGeneratorRepository, TicketGeneratorRepository>();
        return services;
    }
}