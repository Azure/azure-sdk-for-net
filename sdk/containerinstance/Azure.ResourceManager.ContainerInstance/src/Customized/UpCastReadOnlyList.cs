// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.ContainerInstance
{
    /// <summary>
    /// Internal adapter that presents an IReadOnlyList&lt;TBase&gt; as IReadOnlyList&lt;TDerived&gt;.
    /// </summary>
    internal sealed class UpCastReadOnlyList<TDerived, TBase> : IReadOnlyList<TDerived>
        where TDerived : class, TBase
        where TBase : class
    {
        private readonly IReadOnlyList<TBase> _inner;

        internal UpCastReadOnlyList(IReadOnlyList<TBase> inner) => _inner = inner;

        public TDerived this[int index] => _inner[index] as TDerived;
        public int Count => _inner.Count;
        public IEnumerator<TDerived> GetEnumerator() => _inner.Select(x => x as TDerived).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
