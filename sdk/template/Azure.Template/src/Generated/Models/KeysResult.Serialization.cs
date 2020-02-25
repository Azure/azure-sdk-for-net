// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Template.Models
{
    public partial class KeysResult : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("clusters");
            writer.WriteStartObject();
            foreach (var item in Clusters)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStartArray();
                foreach (var item0 in item.Value)
                {
                    writer.WriteStringValue(item0);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
        internal static KeysResult DeserializeKeysResult(JsonElement element)
        {
            KeysResult result = new KeysResult();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("clusters"))
                {
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        System.Collections.Generic.ICollection<string> value = new System.Collections.Generic.List<string>();
                        foreach (var item in property0.Value.EnumerateArray())
                        {
                            value.Add(item.GetString());
                        }
                        result.Clusters.Add(property0.Name, value);
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
