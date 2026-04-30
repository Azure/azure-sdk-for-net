// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmNetAppModelFactory
    {
        /// <summary> Initializes a new instance of NetAppBackupData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="backupId"> UUID v4 used to identify the Backup. </param>
        /// <param name="createdOn"> The creation date of the backup. </param>
        /// <param name="provisioningState"> Azure lifecycle management. </param>
        /// <param name="size"> Size of backup. </param>
        /// <param name="label"> Label for backup. </param>
        /// <param name="backupType"> Type of backup Manual or Scheduled. </param>
        /// <param name="failureReason"> Failure reason. </param>
        /// <param name="volumeName"> Volume name. </param>
        /// <param name="useExistingSnapshot"> Manual backup an already existing snapshot. This will always be false for scheduled backups and true/false for manual backups. </param>
        /// <returns> A new <see cref="NetApp.NetAppBackupData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]

        public static NetAppBackupData NetAppBackupData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, AzureLocation location, string backupId = null, DateTimeOffset? createdOn = null, string provisioningState = null, long? size = null, string label = null, NetAppBackupType? backupType = null, string failureReason = null, string volumeName = null, bool? useExistingSnapshot = null)
        {
            return NetAppBackupData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                backupId: backupId,
                createdOn: createdOn,
                snapshotCreationOn: null,
                provisioningState: provisioningState,
                size: size,
                label: label,
                backupType: backupType,
                failureReason: failureReason,
                useExistingSnapshot: useExistingSnapshot
            );
        }

        /// <summary> Initializes a new instance of <see cref="Models.ClusterPeerCommandResult"/>. </summary>
        /// <param name="peerAcceptCommand"> Cluster peering command to run to accept the cluster peer. Kept with this name for backward compatibility. </param>
        /// <returns> A new <see cref="Models.ClusterPeerCommandResult"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ClusterPeerCommandResult ClusterPeerCommandResult(string peerAcceptCommand = null)
        {
            return new ClusterPeerCommandResult(
                new ClusterPeerCommandResponseProperties(peerAcceptCommand, passphrase: null, serializedAdditionalRawData: null),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.NetAppVolumeGroupMetadata"/>. </summary>
        /// <param name="groupDescription"> Group Description. </param>
        /// <param name="applicationType"> Application Type. </param>
        /// <param name="applicationIdentifier"> Application specific identifier. </param>
        /// <param name="globalPlacementRules"> Application specific placement rules for the volume group. </param>
        /// <param name="deploymentSpecId"> Application specific identifier of deployment rules for the volume group. </param>
        /// <param name="volumesCount"> Number of volumes in volume group. </param>
        /// <returns> A new <see cref="Models.NetAppVolumeGroupMetadata"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeGroupMetadata NetAppVolumeGroupMetadata(string groupDescription, NetAppApplicationType? applicationType, string applicationIdentifier, IEnumerable<NetAppVolumePlacementRule> globalPlacementRules, string deploymentSpecId, long? volumesCount)
            => NetAppVolumeGroupMetadata(groupDescription, applicationType, applicationIdentifier, globalPlacementRules, volumesCount);

        /// <summary> Initializes a new instance of <see cref="Models.AvailabilityZoneMapping"/>. </summary>
        /// <param name="availabilityZone"> Logical availability zone. </param>
        /// <param name="isAvailable"> Available availability zone. </param>
        /// <returns> A new <see cref="Models.AvailabilityZoneMapping"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AvailabilityZoneMapping AvailabilityZoneMapping(string availabilityZone = null, bool? isAvailable = null)
        {
            return new AvailabilityZoneMapping(availabilityZone, isAvailable, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.NetAppVolumePatch"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="serviceLevel"> The service level of the file system. </param>
        /// <param name="usageThreshold"> Maximum storage quota allowed for a file system in bytes. This is a soft quota used for alerting only. Minimum size is 100 GiB. Upper limit is 100TiB, 500Tib for LargeVolume or 2400Tib for LargeVolume on exceptional basis. Specified in bytes. </param>
        /// <param name="exportRules"> Set of export policy rules. </param>
        /// <param name="throughputMibps"> Maximum throughput in MiB/s that can be achieved by this volume and this will be accepted as input only for manual qosType volume. </param>
        /// <param name="snapshotPolicyId"> DataProtection type volumes include an object containing details of the replication. </param>
        /// <param name="isDefaultQuotaEnabled"> Specifies if default quota is enabled for the volume. </param>
        /// <param name="defaultUserQuotaInKiBs"> Default user quota for volume in KiBs. If isDefaultQuotaEnabled is set, the minimum value of 4 KiBs applies . </param>
        /// <param name="defaultGroupQuotaInKiBs"> Default group quota for volume in KiBs. If isDefaultQuotaEnabled is set, the minimum value of 4 KiBs applies. </param>
        /// <param name="unixPermissions"> UNIX permissions for NFS volume accepted in octal 4 digit format. First digit selects the set user ID(4), set group ID (2) and sticky (1) attributes. Second digit selects permission for the owner of the file: read (4), write (2) and execute (1). Third selects permissions for other users in the same group. the fourth for other users not in the group. 0755 - gives read/write/execute permissions to owner and read/execute to group and other users. </param>
        /// <param name="isCoolAccessEnabled"> Specifies whether Cool Access(tiering) is enabled for the volume. </param>
        /// <param name="coolnessPeriod"> Specifies the number of days after which data that is not accessed by clients will be tiered. </param>
        /// <param name="coolAccessRetrievalPolicy">
        /// coolAccessRetrievalPolicy determines the data retrieval behavior from the cool tier to standard storage based on the read pattern for cool access enabled volumes. The possible values for this field are:
        ///  Default - Data will be pulled from cool tier to standard storage on random reads. This policy is the default.
        ///  OnRead - All client-driven data read is pulled from cool tier to standard storage on both sequential and random reads.
        ///  Never - No client-driven data is pulled from cool tier to standard storage.
        /// </param>
        /// <param name="isSnapshotDirectoryVisible"> If enabled (true) the volume will contain a read-only snapshot directory which provides access to each of the volume's snapshots. </param>
        /// <param name="smbAccessBasedEnumeration"> Enables access-based enumeration share property for SMB Shares. Only applicable for SMB/DualProtocol volume. </param>
        /// <param name="smbNonBrowsable"> Enables non-browsable property for SMB Shares. Only applicable for SMB/DualProtocol volume. </param>
        /// <returns> A new <see cref="Models.NetAppVolumePatch"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumePatch NetAppVolumePatch(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, NetAppFileServiceLevel? serviceLevel = null, long? usageThreshold = null, IEnumerable<NetAppVolumeExportPolicyRule> exportRules = null, float? throughputMibps = null, ResourceIdentifier snapshotPolicyId = null, bool? isDefaultQuotaEnabled = null, long? defaultUserQuotaInKiBs = null, long? defaultGroupQuotaInKiBs = null, string unixPermissions = null, bool? isCoolAccessEnabled = null, int? coolnessPeriod = null, CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy = null, bool? isSnapshotDirectoryVisible = null, SmbAccessBasedEnumeration? smbAccessBasedEnumeration = null, SmbNonBrowsable? smbNonBrowsable = null)
        {
            tags ??= new Dictionary<string, string>();
            exportRules ??= new List<NetAppVolumeExportPolicyRule>();

            return new NetAppVolumePatch(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                serviceLevel,
                usageThreshold,
                exportRules != null ? new VolumePatchPropertiesExportPolicy(exportRules?.ToList(), serializedAdditionalRawData: null) : null,
                null, //protocolTypes
                throughputMibps,
                snapshotPolicyId != null ? new NetAppVolumePatchDataProtection(null, new VolumeSnapshotProperties(snapshotPolicyId, serializedAdditionalRawData: null), null, serializedAdditionalRawData: null) : null,
                isDefaultQuotaEnabled,
                defaultUserQuotaInKiBs,
                defaultGroupQuotaInKiBs,
                unixPermissions,
                isCoolAccessEnabled,
                coolnessPeriod,
                coolAccessRetrievalPolicy,
                null,
                isSnapshotDirectoryVisible,
                smbAccessBasedEnumeration,
                smbNonBrowsable,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="NetApp.NetAppBackupData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="backupId"> UUID v4 used to identify the Backup. </param>
        /// <param name="createdOn"> The creation date of the backup. </param>
        /// <param name="provisioningState"> Azure lifecycle management. </param>
        /// <param name="size"> Size of backup in bytes. </param>
        /// <param name="label"> Label for backup. </param>
        /// <param name="backupType"> Type of backup Manual or Scheduled. </param>
        /// <param name="failureReason"> Failure reason. </param>
        /// <param name="volumeResourceId"> ResourceId used to identify the Volume. </param>
        /// <param name="useExistingSnapshot"> Manual backup an already existing snapshot. This will always be false for scheduled backups and true/false for manual backups. </param>
        /// <param name="snapshotName"> The name of the snapshot. </param>
        /// <param name="backupPolicyResourceId"> ResourceId used to identify the backup policy. </param>
        /// <returns> A new <see cref="NetApp.NetAppBackupData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppBackupData NetAppBackupData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string backupId, DateTimeOffset? createdOn, string provisioningState = null, long? size = null, string label = null, NetAppBackupType? backupType = null, string failureReason = null, ResourceIdentifier volumeResourceId = null, bool? useExistingSnapshot = null, string snapshotName = null, string backupPolicyResourceId = null)
        {
            return NetAppBackupData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                backupId: backupId,
                createdOn: createdOn,
                provisioningState: provisioningState,
                size: size,
                label: label,
                backupType: backupType,
                failureReason: failureReason,
                volumeResourceId: volumeResourceId,
                useExistingSnapshot: useExistingSnapshot,
                snapshotName: snapshotName,
                new ResourceIdentifier(backupPolicyResourceId));
        }

        /// <summary> Initializes a new instance of <see cref="Models.NetAppKeyVaultProperties"/>. </summary>
        /// <param name="keyVaultId"> UUID v4 used to identify the Azure Key Vault configuration. </param>
        /// <param name="keyVaultUri"> The Uri of KeyVault. </param>
        /// <param name="keyName"> The name of KeyVault key. </param>
        /// <param name="keyVaultResourceId"> The resource ID of KeyVault. </param>
        /// <param name="status"> Status of the KeyVault connection. </param>
        /// <returns> A new <see cref="Models.NetAppKeyVaultProperties"/> instance for mocking. </returns>
        public static NetAppKeyVaultProperties NetAppKeyVaultProperties(string keyVaultId = null, Uri keyVaultUri = null, string keyName = null, string keyVaultResourceId = null, NetAppKeyVaultStatus? status = null)
        {
            ResourceIdentifier _keyVaultResourceId = new ResourceIdentifier(keyVaultResourceId);
            return new NetAppKeyVaultProperties(
                keyVaultId,
                keyVaultUri,
                keyName,
                _keyVaultResourceId,
                status,
                serializedAdditionalRawData: null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CapacityPoolData CapacityPoolData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, ETag? etag = null, Guid? poolId = null, long size = default, NetAppFileServiceLevel serviceLevel = default, string provisioningState = null, float? totalThroughputMibps = null, float? utilizedThroughputMibps = null, CapacityPoolQosType? qosType = null, bool? isCoolAccessEnabled = null, CapacityPoolEncryptionType? encryptionType = null)
        {
            return CapacityPoolData(id, name, resourceType, systemData, tags, location, etag, poolId, size, serviceLevel, provisioningState, totalThroughputMibps, utilizedThroughputMibps, customThroughputMibps: null, qosType, isCoolAccessEnabled, encryptionType);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CapacityPoolData CapacityPoolData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, ETag? etag = null, Guid? poolId = null, long size = default, NetAppFileServiceLevel serviceLevel = default, string provisioningState = null, float? totalThroughputMibps = null, float? utilizedThroughputMibps = null, float? customThroughputMibps = null, CapacityPoolQosType? qosType = null, bool? isCoolAccessEnabled = null, CapacityPoolEncryptionType? encryptionType = null)
        {
            return CapacityPoolData(id, name, resourceType, systemData, tags, location, etag, poolId, size, serviceLevel, provisioningState, totalThroughputMibps, utilizedThroughputMibps, customThroughputMibps.HasValue ? (int?)customThroughputMibps.Value : null, qosType, isCoolAccessEnabled, encryptionType);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CapacityPoolData CapacityPoolData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, ETag? etag = null, Guid? poolId = null, long size = default, NetAppFileServiceLevel serviceLevel = default, string provisioningState = null, float? totalThroughputMibps = null, float? utilizedThroughputMibps = null, int? customThroughputMibps = null, CapacityPoolQosType? qosType = null, bool? isCoolAccessEnabled = null, CapacityPoolEncryptionType? encryptionType = null)
        {
            tags ??= new Dictionary<string, string>();

            return new CapacityPoolData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                etag,
                poolId,
                size,
                serviceLevel,
                provisioningState,
                totalThroughputMibps,
                utilizedThroughputMibps,
                customThroughputMibps,
                qosType,
                isCoolAccessEnabled,
                encryptionType,
                serializedAdditionalRawData: null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CapacityPoolPatch CapacityPoolPatch(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, long? size = null, CapacityPoolQosType? qosType = null, bool? isCoolAccessEnabled = null, int? customThroughputMibpsInt = null)
        {
            tags ??= new Dictionary<string, string>();

            return new CapacityPoolPatch(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                size,
                qosType,
                isCoolAccessEnabled,
                customThroughputMibpsInt,
                serializedAdditionalRawData: null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CapacityPoolPatch CapacityPoolPatch(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, long? size = null, CapacityPoolQosType? qosType = null, bool? isCoolAccessEnabled = null, float? customThroughputMibps = null)
        {
            return CapacityPoolPatch(id, name, resourceType, systemData, tags, location, size, qosType, isCoolAccessEnabled, customThroughputMibpsInt: customThroughputMibps.HasValue ? (int?)customThroughputMibps.Value : null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppRestoreStatus NetAppRestoreStatus(bool? isHealthy = null, NetAppRelationshipStatus? relationshipStatus = null, NetAppMirrorState? mirrorState = null, string unhealthyReason = null, string errorMessage = null, long? totalTransferBytes = null)
        {
            VolumeRestoreRelationshipStatus? legacyRelationshipStatus = relationshipStatus.HasValue ? new VolumeRestoreRelationshipStatus(relationshipStatus.Value.ToString()) : (VolumeRestoreRelationshipStatus?)null;
            return NetAppRestoreStatus(isHealthy, legacyRelationshipStatus, mirrorState, unhealthyReason, errorMessage, totalTransferBytes);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppRestoreStatus NetAppRestoreStatus(bool? isHealthy = null, VolumeRestoreRelationshipStatus? relationshipStatus = null, NetAppMirrorState? mirrorState = null, string unhealthyReason = null, string errorMessage = null, long? totalTransferBytes = null)
        {
            return NetAppRestoreStatus(isHealthy, relationshipStatus, mirrorState, unhealthyReason, errorMessage, totalTransferBytes);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeBackupStatus NetAppVolumeBackupStatus(bool? isHealthy = null, VolumeBackupRelationshipStatus? relationshipStatus = null, NetAppMirrorState? mirrorState = null, string unhealthyReason = null, string errorMessage = null, long? lastTransferSize = null, string lastTransferType = null, long? totalTransferBytes = null, long? transferProgressBytes = null)
        {
            return NetAppVolumeBackupStatus(isHealthy, relationshipStatus, mirrorState, unhealthyReason, errorMessage, lastTransferSize, lastTransferType, totalTransferBytes, transferProgressBytes);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeReplicationStatus NetAppVolumeReplicationStatus(bool? isHealthy = null, VolumeReplicationRelationshipStatus? relationshipStatus = null, NetAppMirrorState? mirrorState = null, string totalProgress = null, string errorMessage = null)
        {
            return NetAppVolumeReplicationStatus(isHealthy, relationshipStatus, mirrorState, totalProgress, errorMessage);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeReplicationStatus NetAppVolumeReplicationStatus(bool? isHealthy = null, NetAppRelationshipStatus? relationshipStatus = null, NetAppMirrorState? mirrorState = null, string totalProgress = null, string errorMessage = null)
        {
            VolumeReplicationRelationshipStatus? legacyRelationshipStatus = relationshipStatus.HasValue ? new VolumeReplicationRelationshipStatus(relationshipStatus.Value.ToString()) : (VolumeReplicationRelationshipStatus?)null;
            return NetAppVolumeReplicationStatus(isHealthy, legacyRelationshipStatus, mirrorState, totalProgress, errorMessage);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeBackupStatus NetAppVolumeBackupStatus(bool? isHealthy = null, NetAppRelationshipStatus? relationshipStatus = null, NetAppMirrorState? mirrorState = null, string unhealthyReason = null, string errorMessage = null, long? lastTransferSize = null, string lastTransferType = null, long? totalTransferBytes = null, long? transferProgressBytes = null)
        {
            VolumeBackupRelationshipStatus? legacyRelationshipStatus = relationshipStatus.HasValue ? new VolumeBackupRelationshipStatus(relationshipStatus.Value.ToString()) : (VolumeBackupRelationshipStatus?)null;
            return NetAppVolumeBackupStatus(isHealthy, legacyRelationshipStatus, mirrorState, unhealthyReason, errorMessage, lastTransferSize, lastTransferType, totalTransferBytes, transferProgressBytes);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeBackupStatus NetAppVolumeBackupStatus(bool? isHealthy = null, NetAppRelationshipStatus? relationshipStatus = null, NetAppMirrorState? mirrorState = null, string unhealthyReason = null, string errorMessage = null, long? lastTransferSize = null, string lastTransferType = null, long? totalTransferBytes = null)
        {
            return NetAppVolumeBackupStatus(isHealthy, relationshipStatus, mirrorState, unhealthyReason, errorMessage, lastTransferSize, lastTransferType, totalTransferBytes, transferProgressBytes: null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppSubscriptionQuotaItem NetAppSubscriptionQuotaItem(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, int? current = null, int? @default = null)
        {
            return NetAppSubscriptionQuotaItem(id, name, resourceType, systemData, current, @default, usage: null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppSubscriptionQuotaItem NetAppSubscriptionQuotaItem(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, int? current = null, int? @default = null, int? usage = null)
        {
            return new NetAppSubscriptionQuotaItem(id, name, resourceType, systemData, current, @default, usage);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeQuotaRuleData NetAppVolumeQuotaRuleData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, NetAppProvisioningState? provisioningState = null, long? quotaSizeInKiBs = null, NetAppVolumeQuotaType? quotaType = null, string quotaTarget = null)
        {
            NetAppVolumeQuotaRuleProvisioningState? quotaRuleProvisioningState = provisioningState.HasValue ? new NetAppVolumeQuotaRuleProvisioningState(provisioningState.Value.ToString()) : (NetAppVolumeQuotaRuleProvisioningState?)null;
            return NetAppVolumeQuotaRuleData(id, name, resourceType, systemData, tags, location, quotaRuleProvisioningState, quotaSizeInKiBs, quotaType, quotaTarget);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeQuotaRulePatch NetAppVolumeQuotaRulePatch(IDictionary<string, string> tags = null, NetAppProvisioningState? provisioningState = null, long? quotaSizeInKiBs = null, NetAppVolumeQuotaType? quotaType = null, string quotaTarget = null)
        {
            NetAppVolumeQuotaRuleProvisioningState? quotaRuleProvisioningState = provisioningState.HasValue ? new NetAppVolumeQuotaRuleProvisioningState(provisioningState.Value.ToString()) : (NetAppVolumeQuotaRuleProvisioningState?)null;
            return NetAppVolumeQuotaRulePatch(tags, quotaRuleProvisioningState, quotaSizeInKiBs, quotaType, quotaTarget);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppAccountPatch NetAppAccountPatch(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string provisioningState = null, IEnumerable<NetAppAccountActiveDirectory> activeDirectories = null, NetAppAccountEncryption encryption = null, bool? disableShowmount = null, string nfsV4IdDomain = null, MultiAdStatus? multiAdStatus = null)
        {
            return NetAppAccountPatch(id, name, resourceType, systemData, tags, location, identity, provisioningState, activeDirectories, encryption, disableShowmount, nfsV4IdDomain, multiAdStatus);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppAccountPatch NetAppAccountPatch(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string provisioningState = null, IEnumerable<NetAppAccountActiveDirectory> activeDirectories = null, NetAppAccountEncryption encryption = null, bool? disableShowmount = null)
        {
            return NetAppAccountPatch(id, name, resourceType, systemData, tags, location, identity, provisioningState, activeDirectories, encryption, disableShowmount);
        }
    }
}
