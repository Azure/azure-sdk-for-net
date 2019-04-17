// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ApplicationModel.Configuration
{
    static class ConfigurationServiceSerializer
    {
        public static bool TrySerialize(ConfigurationSetting setting, byte[] buffer, out int written)
        {
            try {
                var writer = new FixedSizedBufferWriter(buffer);
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
                written = (int)json.BytesWritten;
                return true;
            }
            catch(ArgumentException) {
                written = 0;
                return false;
            }
        }

        private static ConfigurationSetting ReadSetting(JsonElement root)
        {
            // TODO (pri 2): make the deserializer version resilient
            var setting = new ConfigurationSetting();
            if (root.TryGetProperty("key", out var keyValue)) setting.Key = keyValue.GetString();
            if (root.TryGetProperty("value", out var value)) setting.Value = value.GetString();
            if (root.TryGetProperty("label", out var labelValue)) setting.Label = labelValue.GetString();
            if (root.TryGetProperty("content_type", out var contentValue)) setting.ContentType = contentValue.GetString();
            if (root.TryGetProperty("etag", out var eTagValue)) setting.ETag = eTagValue.GetString();
            if (root.TryGetProperty("last_modified", out var lastModified))
            {
                if(lastModified.Type == JsonValueType.Null)
                {
                    setting.LastModified = null;
                }
                else
                {
                    setting.LastModified = DateTimeOffset.Parse(lastModified.GetString());
                }
            }
            if (root.TryGetProperty("locked", out var lockedValue))
            {
                if(lockedValue.Type == JsonValueType.Null)
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

        public static async Task<SettingBatch> ParseBatchAsync(Response response, SettingSelector selector, CancellationToken cancellation)
        {
            TryGetNextAfterValue(ref response, out string nextBatchUri);

            Stream content = response.ContentStream;
            using (JsonDocument json = await JsonDocument.ParseAsync(content, default, cancellation).ConfigureAwait(false))
            {
                JsonElement itemsArray = json.RootElement.GetProperty("items");
                int length = itemsArray.GetArrayLength();
                ConfigurationSetting[] settings = new ConfigurationSetting[length];

                int i = 0;
                foreach(JsonElement item in  itemsArray.EnumerateArray())
                {
                    settings[i++] = ReadSetting(item);
                }

                var batch = new SettingBatch(settings, nextBatchUri, selector);
                return batch;
            }
        }

        static readonly string s_link = "Link";
        static readonly string s_after = "after=";
        static bool TryGetNextAfterValue(ref Response response, out string afterValue)
        {
            afterValue = default;
            if (!response.TryGetHeader(s_link, out var headerValue)) return false;

            // the headers value is something like this: "</kv?after={token}>; rel=\"next\""
            var afterIndex = headerValue.IndexOf(s_after);
            if (afterIndex < 0) return false;

            int beginingToken = afterIndex + s_after.Length;
            int endToken = headerValue.IndexOf(">");
            int tokenLenght = endToken - beginingToken;
            afterValue = headerValue.Substring(beginingToken, tokenLenght);
            return true;
        }
    }
}

