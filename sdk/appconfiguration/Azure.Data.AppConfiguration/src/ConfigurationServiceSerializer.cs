// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
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
            writer.WriteBooleanIfNotNull("locked", setting.IsReadOnly);
            writer.WriteStringIfNotNull("last_modified", setting.LastModified?.ToString(CultureInfo.InvariantCulture));

            WriteRequestBody(writer, setting);

            writer.WriteEndObject();
        }

        public static ReadOnlyMemory<byte> SerializeRequestBody(ConfigurationSetting setting)
        {
            var writer = new ArrayBufferWriter<byte>();

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
            writer.WriteDictionaryIfNotNull("tags", setting.Tags);
            writer.WriteStringIfNotNull("etag", setting.ETag != default ? setting.ETag.ToString() : null);
        }

        public static ConfigurationSetting ReadSetting(ref Utf8JsonReader reader)
        {
            using JsonDocument json = JsonDocument.ParseValue(ref reader);
            JsonElement root = json.RootElement;
            return ReadSetting(root);
        }

        private static ConfigurationSetting ReadSetting(JsonElement root)
        {
            // TODO (pri 2): make the deserializer version resilient
            var setting = new ConfigurationSetting();
            foreach (JsonProperty property in root.EnumerateObject())
            {
                ReadPropertyValue(setting, property);
            }
            return setting;
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
                setting.LastModified = property.GetDateTimeOffsetOrNull();
            }
            else if (property.NameEquals("locked"))
            {
                setting.IsReadOnly = property.GetBooleanOrNull();
            }
            else if (property.NameEquals("tags"))
            {
                property.ReadToDictionary(setting.Tags);
            }
            else if (property.NameEquals("value"))
            {
                setting.Value = property.Value.GetString();
            }
        }

        public static async Task<ConfigurationSetting> DeserializeSettingAsync(Stream content, CancellationToken cancellation)
        {
            using JsonDocument json = await JsonDocument.ParseAsync(content, default, cancellation).ConfigureAwait(false);
            JsonElement root = json.RootElement;
            return ReadSetting(root);
        }

        public static ConfigurationSetting DeserializeSetting(Stream content)
        {
            using JsonDocument json = JsonDocument.Parse(content, default);
            JsonElement root = json.RootElement;
            return ReadSetting(root);
        }

        public static async Task<SettingBatch> ParseBatchAsync(Response response, CancellationToken cancellation)
        {
            Stream content = response.ContentStream;
            using (JsonDocument json = await JsonDocument.ParseAsync(content, cancellationToken: cancellation).ConfigureAwait(false))
            {
                return ParseSettingBatch(response, json);
            }
        }

        public static SettingBatch ParseBatch(Response response)
        {
            Stream content = response.ContentStream;
            using (JsonDocument json = JsonDocument.Parse(content))
            {
                return ParseSettingBatch(response, json);
            }
        }

        private static SettingBatch ParseSettingBatch(Response response, JsonDocument json)
        {
            TryGetNextAfterValue(ref response, out string nextBatchUri);

            JsonElement itemsArray = json.RootElement.GetProperty("items");
            int length = itemsArray.GetArrayLength();
            ConfigurationSetting[] settings = new ConfigurationSetting[length];

            int i = 0;
            foreach (JsonElement item in itemsArray.EnumerateArray())
            {
                settings[i++] = ReadSetting(item);
            }

            return new SettingBatch(settings, nextBatchUri);
        }

        private const string Link = "Link";
        private const string After = "after=";
        private static bool TryGetNextAfterValue(ref Response response, out string afterValue)
        {
            afterValue = default;
            if (!response.Headers.TryGetValue(Link, out var headerValue))
                return false;

            // the headers value is something like this: "</kv?after={token}>; rel=\"next\""
            var afterIndex = headerValue.IndexOf(After, StringComparison.Ordinal);
            if (afterIndex < 0)
                return false;

            int beginingToken = afterIndex + After.Length;
            int endToken = headerValue.IndexOf(">", StringComparison.Ordinal);
            int tokenLenght = endToken - beginingToken;
            afterValue = headerValue.Substring(beginingToken, tokenLenght);
            return true;
        }
    }
}
