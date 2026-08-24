// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Azure.ResourceManager.ServiceBus;

namespace Azure.ResourceManager.ServiceBus.Models
{
    public partial class ServiceBusCorrelationFilter
    {
        private IDictionary<string, object> _applicationProperties;

        // Preserve the previously shipped property while directing callers to the string-valued service contract.
        /// <summary> Gets the application properties using the previous object-valued model shape. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("ApplicationProperties is obsolete and will be removed in a future release. Use Properties instead.")]
        [WirePath("properties")]
        public IDictionary<string, object> ApplicationProperties
            => _applicationProperties ??= new ObjectDictionary(Properties);

        internal void SetApplicationProperties(IDictionary<string, object> applicationProperties)
        {
            if (applicationProperties is null)
            {
                return;
            }

            foreach (KeyValuePair<string, object> property in applicationProperties)
            {
                (_applicationProperties ??= new ObjectDictionary(Properties)).Add(property);
            }
        }

        private sealed class ObjectDictionary : IDictionary<string, object>
        {
            private readonly IDictionary<string, string> _inner;
            private readonly IDictionary<string, object> _originalValues = new Dictionary<string, object>();

            public ObjectDictionary(IDictionary<string, string> inner)
            {
                _inner = inner;
            }

            public object this[string key]
            {
                get => GetValue(key, _inner[key]);
                set
                {
                    _inner[key] = ConvertToString(value);
                    _originalValues[key] = value;
                }
            }

            public ICollection<string> Keys => _inner.Keys;

            public ICollection<object> Values
            {
                get
                {
                    var values = new List<object>(_inner.Count);
                    foreach (KeyValuePair<string, string> item in _inner)
                    {
                        values.Add(GetValue(item.Key, item.Value));
                    }
                    return values;
                }
            }

            public int Count => _inner.Count;

            public bool IsReadOnly => _inner.IsReadOnly;

            public void Add(string key, object value)
            {
                _inner.Add(key, ConvertToString(value));
                _originalValues.Add(key, value);
            }

            public void Add(KeyValuePair<string, object> item) => Add(item.Key, item.Value);

            public void Clear()
            {
                _inner.Clear();
                _originalValues.Clear();
            }

            public bool Contains(KeyValuePair<string, object> item)
                => TryGetValue(item.Key, out object value) && Equals(value, item.Value);

            public bool ContainsKey(string key) => _inner.ContainsKey(key);

            public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
            {
                foreach (KeyValuePair<string, object> item in this)
                {
                    array[arrayIndex++] = item;
                }
            }

            public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
            {
                foreach (KeyValuePair<string, string> item in _inner)
                {
                    yield return new KeyValuePair<string, object>(item.Key, GetValue(item.Key, item.Value));
                }
            }

            public bool Remove(string key)
            {
                _originalValues.Remove(key);
                return _inner.Remove(key);
            }

            public bool Remove(KeyValuePair<string, object> item)
                => Contains(item) && Remove(item.Key);

            public bool TryGetValue(string key, out object value)
            {
                if (_inner.TryGetValue(key, out string stringValue))
                {
                    value = GetValue(key, stringValue);
                    return true;
                }

                value = null;
                return false;
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            private object GetValue(string key, string value)
            {
                if (_originalValues.TryGetValue(key, out object originalValue)
                    && string.Equals(ConvertToString(originalValue), value, StringComparison.Ordinal))
                {
                    return originalValue;
                }

                _originalValues.Remove(key);
                return value;
            }

            private static string ConvertToString(object value) => value switch
            {
                null => null,
                string stringValue => stringValue,
                DateTime dateTime => dateTime.ToString("O", CultureInfo.InvariantCulture),
                DateTimeOffset dateTimeOffset => dateTimeOffset.ToString("O", CultureInfo.InvariantCulture),
                IFormattable formattable => formattable.ToString(null, CultureInfo.InvariantCulture),
                _ => value.ToString()
            };
        }
    }
}
