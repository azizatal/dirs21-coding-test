namespace DynamicMapping.Google.Validations;

using DynamicMapping.Shared.Excpetions;
using DynamicMapping.Google.Models;

/// <summary>
/// Validator based on custom validation rules for 'GoogleRoom' to internal 'Room' model mapping.
/// </summary>
public static class GoogleToModelRoomValidator
{
    public static void Validate(
        string sourceType,
        string targetType,
        GoogleRoom google)
    {
        // Ckeck that the GoogleRoom object is not null
        if (google == null)
        {
            throw ValidationException.InvalidInput(
                sourceType,
                targetType,
                "GoogleRoom",
                "null",
                "Room object cannot be null.");
        }

        // 1. RoomNumber required
        if (string.IsNullOrWhiteSpace(google.RoomNumber))
        {
            throw ValidationException.InvalidInput(
                sourceType,
                targetType,
                nameof(google.RoomNumber),
                google.RoomNumber ?? "null",
                "RoomNumber is required.");
        }

        // 2. Capacity must be greater than zero
        if (google.MaxCapacity <= 0)
        {
            throw ValidationException.InvalidInput(
                sourceType,
                targetType,
                nameof(google.MaxCapacity),
                google.MaxCapacity.ToString(),
                "MaxCapacity must be greater than zero.");
        }
    }
}
