// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Core.Serialization
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    public class ChangeListDictionary<T> : IDictionary<string, T>
    {
        private readonly ChangeListElement _changes;
        private readonly Dictionary<string, T> _dictionary;

        public ChangeListDictionary(string path, ChangeListElement changes)
        {
            _changes = changes.GetElement(path);
            _dictionary = new Dictionary<string, T>();
        }

        T IDictionary<string, T>.this[string key]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        ICollection<string> IDictionary<string, T>.Keys => _dictionary.Keys;

        ICollection<T> IDictionary<string, T>.Values => _dictionary.Values;

        int ICollection<KeyValuePair<string, T>>.Count => _dictionary.Count;

        bool ICollection<KeyValuePair<string, T>>.IsReadOnly => false;

        void IDictionary<string, T>.Add(string key, T value)
        {
            _dictionary.Add(key, value);
            _changes.Set(key, value);
        }

        void ICollection<KeyValuePair<string, T>>.Add(KeyValuePair<string, T> item)
        {
            (_dictionary as ICollection<KeyValuePair<string, T>>).Add(item);
            _changes.Set(item.Key, item.Value);
        }

        void ICollection<KeyValuePair<string, T>>.Clear()
        {
            ICollection<KeyValuePair<string, T>> collection = _dictionary;
            foreach (KeyValuePair<string, T> item in collection)
            {
                _changes.SetNull(item.Key);
            }

            collection.Clear();
        }

        bool ICollection<KeyValuePair<string, T>>.Contains(KeyValuePair<string, T> item)
        {
            return (_dictionary as ICollection<KeyValuePair<string, T>>).Contains(item);
        }

        bool IDictionary<string, T>.ContainsKey(string key)
        {
            return _dictionary.ContainsKey(key);
        }

        void ICollection<KeyValuePair<string, T>>.CopyTo(KeyValuePair<string, T>[] array, int arrayIndex)
        {
            (_dictionary as ICollection<KeyValuePair<string, T>>).CopyTo(array, arrayIndex);
        }

        IEnumerator<KeyValuePair<string, T>> IEnumerable<KeyValuePair<string, T>>.GetEnumerator()
        {
            return (_dictionary as IEnumerable<KeyValuePair<string, T>>).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (_dictionary as IEnumerable).GetEnumerator();
        }

        bool IDictionary<string, T>.Remove(string key)
        {
            _changes.SetNull(key);
            return _dictionary.Remove(key);
        }

        bool ICollection<KeyValuePair<string, T>>.Remove(KeyValuePair<string, T> item)
        {
            _changes.SetNull(item.Key);
            return (_dictionary as ICollection<KeyValuePair<string, T>>).Remove(item);
        }

#if NET5_0_OR_GREATER
        public bool TryGetValue(string key, [MaybeNullWhen(false)] out T value)
#else
        public bool TryGetValue(string key, out T value)
#endif
        {
            return _dictionary.TryGetValue(key, out value);
        }
    }
#pragma warning restore CS1591
}
