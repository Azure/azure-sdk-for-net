// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Azure.Core.Serialization
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable AZC0014 // STJ
    public class MergePatchDictionary<T> : IDictionary<string, T>
    {
        // TODO: Test cases
        // - Dictionary of IModelSerializable
        // - Dictionary of int

        public bool HasChanges { get; private set; }

        private readonly Dictionary<string, bool> _changed;
        private readonly Dictionary<string, T> _dictionary;

        private readonly Action<Utf8JsonWriter, T> _writeValue;

        public MergePatchDictionary(Action<Utf8JsonWriter, T> writeValue)
        {
            _changed = new Dictionary<string, bool>();
            _dictionary = new Dictionary<string, T>();
            _writeValue = writeValue;
        }

        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="writeValue"></param>
        public MergePatchDictionary(Dictionary<string, T> dictionary, Action<Utf8JsonWriter, T> writeValue) : this(writeValue)
        {
            _changed = new Dictionary<string, bool>(_dictionary.Count);
            _dictionary = dictionary;
        }

        // TODO: implement IModel serializable?
        public void SerializePatch(Utf8JsonWriter writer)
        {
            if (HasChanges)
            {
                writer.WriteStartObject();

                foreach (KeyValuePair<string, bool> kvp in _changed)
                {
                    if (kvp.Value)
                    {
                        writer.WritePropertyName(kvp.Key);

                        if (!_dictionary.TryGetValue(kvp.Key, out T? value) || value == null)
                        {
                            writer.WriteNullValue();
                        }
                        else
                        {
                            _writeValue(writer, _dictionary[kvp.Key]);
                        }
                    }
                }

                writer.WriteEndObject();
            }
        }

        public T this[string key]
        {
            get
            {
                // If the value is read and a reference value, it might get changed
                _changed[key] = _dictionary[key] is IModelSerializable<object>;
                return _dictionary[key];
            }

            set
            {
                HasChanges = true;
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
            HasChanges = true;
            _changed[key] = true;
            _dictionary.Add(key, value);
        }

        void ICollection<KeyValuePair<string, T>>.Add(KeyValuePair<string, T> item)
        {
            HasChanges = true;
            _changed[item.Key] = true;
            (_dictionary as ICollection<KeyValuePair<string, T>>).Add(item);
        }

        void ICollection<KeyValuePair<string, T>>.Clear()
        {
            HasChanges = true;
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
            => _dictionary.GetEnumerator();

        // TODO: Could enumerators introduce changes to children?
        IEnumerator IEnumerable.GetEnumerator() => (_dictionary as IEnumerable).GetEnumerator();

        bool IDictionary<string, T>.Remove(string key)
        {
            HasChanges = true;
            _changed[key] = true;
            return _dictionary.Remove(key);
        }

        bool ICollection<KeyValuePair<string, T>>.Remove(KeyValuePair<string, T> item)
        {
            HasChanges = true;
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
                _changed[key] = value is IModelSerializable<object>;
                return true;
            }

            return false;
        }
    }
#pragma warning restore AZC0014
#pragma warning restore CS1591
}
