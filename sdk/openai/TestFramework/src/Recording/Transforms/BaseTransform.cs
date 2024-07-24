// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;
using OpenAI.TestFramework.Recording.Common;

namespace OpenAI.TestFramework.Recording.Transforms;

/// <summary>
/// Base class for test recording proxy transforms. Transforms are applied when returning a request during playback.
/// </summary>
public abstract class BaseTransform : IUtf8JsonSerializable
{
    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="type">The type of this sanitizer (e.g. GeneralRegexSanitizer).</param>
    /// <exception cref="ArgumentNullException">If the type was null.</exception>
    protected BaseTransform(string type)
    {
        Type = type ?? throw new ArgumentNullException(nameof(Type));
    }

    /// <summary>
    /// Gets the type of the sanitizer (e.g. HeaderRegexSanitizer).
    /// </summary>
    [JsonIgnore]
    public string Type { get; }

    /// <inheritdoc />
    public virtual void Write(Utf8JsonWriter writer)
    {
        JsonSerializer.Serialize(writer, this, Default.RecordingJsonOptions);
    }
}
