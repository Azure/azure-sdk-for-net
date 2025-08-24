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
    /// A class representing the NetworkCloudRack data model.
    /// Rack represents the hardware of the rack and is dependent upon the cluster for lifecycle.
    /// </summary>
    public partial class NetworkCloudRackData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudRackData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="availabilityZone"> The value that will be used for machines in this rack to represent the availability zones that can be referenced by Hybrid AKS Clusters for node arrangement. </param>
        /// <param name="rackLocation"> The free-form description of the rack location. (e.g. “DTN Datacenter, Floor 3, Isle 9, Rack 2B”). </param>
        /// <param name="rackSerialNumber"> The unique identifier for the rack within Network Cloud cluster. An alternate unique alphanumeric value other than a serial number may be provided if desired. </param>
        /// <param name="rackSkuId"> The SKU for the rack. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="extendedLocation"/>, <paramref name="availabilityZone"/>, <paramref name="rackLocation"/>, <paramref name="rackSerialNumber"/> or <paramref name="rackSkuId"/> is null. </exception>
        public NetworkCloudRackData(AzureLocation location, ExtendedLocation extendedLocation, string availabilityZone, string rackLocation, string rackSerialNumber, ResourceIdentifier rackSkuId)
            : this(location, availabilityZone, rackLocation, rackSerialNumber, rackSkuId, extendedLocation)
        {
        }
    }
}
