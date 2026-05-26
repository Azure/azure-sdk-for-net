// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ElasticSan.Models
{
    // temperary util https://github.com/Azure/azure-sdk-for-net/issues/55203 is resolved
    public static partial class ArmElasticSanModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="ElasticSan.ElasticSanVolumeGroupData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="identity"> The identity of the resource. Current supported identity types: None, SystemAssigned, UserAssigned. </param>
        /// <param name="provisioningState"> State of the operation on the resource. </param>
        /// <param name="protocolType"> Type of storage target. </param>
        /// <param name="encryption"> Type of encryption. </param>
        /// <param name="encryptionProperties"> Encryption Properties describing Key Vault and Identity information. </param>
        /// <param name="virtualNetworkRules"> A collection of rules governing the accessibility from specific network locations. </param>
        /// <param name="privateEndpointConnections"> The list of Private Endpoint Connections. </param>
        /// <returns> A new <see cref="ElasticSan.ElasticSanVolumeGroupData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ElasticSanVolumeGroupData ElasticSanVolumeGroupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ManagedServiceIdentity identity, ElasticSanProvisioningState? provisioningState, ElasticSanStorageTargetType? protocolType, ElasticSanEncryptionType? encryption, ElasticSanEncryptionProperties encryptionProperties, IEnumerable<ElasticSanVirtualNetworkRule> virtualNetworkRules, IEnumerable<ElasticSanPrivateEndpointConnectionData> privateEndpointConnections)
        {
            return ElasticSanVolumeGroupData(id, name, resourceType, systemData, identity, provisioningState, protocolType, encryption, encryptionProperties, virtualNetworkRules, privateEndpointConnections, enforceDataIntegrityCheckForIscsi: default);
        }

        // Backward-compat: pre-overhaul signature had baseSizeTiB and extendedCapacitySizeTiB as long? (nullable).
        // The mgmt generator's flatten/lift-to-nullable overhaul now exposes these as non-nullable long.
        /// <summary> Initializes a new instance of <see cref="ElasticSan.ElasticSanData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ElasticSanData ElasticSanData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ElasticSanSku sku, IEnumerable<string> availabilityZones, ElasticSanProvisioningState? provisioningState, long? baseSizeTiB, long? extendedCapacitySizeTiB, long? totalVolumeSizeGiB, long? volumeGroupCount, long? totalIops, long? totalMbps, long? totalSizeTiB, IEnumerable<ElasticSanPrivateEndpointConnectionData> privateEndpointConnections, ElasticSanPublicNetworkAccess? publicNetworkAccess, ElasticSanScaleUpProperties scaleUpProperties)
        {
            return ElasticSanData(id, name, resourceType, systemData, tags, location, sku, availabilityZones, provisioningState, baseSizeTiB.GetValueOrDefault(), extendedCapacitySizeTiB.GetValueOrDefault(), totalVolumeSizeGiB, volumeGroupCount, totalIops, totalMbps, totalSizeTiB, privateEndpointConnections, publicNetworkAccess, scaleUpProperties);
        }

        // Workaround: The generator has a bug that when an overload is created in customized code with the same parameter list, but the nullability of some parameters is different,
        // the generator somehow treat the overload as a duplicated method, and the generated overload with different nullability will no longer be generated.
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="sku"> resource sku. </param>
        /// <param name="availabilityZones"> Logical zone for Elastic San resource; example: ["1"]. </param>
        /// <param name="provisioningState"> State of the operation on the resource. </param>
        /// <param name="baseSizeTiB"> Base size of the Elastic San appliance in TiB. </param>
        /// <param name="extendedCapacitySizeTiB"> Extended size of the Elastic San appliance in TiB. </param>
        /// <param name="totalVolumeSizeGiB"> Total size of the provisioned Volumes in GiB. </param>
        /// <param name="volumeGroupCount"> Total number of volume groups in this Elastic San appliance. </param>
        /// <param name="totalIops"> Total Provisioned IOPS of the Elastic San appliance. </param>
        /// <param name="totalMbps"> Total Provisioned MBps Elastic San appliance. </param>
        /// <param name="totalSizeTiB"> Total size of the Elastic San appliance in TB. </param>
        /// <param name="privateEndpointConnections"> The list of Private Endpoint Connections. </param>
        /// <param name="publicNetworkAccess"> Allow or disallow public network access to ElasticSan. Value is optional but if passed in, must be 'Enabled' or 'Disabled'. </param>
        /// <param name="scaleUpProperties"> Scale up settings on Elastic San Appliance. </param>
        /// <returns> A new <see cref="ElasticSan.ElasticSanData"/> instance for mocking. </returns>
        public static ElasticSanData ElasticSanData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, ElasticSanSku sku = default, IEnumerable<string> availabilityZones = default, ElasticSanProvisioningState? provisioningState = default, long baseSizeTiB = default, long extendedCapacitySizeTiB = default, long? totalVolumeSizeGiB = default, long? volumeGroupCount = default, long? totalIops = default, long? totalMbps = default, long? totalSizeTiB = default, IEnumerable<ElasticSanPrivateEndpointConnectionData> privateEndpointConnections = default, ElasticSanPublicNetworkAccess? publicNetworkAccess = default, ElasticSanScaleUpProperties scaleUpProperties = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new ElasticSanData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                new ElasticSanProperties(
                    sku,
                    (availabilityZones ?? new ChangeTrackingList<string>()).ToList(),
                    provisioningState,
                    baseSizeTiB,
                    extendedCapacitySizeTiB,
                    totalVolumeSizeGiB,
                    volumeGroupCount,
                    totalIops,
                    totalMbps,
                    totalSizeTiB,
                    (privateEndpointConnections ?? new ChangeTrackingList<ElasticSanPrivateEndpointConnectionData>()).ToList(),
                    publicNetworkAccess,
                    new AutoScaleProperties(scaleUpProperties, null),
                    null));
        }
    }
}
