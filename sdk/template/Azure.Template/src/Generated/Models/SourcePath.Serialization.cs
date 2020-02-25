// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class SourcePath : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Source != null)
            {
                writer.WritePropertyName("source");
                writer.WriteStringValue(Source);
            }
            writer.WriteEndObject();
        }
        internal static SourcePath DeserializeSourcePath(JsonElement element)
        {
            SourcePath result = new SourcePath();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("source"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Source = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
