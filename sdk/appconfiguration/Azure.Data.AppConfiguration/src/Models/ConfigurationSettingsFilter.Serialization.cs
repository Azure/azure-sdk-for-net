// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            writer.WriteEndObject();
        }

        internal static ConfigurationSettingsFilter DeserializeKeyValueFilter(JsonElement element)
        {
            string key = default;
            Optional<string> label = default;
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
            }
            return new ConfigurationSettingsFilter(key, label.Value);
        }
    }
}
