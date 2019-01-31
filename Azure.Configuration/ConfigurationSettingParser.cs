// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core;
using System;
using System.Buffers;
using System.Buffers.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
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
            // TODO (pri 2): can any of these properties not be present in the payload? 
            var setting = new ConfigurationSetting();
            setting.Key = root.GetProperty("key").GetString();
            setting.Value = root.GetProperty("value").GetString();
            setting.Label = root.GetProperty("label").GetString();
            setting.ContentType = root.GetProperty("content_type").GetString();
            setting.Locked = root.GetProperty("locked").GetBoolean();
            setting.ETag = root.GetProperty("etag").GetString();
            setting.LastModified = DateTimeOffset.Parse(root.GetProperty("last_modified").GetString());

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

        public static async Task<SettingBatch> ParseBatchAsync(Response response, SettingBatchFilter filter, CancellationToken cancellation)
        {
            TryGetNextAfterValue(ref response, out string token);

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

                var batch = new SettingBatch(settings, token, filter);
                return batch;
            }
        }

        static readonly string s_link = "Link";
        static readonly string s_after = "after=";
        static bool TryGetNextAfterValue(ref Response response, out string afterValue)
        {
            afterValue = default;
            string headerValue = string.Empty;
            if (!response.TryGetHeader(s_link, out headerValue)) return false;

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

    // TODO (pri 3): CoreFx will soon have a type like this. We should remove this one then.
    internal class FixedSizedBufferWriter : IBufferWriter<byte>
    {
        private readonly byte[] _buffer;
        private int _count;

        public FixedSizedBufferWriter(byte[] buffer)
        {
            _buffer = buffer;
        }

        public Memory<byte> GetMemory(int minimumLength = 0) => _buffer.AsMemory(_count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<byte> GetSpan(int minimumLength = 0) => _buffer.AsSpan(_count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Advance(int bytes)
        {
            _count += bytes;
            if (_count > _buffer.Length)
            {
                throw new InvalidOperationException("Cannot advance past the end of the buffer.");
            }
        }
    }
}
