// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;
using OpenAI.TestFramework.Utils;

namespace OpenAI.TestFramework.Recording.Sanitizers;

/// <summary>
/// The base class for all test proxy recording sanitizers
/// </summary>
public abstract class BaseSanitizer : IUtf8JsonSerializable
{
    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="type">The type of this sanitizer (e.g. GeneralRegexSanitizer).</param>
    /// <exception cref="ArgumentNullException">If the type was null.</exception>
    protected BaseSanitizer(string type)
    {
        Type = type ?? throw new ArgumentNullException(nameof(Type));
    }

    /// <summary>
    /// Gets the type of the sanitizer (e.g. HeaderRegexSanitizer).
    /// </summary>
    [JsonIgnore]
    public string Type { get; }

    /// <inheritdoc />
    public void Write(Utf8JsonWriter writer, JsonSerializerOptions? options = null)
    {
        writer.WriteStartObject();
        {
            writer.WriteString("Name"u8, Type);
            writer.WritePropertyName("Body"u8);

            SerializeInner(writer, options);
        }
        writer.WriteEndObject();
    }

    /// <summary>
    /// Serializes the child types. By default this will use reflection based serialization.
    /// </summary>
    /// <param name="writer">The writer to write to.</param>
    protected virtual void SerializeInner(Utf8JsonWriter writer, JsonSerializerOptions? options = null)
    {
        // By default use reflection based serialization
        JsonSerializer.Serialize(writer, this, GetType(), Default.InnerRecordingJsonOptions);
    }
}
