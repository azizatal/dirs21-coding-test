namespace DynamicMapping.Shared.Parsers;

using DynamicMapping.Shared.Excpetions;
using System.Globalization;

/// <summary>
/// Provides helper methods to parse string date values into <see cref="DateTime"/> instances
/// with mapping-aware validation.
/// </summary>
/// <param name="sourceType">To map source type in <see cref="MappingException"/> if error occurred.</param>
/// <param name="targetType">To map target type in <see cref="MappingException"/> if error occurred.</param>
/// <param name="fieldName">The name of the field being validated.</param>
/// <param name="value">The string date value to parse.</param>
public static class DateParser
{
    /// <summary>
    /// Parses the specified string value into a <see cref="DateTime"/>. Throws an exception if the value is null,
    /// empty, or not a valid date.
    /// </summary>
    /// <param name="value">The string value to parse. Must not be null, empty, or whitespace.</param>
    /// <returns>The parsed <see cref="DateTime"/> value.</returns>
    public static DateTime ToDateRequired(string sourceType, string target, string fieldName, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw ValidationException.FieldRequired(sourceType, target, fieldName);

        // Use explicit format to avoid culture issues
        if (!DateTime.TryParseExact(
                value,
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var dt))
        {
            throw ValidationException.InvalidInput(
                sourceType,
                target,
                fieldName,
                value,
                "Expected a valid date in format 'yyyy-MM-dd'.");
        }

        return dt;
    }

    /// <summary>
    /// Parses the specified string value into a nullable <see cref="DateTime"/>.
    /// </summary>
    /// A <see cref="DateTime"/> representing the parsed date, or <see langword="null"/> if
    /// <paramref name="value"/> is null, empty, or consists only of whitespace.
    /// <returns>The parsed <see cref="DateTime?"/> value.</returns>
    public static DateTime? ToDateOptional(string sourceType, string target, string fieldName, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        if (!DateTime.TryParseExact(
                value,
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var dt))
        {
            throw ValidationException.InvalidInput(
                sourceType,
                target,
                fieldName,
                value,
                "Expected a valid date in format 'yyyy-MM-dd'.");
        }

        return dt;
    }
}
