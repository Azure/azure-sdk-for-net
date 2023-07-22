// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;

#nullable enable

namespace Azure.Core.Json
{
    internal readonly struct MutableJsonDictionary<T> : IDictionary<string, T>
    {
        private readonly MutableJsonElement _element;

        public MutableJsonDictionary(MutableJsonElement element)
        {
            Debug.Assert(_element.ValueKind == JsonValueKind.Object);

            _element = element;
        }

        public T this[string key]
        {
            get
            {
                return _element.GetProperty(key).ConvertTo<T>();
            }

            set => _element.SetProperty(key, value);
        }

        // TODO: implement
        public ICollection<string> Keys => throw new NotImplementedException();

        // TODO: implement
        public ICollection<T> Values => throw new NotImplementedException();

        public int Count => _element.EnumerateObject().Count();

        public bool IsReadOnly => false;

        public void Add(string key, T value)
        {
            Argument.AssertNotNull(key, nameof(key));

            if (_element.TryGetProperty(key, out _))
            {
                throw new ArgumentException($"An element with the same key already exists in the MutableJsonDictionary<string,{typeof(T)}>.");
            }

            _element.SetProperty(key, value);
        }

        public void Add(KeyValuePair<string, T> item) => Add(item.Key, item.Value);

        // TODO: use static value for empty object
        // TODO: add test case
        public void Clear() => _element.Set(JsonDocument.Parse("{}"u8.ToArray()));

        public bool Contains(KeyValuePair<string, T> item) => _element.TryGetProperty(item.Key, out _);

        public bool ContainsKey(string key) => _element.TryGetProperty(key, out _);

        // TODO: Add test case
        public void CopyTo(KeyValuePair<string, T>[] array, int arrayIndex)
        {
            Argument.AssertNotNull(array, nameof(array));
            Argument.AssertInRange(arrayIndex, 0, int.MaxValue, nameof(arrayIndex));

            int i = arrayIndex;
            foreach ((string Name, MutableJsonElement Value) in _element.EnumerateObject())
            {
                if (i >= array.Length)
                {
                    throw new ArgumentException("The number of elements in the dictionary is greater than the available space from 'arrayIndex' to the end of the destination array.");
                }

                array[i++] = new KeyValuePair<string, T>(Name, Value.ConvertTo<T>());
            }
        }

        public IEnumerator<KeyValuePair<string, T>> GetEnumerator()
        {
            foreach ((string Name, MutableJsonElement Value) in _element.EnumerateObject())
            {
                yield return new KeyValuePair<string, T>(Name, Value.ConvertTo<T>());
            }
        }

        // TODO: Add test case
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool Remove(string key)
        {
            _element.RemoveProperty(key);
            return true;
        }

        public bool Remove(KeyValuePair<string, T> item)
        {
            _element.RemoveProperty(item.Key);
            return true;
        }

#if NET6_0_OR_GREATER
        public bool TryGetValue(string key, [MaybeNullWhen(false)] out T value)
#else
        public bool TryGetValue(string key, out T value)
#endif
        {
            if (_element.TryGetProperty(key, out MutableJsonElement element))
            {
                value = element.ConvertTo<T>();
                return true;
            }

            value = default!;
            return false;
        }
    }
}
