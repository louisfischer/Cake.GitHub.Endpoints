namespace Cake.GitHub.Endpoints;

/// <summary>
/// Extension methods for <see cref="string"/>.
/// </summary>
internal static class StringExtensions
{
    /// <summary>
    /// Sanitizes a base64 string by removing any new line or carriage return characters.
    /// This is useful when the base64 string is being used in a context where these characters are not allowed.        
    /// </summary>
    /// <param name="value">Base64 string to sanitize</param>
    /// <returns>Sanitized base64 string</returns>
    public static string Base64Sanitize(this string value) => value?
        .Replace("\r", "")
        .Replace("\n", "")
        .TrimEnd('=')
        .Replace('+', '-')
        .Replace('/', '_') ?? string.Empty;
}