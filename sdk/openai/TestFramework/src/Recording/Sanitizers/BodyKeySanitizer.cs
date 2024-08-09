// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OpenAI.TestFramework.Recording.Sanitizers;

/// <summary>
/// Sanitizer for a request body that matches a particular value in JSON using a JPath expression.
/// </summary>
public class BodyKeySanitizer : BaseRegexSanitizer
{
    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="jsonPath">The JSON path to match.</param>
    /// <exception cref="ArgumentNullException">If the JSON path is null.</exception>
    public BodyKeySanitizer(string jsonPath) : base("BodyKeySanitizer")
    {
        JsonPath = jsonPath ?? throw new ArgumentNullException(nameof(jsonPath));
    }

    /// <summary>
    /// The JPath expression to match a particular value to sanitize.
    /// </summary>
    public string JsonPath { get; }
}
