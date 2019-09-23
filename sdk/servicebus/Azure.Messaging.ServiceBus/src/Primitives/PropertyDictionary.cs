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
        private readonly IDictionary<string, object> inner;

        public PropertyDictionary()
        {
            this.inner = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }

        public PropertyDictionary(IDictionary<string, object> container)
        {
            this.inner = container;
        }

        public ICollection<string> Keys => this.inner.Keys;

        public ICollection<object> Values => this.inner.Values;

        public int Count => this.inner.Count;

        public bool IsReadOnly => this.inner.IsReadOnly;

        public object this[string key]
        {
            get => this.inner[key];

            set
            {
                if (this.IsSupportedObject(value))
                {
                    this.inner[key] = value;
                }
            }
        }

        public void Add(string key, object value)
        {
            if (this.IsSupportedObject(value))
            {
                this.inner.Add(key, value);
            }
        }

        public bool ContainsKey(string key)
        {
            return this.inner.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            return this.inner.Remove(key);
        }

        public bool TryGetValue(string key, out object value)
        {
            return this.inner.TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<string, object> item)
        {
            this.inner.Add(item);
        }

        public void Clear()
        {
            this.inner.Clear();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return this.inner.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            this.inner.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            return this.inner.Remove(item);
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return this.inner.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.inner.GetEnumerator();
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