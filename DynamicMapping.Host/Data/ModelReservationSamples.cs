namespace DynamicMapping.Host.Data;

using DynamicMapping.Model;
using System;

internal static class ModelReservationSamples
{
    public static Reservation BasicReservation() =>
        new Reservation
        {
            Id = Guid.NewGuid(),
            GuestFirstName = "John",
            GuestLastName = "Doe",
            CheckIn = new DateTime(2024, 10, 1),
            CheckOut = new DateTime(2024, 10, 5),
            DataSource = PartnerType.Google
        };

    /// <summary>
    /// Missing guest (fisrt name & last name) -> should fail validation.
    /// </summary>
    public static Reservation MissingGuestName() =>
        new Reservation
        {
            Id = Guid.NewGuid(),
            GuestFirstName = "",
            GuestLastName = "",
            CheckIn = new DateTime(2024, 10, 1),
            CheckOut = new DateTime(2024, 10, 5),
            DataSource = PartnerType.None
        };

    /// <summary>
    /// Missing required check-in date -> should fail validation.
    /// </summary>
    public static Reservation MissingCheckIn() =>
        new Reservation
        {
            Id = Guid.NewGuid(),
            GuestFirstName = "Jane",
            GuestLastName = "Doe",
            CheckIn = default,  // invalid
            CheckOut = new DateTime(2024, 10, 5),
            DataSource = PartnerType.None
        };

    /// <summary>
    /// Check-out earlier than check-in -> should fail validation.
    /// </summary>
    public static Reservation InvalidDateRange() =>
        new Reservation
        {
            Id = Guid.NewGuid(),
            GuestFirstName = "Chris",
            GuestLastName = "Parker",
            CheckIn = new DateTime(2024, 10, 10),
            CheckOut = new DateTime(2024, 10, 5),
            DataSource = PartnerType.Google
        };
}
