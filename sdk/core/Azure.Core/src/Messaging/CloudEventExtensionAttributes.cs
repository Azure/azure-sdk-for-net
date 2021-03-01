// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Azure.Core;

namespace Azure.Messaging
{
    internal class CloudEventExtensionAttributes<TKey, TValue> : IDictionary<TKey, TValue> where TKey : class
    {
        private readonly Dictionary<TKey, TValue> _backingDictionary;
        private static readonly HashSet<string> s_reservedAttributes = new HashSet<string>
        {
            CloudEventConstants.SpecVersion,
            CloudEventConstants.Id,
            CloudEventConstants.Source,
            CloudEventConstants.Type,
            CloudEventConstants.DataContentType,
            CloudEventConstants.DataSchema,
            CloudEventConstants.Subject,
            CloudEventConstants.Time,
            CloudEventConstants.Data,
            CloudEventConstants.DataBase64
        };

        public CloudEventExtensionAttributes()
        {
            Debug.Assert(typeof(TKey) == typeof(string));
            _backingDictionary = new Dictionary<TKey, TValue>();
        }
        public TValue this[TKey key]
        {
            get
            {
                return _backingDictionary[key];
            }
            set
            {
                ValidateAttribute(key as string, value);
                _backingDictionary[key] = value;
            }
        }

        public ICollection<TKey> Keys => _backingDictionary.Keys;

        public ICollection<TValue> Values => _backingDictionary.Values;

        public int Count => _backingDictionary.Count;

        public bool IsReadOnly => ((ICollection<KeyValuePair<TKey, TValue>>)_backingDictionary).IsReadOnly;

        public void Add(TKey key, TValue value)
        {
            ValidateAttribute(key as string, value);
            _backingDictionary.Add(key, value);
        }

        // used for deserializing when not in strict mode
        public void AddWithoutValidation(TKey key, TValue value)
        {
            _backingDictionary.Add(key, value);
        }
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            ValidateAttribute(item.Key as string, item.Value);
            ((ICollection<KeyValuePair<TKey, TValue>>)_backingDictionary).Add(item);
        }

        public void Clear() => _backingDictionary.Clear();

        public bool Contains(KeyValuePair<TKey, TValue> item) => ((ICollection<KeyValuePair<TKey, TValue>>)_backingDictionary).Contains(item);

        public bool ContainsKey(TKey key) => _backingDictionary.ContainsKey(key);

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => ((ICollection<KeyValuePair<TKey, TValue>>)_backingDictionary).CopyTo(array, arrayIndex);

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _backingDictionary.GetEnumerator();

        public bool Remove(TKey key) => _backingDictionary.Remove(key);

        public bool Remove(KeyValuePair<TKey, TValue> item) => ((ICollection<KeyValuePair<TKey, TValue>>)_backingDictionary).Remove(item);

        public bool TryGetValue(TKey key, out TValue value) => _backingDictionary.TryGetValue(key, out value!);

        IEnumerator IEnumerable.GetEnumerator() => _backingDictionary.GetEnumerator();

        private static void ValidateAttribute(string? name, object? value)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(value, nameof(value));
            if (s_reservedAttributes.Contains(name))
            {
                throw new ArgumentException($"Attribute name cannot use the reserved attribute: '{name}'", nameof(name));
            }

            // https://github.com/cloudevents/spec/blob/v1.0/spec.md#attribute-naming-convention
            for (int i = 0; i < name.Length; i++)
            {
                char c = name[i];
                bool valid = (c >= '0' && c <= '9') || (c >= 'a' && c <= 'z');
                if (!valid)
                {
                    throw new ArgumentException(
                        $"Invalid character in extension attribute name: '{c}'. " +
                        "CloudEvent attribute names must consist of lower-case letters ('a' to 'z')" +
                        " or digits ('0' to '9') from the ASCII character set.",
                        nameof(name));
                }
            }

            // https://github.com/cloudevents/spec/blob/v1.0/spec.md#type-system
            switch (value)
            {
                case string:
                case byte[]:
                case ReadOnlyMemory<byte>:
                case int:
                case bool:
                case Uri:
                case DateTime:
                case DateTimeOffset:
                    return;
                default:
                    throw new ArgumentException($"Values of type {value.GetType()} are not supported. " +
                        "Attribute values must be of type bool, byte, int, Uri, DateTime, or DateTimeOffset.");
            }
        }
    }
}
