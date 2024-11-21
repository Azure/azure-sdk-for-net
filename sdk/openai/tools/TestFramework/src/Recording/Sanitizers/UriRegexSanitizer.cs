// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Recording.Sanitizers;

/// <summary>
/// Sanitizer for a request URI.
/// </summary>
public class UriRegexSanitizer : BaseRegexSanitizer
{
    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="regex">The regular expression to match in the request URI.</param>
    /// <exception cref="ArgumentNullException">If the regular expression is null.</exception>
    public UriRegexSanitizer(string regex) : base("UriRegexSanitizer")
    {
        Regex = regex ?? throw new ArgumentNullException(nameof(regex));
    }
}
