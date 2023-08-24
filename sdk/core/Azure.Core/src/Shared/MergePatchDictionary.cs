// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Azure.Core.Serialization
{
    // TODO: implement IModel serializable?
    internal class MergePatchDictionary<T> : IDictionary<string, T>
    {
        public static MergePatchDictionary<string> GetStringDictionary()
            => new((w, n, s) => w.WriteString(n, s), default);

        public static MergePatchDictionary<string> GetStringDictionary(Dictionary<string, string> d)
            => new(d, (w, n, s) => w.WriteString(n, s), default);

        private readonly Dictionary<string, bool> _changed;
        private readonly Dictionary<string, T> _dictionary;

        private readonly Action<Utf8JsonWriter, string, T> _writeProperty;
        private readonly Func<T, bool>? _itemHasChanges;

        private bool _hasChanges;

        public MergePatchDictionary(Action<Utf8JsonWriter, string, T> writeProperty,
            Func<T, bool>? hasChanges)
        {
            _changed = new Dictionary<string, bool>();
            _dictionary = new Dictionary<string, T>();
            _writeProperty = writeProperty;
            _itemHasChanges = hasChanges;
        }

        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        public MergePatchDictionary(Dictionary<string, T> dictionary,
            Action<Utf8JsonWriter, string, T> writeProperty,
            Func<T, bool>? hasChanges)
            : this(writeProperty, hasChanges)
        {
            _changed = new Dictionary<string, bool>(_dictionary.Count);
            _dictionary = dictionary;
        }

        public bool HasChanges => _hasChanges;

        public T this[string key]
        {
            get
            {
                // If the value is read and a reference value, it might get changed
                return _dictionary[key];
            }

            set
            {
                _hasChanges = true;
                _changed[key] = true;
                _dictionary[key] = value;
            }
        }

        ICollection<string> IDictionary<string, T>.Keys => _dictionary.Keys;

        ICollection<T> IDictionary<string, T>.Values => _dictionary.Values;

        int ICollection<KeyValuePair<string, T>>.Count => _dictionary.Count;

        bool ICollection<KeyValuePair<string, T>>.IsReadOnly => false;

        public void Add(string key, T value)
        {
            _hasChanges = true;
            _changed[key] = true;
            _dictionary.Add(key, value);
        }

        void ICollection<KeyValuePair<string, T>>.Add(KeyValuePair<string, T> item)
        {
            _hasChanges = true;
            _changed[item.Key] = true;
            (_dictionary as ICollection<KeyValuePair<string, T>>).Add(item);
        }

        void ICollection<KeyValuePair<string, T>>.Clear()
        {
            _hasChanges = true;
            foreach (string key in _dictionary.Keys)
            {
                _changed[key] = true;
            }

            (_dictionary as ICollection<KeyValuePair<string, T>>).Clear();
        }

        bool ICollection<KeyValuePair<string, T>>.Contains(KeyValuePair<string, T> item) =>
            (_dictionary as ICollection<KeyValuePair<string, T>>).Contains(item);

        bool IDictionary<string, T>.ContainsKey(string key)
            => _dictionary.ContainsKey(key);

        void ICollection<KeyValuePair<string, T>>.CopyTo(KeyValuePair<string, T>[] array, int arrayIndex)
            => (_dictionary as ICollection<KeyValuePair<string, T>>).CopyTo(array, arrayIndex);

        IEnumerator<KeyValuePair<string, T>> IEnumerable<KeyValuePair<string, T>>.GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (_dictionary as IEnumerable).GetEnumerator();
        }

        bool IDictionary<string, T>.Remove(string key)
        {
            _hasChanges = true;
            _changed[key] = true;
            return _dictionary.Remove(key);
        }

        bool ICollection<KeyValuePair<string, T>>.Remove(KeyValuePair<string, T> item)
        {
            _hasChanges = true;
            _changed[item.Key] = true;
            return (_dictionary as ICollection<KeyValuePair<string, T>>).Remove(item);
        }

#if NET5_0_OR_GREATER
        public bool TryGetValue(string key, [MaybeNullWhen(false)] out T value)
#else
        public bool TryGetValue(string key, out T value)
#endif
        {
            if (_dictionary.TryGetValue(key, out value))
            {
                // TODO: handle item changes
                return true;
            }

            return false;
        }

        public void SerializePatch(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();

            foreach (KeyValuePair<string, bool> kvp in _changed)
            {
                if (kvp.Value)
                {
                    if (!_dictionary.TryGetValue(kvp.Key, out T? value) || value == null)
                    {
                        writer.WritePropertyName(kvp.Key);
                        writer.WriteNullValue();
                    }
                    else
                    {
                        _writeProperty(writer, kvp.Key, value);
                    }
                }
            }

            writer.WriteEndObject();
        }
    }
}
