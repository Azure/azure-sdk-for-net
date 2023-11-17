// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    internal static class ConfigurationServiceSerializer
    {
        public static void WriteSetting(Utf8JsonWriter writer, ConfigurationSetting setting)
        {
            writer.WriteStartObject();
            writer.WriteString("key", setting.Key);
            writer.WriteString("label", setting.Label);

            if (setting.IsReadOnly != default)
            {
                writer.WriteBoolean("locked", setting.IsReadOnly.Value);
            }

            if (setting.LastModified != default)
            {
                writer.WriteString("last_modified", setting.LastModified.Value.ToString(CultureInfo.InvariantCulture));
            }

            WriteRequestBody(writer, setting);
            writer.WriteEndObject();
        }

        public static ReadOnlyMemory<byte> SerializeRequestBody(ConfigurationSetting setting)
        {
            var writer = new Core.ArrayBufferWriter<byte>();
            using var json = new Utf8JsonWriter(writer);
            json.WriteStartObject();
            WriteRequestBody(json, setting);
            json.WriteEndObject();
            json.Flush();
            return writer.WrittenMemory;
        }

        private static void WriteRequestBody(Utf8JsonWriter writer, ConfigurationSetting setting)
        {
            writer.WriteString("value", setting.Value);
            writer.WriteString("content_type", setting.ContentType);
            if (setting.Tags != null)
            {
                writer.WriteStartObject("tags");
                foreach (System.Collections.Generic.KeyValuePair<string, string> tag in setting.Tags)
                {
                    writer.WriteString(tag.Key, tag.Value);
                }

                writer.WriteEndObject();
            }

            if (setting.ETag != default)
            {
                writer.WriteString("etag", setting.ETag.ToString());
            }
        }

        public static ConfigurationSetting ReadSetting(ref Utf8JsonReader reader)
        {
            using JsonDocument json = JsonDocument.ParseValue(ref reader);
            JsonElement root = json.RootElement;
            return ReadSetting(root);
        }

        public static ConfigurationSetting ReadSetting(JsonElement root)
        {
            ConfigurationSetting setting;

            if (IsFeatureFlag(root))
            {
                setting = new FeatureFlagConfigurationSetting();
            }
            else if (IsSecretReference(root))
            {
                setting = new SecretReferenceConfigurationSetting();
            }
            else
            {
                setting = new ConfigurationSetting();
            }

            foreach (JsonProperty property in root.EnumerateObject())
            {
                ReadPropertyValue(setting, property);
            }

            return setting;
        }

        private static bool IsSecretReference(JsonElement settingElement)
        {
            return settingElement.TryGetProperty("content_type", out var contentTypeProperty) &&
                   contentTypeProperty.ValueKind == JsonValueKind.String &&
                   contentTypeProperty.GetString() == SecretReferenceConfigurationSetting.SecretReferenceContentType;
        }

        private static bool IsFeatureFlag(JsonElement settingElement)
        {
            return settingElement.TryGetProperty("content_type", out var contentTypeProperty) &&
                   contentTypeProperty.ValueKind == JsonValueKind.String &&
                   contentTypeProperty.GetString() == FeatureFlagConfigurationSetting.FeatureFlagContentType &&
                   settingElement.TryGetProperty("key", out var keyProperty) &&
                   keyProperty.ValueKind == JsonValueKind.String &&
                   keyProperty.GetString().StartsWith(FeatureFlagConfigurationSetting.KeyPrefix, StringComparison.Ordinal);
        }

        private static void ReadPropertyValue(ConfigurationSetting setting, JsonProperty property)
        {
            if (property.NameEquals("content_type"))
            {
                setting.ContentType = property.Value.GetString();
            }
            else if (property.NameEquals("etag"))
            {
                setting.ETag = new ETag(property.Value.GetString());
            }
            else if (property.NameEquals("key"))
            {
                setting.Key = property.Value.GetString();
            }
            else if (property.NameEquals("label"))
            {
                setting.Label = property.Value.GetString();
            }
            else if (property.NameEquals("last_modified"))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    setting.LastModified = null;
                }
                else
                {
                    setting.LastModified = DateTimeOffset.Parse(property.Value.GetString(), CultureInfo.InvariantCulture);
                }
            }
            else if (property.NameEquals("locked"))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    setting.IsReadOnly = null;
                }
                else
                {
                    setting.IsReadOnly = property.Value.GetBoolean();
                }
            }
            else if (property.NameEquals("tags"))
            {
                foreach (JsonProperty element in property.Value.EnumerateObject())
                {
                    setting.Tags.Add(element.Name, element.Value.GetString());
                }
            }
            else if (property.NameEquals("value"))
            {
                setting.Value = property.Value.GetString();
            }
        }

        public static async Task<ConfigurationSetting> DeserializeSettingAsync(BinaryData content, CancellationToken cancellation)
        {
            using (JsonDocument json = await JsonDocument.ParseAsync(content.ToStream(), default, cancellation).ConfigureAwait(false))
            {
                JsonElement root = json.RootElement;
                return ReadSetting(root);
            }
        }

        public static ConfigurationSetting DeserializeSetting(BinaryData content)
        {
            using JsonDocument json = JsonDocument.Parse(content.ToMemory(), default);
            JsonElement root = json.RootElement;
            return ReadSetting(root);
        }
    }
}
