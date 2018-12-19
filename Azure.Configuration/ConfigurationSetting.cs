using Azure.Core.Net;
using System;
using System.Buffers;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.JsonLab;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Configuration
{
    public sealed class ConfigurationSetting
    {
        /// <summary>
        /// The primary identifier of a key-value.
        /// The key is used in unison with the label to uniquely identify a key-value.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// A value used to group key-values.
        /// The label is used in unison with the key to uniquely identify a key-value.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The value of the key-value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The content type of the key-value's value.
        /// Providing a proper content-type can enable transformations of values when they are retrieved by applications.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// An ETag indicating the state of a key-value within a configuration store.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// The last time a modifying operation was performed on the given key-value.
        /// </summary>
        public DateTimeOffset LastModified { get; set; }

        /// <summary>
        /// A value indicating whether the key-value is locked.
        /// A locked key-value may not be modified until it is unlocked.
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// A dictionary of tags that can help identify what a key-value may be applicable for.
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }

    public class SettingBatch : IEnumerable<ConfigurationSetting>
    {
        List<ConfigurationSetting> _parsed;

        public int NextIndex { get; set; }

        internal static SettingBatch Parse(ServiceResponse response)
        {
            var batch = new SettingBatch();
            if (TryGetNextAfterValue(ref response, out int next))
            {
                batch.NextIndex = next;
            }
            ConfigurationServiceParser.TryParse(response.Content.Bytes, out batch._parsed, out long consumed);
            return batch;
        }

        // TODO (pri 2): add struct enumerator 
        public IEnumerator<ConfigurationSetting> GetEnumerator() => _parsed.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _parsed.GetEnumerator();

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

        #region nobody wants to see these
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
        #endregion
    }

    static class ConfigurationServiceParser
    {
        static byte[][] s_nameTable;
        static JsonState[] s_valueTable;

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

        static void SetValue(ref Utf8JsonReader json, JsonState state, ref ConfigurationSetting result)
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

        public static async Task<ConfigurationSetting> Parse(Stream content, CancellationToken cancel)
        {
            byte[] buffer = null;
            try {
                buffer = ArrayPool<byte>.Shared.Rent(4096);
                var read = await content.ReadAsync(buffer, 0, buffer.Length, cancel);
                var sequence = new ReadOnlySequence<byte>(buffer, 0, read);
                if(TryParse(sequence, out ConfigurationSetting result, out _)) {
                    return result;
                }
                else {
                    throw new NotImplementedException();
                }
            }
            finally {
                if(buffer!=null) ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        public static bool TryParse(ReadOnlySequence<byte> content, out ConfigurationSetting result, out long consumed)
        {
            result = new ConfigurationSetting();
            consumed = 0;
            var json = new Utf8JsonReader(content, true);
            JsonState state = JsonState.Other;
            while (json.Read()) {
                switch (json.TokenType) {
                    case JsonTokenType.PropertyName:
                        state = json.Value.ToJsonState();
                        break;
                    case JsonTokenType.Number:
                    case JsonTokenType.String:
                    case JsonTokenType.False:
                    case JsonTokenType.True:
                        SetValue(ref json, state, ref result);
                        break;
                }
            }

            consumed = json.Consumed;
            return true;
        }

        public static bool TryParse(ReadOnlySequence<byte> content, out List<ConfigurationSetting> result, out long consumed)
        {
            var debug = Encoding.UTF8.GetString(content.ToArray());

            result = new List<ConfigurationSetting>();
            consumed = 0;
            var json = new Utf8JsonReader(content, true);
            JsonState state = JsonState.Other;
            ConfigurationSetting value = default;
            while (json.Read())
            {
                switch (json.TokenType)
                {
                    case JsonTokenType.StartObject:
                        value = new ConfigurationSetting();
                        break;
                    case JsonTokenType.EndObject:
                        result.Add(value);
                        break;
                    case JsonTokenType.EndArray:
                        consumed = json.Consumed;
                        return true;
                    case JsonTokenType.PropertyName:
                        state = json.Value.ToJsonState();
                        break;
                    case JsonTokenType.Number:
                    case JsonTokenType.String:
                    case JsonTokenType.False:
                    case JsonTokenType.True:
                        SetValue(ref json, state, ref value);
                        break;
                }
            }

            consumed = json.Consumed;
            return true;
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

        static ConfigurationServiceParser()
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
    }
}
