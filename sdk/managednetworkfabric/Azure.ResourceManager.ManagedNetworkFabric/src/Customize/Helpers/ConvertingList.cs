// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    internal sealed class ConvertingList<TCompatibility, TGenerated> : IList<TCompatibility>
    {
        private readonly IList<TGenerated> _inner;
        private readonly Func<TGenerated, TCompatibility> _toCompatibility;
        private readonly Func<TCompatibility, TGenerated> _toGenerated;

        public ConvertingList(IList<TGenerated> inner, Func<TGenerated, TCompatibility> toCompatibility, Func<TCompatibility, TGenerated> toGenerated)
        {
            _inner = inner;
            _toCompatibility = toCompatibility;
            _toGenerated = toGenerated;
        }

        public TCompatibility this[int index]
        {
            get => _toCompatibility(_inner[index]);
            set => _inner[index] = _toGenerated(value);
        }

        public int Count => _inner.Count;

        public bool IsReadOnly => _inner.IsReadOnly;

        public void Add(TCompatibility item) => _inner.Add(_toGenerated(item));

        public void Clear() => _inner.Clear();

        public bool Contains(TCompatibility item) => _inner.Contains(_toGenerated(item));

        public void CopyTo(TCompatibility[] array, int arrayIndex)
        {
            for (int i = 0; i < _inner.Count; i++)
            {
                array[arrayIndex + i] = _toCompatibility(_inner[i]);
            }
        }

        public IEnumerator<TCompatibility> GetEnumerator()
        {
            foreach (TGenerated item in _inner)
            {
                yield return _toCompatibility(item);
            }
        }

        public int IndexOf(TCompatibility item) => _inner.IndexOf(_toGenerated(item));

        public void Insert(int index, TCompatibility item) => _inner.Insert(index, _toGenerated(item));

        public bool Remove(TCompatibility item) => _inner.Remove(_toGenerated(item));

        public void RemoveAt(int index) => _inner.RemoveAt(index);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
