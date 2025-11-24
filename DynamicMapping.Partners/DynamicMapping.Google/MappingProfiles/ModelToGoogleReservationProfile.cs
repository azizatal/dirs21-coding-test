namespace DynamicMapping.Google.MappingProfiles;

using DynamicMapping.Shared.Helpers;
using DynamicMapping.Google.Validations;
using DynamicMapping.Google.Models;
using DynamicMapping.Model;
using DynamicMapping.Core;

/// <summary>
/// Mapping profile to convert internal 'Reservation' model to 'GoogleReservation'.
/// </summary>
public class ModelToGoogleReservationProfile : MappingProfileBase<Reservation, GoogleReservation>
{
    public override string SourceType => "Model.Reservation";
    public override string TargetType => "Google.Reservation";

    public override GoogleReservation Map(Reservation model)
    {
        // 1. Validate 'Reservation' model for mapping to 'GoogleReservation'
        ModelToGoogleReservationValidator.Validate(SourceType, TargetType, model);

        // 2. Build 'GuestFullName' from First and Last names
        var fullName = NameHelpers.BuildFullName(
            model.GuestFirstName,
            model.GuestLastName);

        // 3. Mapp 'Reservation' to 'GoogleReservation' model
        var google = new GoogleReservation
        {
            StartDate = DateFormatting.ToDateString(model.CheckIn),
            EndDate = DateFormatting.ToDateString(model.CheckOut),
            GuestFullName = fullName
        };

        return google;
    }
}
