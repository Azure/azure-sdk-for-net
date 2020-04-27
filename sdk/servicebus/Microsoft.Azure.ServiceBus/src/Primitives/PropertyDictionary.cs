// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Amqp;

    internal sealed class PropertyDictionary : IDictionary<string, object>
    {
	    private readonly IDictionary<string, object> inner;

        public PropertyDictionary()
        {
            inner = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }

        public PropertyDictionary(IDictionary<string, object> container)
        {
            inner = container;
        }

        public ICollection<string> Keys => inner.Keys;

        public ICollection<object> Values => inner.Values;

        public int Count => inner.Count;

        public bool IsReadOnly => inner.IsReadOnly;

        public object this[string key]
        {
            get => inner[key];

            set
            {
                if (IsSupportedObject(value))
                {
                    inner[key] = value;
                }
            }
        }

        public void Add(string key, object value)
        {
            if (IsSupportedObject(value))
            {
                inner.Add(key, value);
            }
        }

        public bool ContainsKey(string key)
        {
            return inner.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            return inner.Remove(key);
        }

        public bool TryGetValue(string key, out object value)
        {
            return inner.TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<string, object> item)
        {
            inner.Add(item);
        }

        public void Clear()
        {
            inner.Clear();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return inner.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            inner.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            return inner.Remove(item);
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return inner.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return inner.GetEnumerator();
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