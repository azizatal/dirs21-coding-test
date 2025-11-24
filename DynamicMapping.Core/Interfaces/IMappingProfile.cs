namespace DynamicMapping.Core.Interfaces;

/// <summary>
/// Defines a mapping profile that converts a source type into a target type.
/// </summary>
public interface IMappingProfile
{
    /// <summary>
    /// Identifier of the supported source type.
    /// </summary>
    string SourceType { get; }

    /// <summary>
    /// Identifier of the produced target type.
    /// </summary>
    string TargetType { get; }

    /// <summary>
    /// Maps the given source object to its target representation.
    /// </summary>
    object Map(object source);
}
