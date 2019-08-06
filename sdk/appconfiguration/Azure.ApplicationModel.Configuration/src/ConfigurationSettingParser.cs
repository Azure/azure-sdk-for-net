// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Buffers;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Http;

namespace Azure.ApplicationModel.Configuration
{
    static class ConfigurationServiceSerializer
    {
        public static void Serialize(ConfigurationSetting setting, IBufferWriter<byte> writer)
        {
            var json = new Utf8JsonWriter(writer);
            json.WriteStartObject();
            json.WriteString("value", setting.Value);
            json.WriteString("content_type", setting.ContentType);
            if(setting.Tags != null)
            {
                json.WriteStartObject("tags");
                foreach (var tag in setting.Tags)
                {
                    json.WriteString(tag.Key, tag.Value);
                }
                json.WriteEndObject();
            }
            json.WriteEndObject();
            json.Flush();
        }

        private static ConfigurationSetting ReadSetting(JsonElement root)
        {
            // TODO (pri 2): make the deserializer version resilient
            var setting = new ConfigurationSetting();
            if (root.TryGetProperty("key", out var keyValue)) setting.Key = keyValue.GetString();
            if (root.TryGetProperty("value", out var value)) setting.Value = value.GetString();
            if (root.TryGetProperty("label", out var labelValue)) setting.Label = labelValue.GetString();
            if (root.TryGetProperty("content_type", out var contentValue)) setting.ContentType = contentValue.GetString();
            if (root.TryGetProperty("etag", out var eTagValue)) setting.ETag = new ETag(eTagValue.GetString());
            if (root.TryGetProperty("last_modified", out var lastModified))
            {
                if(lastModified.ValueKind == JsonValueKind.Null)
                {
                    setting.LastModified = null;
                }
                else
                {
                    setting.LastModified = DateTimeOffset.Parse(lastModified.GetString(), CultureInfo.InvariantCulture);
                }
            }
            if (root.TryGetProperty("locked", out var lockedValue))
            {
                if(lockedValue.ValueKind == JsonValueKind.Null)
                {
                    setting.Locked = null;
                }
                else
                {
                    setting.Locked = lockedValue.GetBoolean();
                }
            }
            if (root.TryGetProperty("tags", out var tagsValue))
            {
                foreach (var element in tagsValue.EnumerateObject())
                {
                    setting.Tags.Add(element.Name, element.Value.GetString());
                }
            }

            return setting;
        }

        public static async Task<ConfigurationSetting> DeserializeSettingAsync(Stream content, CancellationToken cancellation)
        {
            using (JsonDocument json = await JsonDocument.ParseAsync(content, default, cancellation).ConfigureAwait(false))
            {
                JsonElement root = json.RootElement;
                return ReadSetting(root);
            }
        }

        public static ConfigurationSetting DeserializeSetting(Stream content)
        {
            using (JsonDocument json = JsonDocument.Parse(content, default))
            {
                JsonElement root = json.RootElement;
                return ReadSetting(root);
            }
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
        static bool TryGetNextAfterValue(ref Response response, out string afterValue)
        {
            afterValue = default;
            if (!response.Headers.TryGetValue(Link, out var headerValue)) return false;

            // the headers value is something like this: "</kv?after={token}>; rel=\"next\""
            var afterIndex = headerValue.IndexOf(After, StringComparison.Ordinal);
            if (afterIndex < 0) return false;

            int beginingToken = afterIndex + After.Length;
            int endToken = headerValue.IndexOf(">", StringComparison.Ordinal);
            int tokenLenght = endToken - beginingToken;
            afterValue = headerValue.Substring(beginingToken, tokenLenght);
            return true;
        }
    }
}

