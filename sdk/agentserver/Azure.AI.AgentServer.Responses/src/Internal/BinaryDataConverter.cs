// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// JSON converter for <see cref="BinaryData"/> values.
/// Preserves the raw JSON representation during serialization and deserialization.
/// </summary>
internal sealed class BinaryDataConverter : JsonConverter<BinaryData>
{
    /// <inheritdoc/>
    public override BinaryData? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var jsonString = document.RootElement.GetRawText();
        return BinaryData.FromString(jsonString);
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, BinaryData value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteRawValue(value.ToString());
    }
}
