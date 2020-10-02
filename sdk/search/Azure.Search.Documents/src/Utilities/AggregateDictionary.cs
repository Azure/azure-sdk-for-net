// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Aggregates multiple dictionaries as a single dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of key.</typeparam>
    /// <typeparam name="TValue">The type of value.</typeparam>
    internal abstract class AggregateDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly IDictionary<TKey, TValue>[] _dictionaries;

        /// <summary>
        /// Creates a new instance of the <see cref="AggregateDictionary{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="dictionaries">The dictionaries to aggregate as a single dictionary.</param>
        /// <exception cref="ArgumentNullException"><paramref name="dictionaries"/> is null.</exception>
        public AggregateDictionary(IEnumerable<IDictionary<TKey, TValue>> dictionaries)
        {
            // Make a copy of the source to an array to avoid unexpected changes. Enumerating arrays is more efficient as well.
            _dictionaries = dictionaries?.ToArray() ?? throw new ArgumentNullException(nameof(dictionaries));

            // Assume only 2 elements.
            const int capacity = 2;

            List<ICollection<TKey>> keys = new List<ICollection<TKey>>(capacity);
            List<ICollection<TValue>> values = new List<ICollection<TValue>>(capacity);

            foreach (IDictionary<TKey, TValue> dictionary in _dictionaries)
            {
                keys.Add(dictionary.Keys);
                values.Add(dictionary.Values);
            }

            Keys = new ReadOnlyAggregateCollection<TKey>(keys);
            Values = new ReadOnlyAggregateCollection<TValue>(values);
        }

        /// <inheritdoc />
        public TValue this[TKey key]
        {
            get
            {
                if (key is null)
                {
                    throw new ArgumentNullException(nameof(key));
                }

                foreach (IDictionary<TKey, TValue> dictionary in _dictionaries)
                {
                    if (dictionary.TryGetValue(key, out TValue value))
                    {
                        return value;
                    }
                }

                throw new KeyNotFoundException($"Key '{key}' not found");
            }

            set
            {
                if (key is null)
                {
                    throw new ArgumentNullException(nameof(key));
                }

                Set(key, value);
            }
        }

        /// <inheritdoc />
        public ICollection<TKey> Keys { get; }

        /// <inheritdoc />
        public ICollection<TValue> Values { get; }

        /// <inheritdoc />
        public int Count =>
            _dictionaries.Sum(d => d.Count);

        /// <inheritdoc />
        public bool IsReadOnly =>
            _dictionaries.All(d => d.IsReadOnly);

        /// <inheritdoc />
        public void Add(TKey key, TValue value)
        {
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (ContainsKey(key))
            {
                throw new ArgumentException($"An element with the key '{key}' already exists", nameof(key));
            }

            Set(key, value);
        }

        /// <inheritdoc />
        public void Add(KeyValuePair<TKey, TValue> item) =>
            Add(item.Key, item.Value);

        /// <inheritdoc />
        public void Clear()
        {
            foreach (IDictionary<TKey, TValue> dictionary in _dictionaries)
            {
                dictionary.Clear();
            }
        }

        /// <inheritdoc />
        public bool Contains(KeyValuePair<TKey, TValue> item) =>
            TryGetValue(item.Key, out TValue value) && EqualityComparer<TValue>.Default.Equals(value, item.Value);

        /// <inheritdoc />
        public bool ContainsKey(TKey key) =>
            _dictionaries.Any(d => d.ContainsKey(key));

        /// <inheritdoc />
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            foreach (IDictionary<TKey, TValue> dictionary in _dictionaries)
            {
                dictionary.CopyTo(array, arrayIndex);
                arrayIndex += dictionary.Count;
            }
        }

        /// <inheritdoc />
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (IDictionary<TKey, TValue> dictionary in _dictionaries)
            {
                foreach (KeyValuePair<TKey, TValue> pair in dictionary)
                {
                    yield return pair;
                }
            }
        }

        /// <inheritdoc />
        public bool Remove(TKey key)
        {
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            foreach (IDictionary<TKey, TValue> dictionary in _dictionaries)
            {
                if (dictionary.Remove(key))
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc />
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            foreach (IDictionary<TKey, TValue> dictionary in _dictionaries)
            {
                if (dictionary.Remove(item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc />
        public bool TryGetValue(TKey key, out TValue value)
        {
            foreach (IDictionary<TKey, TValue> dictionary in _dictionaries)
            {
                if (dictionary.TryGetValue(key, out value))
                {
                    return true;
                }
            }

            value = default;
            return false;
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();

        /// <summary>
        /// Override to set keys in specific dictionaries.
        /// </summary>
        /// <param name="key">The key to set.</param>
        /// <param name="value">The value to set.</param>
        protected abstract void Set(TKey key, TValue value);

        /// <summary>
        /// Aggregates multiple collections as a single collection.
        /// </summary>
        /// <typeparam name="T">The type of element.</typeparam>
        private class ReadOnlyAggregateCollection<T> : ICollection<T>
        {
            private readonly IEnumerable<ICollection<T>> _collections;

            /// <summary>
            /// Creates a new instance of the <see cref="ReadOnlyAggregateCollection{T}"/> class.
            /// </summary>
            /// <param name="collections">The collections to aggregate as a single collection.</param>
            /// <exception cref="ArgumentNullException"><paramref name="collections"/> is null.</exception>
            public ReadOnlyAggregateCollection(IEnumerable<ICollection<T>> collections)
            {
                _collections = collections ?? throw new ArgumentNullException(nameof(collections));
            }

            /// <inheritdoc />
            public int Count =>
                _collections.Sum(c => c.Count);

            /// <inheritdoc />
            public bool IsReadOnly => true;

            /// <inheritdoc />
            /// <exception cref="NotSupportedException">Always throws <see cref="NotSupportedException"/>.</exception>
            public void Add(T item) => throw new NotSupportedException();

            /// <inheritdoc />
            /// <exception cref="NotSupportedException">Always throws <see cref="NotSupportedException"/>.</exception>
            public void Clear() => throw new NotSupportedException();

            /// <inheritdoc />
            public bool Contains(T item) =>
                _collections.Any(c => c.Contains(item));

            /// <inheritdoc />
            public void CopyTo(T[] array, int arrayIndex)
            {
                if (array is null)
                {
                    throw new ArgumentNullException(nameof(array));
                }

                foreach (ICollection<T> collection in _collections)
                {
                    collection.CopyTo(array, arrayIndex);
                    arrayIndex += collection.Count;
                }
            }

            /// <inheritdoc />
            public IEnumerator<T> GetEnumerator()
            {
                foreach (ICollection<T> collection in _collections)
                {
                    foreach (T element in collection)
                    {
                        yield return element;
                    }
                }
            }

            /// <inheritdoc />
            /// <exception cref="NotSupportedException">Always throws <see cref="NotSupportedException"/>.</exception>
            public bool Remove(T item) => throw new NotSupportedException();

            IEnumerator IEnumerable.GetEnumerator() =>
                GetEnumerator();
        }
    }
}
