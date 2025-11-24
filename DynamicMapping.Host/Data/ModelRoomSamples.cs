namespace DynamicMapping.Host.Data;

using DynamicMapping.Model;

internal static class ModelRoomSamples
{
    public static Room BasicRoom() =>
        new Room
        {
            Id = Guid.NewGuid(),
            RoomCode = "101A",
            MaxCapacity = 2,
            DataSource = PartnerType.None
        };

    /// <summary>
    /// Missing room code -> should fail validation.
    /// </summary>
    public static Room MissingRoomCode() =>
        new Room
        {
            Id = Guid.NewGuid(),
            RoomCode = "",
            MaxCapacity = 2,
            DataSource = PartnerType.None
        };

    /// <summary>
    /// Zero capacity  -> should fail validation.
    /// </summary>
    public static Room ZeroCapacity() =>
        new Room
        {
            Id = Guid.NewGuid(),
            RoomCode = "300X",
            MaxCapacity = 0,
            DataSource = PartnerType.None
        };
}
