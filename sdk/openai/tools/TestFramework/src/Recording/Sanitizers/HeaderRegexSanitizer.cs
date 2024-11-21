// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Recording.Sanitizers;

/// <summary>
/// Sanitizer for a request header.
/// </summary>
public class HeaderRegexSanitizer : BaseRegexSanitizer
{
    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="key">The header to sanitize.</param>
    /// <exception cref="ArgumentNullException">If the <paramref name="key"/> is null.</exception>
    public HeaderRegexSanitizer(string key) : base("HeaderRegexSanitizer")
    {
        Key = key ?? throw new ArgumentNullException(nameof(key));
    }

    /// <summary>
    /// The name of the header to sanitize.
    /// </summary>
    public string Key { get; }
}
