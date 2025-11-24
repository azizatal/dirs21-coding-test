namespace DynamicMapping.Google.MappingProfiles;

using DynamicMapping.Google.Validations;
using DynamicMapping.Google.Models;
using DynamicMapping.Model;
using DynamicMapping.Core;

/// <summary>
/// Mapping profile to convert internal 'Room' model to 'GoogleRoom'.
/// </summary>
public class ModelToGoogleRoomProfile : MappingProfileBase<Room, GoogleRoom>
{
    public override string SourceType => "Model.Room";
    public override string TargetType => "Google.Room";

    public override GoogleRoom Map(Room model)
    {
        // 1. Validate internal Room model before mapping out
        ModelToGoogleRoomValidator.Validate(SourceType, TargetType, model);

        // 2. Map 'Room' to 'GoogleRoom' model
        var google = new GoogleRoom
        {
            RoomNumber = model.RoomCode,
            MaxCapacity = model.MaxCapacity
        };

        return google;
    }
}
