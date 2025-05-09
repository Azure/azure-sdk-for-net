// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ElasticSan.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmElasticSanModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.ElasticSanSkuInformation"/>. </summary>
        /// <param name="name"> Sku Name. </param>
        /// <param name="tier"> Sku Tier. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <param name="locations"> The set of locations that the SKU is available. This will be supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.). </param>
        /// <param name="locationInfo"> Availability of the SKU for the location/zone. </param>
        /// <param name="capabilities"> The capability information in the specified SKU. </param>
        /// <returns> A new <see cref="Models.ElasticSanSkuInformation"/> instance for mocking. </returns>
        public static ElasticSanSkuInformation ElasticSanSkuInformation(ElasticSanSkuName name = default, ElasticSanSkuTier? tier = null, string resourceType = null, IEnumerable<string> locations = null, IEnumerable<ElasticSanSkuLocationInfo> locationInfo = null, IEnumerable<ElasticSanSkuCapability> capabilities = null)
        {
            locations ??= new List<string>();
            locationInfo ??= new List<ElasticSanSkuLocationInfo>();
            capabilities ??= new List<ElasticSanSkuCapability>();

            return new ElasticSanSkuInformation(
                name,
                tier,
                resourceType,
                locations?.ToList(),
                locationInfo?.ToList(),
                capabilities?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ElasticSanSkuLocationInfo"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="zones"> The zones. </param>
        /// <returns> A new <see cref="Models.ElasticSanSkuLocationInfo"/> instance for mocking. </returns>
        public static ElasticSanSkuLocationInfo ElasticSanSkuLocationInfo(AzureLocation? location = null, IEnumerable<string> zones = null)
        {
            zones ??= new List<string>();

            return new ElasticSanSkuLocationInfo(location, zones?.ToList(), serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ElasticSanSkuCapability"/>. </summary>
        /// <param name="name"> The name of capability. </param>
        /// <param name="value"> A string value to indicate states of given capability. </param>
        /// <returns> A new <see cref="Models.ElasticSanSkuCapability"/> instance for mocking. </returns>
        public static ElasticSanSkuCapability ElasticSanSkuCapability(string name = null, string value = null)
        {
            return new ElasticSanSkuCapability(name, value, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="ElasticSan.ElasticSanData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
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
        /// <param name="scaleUpProperties"> Auto Scale Properties for Elastic San Appliance. </param>
        /// <returns> A new <see cref="ElasticSan.ElasticSanData"/> instance for mocking. </returns>
        public static ElasticSanData ElasticSanData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, ElasticSanSku sku = null, IEnumerable<string> availabilityZones = null, ElasticSanProvisioningState? provisioningState = null, long baseSizeTiB = default, long extendedCapacitySizeTiB = default, long? totalVolumeSizeGiB = null, long? volumeGroupCount = null, long? totalIops = null, long? totalMbps = null, long? totalSizeTiB = null, IEnumerable<ElasticSanPrivateEndpointConnectionData> privateEndpointConnections = null, ElasticSanPublicNetworkAccess? publicNetworkAccess = null, ElasticSanScaleUpProperties scaleUpProperties = null)
        {
            tags ??= new Dictionary<string, string>();
            availabilityZones ??= new List<string>();
            privateEndpointConnections ??= new List<ElasticSanPrivateEndpointConnectionData>();

            return new ElasticSanData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                sku,
                availabilityZones?.ToList(),
                provisioningState,
                baseSizeTiB,
                extendedCapacitySizeTiB,
                totalVolumeSizeGiB,
                volumeGroupCount,
                totalIops,
                totalMbps,
                totalSizeTiB,
                privateEndpointConnections?.ToList(),
                publicNetworkAccess,
                scaleUpProperties != null ? new AutoScaleProperties(scaleUpProperties, serializedAdditionalRawData: null) : null,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="ElasticSan.ElasticSanPrivateEndpointConnectionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"> Provisioning State of Private Endpoint connection resource. </param>
        /// <param name="privateEndpointId"> Private Endpoint resource. </param>
        /// <param name="connectionState"> Private Link Service Connection State. </param>
        /// <param name="groupIds"> List of resources private endpoint is mapped. </param>
        /// <returns> A new <see cref="ElasticSan.ElasticSanPrivateEndpointConnectionData"/> instance for mocking. </returns>
        public static ElasticSanPrivateEndpointConnectionData ElasticSanPrivateEndpointConnectionData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ElasticSanProvisioningState? provisioningState = null, ResourceIdentifier privateEndpointId = null, ElasticSanPrivateLinkServiceConnectionState connectionState = null, IEnumerable<string> groupIds = null)
        {
            groupIds ??= new List<string>();

            return new ElasticSanPrivateEndpointConnectionData(
                id,
                name,
                resourceType,
                systemData,
                provisioningState,
                privateEndpointId != null ? ResourceManagerModelFactory.SubResource(privateEndpointId) : null,
                connectionState,
                groupIds?.ToList(),
                serializedAdditionalRawData: null);
        }

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
        /// <param name="enforceDataIntegrityCheckForIscsi"> A boolean indicating whether or not Data Integrity Check is enabled. </param>
        /// <param name="deleteRetentionPolicy"> The retention policy for the soft deleted volume group and its associated resources. </param>
        /// <returns> A new <see cref="ElasticSan.ElasticSanVolumeGroupData"/> instance for mocking. </returns>
        public static ElasticSanVolumeGroupData ElasticSanVolumeGroupData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ManagedServiceIdentity identity = null, ElasticSanProvisioningState? provisioningState = null, ElasticSanStorageTargetType? protocolType = null, ElasticSanEncryptionType? encryption = null, ElasticSanEncryptionProperties encryptionProperties = null, IEnumerable<ElasticSanVirtualNetworkRule> virtualNetworkRules = null, IEnumerable<ElasticSanPrivateEndpointConnectionData> privateEndpointConnections = null, bool? enforceDataIntegrityCheckForIscsi = null, ElasticSanDeleteRetentionPolicy deleteRetentionPolicy = null)
        {
            virtualNetworkRules ??= new List<ElasticSanVirtualNetworkRule>();
            privateEndpointConnections ??= new List<ElasticSanPrivateEndpointConnectionData>();

            return new ElasticSanVolumeGroupData(
                id,
                name,
                resourceType,
                systemData,
                identity,
                provisioningState,
                protocolType,
                encryption,
                encryptionProperties,
                virtualNetworkRules != null ? new ElasticSanNetworkRuleSet(virtualNetworkRules?.ToList(), serializedAdditionalRawData: null) : null,
                privateEndpointConnections?.ToList(),
                enforceDataIntegrityCheckForIscsi,
                deleteRetentionPolicy,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ElasticSanKeyVaultProperties"/>. </summary>
        /// <param name="keyName"> The name of KeyVault key. </param>
        /// <param name="keyVersion"> The version of KeyVault key. </param>
        /// <param name="keyVaultUri"> The Uri of KeyVault. </param>
        /// <param name="currentVersionedKeyIdentifier"> The object identifier of the current versioned Key Vault Key in use. </param>
        /// <param name="lastKeyRotationTimestamp"> Timestamp of last rotation of the Key Vault Key. </param>
        /// <param name="currentVersionedKeyExpirationTimestamp"> This is a read only property that represents the expiration time of the current version of the customer managed key used for encryption. </param>
        /// <returns> A new <see cref="Models.ElasticSanKeyVaultProperties"/> instance for mocking. </returns>
        public static ElasticSanKeyVaultProperties ElasticSanKeyVaultProperties(string keyName = null, string keyVersion = null, Uri keyVaultUri = null, string currentVersionedKeyIdentifier = null, DateTimeOffset? lastKeyRotationTimestamp = null, DateTimeOffset? currentVersionedKeyExpirationTimestamp = null)
        {
            return new ElasticSanKeyVaultProperties(
                keyName,
                keyVersion,
                keyVaultUri,
                currentVersionedKeyIdentifier,
                lastKeyRotationTimestamp,
                currentVersionedKeyExpirationTimestamp,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="ElasticSan.ElasticSanVolumeData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="volumeId"> Unique Id of the volume in GUID format. </param>
        /// <param name="creationData"> State of the operation on the resource. </param>
        /// <param name="sizeGiB"> Volume size. </param>
        /// <param name="storageTarget"> Storage target information. </param>
        /// <param name="managedByResourceId"> Parent resource information. </param>
        /// <param name="provisioningState"> State of the operation on the resource. </param>
        /// <returns> A new <see cref="ElasticSan.ElasticSanVolumeData"/> instance for mocking. </returns>
        public static ElasticSanVolumeData ElasticSanVolumeData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, Guid? volumeId = null, ElasticSanVolumeDataSourceInfo creationData = null, long sizeGiB = default, IscsiTargetInfo storageTarget = null, ResourceIdentifier managedByResourceId = null, ElasticSanProvisioningState? provisioningState = null)
        {
            return new ElasticSanVolumeData(
                id,
                name,
                resourceType,
                systemData,
                volumeId,
                creationData,
                sizeGiB,
                storageTarget,
                managedByResourceId != null ? new ManagedByInfo(managedByResourceId, serializedAdditionalRawData: null) : null,
                provisioningState,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.IscsiTargetInfo"/>. </summary>
        /// <param name="targetIqn"> iSCSI Target IQN (iSCSI Qualified Name); example: "iqn.2005-03.org.iscsi:server". </param>
        /// <param name="targetPortalHostname"> iSCSI Target Portal Host Name. </param>
        /// <param name="targetPortalPort"> iSCSI Target Portal Port. </param>
        /// <param name="provisioningState"> State of the operation on the resource. </param>
        /// <param name="status"> Operational status of the iSCSI Target. </param>
        /// <returns> A new <see cref="Models.IscsiTargetInfo"/> instance for mocking. </returns>
        public static IscsiTargetInfo IscsiTargetInfo(string targetIqn = null, string targetPortalHostname = null, int? targetPortalPort = null, ElasticSanProvisioningState? provisioningState = null, ResourceOperationalStatus? status = null)
        {
            return new IscsiTargetInfo(
                targetIqn,
                targetPortalHostname,
                targetPortalPort,
                provisioningState,
                status,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ElasticSanPrivateLinkResource"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="groupId"> The private link resource group id. </param>
        /// <param name="requiredMembers"> The private link resource required member names. </param>
        /// <param name="requiredZoneNames"> The private link resource Private link DNS zone name. </param>
        /// <returns> A new <see cref="Models.ElasticSanPrivateLinkResource"/> instance for mocking. </returns>
        public static ElasticSanPrivateLinkResource ElasticSanPrivateLinkResource(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string groupId = null, IEnumerable<string> requiredMembers = null, IEnumerable<string> requiredZoneNames = null)
        {
            requiredMembers ??= new List<string>();
            requiredZoneNames ??= new List<string>();

            return new ElasticSanPrivateLinkResource(
                id,
                name,
                resourceType,
                systemData,
                groupId,
                requiredMembers?.ToList(),
                requiredZoneNames?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="ElasticSan.ElasticSanSnapshotData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="creationDataSourceId"> Data used when creating a volume snapshot. </param>
        /// <param name="provisioningState"> State of the operation on the resource. </param>
        /// <param name="sourceVolumeSizeGiB"> Size of Source Volume. </param>
        /// <param name="volumeName"> Source Volume Name of a snapshot. </param>
        /// <returns> A new <see cref="ElasticSan.ElasticSanSnapshotData"/> instance for mocking. </returns>
        public static ElasticSanSnapshotData ElasticSanSnapshotData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ResourceIdentifier creationDataSourceId = null, ElasticSanProvisioningState? provisioningState = null, long? sourceVolumeSizeGiB = null, string volumeName = null)
        {
            return new ElasticSanSnapshotData(
                id,
                name,
                resourceType,
                systemData,
                creationDataSourceId != null ? new SnapshotCreationInfo(creationDataSourceId, serializedAdditionalRawData: null) : null,
                provisioningState,
                sourceVolumeSizeGiB,
                volumeName,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ElasticSanPreValidationResult"/>. </summary>
        /// <param name="validationStatus"> a status value indicating success or failure of validation. </param>
        /// <returns> A new <see cref="Models.ElasticSanPreValidationResult"/> instance for mocking. </returns>
        public static ElasticSanPreValidationResult ElasticSanPreValidationResult(string validationStatus = null)
        {
            return new ElasticSanPreValidationResult(validationStatus, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.ElasticSan.ElasticSanData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
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
        /// <returns> A new <see cref="T:Azure.ResourceManager.ElasticSan.ElasticSanData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ElasticSanData ElasticSanData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ElasticSanSku sku, IEnumerable<string> availabilityZones, ElasticSanProvisioningState? provisioningState, long baseSizeTiB, long extendedCapacitySizeTiB, long? totalVolumeSizeGiB, long? volumeGroupCount, long? totalIops, long? totalMbps, long? totalSizeTiB, IEnumerable<ElasticSanPrivateEndpointConnectionData> privateEndpointConnections, ElasticSanPublicNetworkAccess? publicNetworkAccess)
        {
            return ElasticSanData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, sku: sku, availabilityZones: availabilityZones, provisioningState: provisioningState, baseSizeTiB: baseSizeTiB, extendedCapacitySizeTiB: extendedCapacitySizeTiB, totalVolumeSizeGiB: totalVolumeSizeGiB, volumeGroupCount: volumeGroupCount, totalIops: totalIops, totalMbps: totalMbps, totalSizeTiB: totalSizeTiB, privateEndpointConnections: privateEndpointConnections, publicNetworkAccess: publicNetworkAccess, scaleUpProperties: default);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupData" />. </summary>
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
        /// <param name="enforceDataIntegrityCheckForIscsi"> A boolean indicating whether or not Data Integrity Check is enabled. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ElasticSanVolumeGroupData ElasticSanVolumeGroupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ManagedServiceIdentity identity, ElasticSanProvisioningState? provisioningState, ElasticSanStorageTargetType? protocolType, ElasticSanEncryptionType? encryption, ElasticSanEncryptionProperties encryptionProperties, IEnumerable<ElasticSanVirtualNetworkRule> virtualNetworkRules, IEnumerable<ElasticSanPrivateEndpointConnectionData> privateEndpointConnections, bool? enforceDataIntegrityCheckForIscsi)
        {
            return ElasticSanVolumeGroupData(id: id, name: name, resourceType: resourceType, systemData: systemData, identity: identity, provisioningState: provisioningState, protocolType: protocolType, encryption: encryption, encryptionProperties: encryptionProperties, virtualNetworkRules: virtualNetworkRules, privateEndpointConnections: privateEndpointConnections, enforceDataIntegrityCheckForIscsi: enforceDataIntegrityCheckForIscsi, deleteRetentionPolicy: default);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupData" />. </summary>
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
        /// <returns> A new <see cref="T:Azure.ResourceManager.ElasticSan.ElasticSanVolumeGroupData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ElasticSanVolumeGroupData ElasticSanVolumeGroupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ManagedServiceIdentity identity, ElasticSanProvisioningState? provisioningState, ElasticSanStorageTargetType? protocolType, ElasticSanEncryptionType? encryption, ElasticSanEncryptionProperties encryptionProperties, IEnumerable<ElasticSanVirtualNetworkRule> virtualNetworkRules, IEnumerable<ElasticSanPrivateEndpointConnectionData> privateEndpointConnections)
        {
            return ElasticSanVolumeGroupData(id: id, name: name, resourceType: resourceType, systemData: systemData, identity: identity, provisioningState: provisioningState, protocolType: protocolType, encryption: encryption, encryptionProperties: encryptionProperties, virtualNetworkRules: virtualNetworkRules, privateEndpointConnections: privateEndpointConnections, enforceDataIntegrityCheckForIscsi: default, deleteRetentionPolicy: default);
        }
    }
}
