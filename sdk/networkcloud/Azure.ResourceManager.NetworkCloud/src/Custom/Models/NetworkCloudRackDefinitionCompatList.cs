// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections;
using System.Collections.Generic;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    /// <summary>
    /// A live translating view over a <see cref="NetworkCloudRackDefinitionPatch"/> collection that
    /// exposes it as <see cref="NetworkCloudRackDefinition"/> for backward compatibility with the
    /// pre-1.4.0 public surface of <see cref="NetworkCloudClusterPatch.ComputeRackDefinitions"/>.
    /// </summary>
    internal sealed class NetworkCloudRackDefinitionCompatList : IList<NetworkCloudRackDefinition>
    {
        private readonly IList<NetworkCloudRackDefinitionPatch> _inner;

        public NetworkCloudRackDefinitionCompatList(IList<NetworkCloudRackDefinitionPatch> inner)
        {
            _inner = inner;
        }

        public NetworkCloudRackDefinition this[int index]
        {
            get => NetworkCloudPatchCompatibility.ToClassic(_inner[index]);
            set => _inner[index] = NetworkCloudPatchCompatibility.ToPatch(value);
        }

        public int Count => _inner.Count;

        public bool IsReadOnly => _inner.IsReadOnly;

        public void Add(NetworkCloudRackDefinition item) => _inner.Add(NetworkCloudPatchCompatibility.ToPatch(item));

        public void Clear() => _inner.Clear();

        public bool Contains(NetworkCloudRackDefinition item) => IndexOf(item) >= 0;

        public void CopyTo(NetworkCloudRackDefinition[] array, int arrayIndex)
        {
            for (int i = 0; i < _inner.Count; i++)
            {
                array[arrayIndex + i] = NetworkCloudPatchCompatibility.ToClassic(_inner[i]);
            }
        }

        public IEnumerator<NetworkCloudRackDefinition> GetEnumerator()
        {
            foreach (NetworkCloudRackDefinitionPatch item in _inner)
            {
                yield return NetworkCloudPatchCompatibility.ToClassic(item);
            }
        }

        public int IndexOf(NetworkCloudRackDefinition item)
        {
            for (int i = 0; i < _inner.Count; i++)
            {
                if (NetworkCloudPatchCompatibility.ToClassic(_inner[i])?.RackSerialNumber == item?.RackSerialNumber)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, NetworkCloudRackDefinition item) => _inner.Insert(index, NetworkCloudPatchCompatibility.ToPatch(item));

        public bool Remove(NetworkCloudRackDefinition item)
        {
            int index = IndexOf(item);
            if (index < 0)
            {
                return false;
            }
            _inner.RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index) => _inner.RemoveAt(index);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
