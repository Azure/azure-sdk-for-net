// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Messaging.ServiceBus.Amqp;

namespace Azure.Messaging.ServiceBus.Primitives
{
    internal sealed class PropertyDictionary : IDictionary<string, object>
    {
        private readonly IDictionary<string, object> _inner;

        public PropertyDictionary()
        {
            _inner = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }

        public PropertyDictionary(IDictionary<string, object> container)
        {
            _inner = container;
        }

        public ICollection<string> Keys => _inner.Keys;

        public ICollection<object> Values => _inner.Values;

        public int Count => _inner.Count;

        public bool IsReadOnly => _inner.IsReadOnly;

        public object this[string key]
        {
            get => _inner[key];

            set
            {
                if (IsSupportedObject(value))
                {
                    _inner[key] = value;
                }
            }
        }

        public void Add(string key, object value)
        {
            if (IsSupportedObject(value))
            {
                _inner.Add(key, value);
            }
        }

        public bool ContainsKey(string key)
        {
            return _inner.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            return _inner.Remove(key);
        }

        public bool TryGetValue(string key, out object value)
        {
            return _inner.TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<string, object> item)
        {
            _inner.Add(item);
        }

        public void Clear()
        {
            _inner.Clear();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return _inner.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            _inner.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            return _inner.Remove(item);
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return _inner.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _inner.GetEnumerator();
        }

        private static bool IsSupportedObject(object value)
        {
            if (value != null)
            {
                var type = value.GetType();

                if (!SerializationUtilities.IsSupportedPropertyType(type))
                {
                    throw new ArgumentException(Resources.NotSupportedPropertyType.FormatForUser(type), nameof(value));
                }
            }

            return true;
        }

        internal PropertyDictionary Clone() =>
            new PropertyDictionary(_inner);
    }
}
