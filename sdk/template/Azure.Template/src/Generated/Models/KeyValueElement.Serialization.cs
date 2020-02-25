// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class KeyValueElement : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("text");
            writer.WriteStringValue(Text);
            if (BoundingBox != null)
            {
                writer.WritePropertyName("boundingBox");
                writer.WriteStartArray();
                foreach (var item in BoundingBox)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (Elements != null)
            {
                writer.WritePropertyName("elements");
                writer.WriteStartArray();
                foreach (var item in Elements)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static KeyValueElement DeserializeKeyValueElement(JsonElement element)
        {
            KeyValueElement result = new KeyValueElement();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("text"))
                {
                    result.Text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("boundingBox"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.BoundingBox = new List<float>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.BoundingBox.Add(item.GetSingle());
                    }
                    continue;
                }
                if (property.NameEquals("elements"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Elements = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Elements.Add(item.GetString());
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
