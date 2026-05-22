// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    internal sealed class ResourceIdentifierStringList : IList<ResourceIdentifier>
    {
        private readonly IList<string> _inner;

        public ResourceIdentifierStringList(IList<string> inner)
        {
            _inner = inner;
        }

        public ResourceIdentifier this[int index]
        {
            get => _inner[index] is null ? null : new ResourceIdentifier(_inner[index]);
            set => _inner[index] = value?.ToString();
        }

        public int Count => _inner.Count;
        public bool IsReadOnly => _inner.IsReadOnly;
        public void Add(ResourceIdentifier item) => _inner.Add(item?.ToString());
        public void Clear() => _inner.Clear();
        public bool Contains(ResourceIdentifier item) => _inner.Contains(item?.ToString());
        public void CopyTo(ResourceIdentifier[] array, int arrayIndex)
        {
            Argument.AssertNotNull(array, nameof(array));
            for (int i = 0; i < _inner.Count; i++)
            {
                array[arrayIndex + i] = _inner[i] is null ? null : new ResourceIdentifier(_inner[i]);
            }
        }

        public IEnumerator<ResourceIdentifier> GetEnumerator()
        {
            foreach (string value in _inner)
            {
                yield return value is null ? null : new ResourceIdentifier(value);
            }
        }

        public int IndexOf(ResourceIdentifier item) => _inner.IndexOf(item?.ToString());
        public void Insert(int index, ResourceIdentifier item) => _inner.Insert(index, item?.ToString());
        public bool Remove(ResourceIdentifier item) => _inner.Remove(item?.ToString());
        public void RemoveAt(int index) => _inner.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
