// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Azure.Core.Amqp
{
    #nullable enable
    internal class AnnotatedMessageMetadataDictionary : IDictionary<string, object?>
    {
        private readonly AmqpAnnotatedMessage _message;
        private readonly IDictionary<string, object?> _dictionary;
        internal const string ContentType = "ContentType";

        public AnnotatedMessageMetadataDictionary(AmqpAnnotatedMessage message)
        {
            _message = message;
            _dictionary = new Dictionary<string, object?>();
        }

        public IEnumerator<KeyValuePair<string, object?>> GetEnumerator() => _dictionary.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<string, object?> item) => Add(item.Key, item.Value);

        public void Clear()
        {
            if (_dictionary.ContainsKey(ContentType))
            {
                _message.Properties.ContentType = null;
            }
            _dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, object?> item) => _dictionary.Contains(item);

        public void CopyTo(KeyValuePair<string, object?>[] array, int arrayIndex) => _dictionary.CopyTo(array, arrayIndex);

        public bool Remove(KeyValuePair<string, object?> item) => Remove(item.Key);

        public int Count => _dictionary.Count;
        public bool IsReadOnly => _dictionary.IsReadOnly;

        public void Add(string key, object? value)
        {
            if (key == ContentType)
            {
                AddContentType(value);
            }

            _dictionary.Add(key, value);
        }

        public bool ContainsKey(string key) => _dictionary.ContainsKey(key);

        public bool Remove(string key)
        {
            if (key == ContentType)
            {
                _message.Properties.ContentType = null;
            }

            return _dictionary.Remove(key);
        }

        public bool TryGetValue(string key, out object? value) => _dictionary.TryGetValue(key, out value);

        public object? this[string key]
        {
            get => _dictionary[key];
            set
            {
                if (key == ContentType)
                {
                    AddContentType(value);
                }

                _dictionary[key] = value;
            }
        }

        public ICollection<string> Keys => _dictionary.Keys;
        public ICollection<object?> Values => _dictionary.Values;

        private void AddContentType(object? value)
        {
            _message.Properties.ContentType = value switch
            {
                null => null,
                string stringVal => stringVal,
                _ => throw new InvalidOperationException($"The value for key '{ContentType}' must be a string.")
            };
        }
    }
}