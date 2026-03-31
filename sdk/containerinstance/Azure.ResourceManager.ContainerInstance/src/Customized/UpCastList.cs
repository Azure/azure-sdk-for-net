// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.ContainerInstance
{
    /// <summary>
    /// Internal adapter that presents an IList&lt;TBase&gt; as IList&lt;TDerived&gt;
    /// for backward-compat property shims where TDerived : TBase (class inheritance).
    /// </summary>
    internal sealed class UpCastList<TDerived, TBase> : IList<TDerived>
        where TDerived : class, TBase
        where TBase : class
    {
        private readonly IList<TBase> _inner;

        internal UpCastList(IList<TBase> inner) => _inner = inner;

        public TDerived this[int index]
        {
            get => _inner[index] as TDerived;
            set => _inner[index] = value;
        }

        public int Count => _inner.Count;
        public bool IsReadOnly => _inner.IsReadOnly;
        public void Add(TDerived item) => _inner.Add(item);
        public void Clear() => _inner.Clear();
        public bool Contains(TDerived item) => _inner.Contains(item);
        public void CopyTo(TDerived[] array, int arrayIndex)
        {
            for (int i = 0; i < _inner.Count; i++)
                array[arrayIndex + i] = _inner[i] as TDerived;
        }
        public IEnumerator<TDerived> GetEnumerator() => _inner.Select(x => x as TDerived).GetEnumerator();
        public int IndexOf(TDerived item) => _inner.IndexOf(item);
        public void Insert(int index, TDerived item) => _inner.Insert(index, item);
        public bool Remove(TDerived item) => _inner.Remove(item);
        public void RemoveAt(int index) => _inner.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
