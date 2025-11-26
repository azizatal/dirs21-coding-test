namespace DynamicMapping.Core.Engine;

using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtention
{
    public static IServiceCollection AddMappingEngine(this IServiceCollection services)
    {
        services.AddSingleton<ProfileRegistry>();
        services.AddSingleton<MapHandler>();
        return services;
    }
}
