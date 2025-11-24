using DynamicMapping.Host;
using DynamicMapping.Host.Demo;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    static void Main(string[] args)
    {
        using var provider = Startup.BuildServiceProvider();

        var GoogleToModelRes = provider.GetRequiredService<GoogleToModelReservationDemo>();
        GoogleToModelRes.RunDemo();

        var GoogleToModelRoom = provider.GetRequiredService<GoogleToModelRoomDemo>();
        GoogleToModelRoom.RunDemo();

        var ModelToGoogleRes = provider.GetRequiredService<ModelToGoogleReservationDemo>();
        ModelToGoogleRes.RunDemo();

        var ModelToGoogleRoom = provider.GetRequiredService<ModelToGoogleRoomDemo>();
        ModelToGoogleRoom.RunDemo();
    }
}