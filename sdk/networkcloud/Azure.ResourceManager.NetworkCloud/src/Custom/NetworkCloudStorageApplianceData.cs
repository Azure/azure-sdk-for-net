// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    /// <summary>
    /// A class representing the NetworkCloudStorageAppliance data model.
    /// StorageAppliance represents on-premises Network Cloud storage appliance.
    /// </summary>
    public partial class NetworkCloudStorageApplianceData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudStorageApplianceData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="administratorCredentials"> The credentials of the administrative interface on this storage appliance. </param>
        /// <param name="rackId"> The resource ID of the rack where this storage appliance resides. </param>
        /// <param name="rackSlot"> The slot the storage appliance is in the rack based on the BOM configuration. </param>
        /// <param name="serialNumber"> The serial number for the storage appliance. </param>
        /// <param name="storageApplianceSkuId"> The SKU for the storage appliance. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="extendedLocation"/>, <paramref name="administratorCredentials"/>, <paramref name="rackId"/>, <paramref name="serialNumber"/> or <paramref name="storageApplianceSkuId"/> is null. </exception>
        public NetworkCloudStorageApplianceData(AzureLocation location, ExtendedLocation extendedLocation, AdministrativeCredentials administratorCredentials, ResourceIdentifier rackId, long rackSlot, string serialNumber, string storageApplianceSkuId)
            : this(location,  administratorCredentials,  rackId, rackSlot, serialNumber, storageApplianceSkuId, extendedLocation)
        {
        }
    }
}
