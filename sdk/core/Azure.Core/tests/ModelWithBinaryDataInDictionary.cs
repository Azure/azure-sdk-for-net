// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace Azure.Core.Tests
{
    internal class ModelWithBinaryDataInDictionary : IUtf8JsonSerializable
    {
        public string A { get; set; }
        public IReadOnlyDictionary<string, BinaryData> Details { get; set; }

        public ModelWithBinaryDataInDictionary() { }

        private ModelWithBinaryDataInDictionary(string a, IReadOnlyDictionary<string, BinaryData> details)
        {
            A = a;
            Details = details;
        }

        public void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(A))
            {
                writer.WritePropertyName("a");
                writer.WriteStringValue(A);
            }
            if (Optional.IsDefined(Details))
            {
                //THIS DOESN'T WORK WITH OUR CURRENT AUTOREST
                writer.WritePropertyName("details");
                writer.WriteStartObject();
                foreach (var kv in Details)
                {
                    writer.WritePropertyName(kv.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(kv.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(kv.Value.ToString()).RootElement);
#endif
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        internal static ModelWithBinaryDataInDictionary DeserializeModelWithBinaryDataInDictionary(JsonElement element)
        {
            Optional<string> a = default;
            Optional<IReadOnlyDictionary<string, BinaryData>> details = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("a"))
                {
                    a = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("details"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    Dictionary<string, BinaryData> dictionary = new Dictionary<string, BinaryData>();
                    foreach (var property1 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property1.Name, BinaryData.FromString(property1.Value.GetRawText()));
                    }
                    details = dictionary;
                    continue;
                }
            }
            return new ModelWithBinaryDataInDictionary(a.Value, details.Value);
        }
    }
}
