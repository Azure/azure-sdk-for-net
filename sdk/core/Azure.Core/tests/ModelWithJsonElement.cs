// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Core.Tests
{
    internal class ModelWithJsonElement : IUtf8JsonSerializable
    {
        public string A { get; set; }
        public JsonElement Properties { get; set; }

        public ModelWithJsonElement() { }

        private ModelWithJsonElement(string a, JsonElement properties)
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
                Properties.WriteTo(writer);
            }
            writer.WriteEndObject();
        }

        internal static ModelWithJsonElement DeserializeModelWithJsonElement(JsonElement element)
        {
            Optional<string> a = default;
            Optional<JsonElement> properties = default;
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
                    properties = property.Value;
                    continue;
                }
            }
            return new ModelWithJsonElement(a.Value, properties.Value);
        }
    }
}
