// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Azure.Core.Serialization
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    public class MergePatchDictionary<T> : IDictionary<string, T>
    {
        public bool HasChanges { get; private set; }

        private readonly Dictionary<string, Changed<T>> _dictionary;

        public MergePatchDictionary()
        {
            _dictionary = new Dictionary<string, Changed<T>>();
        }

        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        /// <param name="dictionary"></param>
        public MergePatchDictionary(Dictionary<string, T> dictionary) : this()
        {
            // TODO: should take dictionary<T>?
            _dictionary = dictionary;
        }

        public T this[string key]
        {
            get
            {
                // If the value is read and a reference value, it might get changed
                HasChanges = _dictionary[key].Value is IModelSerializable<object>;
                return _dictionary[key].Value;
            }

            set
            {
                HasChanges = true;
                if (_dictionary.ContainsKey(key))
                {
                    // TODO: test
                    Changed<T> changed = _dictionary[key];
                    changed.Value = value;
                    _dictionary[key] = changed;
                }
                else
                {
                    _dictionary[key] = new Changed<T>(value);
                }
            }
        }

        ICollection<string> IDictionary<string, T>.Keys => _dictionary.Keys;

        ICollection<T> IDictionary<string, T>.Values
        {
            get
            {
                Dictionary<string, Changed<T>>.ValueCollection values = _dictionary.Values;
                throw new NotImplementedException();
                //return new Dictionary<string, T>.ValueCollection(this);
            }
        }

        int ICollection<KeyValuePair<string, T>>.Count => _dictionary.Count;

        bool ICollection<KeyValuePair<string, T>>.IsReadOnly => false;

        public void Add(string key, T value)
        {
            HasChanges = true;
            _dictionary.Add(key, new Changed<T>(value));
        }

        void ICollection<KeyValuePair<string, T>>.Add(KeyValuePair<string, T> item)
        {
            HasChanges = true;
            (_dictionary as ICollection<KeyValuePair<string, Changed<T>>>).Add(new KeyValuePair<string, Changed<T>>(item.Key, new Changed<T>(item.Value)));
        }

        void ICollection<KeyValuePair<string, T>>.Clear()
        {
            HasChanges = true;
            (_dictionary as ICollection<KeyValuePair<string, Changed<T>>>).Clear();
        }

        bool ICollection<KeyValuePair<string, T>>.Contains(KeyValuePair<string, T> item) =>
            // TODO: test this per Changed<T> equality
            (_dictionary as ICollection<KeyValuePair<string, Changed<T>>>).Contains(new KeyValuePair<string, Changed<T>>(item.Key, new Changed<T>(item.Value)));

        bool IDictionary<string, T>.ContainsKey(string key)
            => _dictionary.ContainsKey(key);

        void ICollection<KeyValuePair<string, T>>.CopyTo(KeyValuePair<string, T>[] array, int arrayIndex)
        {
            // TODO: Yuck
            KeyValuePair<string, Changed<T>>[] copy = new KeyValuePair<string, Changed<T>>[array.Length];
            (_dictionary as ICollection<KeyValuePair<string, Changed<T>>>).CopyTo(copy, arrayIndex);
            for (int i = arrayIndex; i < array.Length; i++)
            {
                array[i] = new KeyValuePair<string, T>(copy[i].Key, copy[i].Value.Value);
            }
        }

        IEnumerator<KeyValuePair<string, T>> IEnumerable<KeyValuePair<string, T>>.GetEnumerator()
        {
            foreach (KeyValuePair<string, Changed<T>> kvp in _dictionary as IEnumerable<KeyValuePair<string, Changed<T>>>)
            {
                yield return new KeyValuePair<string, T>(kvp.Key, kvp.Value.Value);
            }
        }

        // TODO: Could enumerators introduce changes to children?
        IEnumerator IEnumerable.GetEnumerator() => (_dictionary as IEnumerable).GetEnumerator();

        bool IDictionary<string, T>.Remove(string key)
        {
            HasChanges = true;
            return _dictionary.Remove(key);
        }

        bool ICollection<KeyValuePair<string, T>>.Remove(KeyValuePair<string, T> item)
        {
            HasChanges = true;
            return (_dictionary as ICollection<KeyValuePair<string, Changed<T>>>).Remove(new KeyValuePair<string, Changed<T>>(item.Key, new Changed<T>(item.Value)));
        }

#if NET5_0_OR_GREATER
        public bool TryGetValue(string key, [MaybeNullWhen(false)] out T value)
#else
        public bool TryGetValue(string key, out T value)
#endif
        {
            if (_dictionary.TryGetValue(key, out Changed<T> changedValue))
            {
                HasChanges = changedValue.Value is IModelSerializable<object>;
                value = changedValue.Value;
                return true;
            }

            value = default(T);
            return false;
        }
    }
#pragma warning restore CS1591
}
