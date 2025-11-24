namespace DynamicMapping.Google.Models;
/// <summary>
/// Assumed Google-specific model for a reservation with basic properties.
/// </summary>
public class GoogleReservation
{
    public string GuestFullName { get; set; } = string.Empty;
    public string StartDate { get; set; } = string.Empty;
    public string EndDate { get; set; } = string.Empty;
}
