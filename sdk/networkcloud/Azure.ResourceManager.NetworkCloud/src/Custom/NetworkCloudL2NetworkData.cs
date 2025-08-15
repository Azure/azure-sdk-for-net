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
    /// A class representing the NetworkCloudL2Network data model.
    /// L2Network represents a network that utilizes a single isolation domain set up for layer-2 resources.
    /// </summary>
    public partial class NetworkCloudL2NetworkData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudL2NetworkData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="l2IsolationDomainId"> The resource ID of the Network Fabric l2IsolationDomain. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="extendedLocation"/> or <paramref name="l2IsolationDomainId"/> is null. </exception>
        public NetworkCloudL2NetworkData(AzureLocation location, ExtendedLocation extendedLocation, ResourceIdentifier l2IsolationDomainId)
            : this(location, l2IsolationDomainId, extendedLocation)
        {
        }
    }
}
