// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using System.Text.Json;

namespace Azure.Core.Tests
{
    public class ModelWithObject : IUtf8JsonSerializable
    {
        public string A { get; set; }
        public object Properties { get; set; }

        public ModelWithObject() { }

        private ModelWithObject(string a, object properties)
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
                writer.WriteObjectValue(Properties);
            }
            writer.WriteEndObject();
        }

        public static ModelWithObject DeserializeModelWithObject(JsonElement element)
        {
            Optional<string> a = default;
            Optional<object> properties = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("a"))
                {
                    a = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    properties = property.Value.GetObject();
                    continue;
                }
            }
            return new ModelWithObject(a.Value, properties.Value);
        }
    }
}