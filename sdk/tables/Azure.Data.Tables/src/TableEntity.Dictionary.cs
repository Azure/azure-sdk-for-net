// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;

namespace Azure.Data.Tables
{
    public partial class TableEntity : IDictionary<string, object>
    {
        /// <summary>
        /// Gets or sets the entity's property, given the name of the property.
        /// </summary>
        /// <param name="key">A string containing the name of the property.</param>
        /// <returns>The property value typed as an object.</returns>
        public object this[string key]
        {
            get { return GetValue(key); }
            set { SetValue(key, value); }
        }

        /// <inheritdoc />
        public ICollection<string> Keys => _properties.Keys;

        /// <inheritdoc cref="IDictionary{TKey, TValue}.Values" />
        ICollection<object> IDictionary<string, object>.Values => _properties.Values;

        /// <inheritdoc />
        public int Count => _properties.Count;

        /// <inheritdoc cref="ICollection{T}.IsReadOnly" />
        bool ICollection<KeyValuePair<string, object>>.IsReadOnly => _properties.IsReadOnly;

        /// <inheritdoc />
        public void Add(string key, object value) => SetValue(key, value);

        /// <inheritdoc />
        public bool ContainsKey(string key) => _properties.ContainsKey(key);

        /// <inheritdoc />
        public bool Remove(string key) => _properties.Remove(key);

        /// <inheritdoc />
        public bool TryGetValue(string key, out object value) => _properties.TryGetValue(key, out value);

        /// <inheritdoc cref="ICollection{T}.Add(T)" />
        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item) => SetValue(item.Key, item.Value);

        /// <inheritdoc />
        public void Clear() => _properties.Clear();

        /// <inheritdoc cref="ICollection{T}.Contains(T)"/>
        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item) => _properties.Contains(item);

        /// <inheritdoc cref="ICollection{T}.CopyTo(T[], int)" />
        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex) => _properties.CopyTo(array, arrayIndex);

        /// <inheritdoc cref="ICollection{T}.Remove(T)" />
        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item) => _properties.Remove(item);

        /// <inheritdoc />
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => _properties.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
