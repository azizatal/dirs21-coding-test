namespace DynamicMapping.Shared.Excpetions;

/// <summary>
/// Custom exceptions thrown when a field's validation fails.
/// Additional mapping details are provided via the <see cref="MappingException"/> base class.
/// </summary>
/// <param name="sourceType">To map source type in <see cref="MappingException"/> if error occurred.</param>
/// <param name="targetType">To map target type in <see cref="MappingException"/> if error occurred.</param>
public sealed class ValidationException : Exception
{
    public string SourceType { get; }
    public string TargetType { get; }
    public string UserMessage { get; }

    public ValidationException(
        string sourceType,
        string targetType,
        string userMessage,
        Exception? inner = null)
        : base(BuildMessage(sourceType, targetType,userMessage), inner)
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
$@"Source    : {sourceType}
Target    : {targetType}
Message   : Validation failed. -> {message}";
    }

    // -------- Factory Methods --------

        /// <summary>
        /// Exception for a required object that is null.
        /// </summary>
    public static ValidationException ObjectRequired(
        string sourceType,
        string targetType,
        string objectName)
        => new(
            sourceType,
            targetType,
            $"Object={objectName}. Reason=The required object is null."
        );

    /// <summary>
    /// Exception for a required field that is missing or empty.
    /// </summary>
    public static ValidationException FieldRequired(
        string sourceType,
        string targetType,
        string field)
        => new(
            sourceType,
            targetType,
            $"Field={field}. Reason=Required field is missing."
        );
    /// <summary>
    /// Exception for invalid date order between two fields.
    /// </summary>
    public static ValidationException InvalidDateOrder(
        string sourceType,
        string targetType,
        string earlierDate,
        string laterDate)
        => new(
            sourceType,
            targetType,
            $"EarlierField={earlierDate}, LaterField={laterDate}. Reason=Invalid chronological order."
        );

    /// <summary>
    /// Creates a <see cref="ValidationException"/> for an invalid field value.
    /// </summary>
    /// <param name="reason">The explanation of why the value is invalid.</param>
    public static ValidationException InvalidInput(
        string sourceType,
        string targetType,
        string field,
        string value,
        string reason)
        => new(
            sourceType,
            targetType,
            $"Field={field} Value={value}. Reason={reason}."
        );
}
