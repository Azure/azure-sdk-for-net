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
            "specversion",
            "id",
            "source",
            "type",
            "datacontenttype",
            "dataschema",
            "subject",
            "time",
            "data"
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
                ValidateAttributeKey(key as string);
                _backingDictionary[key] = value;
            }
        }

        public ICollection<TKey> Keys => _backingDictionary.Keys;

        public ICollection<TValue> Values => _backingDictionary.Values;

        public int Count => _backingDictionary.Count;

        public bool IsReadOnly => ((ICollection<KeyValuePair<TKey, TValue>>)_backingDictionary).IsReadOnly;

        public void Add(TKey key, TValue value)
        {
            ValidateAttributeKey(key as string);
            _backingDictionary.Add(key, value);
        }

        // used for deserializing
        public void AddWithoutValidation(TKey key, TValue value)
        {
            _backingDictionary.Add(key, value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            ValidateAttributeKey(item.Key as string);
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

        private static void ValidateAttributeKey(string? key)
        {
            Argument.AssertNotNullOrEmpty(key, nameof(key));
            if (s_reservedAttributes.Contains(key))
            {
                throw new ArgumentException($"Attribute key cannot use the reserved attribute: '{key}'", nameof(key));
            }
            for (int i = 0; i < key.Length; i++)
            {
                char c = key[i];
                bool valid = (c >= '0' && c <= '9') || (c >= 'a' && c <= 'z');
                if (!valid)
                {
                    throw new ArgumentException($"Invalid character in extension attribute key: '{c}'", nameof(key));
                }
            }
        }
    }
}
