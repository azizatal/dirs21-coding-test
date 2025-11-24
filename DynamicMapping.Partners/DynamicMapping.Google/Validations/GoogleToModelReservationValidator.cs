namespace DynamicMapping.Google.Validations;

using DynamicMapping.Shared.Excpetions;
using DynamicMapping.Google.Models;
using System;

/// <summary>
/// Validator based on custom validation rules for 'GoogleReservation' to internal 'Reservation' model mapping.
/// </summary>

public static class GoogleToModelReservationValidator
{
    /// <param name="checkIn"> parsed 'checkIn' in a valid date format (not to use from model).</param>
    /// <param name="checkOut"> parsed 'checkIn' in a valid date format or null (not to use from model).</param>

    public static void Validate(string sourceType, string targetType, GoogleReservation google, DateTime checkIn, DateTime? checkOut)
    {
        // Ckeck that object is not null.
        if (google is null)
            throw ValidationException.ObjectRequired(sourceType, targetType, nameof(google));

        // Validates if full-name is null or white-space.
        if (string.IsNullOrWhiteSpace(google.GuestFullName?.Trim()))
            throw ValidationException.FieldRequired(sourceType, targetType, nameof(google.GuestFullName));

        // Validates if checkin date start (checkin) date not greater than end (checkout) date.
        if (checkOut != null && checkOut < checkIn)
            throw ValidationException.InvalidDateOrder(sourceType, targetType, google.StartDate, google.EndDate);
    }
}     
