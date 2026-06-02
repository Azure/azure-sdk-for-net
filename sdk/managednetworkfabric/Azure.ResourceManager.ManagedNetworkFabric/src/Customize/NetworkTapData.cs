// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // Backward compatibility shim for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // The new API version removed the public constructor that was present in v1.1.2.
    // This preserves the old constructor signature.
    public partial class NetworkTapData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkTapData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="networkPacketBrokerId"> ARM resource ID of the Network Packet Broker. </param>
        /// <param name="destinations"> List of destinations to send the filter traffic. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkTapData(AzureLocation location, ResourceIdentifier networkPacketBrokerId, IEnumerable<NetworkTapPropertiesDestinationsItem> destinations) : base(location)
        {
            NetworkPacketBrokerId = networkPacketBrokerId;
            Destinations = destinations?.ToList();
        }
    }
}
