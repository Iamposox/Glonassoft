using GlonasSoft.Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace GlonasSoft.Application.Extensions;

public static class ApplicationDIConfigurations
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserStatisticService, UserStatisticService>();

        return services;
    }
}
