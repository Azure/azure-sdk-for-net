// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;

// This logic belongs in DynamicData, but they may not ship at the same time
// so we optionally compile a version of it into SearchDocument.
#if EXPERIMENTAL_DYNAMIC
namespace Azure.Core
{
    public partial class DynamicData
#else
namespace Azure.Search.Documents.Models
{
    public partial class SearchDocument
#endif
        : IDictionary<string, object>
    {
        /// <inheritdoc />
        public object this[string key]
        {
            get => GetValue(key);
            set => SetValue(key, value);
        }

        /// <inheritdoc />
        public bool TryGetValue(string key, out object value) =>
            TryGetValue(key, typeof(object), out value);

        /// <inheritdoc />
        public ICollection<string> Keys => _values.Keys;

        /// <inheritdoc cref="IDictionary{TKey, TValue}.Values" />
        ICollection<object> IDictionary<string, object>.Values => _values.Values;

        /// <inheritdoc />
        public int Count => _values.Count;

        /// <inheritdoc cref="ICollection{T}.IsReadOnly" />
        bool ICollection<KeyValuePair<string, object>>.IsReadOnly => _values.IsReadOnly;

        /// <inheritdoc />
        public void Add(string key, object value) => SetValue(key, value);

        /// <inheritdoc />
        public bool ContainsKey(string key) => _values.ContainsKey(key);

        /// <inheritdoc cref="ICollection{T}.Add" />
        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item) =>
            SetValue(item.Key, item.Value);

        /// <inheritdoc cref="ICollection{T}.Contains" />
        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item) =>
            _values.Contains(item);

        /// <inheritdoc cref="ICollection{T}.CopyTo" />
        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex) =>
            _values.CopyTo(array, arrayIndex);

        /// <inheritdoc />
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() =>
            _values.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        public bool Remove(string key) => _values.Remove(key);

        /// <inheritdoc cref="ICollection{T}.Remove" />
        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item) =>
            _values.Remove(item);

        /// <inheritdoc />
        public void Clear() => _values.Clear();
    }
}
