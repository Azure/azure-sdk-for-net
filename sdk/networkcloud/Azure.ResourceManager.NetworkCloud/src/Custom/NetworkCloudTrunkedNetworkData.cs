// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    /// <summary>
    /// A class representing the NetworkCloudTrunkedNetwork data model.
    /// TrunkedNetwork represents a network that utilizes multiple isolation domains and specified VLANs to create a trunked network.
    /// </summary>
    public partial class NetworkCloudTrunkedNetworkData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudTrunkedNetworkData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="isolationDomainIds"> The list of resource IDs representing the Network Fabric isolation domains. It can be any combination of l2IsolationDomain and l3IsolationDomain resources. </param>
        /// <param name="vlans"> The list of vlans that are selected from the isolation domains for trunking. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="extendedLocation"/>, <paramref name="isolationDomainIds"/> or <paramref name="vlans"/> is null. </exception>
        public NetworkCloudTrunkedNetworkData(AzureLocation location, ExtendedLocation extendedLocation, IEnumerable<ResourceIdentifier> isolationDomainIds, IEnumerable<long> vlans)
            : this(location, isolationDomainIds, vlans,extendedLocation)
        {
        }
    }
}