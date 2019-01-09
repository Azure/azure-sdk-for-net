using Azure.Core.Net;
using System;
using System.Buffers;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.JsonLab;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Configuration
{
    // This should be simplified twice:
    // - once JsonReader supports for reading from stream
    // - second time we have the serializer
    static class ConfigurationServiceSerializer
    {
        static byte[][] s_nameTable;
        static JsonState[] s_valueTable;

        public static bool TrySerialize(ConfigurationSetting setting, byte[] buffer, out int written)
        {
            var json = new Utf8JsonWriter2(buffer);
            json.WriteStartObject();
            json.WriteString("value", setting.Value);
            json.WriteString("content_type", setting.ContentType);
            json.WriteEndObject();
            json.Flush();
            written = (int)json.BytesWritten;
            return true;
        }

        public enum JsonState : byte
        {
            Other = 0,

            key,
            label,
            content_type,
            locked,
            value,
            etag,
            lastmodified
        }

        static JsonState ToJsonState(this ReadOnlySpan<byte> propertyName)
        {
            for (int i = 0; i < s_nameTable.Length; i++)
            {
                if (propertyName.SequenceEqual(s_nameTable[i]))
                {
                    return s_valueTable[i];
                }
            }
            return JsonState.Other;
        }

        static ConfigurationServiceSerializer()
        {
            var names = Enum.GetNames(typeof(JsonState));
            s_nameTable = new byte[names.Length][];
            s_valueTable = new JsonState[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                var name = names[i];
                s_nameTable[i] = Encoding.UTF8.GetBytes(name);
                Enum.TryParse<JsonState>(name, out var value);
                s_valueTable[i] = value;
            }
        }

        public static async Task<ConfigurationSetting> ParseSettingAsync(Stream content, CancellationToken cancel)
        {
            byte[] buffer = null;
            try
            {
                buffer = ArrayPool<byte>.Shared.Rent(4096);
                var read = await content.ReadAsync(buffer, 0, buffer.Length, cancel);
                var sequence = new ReadOnlySequence<byte>(buffer, 0, read);
                if (TryParse(sequence, out ConfigurationSetting result, out _))
                {
                    return result;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            finally
            {
                if (buffer != null) ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        public static async Task<SettingBatch> ParseBatchAsync(ServiceResponse response, CancellationToken cancellation)
        {
            TryGetNextAfterValue(ref response, out int next);

            var content = response.ContentStream;
            byte[] buffer = null;
            try
            {
                buffer = ArrayPool<byte>.Shared.Rent(4096);
                var read = await content.ReadAsync(buffer, 0, buffer.Length, cancellation);
                var sequence = new ReadOnlySequence<byte>(buffer, 0, read);
                if (TryParse(sequence, out List<ConfigurationSetting> settings, out _))
                {
                    var batch = new SettingBatch(settings, next);
                    return batch;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            finally
            {
                if (buffer != null) ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        static bool TryParse(ReadOnlySequence<byte> content, out ConfigurationSetting result, out long consumed)
        {
            result = new ConfigurationSetting();
            consumed = 0;
            var json = new Utf8Json();

            var reader = json.GetReader(content, true);
            JsonState state = JsonState.Other;
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.PropertyName:
                        state = reader.Value.ToJsonState();
                        break;
                    case JsonTokenType.Number:
                    case JsonTokenType.String:
                    case JsonTokenType.False:
                    case JsonTokenType.True:
                        SetValue(ref reader, state, ref result);
                        break;
                }
            }

            consumed = reader.Consumed;
            return true;
        }

        static bool TryParse(ReadOnlySequence<byte> content, out List<ConfigurationSetting> result, out long consumed)
        {
            var debug = Encoding.UTF8.GetString(content.ToArray());

            result = new List<ConfigurationSetting>();
            consumed = 0;
            var json = new Utf8Json();
            var reader = json.GetReader(content, true);

            JsonState state = JsonState.Other;
            ConfigurationSetting value = default;
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.StartObject:
                        value = new ConfigurationSetting();
                        break;
                    case JsonTokenType.EndObject:
                        result.Add(value);
                        break;
                    case JsonTokenType.EndArray:
                        consumed = reader.Consumed;
                        return true;
                    case JsonTokenType.PropertyName:
                        state = reader.Value.ToJsonState();
                        break;
                    case JsonTokenType.Number:
                    case JsonTokenType.String:
                    case JsonTokenType.False:
                    case JsonTokenType.True:
                        SetValue(ref reader, state, ref value);
                        break;
                }
            }

            consumed = reader.Consumed;
            return true;
        }

        static void SetValue(ref Utf8Json.Reader json, JsonState state, ref ConfigurationSetting result)
        {
            switch (state)
            {
                // strings
                case JsonState.key: result.Key = json.GetValueAsString(); break;
                case JsonState.label: result.Label = json.GetValueAsString(); break;
                case JsonState.content_type: result.ContentType = json.GetValueAsString(); break;
                case JsonState.value: result.Value = json.GetValueAsString(); break;
                case JsonState.etag: result.ETag = json.GetValueAsString(); break;

                // other
                case JsonState.lastmodified:
                    // TODO (pri 1): implement date parsing
                    //if(!Utf8Parser.TryParse(json.Value, out DateTimeOffset date, out int consumed, 'O')) {
                    //    throw new Exception("bad date format " + json.GetValueAsString());
                    //}
                    //result.LastModified = date;
                    break;

                case JsonState.locked:
                    if (json.TokenType == JsonTokenType.True) result.Locked = true;
                    else if (json.TokenType == JsonTokenType.False) result.Locked = false;
                    else throw new Exception("bad parser");
                    break;
                default: break;
            }
        }

        static readonly byte[] s_link = Encoding.ASCII.GetBytes("Link");
        static readonly byte[] s_after = Encoding.ASCII.GetBytes("?after=");
        static bool TryGetNextAfterValue(ref ServiceResponse response, out int afterValue)
        {
            afterValue = default;
            ReadOnlySpan<byte> headerValue = default;
            if (!response.TryGetHeader(s_link, out headerValue)) return false;

            // the headers value is something like this: "</kv?after=10>;rel=\"next\""
            var afterIndex = headerValue.IndexOf(s_after);
            if (afterIndex < 0) return false;

            ReadOnlySpan<byte> urlBytes = headerValue.Slice(afterIndex + s_after.Length);
            return Utf8Parser.TryParse(urlBytes, out afterValue, out _);
        }
    }
}
