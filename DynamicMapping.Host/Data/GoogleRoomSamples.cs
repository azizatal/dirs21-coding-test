namespace DynamicMapping.Host.Data;

using DynamicMapping.Google.Models;

internal static class GoogleRoomSamples
{
    public static GoogleRoom BasicRoom() =>
        new GoogleRoom
        {
            MaxCapacity = 2,
            RoomNumber = "101A"
        };

    /// <summary>
    /// Missing room number -> should fail validation.
    /// </summary>
    public static GoogleRoom MissingRoomNumber() =>
        new GoogleRoom
        {
            MaxCapacity = 2,
            RoomNumber = ""
        };

    /// <summary>
    /// Unknown or zero capacity -> should fail validation.
    /// </summary>
    public static GoogleRoom UnknownCapacity() =>
        new GoogleRoom
        {
            MaxCapacity = 0,
            RoomNumber = "101"
        };
}
