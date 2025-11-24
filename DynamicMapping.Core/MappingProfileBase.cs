namespace DynamicMapping.Core;

using DynamicMapping.Core.Excpetions;
using DynamicMapping.Core.Interfaces;

/// <summary>
/// Base class for strongly-typed mapping profiles, defining source/target type
/// identifiers and providing a typed <see cref="Map(TSource)"/> implementation with
/// an object-based adapter used by the mapping system.
/// </summary>
public abstract class MappingProfileBase<TSourceModel, TTargetModel> : IMappingProfile
{
    // Mapping Profile identifiers
    public abstract string SourceType { get; }                 
    public abstract string TargetType { get; }

    /// <summary>
    /// Performs the strongly typed mapping from <typeparamref name="TSource"/> to <typeparamref name="TTarget"/>.
    /// </summary>
    public abstract TTargetModel Map(TSourceModel source);

    /// <summary>
    /// Adapts the typed mapping method for the untyped mapping system 
    /// by checking the input and delegating to <see cref="Map(TSource)"/>.
    /// </summary>
    public object Map(object source)
    {
        if (source is null)
            throw MappingException.ObjectRequired(SourceType,TargetType);

        if (source is not TSourceModel typed)
            throw MappingException.InvalidSourceObject(SourceType, TargetType, nameof(source));

        return Map(typed)!;
    }
}