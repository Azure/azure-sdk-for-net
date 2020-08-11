// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Azure.Core;

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

        /// <inheritdoc />
        ICollection<object> IDictionary<string, object>.Values => _properties.Values;

        /// <inheritdoc />
        public int Count => _properties.Count;

        /// <inheritdoc />
        bool ICollection<KeyValuePair<string, object>>.IsReadOnly => _properties.IsReadOnly;

        /// <inheritdoc />
        public void Add(string key, object value) => SetValue(key, value);

        /// <inheritdoc />
        public bool ContainsKey(string key) => _properties.ContainsKey(key);

        /// <inheritdoc />
        public bool Remove(string key) => _properties.Remove(key);

        /// <inheritdoc />
        public bool TryGetValue(string key, out object value) => _properties.TryGetValue(key, out value);

        /// <inheritdoc />
        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item) => SetValue(item.Key, item.Value);

        /// <inheritdoc />
        public void Clear()=> _properties.Clear();

        /// <inheritdoc />
        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item) => _properties.Contains(item);

        /// <inheritdoc />
        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex) => _properties.CopyTo(array, arrayIndex);

        /// <inheritdoc />
        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item) => _properties.Remove(item);

        /// <inheritdoc />
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => _properties.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
