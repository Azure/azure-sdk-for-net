// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.StorageCache.Models
{
    public static partial class ArmStorageCacheModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="StorageCache.StorageCacheData"/>. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="cacheSizeGB"> The size of this Cache, in GB. </param>
        /// <param name="health"> Health of the cache. </param>
        /// <param name="mountAddresses"> Array of IPv4 addresses that can be used by clients mounting this cache. </param>
        /// <param name="provisioningState"> ARM provisioning state, see https://github.com/Azure/azure-resource-manager-rpc/blob/master/v1.0/Addendum.md#provisioningstate-property. </param>
        /// <param name="subnet"> Subnet used for the cache. </param>
        /// <param name="upgradeStatus"> Upgrade status of the cache. </param>
        /// <param name="upgradeSettings"> Upgrade settings of the cache. </param>
        /// <param name="networkSettings"> Specifies network settings of the cache. </param>
        /// <param name="encryptionSettings"> Specifies encryption settings of the cache. </param>
        /// <param name="directoryServicesSettings"> Specifies Directory Services settings of the cache. </param>
        /// <param name="zones"> Availability zones for resources. This field should only contain a single element in the array. </param>
        /// <param name="primingJobs"> Specifies the priming jobs defined in the cache. </param>
        /// <param name="spaceAllocation"> Specifies the space allocation percentage for each storage target in the cache. </param>
        /// <param name="securityAccessPolicies"> NFS access policies defined for this cache. </param>
        /// <param name="identity"> The identity of the cache, if configured. </param>
        /// <param name="skuName"> SKU name for this cache. </param>
        /// <returns> A new <see cref="StorageCache.StorageCacheData"/> instance for mocking. </returns>
        public static StorageCacheData StorageCacheData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, int? cacheSizeGB = default, StorageCacheHealth health = default, IEnumerable<IPAddress> mountAddresses = default, StorageCacheProvisioningStateType? provisioningState = default, ResourceIdentifier subnet = default, StorageCacheUpgradeStatus upgradeStatus = default, StorageCacheUpgradeSettings upgradeSettings = default, StorageCacheNetworkSettings networkSettings = default, StorageCacheEncryptionSettings encryptionSettings = default, StorageCacheDirectorySettings directoryServicesSettings = default, IEnumerable<string> zones = default, IEnumerable<PrimingJob> primingJobs = default, IEnumerable<StorageTargetSpaceAllocation> spaceAllocation = default, IEnumerable<NfsAccessPolicy> securityAccessPolicies = default, ManagedServiceIdentity identity = default, string skuName = default)
        {
            // The generator moved this shipped overload to a different parameter order after primingJobs became input-capable.
            return StorageCacheData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                identity,
                skuName,
                cacheSizeGB,
                health,
                mountAddresses,
                provisioningState,
                subnet,
                upgradeStatus,
                upgradeSettings,
                networkSettings,
                encryptionSettings,
                securityAccessPolicies,
                directoryServicesSettings,
                zones,
                primingJobs,
                spaceAllocation);
        }
    }
}
