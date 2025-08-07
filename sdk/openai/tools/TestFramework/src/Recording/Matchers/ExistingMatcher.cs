// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace OpenAI.TestFramework.Recording.Matchers;

/// <summary>
/// Used for specifying the use of pre-existing matchers defined in the test proxy.
/// </summary>
/// <param name="existingMatcherName">The name of the existing matcher.</param>
public class ExistingMatcher(string existingMatcherName) : BaseMatcher(existingMatcherName)
{
    private static ExistingMatcher? _bodiless = null;
    private static ExistingMatcher? _headerless = null;

    /// <summary>
    /// This matcher adjusts the "match" operation to EXCLUDE the body when matching a request to a recording's entries.
    /// </summary>
    public static ExistingMatcher Bodiless => _bodiless ??= new ExistingMatcher("BodilessMatcher");

    /// <summary>
    /// NOT RECOMMENDED. This matcher adjusts the "match" operation to ignore header differences when matching a request.
    /// Be aware that wholly ignoring headers during matching might incur unexpected issues down the line.
    /// </summary>
    public static ExistingMatcher Headerless => _headerless ??= new ExistingMatcher("HeaderlessMatcher");

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, JsonSerializerOptions? options = null)
    {
        // Pre-existing matchers use an empty JSON object.
        writer.WriteStartObject();
        writer.WriteEndObject();
    }
}
