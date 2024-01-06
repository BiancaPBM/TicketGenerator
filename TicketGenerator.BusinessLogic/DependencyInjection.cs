using Microsoft.Extensions.DependencyInjection;
using TicketGenerator.BusinessLogic.Interfaces;
using TicketGenerator.BusinessLogic.Services;

namespace TicketGenerator.BusinessLogic
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITicketGeneratorService, TicketGeneratorService>();
            return services;
        }
    }
}
