// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenAI.TestFramework.Utils;

/// <summary>
/// Converter for types that implement <see cref="IUtf8JsonSerializable"/>.
/// </summary>
public class Utf8JsonSerializableConverter : JsonConverter<IUtf8JsonSerializable>
{
    /// <inheritdoc />
    public override bool CanConvert(Type typeToConvert)
        => typeof(IUtf8JsonSerializable).IsAssignableFrom(typeToConvert);

    /// <inheritdoc />
    public override IUtf8JsonSerializable Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => throw new NotSupportedException("Only writing JSON is supported");

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, IUtf8JsonSerializable value, JsonSerializerOptions options)
        => value.Write(writer);
}
