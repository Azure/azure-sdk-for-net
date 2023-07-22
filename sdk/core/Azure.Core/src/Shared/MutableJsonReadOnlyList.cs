// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

#nullable enable

namespace Azure.Core.Json
{
    // TODO: Add test coverage
    internal readonly struct MutableJsonReadOnlyList<T> : IReadOnlyList<T>
    {
        private readonly MutableJsonElement _element;

        public MutableJsonReadOnlyList(MutableJsonElement element)
        {
            _element = element;

            Debug.Assert(_element.ValueKind == JsonValueKind.Array);
        }

        public T this[int index] => _element.GetIndexElement(index).ConvertTo<T>();

        public int Count => _element.GetArrayLength();

        public IEnumerator<T> GetEnumerator()
        {
            foreach (MutableJsonElement item in _element.EnumerateArray())
            {
                yield return item.ConvertTo<T>();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (MutableJsonElement item in _element.EnumerateArray())
            {
                yield return item.ConvertTo<T>();
            }
        }
    }
}
