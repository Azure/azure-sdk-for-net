// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    /// <summary>
    /// A class representing the NetworkCloudL3Network data model.
    /// L3Network represents a network that utilizes a single isolation domain set up for layer-3 resources.
    /// </summary>
    public partial class NetworkCloudL3NetworkData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudL3NetworkData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="l3IsolationDomainId"> The resource ID of the Network Fabric l3IsolationDomain. </param>
        /// <param name="vlan"> The VLAN from the l3IsolationDomain that is used for this network. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="extendedLocation"/> or <paramref name="l3IsolationDomainId"/> is null. </exception>
        public NetworkCloudL3NetworkData(AzureLocation location, ExtendedLocation extendedLocation, ResourceIdentifier l3IsolationDomainId, long vlan)
        : this(location, l3IsolationDomainId, vlan, extendedLocation)
        {
        }
    }
}
