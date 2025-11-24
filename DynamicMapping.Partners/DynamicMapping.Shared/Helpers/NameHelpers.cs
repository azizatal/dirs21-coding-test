namespace DynamicMapping.Shared.Helpers;

/// <summary>
/// Helpers to define simple mapping rules for names (e.g, string splitting or building names).
/// </summary>
public static class NameHelpers
{

    public static (string First, string Last) SplitFullName(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return (string.Empty, string.Empty);

        var parts = fullName.Trim()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 1)
            return (parts[0], string.Empty);

        return (parts[0], string.Join(" ", parts.Skip(1)));
    }

    public static string BuildFullName(string firstName, string lastName)
    {
        firstName = firstName?.Trim() ?? string.Empty;
        lastName = lastName?.Trim() ?? string.Empty;

        if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            return string.Empty;

        if (string.IsNullOrEmpty(lastName))
            return firstName;

        if (string.IsNullOrEmpty(firstName))
            return lastName;

        return $"{firstName} {lastName}";
    }
}
