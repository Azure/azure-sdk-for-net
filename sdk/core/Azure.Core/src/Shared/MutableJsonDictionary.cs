// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

#nullable enable

namespace Azure.Core.Json
{
    // TODO: this should use Value when availble, to avoid boxing value types.
    internal readonly struct MutableJsonDictionary<T> : IDictionary<string, T>
    {
        private readonly MutableJsonElement _element;

        public MutableJsonDictionary(MutableJsonElement element)
        {
            _element = element;

            Debug.Assert(_element.ValueKind == JsonValueKind.Object);
        }

        public T this[string key]
        {
            get
            {
                return _element.GetProperty(key).ConvertTo<T>();
            }
            set => _element.SetProperty(key, value);
        }

        public ICollection<string> Keys => throw new NotImplementedException();

        public ICollection<T> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(string key, T value)
        {
            Argument.AssertNotNull(key, nameof(key));

            if (_element.TryGetProperty(key, out _))
            {
                throw new ArgumentException($"An element with the same key already exists in the MutableJsonDictionary<string,{typeof(T)}>.");
            }

            _element.SetProperty(key, value);
        }

        public void Add(KeyValuePair<string, T> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<string, T> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(string key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<string, T>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, T>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, T> item)
        {
            throw new NotImplementedException();
        }

#if NET6_0_OR_GREATER
        public bool TryGetValue(string key, [MaybeNullWhen(false)] out T value)
#else
        public bool TryGetValue(string key, out T value)
#endif
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
