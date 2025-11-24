namespace DynamicMapping.Model;
/// <summary>
/// Assumed internal model for a room with basic properties.
/// </summary>
public class Room
{
    public Guid Id { get; set; }
    public required string RoomCode { get; set; }
    public int MaxCapacity { get; set; }
    public required PartnerType DataSource { get; set; }
}

