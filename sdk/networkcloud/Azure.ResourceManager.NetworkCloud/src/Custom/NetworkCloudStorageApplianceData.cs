// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudStorageApplianceData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudStorageApplianceData"/>. </summary>
        public NetworkCloudStorageApplianceData(AzureLocation location, ExtendedLocation extendedLocation, AdministrativeCredentials administratorCredentials, ResourceIdentifier rackId, long rackSlot, string serialNumber, string storageApplianceSkuId)
            : base(location)
        {
            Argument.AssertNotNull(extendedLocation, nameof(extendedLocation));
            Argument.AssertNotNull(administratorCredentials, nameof(administratorCredentials));
            Argument.AssertNotNull(rackId, nameof(rackId));
            Argument.AssertNotNull(serialNumber, nameof(serialNumber));
            Argument.AssertNotNull(storageApplianceSkuId, nameof(storageApplianceSkuId));
            Properties = new StorageApplianceProperties(administratorCredentials, rackId, rackSlot, serialNumber, storageApplianceSkuId, caCertificate: null, capacity: null, capacityUsed: null, clusterId: null, detailedStatus: null, detailedStatusMessage: null, expansionShelves: null, managementIPv4Address: null, manufacturer: null, model: null, monitoringConfigurationStatus: null, remoteVendorManagementFeature: null, remoteVendorManagementStatus: null, secretRotationStatus: null, version: null, provisioningState: null, additionalBinaryDataProperties: null);
            ExtendedLocation = extendedLocation;
        }

        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }
    }
}
