// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
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
                return new ConvertingList<NetworkTapPropertiesDestinationsItem, NetworkTapDestinationProperties>(
                    Properties.DestinationSettings,
                    NetworkTapPropertiesDestinationsItem.FromDestinationProperties,
                    ToDestinationProperties);
            }
        }

        private static NetworkTapDestinationProperties ToDestinationProperties(NetworkTapPropertiesDestinationsItem value)
            => value;
#pragma warning restore CS0618
    }
}
