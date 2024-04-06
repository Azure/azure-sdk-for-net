// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.StorageCache;

namespace Azure.ResourceManager.StorageCache.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmStorageCacheModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="StorageCache.AmlFileSystemData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="identity"> The managed identity used by the AML file system, if configured. Current supported identity types: None, UserAssigned. </param>
        /// <param name="skuName"> SKU for the resource. </param>
        /// <param name="zones"> Availability zones for resources. This field should only contain a single element in the array. </param>
        /// <param name="storageCapacityTiB"> The size of the AML file system, in TiB. This might be rounded up. </param>
        /// <param name="health"> Health of the AML file system. </param>
        /// <param name="provisioningState"> ARM provisioning state. </param>
        /// <param name="filesystemSubnet"> Subnet used for managing the AML file system and for client-facing operations. This subnet should have at least a /24 subnet mask within the VNET's address space. </param>
        /// <param name="clientInfo"> Client information for the AML file system. </param>
        /// <param name="throughputProvisionedMBps"> Throughput provisioned in MB per sec, calculated as storageCapacityTiB * per-unit storage throughput. </param>
        /// <param name="keyEncryptionKey"> Specifies encryption settings of the AML file system. </param>
        /// <param name="maintenanceWindow"> Start time of a 30-minute weekly maintenance window. </param>
        /// <param name="hsm"> Hydration and archive settings and status. </param>
        /// <returns> A new <see cref="StorageCache.AmlFileSystemData"/> instance for mocking. </returns>
        public static AmlFileSystemData AmlFileSystemData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, ResourceManager.Models.SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, ManagedServiceIdentity identity = null, string skuName = null, IEnumerable<string> zones = null, float? storageCapacityTiB = null, AmlFileSystemHealth health = null, AmlFileSystemProvisioningStateType? provisioningState = null, string filesystemSubnet = null, AmlFileSystemClientInfo clientInfo = null, int? throughputProvisionedMBps = null, StorageCacheEncryptionKeyVaultKeyReference keyEncryptionKey = null, AmlFileSystemPropertiesMaintenanceWindow maintenanceWindow = null, AmlFileSystemPropertiesHsm hsm = null)
        {
            tags ??= new Dictionary<string, string>();
            zones ??= new List<string>();

            return new AmlFileSystemData(id, name, resourceType, systemData, tags, location, identity, skuName != null ? new StorageCacheSkuName(skuName, null) : null, zones?.ToList(), storageCapacityTiB, health, provisioningState, filesystemSubnet, clientInfo, throughputProvisionedMBps, keyEncryptionKey != null ? new AmlFileSystemEncryptionSettings(keyEncryptionKey, null) : null, maintenanceWindow, hsm, null, null);
        }
    }
}
