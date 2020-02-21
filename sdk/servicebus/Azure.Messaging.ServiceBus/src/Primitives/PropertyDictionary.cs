// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Primitives
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Azure.Messaging.ServiceBus.Amqp;

    internal sealed class PropertyDictionary : IDictionary<string, object>
    {
        private readonly IDictionary<string, object> _inner;

        public PropertyDictionary()
        {
            this._inner = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }

        public PropertyDictionary(IDictionary<string, object> container)
        {
            this._inner = container;
        }

        public ICollection<string> Keys => this._inner.Keys;

        public ICollection<object> Values => this._inner.Values;

        public int Count => this._inner.Count;

        public bool IsReadOnly => this._inner.IsReadOnly;

        public object this[string key]
        {
            get => this._inner[key];

            set
            {
                if (this.IsSupportedObject(value))
                {
                    this._inner[key] = value;
                }
            }
        }

        public void Add(string key, object value)
        {
            if (this.IsSupportedObject(value))
            {
                this._inner.Add(key, value);
            }
        }

        public bool ContainsKey(string key)
        {
            return this._inner.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            return this._inner.Remove(key);
        }

        public bool TryGetValue(string key, out object value)
        {
            return this._inner.TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<string, object> item)
        {
            this._inner.Add(item);
        }

        public void Clear()
        {
            this._inner.Clear();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return this._inner.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            this._inner.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            return this._inner.Remove(item);
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return this._inner.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._inner.GetEnumerator();
        }

        private bool IsSupportedObject(object value)
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
    }
}
