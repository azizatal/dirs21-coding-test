namespace DynamicMapping.Host;

using DynamicMapping.Google;
using Microsoft.Extensions.DependencyInjection;
using DynamicMapping.Host.Demo;
using DynamicMapping.Core.Engine;

internal static class Startup
{
    public static ServiceProvider BuildServiceProvider()
    {
        var services = new ServiceCollection();

        // mapping infrastructure
        services.AddSingleton<ProfileRegistry>();
        services.AddSingleton<MapHandler>();

        // Add partner modules (each module handles its own mapping profiles)
        services.AddGoogleMappings();

        // Demo class
        services.AddScoped<GoogleToModelReservationDemo>();
        services.AddScoped<GoogleToModelRoomDemo>();
        services.AddScoped<ModelToGoogleReservationDemo>();
        services.AddScoped<ModelToGoogleRoomDemo>();

        return services.BuildServiceProvider();
    }
}

