namespace DynamicMapping.Google.Validations;

using DynamicMapping.Shared.Excpetions;
using DynamicMapping.Model;

/// <summary>
/// Validator based on custom validation rules for internal 'Reservation' model to 'GoogleReservation' mapping.
/// </summary>
public static class ModelToGoogleReservationValidator
{
    public static void Validate(string sourceType, string targetType, Reservation model)
    {
        // Check that the model object is not null
        if (model is null)
            throw ValidationException.ObjectRequired(sourceType, targetType, nameof(model));

        // Validate CheckIn is not default date
        if (model.CheckIn == default)
            throw ValidationException.InvalidInput(
                sourceType, 
                targetType, 
                nameof(model.CheckIn), 
                model.CheckIn.ToString(), 
                "The set is the default system date");

        // Validate CheckOut >= CheckIn (if present)
        if (model.CheckOut.HasValue && model.CheckOut.Value < model.CheckIn)
            throw ValidationException.InvalidDateOrder(sourceType, targetType,nameof(model.CheckOut), nameof(model.CheckOut));

        // Validate if name or last name is present
        if (string.IsNullOrWhiteSpace(model.GuestFirstName.Trim()) && string.IsNullOrWhiteSpace(model.GuestLastName.Trim()))
            throw ValidationException.FieldRequired(sourceType, targetType, nameof(model.GuestFirstName) + " or " + nameof(model.GuestFirstName));
    }
}
