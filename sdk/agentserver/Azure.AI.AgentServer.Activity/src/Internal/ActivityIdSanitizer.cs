// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.RegularExpressions;

namespace Azure.AI.AgentServer.Activity.Internal;

/// <summary>
/// Validates and sanitizes activity and session IDs for safe use in HTTP headers and logs.
/// Accepts alphanumeric characters plus <c>-_.:</c> up to 256 characters.
/// Returns a fallback UUID for invalid or oversized values.
/// </summary>
internal static partial class ActivityIdSanitizer
{
    private const int MaxIdLength = 256;

    [GeneratedRegex(@"^[a-zA-Z0-9\-_.:]+$")]
    private static partial Regex SafeIdPattern();

    /// <summary>
    /// Sanitizes an ID value. Returns the original value if it passes validation,
    /// or a generated UUID if it is null, empty, too long, or contains unsafe characters.
    /// </summary>
    internal static string Sanitize(string? value)
    {
        if (string.IsNullOrEmpty(value)
            || value.Length > MaxIdLength
            || !SafeIdPattern().IsMatch(value))
        {
            return Guid.NewGuid().ToString();
        }

        return value;
    }
}
