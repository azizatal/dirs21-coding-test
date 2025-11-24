namespace DynamicMapping.Model;
/// <summary>
/// Assumed internal model for a reservation with basic properties.
/// </summary>
public class Reservation
{
    public Guid Id { get; set; }
    public string GuestFirstName { get; set; } = string.Empty;
    public string GuestLastName { get; set; } = string.Empty;
    public required DateTime CheckIn { get; set; }
    public DateTime? CheckOut { get; set; }
    public required PartnerType DataSource { get; set; }
}
