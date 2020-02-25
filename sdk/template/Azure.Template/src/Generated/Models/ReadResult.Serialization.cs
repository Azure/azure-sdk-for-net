// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Template.Models
{
    public partial class ReadResult : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("page");
            writer.WriteNumberValue(Page);
            writer.WritePropertyName("angle");
            writer.WriteNumberValue(Angle);
            writer.WritePropertyName("width");
            writer.WriteNumberValue(Width);
            writer.WritePropertyName("height");
            writer.WriteNumberValue(Height);
            writer.WritePropertyName("unit");
            writer.WriteStringValue(Unit.ToSerialString());
            if (Language != null)
            {
                writer.WritePropertyName("language");
                writer.WriteStringValue(Language.Value.ToString());
            }
            if (Lines != null)
            {
                writer.WritePropertyName("lines");
                writer.WriteStartArray();
                foreach (var item in Lines)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static ReadResult DeserializeReadResult(JsonElement element)
        {
            ReadResult result = new ReadResult();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("page"))
                {
                    result.Page = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("angle"))
                {
                    result.Angle = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("width"))
                {
                    result.Width = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("height"))
                {
                    result.Height = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("unit"))
                {
                    result.Unit = property.Value.GetString().ToLengthUnit();
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
                if (property.NameEquals("lines"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Lines = new List<TextLine>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Lines.Add(TextLine.DeserializeTextLine(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
