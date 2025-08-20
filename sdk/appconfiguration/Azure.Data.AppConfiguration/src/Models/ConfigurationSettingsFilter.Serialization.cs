// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    public partial class ConfigurationSettingsFilter : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("key");
            writer.WriteStringValue(Key);
            if (Optional.IsDefined(Label))
            {
                writer.WritePropertyName("label");
                writer.WriteStringValue(Label);
            }
            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags");
                writer.WriteStartArray();
                foreach (var item in Tags)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static ConfigurationSettingsFilter DeserializeKeyValueFilter(JsonElement element)
        {
            string key = default;
            string label = default;
            List<string> tags = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("key"))
                {
                    key = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("label"))
                {
                    label = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("tags"u8))
                {
                    tags = new List<string>();
                    foreach (JsonElement tag in property.Value.EnumerateArray())
                    {
                        tags.Add(tag.GetString());
                    }
                    continue;
                }
            }
            return new ConfigurationSettingsFilter(key, label, tags);
        }
    }
}
