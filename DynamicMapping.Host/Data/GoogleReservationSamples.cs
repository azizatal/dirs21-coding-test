namespace DynamicMapping.Host.Data;

using DynamicMapping.Google.Models;

internal static class GoogleReservationSamples
{
    public static GoogleReservation BasicReservation() =>
        new GoogleReservation
        {
            GuestFullName = "John Doe",
            StartDate = "2024-10-01",
            EndDate = "2024-10-05"
        };

    /// <summary>
    /// Guest name missing or unknown -> should fail validation.
    /// </summary>
    public static GoogleReservation UnknownGuest() =>
        new GoogleReservation
        {
            GuestFullName = "",
            StartDate = "2024-10-01",
            EndDate = "2024-10-05"
        };

    /// <summary>
    /// Date format invalid ->  -> should fail validation.
    /// </summary>
    public static GoogleReservation InvalidDateFormat() =>
        new GoogleReservation
        {
            GuestFullName = "John Doe",
            StartDate = "01-10-2024",   // invalid, wrong format
            EndDate = "2024/10/05"      // invalid, wrong format
        };

    /// <summary>
    /// Missing required check-in date -> should fail validation.
    /// </summary>
    public static GoogleReservation MissingCheckIn() =>
        new GoogleReservation
        {
            GuestFullName = "John Doe",
            StartDate = "",
            EndDate = "2024-10-05"
        };

    /// <summary>
    /// Check-out earlier than check-in -> should fail validation.
    /// </summary>
    public static GoogleReservation InvalidDateRange() =>
        new GoogleReservation
        {
            GuestFullName = "John Doe",
            StartDate = "2024-10-10",
            EndDate = "2024-10-05"
        };
}
