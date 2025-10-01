// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using System.Text.Json;
using System.IO;

namespace Azure.Core.Tests
{
    public class ModelWithBinaryData : IUtf8JsonSerializable
    {
        public string A { get; set; }
        public BinaryData Properties { get; set; }

        public ModelWithBinaryData() { }

        private ModelWithBinaryData(string a, BinaryData properties)
        {
            A = a;
            Properties = properties;
        }

        public void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(A))
            {
                writer.WritePropertyName("a");
                writer.WriteStringValue(A);
            }
            if (Optional.IsDefined(Properties))
            {
                writer.WritePropertyName("properties");
#if NET6_0_OR_GREATER
                writer.WriteRawValue(Properties);
#else
                JsonSerializer.Serialize(writer, JsonDocument.Parse(Properties.ToString()).RootElement);
#endif
            }
            writer.WriteEndObject();
        }

        public static ModelWithBinaryData DeserializeModelWithBinaryData(JsonElement element)
        {
            Optional<string> a = default;
            Optional<BinaryData> properties = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("a"))
                {
                    a = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    properties = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
            }
            return new ModelWithBinaryData(a.Value, properties.Value);
        }
    }
}