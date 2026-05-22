// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class NeighborGroupDestination
    {
        /// <summary> Array of IPv4 Addresses. </summary>
        public IList<IPAddress> IPv4Addresses => new IPAddressStringList(Ipv4Addresses);

        /// <summary> Array of IPv6 Addresses. </summary>
        public IList<string> IPv6Addresses => Ipv6Addresses;

        private sealed class IPAddressStringList : IList<IPAddress>
        {
            private readonly IList<string> _inner;

            public IPAddressStringList(IList<string> inner)
            {
                _inner = inner;
            }

            public IPAddress this[int index]
            {
                get => IPAddress.Parse(_inner[index]);
                set => _inner[index] = value?.ToString();
            }

            public int Count => _inner.Count;
            public bool IsReadOnly => _inner.IsReadOnly;
            public void Add(IPAddress item) => _inner.Add(item?.ToString());
            public void Clear() => _inner.Clear();
            public bool Contains(IPAddress item) => _inner.Contains(item?.ToString());
            public void CopyTo(IPAddress[] array, int arrayIndex)
            {
                Argument.AssertNotNull(array, nameof(array));
                for (int i = 0; i < _inner.Count; i++)
                {
                    array[arrayIndex + i] = IPAddress.Parse(_inner[i]);
                }
            }

            public IEnumerator<IPAddress> GetEnumerator()
            {
                foreach (string value in _inner)
                {
                    yield return IPAddress.Parse(value);
                }
            }

            public int IndexOf(IPAddress item) => _inner.IndexOf(item?.ToString());
            public void Insert(int index, IPAddress item) => _inner.Insert(index, item?.ToString());
            public bool Remove(IPAddress item) => _inner.Remove(item?.ToString());
            public void RemoveAt(int index) => _inner.RemoveAt(index);
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
