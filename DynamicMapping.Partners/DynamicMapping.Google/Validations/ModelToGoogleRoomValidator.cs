namespace DynamicMapping.Google.Validations;

using DynamicMapping.Shared.Excpetions;
using DynamicMapping.Model;

/// <summary>
/// Validator based on custom validation rules for internal 'Room' model to 'GoogleRoom' mapping.
/// </summary>
public static class ModelToGoogleRoomValidator
{
    public static void Validate(
        string sourceType,
        string targetType,
        Room model)
    {
        // Check that object is not null.
        if (model == null)
        {
            throw ValidationException.ObjectRequired(sourceType, targetType, nameof(model));
        }

        // Validates 'RoomCode' required
        if (string.IsNullOrWhiteSpace(model.RoomCode.Trim()))
        {
            throw ValidationException.FieldRequired(sourceType, targetType, nameof(model.RoomCode));
        }

        // Validates 'Capacity' must be > 0
        if (model.MaxCapacity <= 0)
        {
            throw ValidationException.InvalidInput(
                sourceType,
                targetType,
                nameof(model.MaxCapacity),
                model.MaxCapacity.ToString(),
                "MaxCapacity must be greater than zero.");
        }
    }
}
