namespace DynamicMapping.Core.Engine;

using DynamicMapping.Core.Excpetions;
using DynamicMapping.Core.Interfaces;
using System.Collections.Generic;

/// <summary>
/// Stores and resolves mapping profiles using source and target type pairs.
/// </summary>
public class ProfileRegistry
{
    // Registers all provided mapping profiles.
    // Key: (SourceType, TargetType), Value: IMappingProfile
    private readonly Dictionary<(string, string), IMappingProfile> _profiles = new();

    /// <summary>
    /// Registers all provided mapping profiles at startup.
    /// </summary>
    public ProfileRegistry(IEnumerable<IMappingProfile> profiles)
    {
        foreach (var profile in profiles)
        {
            Register(profile);
        }
    }

    /// <summary>
    /// Helper method to the constructor to add a profile to the registry and ensures no duplicates exist.
    /// </summary>
    private void Register(IMappingProfile profile)
    {
        var key = (profile.SourceType.Trim(), profile.TargetType.Trim());

        if (_profiles.ContainsKey(key))
            throw MappingException.DuplicateProfile(profile.SourceType, profile.TargetType, key.ToString());

        _profiles[key] = profile;
    }

    // <summary>
    /// Returns the profile for the given source and target types, or null if not found.
    /// </summary>
    public IMappingProfile? Resolve(string sourceType, string targetType)
    {
        var key = (sourceType.Trim(), targetType.Trim());
        _profiles.TryGetValue(key, out var profile);
        return profile;
    }
}
