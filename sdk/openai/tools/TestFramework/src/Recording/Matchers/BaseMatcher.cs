// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;
using OpenAI.TestFramework.Utils;

namespace OpenAI.TestFramework.Recording.Matchers;

/// <summary>
/// The base class for matchers that are applied during a playback session to match an incoming request
/// to a recorded one.
/// </summary>
public abstract class BaseMatcher : IUtf8JsonSerializable
{
    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="type">The type of this sanitizer (e.g. GeneralRegexSanitizer).</param>
    /// <exception cref="ArgumentNullException">If the type was null.</exception>
    protected BaseMatcher(string type)
    {
        Type = type ?? throw new ArgumentNullException(nameof(type));
    }

    /// <summary>
    /// Gets the type of the matcher (e.g. BodilessMatcher).
    /// </summary>
    [JsonIgnore]
    public string Type { get; }

    /// <inheritdoc />
    public virtual void Write(Utf8JsonWriter writer, JsonSerializerOptions? options = null)
    {
        // By default use reflection based serialization
        JsonSerializer.Serialize(writer, this, GetType(), Default.InnerRecordingJsonOptions);
    }
}
