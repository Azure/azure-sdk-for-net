using System;
using System.Buffers;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;
using System.Text.JsonLab;

namespace Azure.Configuration
{
    public sealed class KeyValue
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
    }

    static class KeyValueResultParser
    {
        static byte[][] s_nameTable;
        static JsonState[] s_valueTable;

        public enum JsonState : byte
        {
            Other = 0,

            key,
            label,
            contenttype,
            locked,
            value,
            etag,
            lastmodified
        }

        static void SetValue(ref Utf8JsonReader json, JsonState state, ref KeyValue result)
        {
            switch (state)
            {
                // strings
                case JsonState.key: result.Key = json.GetValueAsString(); break;
                case JsonState.label: result.Label = json.GetValueAsString(); break;
                case JsonState.contenttype: result.ContentType = json.GetValueAsString(); break;
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

        public static KeyValue Parse(ReadOnlySequence<byte> content)
        {
            var result = new KeyValue();
            var json = new Utf8JsonReader(content, true);
            JsonState state = JsonState.Other;
            while (json.Read())
            {
                switch (json.TokenType)
                {
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

            return result;
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

        static KeyValueResultParser()
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
