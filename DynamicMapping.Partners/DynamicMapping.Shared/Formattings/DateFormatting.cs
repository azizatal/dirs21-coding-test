namespace DynamicMapping.Shared.Formatting;

/// <summary>
/// Helper methods for formatting dates.
/// </summary>
public static class DateFormatting
{
    /// <summary>
    /// Formats a DateTime in the standard "yyyy-MM-dd" format used by partners like Google.
    /// </summary>
    public static string ToDateString(DateTime date)
        => date.ToString("yyyy-MM-dd");

    /// <summary>
    /// Formats an optional DateTime. Returns null if no date is provided.
    /// </summary>
    public static string ToDateString(DateTime? date)
    {
        if (date is null)
            return String.Empty;

        return date.Value.ToString("yyyy-MM-dd");
    }
}
