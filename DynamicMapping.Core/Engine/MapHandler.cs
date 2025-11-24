namespace DynamicMapping.Core.Engine;

using DynamicMapping.Core.Excpetions;

/// <summary>
/// Executes mappings by resolving the correct profile and invoking it.
/// </summary>
public class MapHandler
{
    private readonly ProfileRegistry _registry;

    /// <summary>
    /// Creates a new handler using the given profile registry.
    /// </summary>
    public MapHandler(ProfileRegistry registry)
    {
        _registry = registry;
    }

    /// <summary>
    /// Maps the given data using the profile for the specified source and target types.
    /// </summary>
    public object Map(object data, string sourceType, string targetType)
    {
        if (data is null)
            throw MappingException.ObjectRequired(sourceType, targetType);

        var profile = _registry.Resolve(sourceType, targetType)
            ?? throw MappingException.ProfileNotFound(sourceType, targetType);

        return profile.Map(data);
    }
}
