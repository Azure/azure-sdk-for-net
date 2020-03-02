// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class RawExtractedWord : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("text");
            writer.WriteStringValue(Text);
            writer.WritePropertyName("boundingBox");
            writer.WriteStartArray();
            foreach (var item in BoundingBox)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
            if (Confidence != null)
            {
                writer.WritePropertyName("confidence");
                writer.WriteNumberValue(Confidence.Value);
            }
            writer.WriteEndObject();
        }
        internal static RawExtractedWord DeserializeRawExtractedWord(JsonElement element)
        {
            RawExtractedWord result = new RawExtractedWord();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("text"))
                {
                    result.Text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("boundingBox"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.BoundingBox.Add(item.GetSingle());
                    }
                    continue;
                }
                if (property.NameEquals("confidence"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Confidence = property.Value.GetSingle();
                    continue;
                }
            }
            return result;
        }
    }
}
