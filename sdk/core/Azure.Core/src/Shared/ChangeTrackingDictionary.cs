// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;

#nullable enable

namespace Azure.Core
{
    internal class ChangeTrackingDictionary<TKey, TValue> : IDictionary<TKey, TValue>, IReadOnlyDictionary<TKey, TValue> where TKey: notnull
    {
        private IDictionary<TKey, TValue>? _innerDictionary;

        public ChangeTrackingDictionary()
        {
        }

        public ChangeTrackingDictionary(Optional<IReadOnlyDictionary<TKey, TValue>> optionalDictionary) : this(optionalDictionary.Value)
        {
        }

        public ChangeTrackingDictionary(Optional<IDictionary<TKey, TValue>> optionalDictionary) : this(optionalDictionary.Value)
        {
        }

        private ChangeTrackingDictionary(IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null) return;

            _innerDictionary = new Dictionary<TKey, TValue>(dictionary);
        }

        private ChangeTrackingDictionary(IReadOnlyDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null) return;

            _innerDictionary = new Dictionary<TKey, TValue>();
            foreach (KeyValuePair<TKey, TValue> pair in dictionary)
            {
                _innerDictionary.Add(pair);
            }
        }

        public bool IsUndefined => _innerDictionary == null;

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            if (IsUndefined)
            {
                IEnumerator<KeyValuePair<TKey, TValue>> GetEmptyEnumerator()
                {
                    yield break;
                }
                return GetEmptyEnumerator();
            }
            return EnsureDictionary().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            EnsureDictionary().Add(item);
        }

        public void Clear()
        {
            EnsureDictionary().Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            if (IsUndefined)
            {
                return false;
            }

            return EnsureDictionary().Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (IsUndefined)
            {
                return;
            }

            EnsureDictionary().CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (IsUndefined)
            {
                return false;
            }

            return EnsureDictionary().Remove(item);
        }

        public int Count
        {
            get
            {
                if (IsUndefined)
                {
                    return 0;
                }

                return EnsureDictionary().Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                if (IsUndefined)
                {
                    return false;
                }
                return EnsureDictionary().IsReadOnly;
            }
        }

        public void Add(TKey key, TValue value)
        {
            EnsureDictionary().Add(key, value);
        }

        public bool ContainsKey(TKey key)
        {
            if (IsUndefined)
            {
                return false;
            }

            return EnsureDictionary().ContainsKey(key);
        }

        public bool Remove(TKey key)
        {
            if (IsUndefined)
            {
                return false;
            }

            return EnsureDictionary().Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (IsUndefined)
            {
                value = default!;
                return false;
            }
            return EnsureDictionary().TryGetValue(key, out value!);
        }

        public TValue this[TKey key]
        {
            get
            {
                if (IsUndefined)
                {
                    throw new KeyNotFoundException(nameof(key));
                }

                return EnsureDictionary()[key];
            }
            set => EnsureDictionary()[key] = value;
        }

        IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Keys;

        IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Values;

        public ICollection<TKey> Keys
        {
            get
            {
                if (IsUndefined)
                {
                    return Array.Empty<TKey>();
                }

                return EnsureDictionary().Keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                if (IsUndefined)
                {
                    return Array.Empty<TValue>();
                }

                return EnsureDictionary().Values;
            }
        }

        private IDictionary<TKey, TValue> EnsureDictionary()
        {
            return _innerDictionary ??= new Dictionary<TKey, TValue>();
        }
    }
}
