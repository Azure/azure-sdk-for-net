// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.StorageCache.Models;

namespace Azure.ResourceManager.StorageCache
{
    /// <summary>
    /// A class representing the AmlFileSystem data model.
    /// An AML file system instance. Follows Azure Resource Manager standards: https://github.com/Azure/azure-resource-manager-rpc/blob/master/v1.0/resource-api-reference.md
    /// </summary>
    public partial class AmlFileSystemData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of <see cref="AmlFileSystemData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="identity"> The managed identity used by the AML file system, if configured. Current supported identity types: None, UserAssigned. </param>
        /// <param name="sku"> SKU for the resource. </param>
        /// <param name="zones"> Availability zones for resources. This field should only contain a single element in the array. </param>
        /// <param name="storageCapacityTiB"> The size of the AML file system, in TiB. This might be rounded up. </param>
        /// <param name="health"> Health of the AML file system. </param>
        /// <param name="provisioningState"> ARM provisioning state. </param>
        /// <param name="filesystemSubnet"> Subnet used for managing the AML file system and for client-facing operations. This subnet should have at least a /24 subnet mask within the VNET's address space. </param>
        /// <param name="clientInfo"> Client information for the AML file system. </param>
        /// <param name="throughputProvisionedMBps"> Throughput provisioned in MB per sec, calculated as storageCapacityTiB * per-unit storage throughput. </param>
        /// <param name="encryptionSettings"> Specifies encryption settings of the AML file system. </param>
        /// <param name="maintenanceWindow"> Start time of a 30-minute weekly maintenance window. </param>
        /// <param name="hsm"> Hydration and archive settings and status. </param>
        internal AmlFileSystemData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedServiceIdentity identity, StorageCacheSkuName sku, IList<string> zones, float? storageCapacityTiB, AmlFileSystemHealth health, AmlFileSystemProvisioningStateType? provisioningState, string filesystemSubnet, AmlFileSystemClientInfo clientInfo, int? throughputProvisionedMBps, AmlFileSystemEncryptionSettings encryptionSettings, AmlFileSystemPropertiesMaintenanceWindow maintenanceWindow, AmlFileSystemPropertiesHsm hsm) : base(id, name, resourceType, systemData, tags, location)
        {
            AmlFileSystemData amlFSData = new AmlFileSystemData(id, name, resourceType, systemData, tags, location, identity, sku, zones, storageCapacityTiB, health, provisioningState, filesystemSubnet, clientInfo, throughputProvisionedMBps, encryptionSettings, maintenanceWindow, hsm, null, null);
        }
    }
}
