namespace DynamicMapping.Google.MappingProfiles;

using DynamicMapping.Shared.Formatting;
using DynamicMapping.Shared.Parsers;
using DynamicMapping.Google.Validations;
using DynamicMapping.Google.Models;
using DynamicMapping.Model;
using DynamicMapping.Core;

/// <summary>
/// Mapping profile to convert 'GoogleReservation' to internal 'Reservation' model.
/// </summary>
public class GoogleToModelReservationProfile : MappingProfileBase<GoogleReservation, Reservation>
{
    public override string SourceType => "Google.Reservation";
    public override string TargetType => "Model.Reservation";

    public override Reservation Map(GoogleReservation google)
    {
        // 1. Parse dates (With Exception handling) initially -> Required for inclusive validation. 
        var checkIn = DateParser.ToDateRequired(SourceType, TargetType, nameof(google.StartDate), google.StartDate);
        var checkOut = DateParser.ToDateOptional(SourceType, TargetType, nameof(google.EndDate), google.EndDate);

        // 2. Validate 'GoogleReservation' model + checkIn & checkOut dates for mapping to 'Reservation' model
        GoogleToModelReservationValidator.Validate(SourceType, TargetType, google, checkIn, checkOut);

        // 3. Split validated 'GuestFullName' into First and Last names
        var (first, last) = NameFormatting.SplitFullName(google.GuestFullName);

        // 4. Map 'GoogleReservation' to internal 'Reservation' model
        var reservation = new Reservation
        {
            Id = Guid.NewGuid(),
            GuestFirstName = first,
            GuestLastName = last,
            CheckIn = checkIn,
            CheckOut = checkOut,
            DataSource = PartnerType.Google
        };

        return reservation;
    }
}