namespace DynamicMapping.Core.Excpetions;

/// <summary>
/// Custom exceptions thrown when any mapping fails.
/// </summary>
public class MappingException : Exception
{
    public string SourceType { get; }
    public string TargetType { get; }
    public string UserMessage { get; }

    public MappingException(
        string sourceType,
        string targetType,
        string userMessage,
        Exception? inner = null)
        : base(BuildMessage(sourceType, targetType, userMessage), inner)
    {
        SourceType = sourceType;
        TargetType = targetType;
        UserMessage = userMessage;
    }

    private static string BuildMessage(
        string sourceType,
        string targetType,
        string message)
    {
            return 
$@"Source : {sourceType}
Target    : {targetType}
Message   : Mapping failed. -> {message}";
    }

    // -------- Factory Methods --------

    /// <summary>
    /// Mapping exception for a required object that is null.
    /// </summary>
 
    public static MappingException ObjectRequired(string sourceType,string targetType)
        => new(sourceType, targetType, "Mapping failed. -> Required mapping data object is null.");

    /// <summary>
    /// Mapping exception for missing mapping profile.
    /// </summary>
    
    public static MappingException ProfileNotFound(string sourceType, string targetType)
        => new(sourceType, targetType, "Mapping profile not found.");

    /// <summary>
    /// Mapping exception for duplicated mapping profile to register.
    /// </summary>

    public static MappingException DuplicateProfile(string sourceType, string targetType, string key)
        => new(sourceType, targetType, $"Duplicated mapping profile with the key '{key}'.");

    /// <summary>
    /// Mapping exception for invalid source object.
    /// </summary>
    /// 
    public static MappingException InvalidSourceObject(
        string sourceType, string targetType, string ObjectName, Exception? inner=null)
        => new(sourceType, targetType, $"Invalid source object '{ObjectName}' provided.", inner);

    /// <summary>
    /// Mapping exception for type conversion errors.
    /// </summary>

    public static MappingException ConversionError(
        string sourceType, string targetType, Exception? inner=null)
        => new(sourceType, targetType, "Type conversion failed.", inner);
}
