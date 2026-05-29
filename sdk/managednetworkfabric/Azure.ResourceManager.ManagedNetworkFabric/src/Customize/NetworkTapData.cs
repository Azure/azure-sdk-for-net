// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class NetworkTapData
    {
#pragma warning disable CS0618 // Preserve obsolete NetworkTap destination compatibility surface.
        /// <summary> Initializes a new instance of <see cref="NetworkTapData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="networkPacketBrokerId"> ARM resource ID of the Network Packet Broker. </param>
        /// <param name="destinations"> List of destinations to send the filter traffic. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This constructor is obsolete and will be removed in a future version. Use NetworkTapDestinationProperties for destinations instead.")]
        public NetworkTapData(AzureLocation location, ResourceIdentifier networkPacketBrokerId, IEnumerable<NetworkTapPropertiesDestinationsItem> destinations) : this(location, networkPacketBrokerId, destinations?.Cast<NetworkTapDestinationProperties>())
        {
        }

        // Backward compatibility shim for the TypeSpec migration. The current generated property
        // is DestinationSettings and uses the shared NetworkTapDestinationProperties model directly.
        /// <summary> List of destination properties to send the filter traffic. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use DestinationSettings instead.")]
        public IList<NetworkTapPropertiesDestinationsItem> Destinations
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new NetworkTapProperties();
                }
                return new NetworkTapPropertiesDestinationsItemList(Properties.DestinationSettings);
            }
        }

        private sealed class NetworkTapPropertiesDestinationsItemList : IList<NetworkTapPropertiesDestinationsItem>
        {
            private readonly IList<NetworkTapDestinationProperties> _inner;

            public NetworkTapPropertiesDestinationsItemList(IList<NetworkTapDestinationProperties> inner)
            {
                _inner = inner;
            }

            public NetworkTapPropertiesDestinationsItem this[int index]
            {
                get => NetworkTapPropertiesDestinationsItem.FromDestinationProperties(_inner[index]);
                set => _inner[index] = value;
            }

            public int Count => _inner.Count;
            public bool IsReadOnly => _inner.IsReadOnly;
            public void Add(NetworkTapPropertiesDestinationsItem item) => _inner.Add(item);
            public void Clear() => _inner.Clear();
            public bool Contains(NetworkTapPropertiesDestinationsItem item) => _inner.Contains(item);
            public void CopyTo(NetworkTapPropertiesDestinationsItem[] array, int arrayIndex)
            {
                for (int i = 0; i < _inner.Count; i++)
                {
                    array[arrayIndex + i] = NetworkTapPropertiesDestinationsItem.FromDestinationProperties(_inner[i]);
                }
            }
            public IEnumerator<NetworkTapPropertiesDestinationsItem> GetEnumerator()
            {
                foreach (NetworkTapDestinationProperties item in _inner)
                {
                    yield return NetworkTapPropertiesDestinationsItem.FromDestinationProperties(item);
                }
            }
            public int IndexOf(NetworkTapPropertiesDestinationsItem item) => _inner.IndexOf(item);
            public void Insert(int index, NetworkTapPropertiesDestinationsItem item) => _inner.Insert(index, item);
            public bool Remove(NetworkTapPropertiesDestinationsItem item) => _inner.Remove(item);
            public void RemoveAt(int index) => _inner.RemoveAt(index);
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
#pragma warning restore CS0618
    }
}
