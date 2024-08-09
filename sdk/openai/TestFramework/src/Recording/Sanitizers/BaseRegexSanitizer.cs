// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Recording.Sanitizers;

/// <summary>
/// The case class for regex based sanitizers
/// </summary>
public abstract class BaseRegexSanitizer(string type) : BaseSanitizer(type)
{
    /// <summary>
    /// Gets the regular expression to match what to replace.
    /// </summary>
    public string? Regex { get; set; }

    /// <summary>
    /// Gets or sets the value to replace the match with.
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// Gets or sets the group in the regex match to replace.
    /// </summary>
    public string? GroupForReplace { get; set; }
}
