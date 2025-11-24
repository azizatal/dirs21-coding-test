namespace DynamicMapping.Google.Models;

/// <summary>
/// Assumed Google-specific model for a room with basic properties.
/// </summary>
public class GoogleRoom
{
    public string RoomNumber { get; set; }  = string.Empty;
    public int MaxCapacity { get; set; }
}

