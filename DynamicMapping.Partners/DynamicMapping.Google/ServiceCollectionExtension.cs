namespace DynamicMapping.Google;

using DynamicMapping.Core.Interfaces;
using DynamicMapping.Google.MappingProfiles;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Service collection extensions for Google mapping profiles.
/// </summary>
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddGoogleMappings(this IServiceCollection services)
    {
        services.AddSingleton<IMappingProfile, GoogleToModelReservationProfile>();
        services.AddSingleton<IMappingProfile, ModelToGoogleReservationProfile>();
        services.AddSingleton<IMappingProfile, GoogleToModelRoomProfile>();
        services.AddSingleton<IMappingProfile, ModelToGoogleRoomProfile>();
        return services;
    }
}
