namespace DynamicMapping.Google.MappingProfiles;

using DynamicMapping.Google.Validations;
using DynamicMapping.Google.Models;
using DynamicMapping.Model;
using DynamicMapping.Core;

/// <summary>
/// Mapping profile to convert 'GoogleRoom' to internal 'Room' model.
/// </summary>
public class GoogleToModelRoomProfile : MappingProfileBase<GoogleRoom, Room>
{
    public override string SourceType => "Google.Room";
    public override string TargetType => "Model.Room";

    public override Room Map(GoogleRoom google)
    {
        // 1. Validate incoming GoogleRoom before mapping
        GoogleToModelRoomValidator.Validate(SourceType, TargetType, google);

        // 2. Map 'GoogleRoom' to internal 'Room' model
        return new Room
        {
            Id = Guid.NewGuid(),
            RoomCode = google.RoomNumber,
            MaxCapacity = google.MaxCapacity,
            DataSource = PartnerType.Google
        };
    }
}
