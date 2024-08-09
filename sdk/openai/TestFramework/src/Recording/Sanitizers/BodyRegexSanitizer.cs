// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Recording.Sanitizers;

/// <summary>
/// Sanitizer for the body of a request or response.
/// </summary>
public class BodyRegexSanitizer : BaseRegexSanitizer
{
    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="regex">Gets the regular expression to match what to replace.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="regex"/> was null.</exception>
    public BodyRegexSanitizer(string regex) : base("BodyRegexSanitizer")
    {
        Regex = regex ?? throw new ArgumentNullException(nameof(regex));
    }

    /// <summary>
    /// Condition to apply for the sanitization or transform. If the condition is not met, sanitization is not performed.
    /// </summary>
    public Condition? Condition { get; set; }
}
