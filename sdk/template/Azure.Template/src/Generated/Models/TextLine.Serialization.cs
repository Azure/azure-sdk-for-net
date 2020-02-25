// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class TextLine : IUtf8JsonSerializable
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
            if (Language != null)
            {
                writer.WritePropertyName("language");
                writer.WriteStringValue(Language.Value.ToString());
            }
            writer.WritePropertyName("words");
            writer.WriteStartArray();
            foreach (var item0 in Words)
            {
                writer.WriteObjectValue(item0);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
        internal static TextLine DeserializeTextLine(JsonElement element)
        {
            TextLine result = new TextLine();
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
                if (property.NameEquals("language"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Language = new Language(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("words"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Words.Add(TextWord.DeserializeTextWord(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
