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
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Model factory for models. </summary>
    // The generated backward-compat overload becomes ambiguous after microsoft/typespec#10397
    // switched generated overload dispatch to named arguments because NetApp also has a GA
    // compatibility overload with float? customThroughputMibps. Keep this one shim using
    // positional dispatch to target the generated primary overload unambiguously.
    [CodeGenSuppress("CapacityPoolData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(ETag?), typeof(Guid?), typeof(long), typeof(NetAppFileServiceLevel), typeof(string), typeof(float?), typeof(float?), typeof(CapacityPoolQosType?), typeof(bool?), typeof(CapacityPoolEncryptionType?))]
    public static partial class ArmNetAppModelFactory
    {
        /// <summary> Source Cluster properties for a cluster peer request. </summary>
        /// <param name="peerIPAddresses"> A list of IC-LIF IPs that can be used to connect to the On-prem cluster. </param>
        /// <returns> A new <see cref="Models.PeerClusterForVolumeMigrationContent"/> instance for mocking. </returns>
        public static PeerClusterForVolumeMigrationContent PeerClusterForVolumeMigrationContent(IEnumerable<string> peerIPAddresses = default)
        {
            peerIPAddresses ??= new ChangeTrackingList<string>();

            return new PeerClusterForVolumeMigrationContent(peerIPAddresses.ToList());
        }

        /// <summary> Migrate Backups Request. </summary>
        /// <param name="backupVaultId"> The ResourceId of the Backup Vault. </param>
        /// <returns> A new <see cref="Models.BackupsMigrationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BackupsMigrationContent BackupsMigrationContent(string backupVaultId = default)
        {
            return new BackupsMigrationContent(
                backupVaultId is null ? null : new ResourceIdentifier(backupVaultId),
                additionalBinaryDataProperties: null);
        }

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
            NetAppBackupData data = NetAppBackupData(id, name, resourceType, systemData, backupId, createdOn, provisioningState, size, label, backupType, failureReason, volumeResourceId: null, useExistingSnapshot, snapshotName: null, backupPolicyResourceId: (string)null);
            data.Location = location;
            return data;
        }

        /// <summary> Initializes a new instance of <see cref="Models.ClusterPeerCommandResult"/>. </summary>
        /// <param name="peerAcceptCommand"> Cluster peering command to run to accept the cluster peer. Kept with this name for backward compatibility. </param>
        /// <returns> A new <see cref="Models.ClusterPeerCommandResult"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ClusterPeerCommandResult ClusterPeerCommandResult(string peerAcceptCommand = null)
        {
            return new ClusterPeerCommandResult(
                new ClusterPeerCommandResponseProperties(peerAcceptCommand, passphrase: null, additionalBinaryDataProperties: null),
                additionalBinaryDataProperties: null);
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
        {
            NetAppVolumeGroupMetadata metadata = NetAppVolumeGroupMetadata(groupDescription, applicationType, applicationIdentifier, globalPlacementRules, volumesCount);
            metadata.DeploymentSpecId = deploymentSpecId;
            return metadata;
        }

        /// <summary> Initializes a new instance of <see cref="Models.AvailabilityZoneMapping"/>. </summary>
        /// <param name="availabilityZone"> Logical availability zone. </param>
        /// <param name="isAvailable"> Available availability zone. </param>
        /// <returns> A new <see cref="Models.AvailabilityZoneMapping"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AvailabilityZoneMapping AvailabilityZoneMapping(string availabilityZone = null, bool? isAvailable = null)
        {
            return new AvailabilityZoneMapping(availabilityZone, isAvailable, null);
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
        public static NetAppVolumePatch NetAppVolumePatch(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, NetAppFileServiceLevel? serviceLevel, long? usageThreshold, IEnumerable<NetAppVolumeExportPolicyRule> exportRules, float? throughputMibps, ResourceIdentifier snapshotPolicyId = null, bool? isDefaultQuotaEnabled = null, long? defaultUserQuotaInKiBs = null, long? defaultGroupQuotaInKiBs = null, string unixPermissions = null, bool? isCoolAccessEnabled = null, int? coolnessPeriod = null, CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy = null, bool? isSnapshotDirectoryVisible = null, SmbAccessBasedEnumeration? smbAccessBasedEnumeration = null, SmbNonBrowsable? smbNonBrowsable = null)
        {
            return CreateNetAppVolumePatchCompat(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                serviceLevel: serviceLevel,
                usageThreshold: usageThreshold,
                protocolTypes: default,
                throughputMibps: throughputMibps,
                dataProtection: snapshotPolicyId != null ? new NetAppVolumePatchDataProtection { SnapshotPolicyId = snapshotPolicyId } : default,
                isDefaultQuotaEnabled: isDefaultQuotaEnabled,
                defaultUserQuotaInKiBs: defaultUserQuotaInKiBs,
                defaultGroupQuotaInKiBs: defaultGroupQuotaInKiBs,
                unixPermissions: unixPermissions,
                isCoolAccessEnabled: isCoolAccessEnabled,
                coolnessPeriod: coolnessPeriod,
                coolAccessRetrievalPolicy: coolAccessRetrievalPolicy,
                coolAccessTieringPolicy: default,
                isSnapshotDirectoryVisible: isSnapshotDirectoryVisible,
                smbAccessBasedEnumeration: smbAccessBasedEnumeration,
                smbNonBrowsable: smbNonBrowsable,
                exportRules: exportRules);
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
        public static NetAppBackupData NetAppBackupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string backupId, DateTimeOffset? createdOn, string provisioningState = null, long? size = null, string label = null, NetAppBackupType? backupType = null, string failureReason = null, ResourceIdentifier volumeResourceId = null, bool? useExistingSnapshot = null, string snapshotName = null, string backupPolicyResourceId = null)
        {
            return CreateNetAppBackupDataCompat(id, name, resourceType, systemData, backupId, createdOn, snapshotCreationOn: null, completionOn: null, provisioningState, size, label, backupType, failureReason, volumeResourceId, useExistingSnapshot, snapshotName, backupPolicyResourceId is null ? null : new ResourceIdentifier(backupPolicyResourceId), isLargeVolume: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.NetAppKeyVaultProperties"/>. </summary>
        /// <param name="keyVaultId"> UUID v4 used to identify the Azure Key Vault configuration. </param>
        /// <param name="keyVaultUri"> The Uri of KeyVault. </param>
        /// <param name="keyName"> The name of KeyVault key. </param>
        /// <param name="keyVaultResourceId"> The resource ID of KeyVault. </param>
        /// <param name="status"> Status of the KeyVault connection. </param>
        /// <returns> A new <see cref="Models.NetAppKeyVaultProperties"/> instance for mocking. </returns>
        public static NetAppKeyVaultProperties NetAppKeyVaultProperties(string keyVaultId, Uri keyVaultUri, string keyName, string keyVaultResourceId, NetAppKeyVaultStatus? status = null)
        {
            return NetAppKeyVaultProperties(
                keyVaultId,
                keyVaultUri,
                keyName,
                keyVaultResourceId != null ? new ResourceIdentifier(keyVaultResourceId) : null,
                status);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.NetApp.NetAppSubscriptionQuotaItemData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="current"> The current quota value. </param>
        /// <param name="default"> The default quota value. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppSubscriptionQuotaItem NetAppSubscriptionQuotaItem(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, int? current, int? @default)
        {
            return new NetAppSubscriptionQuotaItem(id, name, resourceType, systemData, current, @default, null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.NetAppVolumeReplicationStatus"/>. </summary>
        /// <param name="isHealthy"> Replication health check. </param>
        /// <param name="relationshipStatus"> Status of the mirror relationship. </param>
        /// <param name="mirrorState"> The mirror state property describes the current status of data replication for a replication. It provides insight into whether the data is actively being mirrored, if the replication process has been paused, or if it has yet to be initialized. </param>
        /// <param name="totalProgress"> The progress of the replication. </param>
        /// <param name="errorMessage"> Displays error message if the replication is in an error state. </param>
        /// <returns> A new <see cref="Models.NetAppVolumeReplicationStatus"/> instance for mocking. </returns>
        public static NetAppVolumeReplicationStatus NetAppVolumeReplicationStatus(bool? isHealthy, NetAppRelationshipStatus? relationshipStatus, NetAppMirrorState? mirrorState = null, string totalProgress = null, string errorMessage = null)
        {
            return new NetAppVolumeReplicationStatus(
                isHealthy,
                relationshipStatus.HasValue ? new VolumeReplicationRelationshipStatus(relationshipStatus.Value.ToString()) : (VolumeReplicationRelationshipStatus?)null,
                mirrorState,
                totalProgress,
                errorMessage,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="NetApp.CapacityPoolData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="poolId"> UUID v4 used to identify the Pool. </param>
        /// <param name="size"> Provisioned size of the pool (in bytes). Allowed values are in 1TiB chunks (value must be multiple of 1099511627776). </param>
        /// <param name="serviceLevel"> The service level of the file system. </param>
        /// <param name="provisioningState"> Azure lifecycle management. </param>
        /// <param name="totalThroughputMibps"> Total throughput of pool in MiB/s. </param>
        /// <param name="utilizedThroughputMibps"> Utilized throughput of pool in MiB/s. </param>
        /// <param name="customThroughputMibps"> Maximum throughput in MiB/s that can be achieved by this pool and this will be accepted as input only for manual qosType pool with Flexible service level. </param>
        /// <param name="qosType"> The qos type of the pool. </param>
        /// <param name="isCoolAccessEnabled"> If enabled (true) the pool can contain cool Access enabled volumes. </param>
        /// <param name="encryptionType"> Encryption type of the capacity pool, set encryption type for data at rest for this pool and all volumes in it. This value can only be set when creating new pool. </param>
        /// <returns> A new <see cref="NetApp.CapacityPoolData"/> instance for mocking. </returns>
        public static CapacityPoolData CapacityPoolData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, ETag? etag = null, Guid? poolId = null, long size = default, NetAppFileServiceLevel serviceLevel = default, string provisioningState = null, float? totalThroughputMibps = null, float? utilizedThroughputMibps = null, float? customThroughputMibps = null, CapacityPoolQosType? qosType = null, bool? isCoolAccessEnabled = null, CapacityPoolEncryptionType? encryptionType = null)
        {
            tags ??= new Dictionary<string, string>();

            return CapacityPoolData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, poolId: poolId, size: size, serviceLevel: serviceLevel, provisioningState: provisioningState, totalThroughputMibps: totalThroughputMibps, utilizedThroughputMibps: utilizedThroughputMibps, customThroughputMibpsInt: customThroughputMibps.HasValue ? (int?)customThroughputMibps.Value : null, qosType: qosType, isCoolAccessEnabled: isCoolAccessEnabled, encryptionType: encryptionType, eTag: etag);
        }

        /// <summary> Initializes a new instance of <see cref="Models.CapacityPoolPatch"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="size"> Provisioned size of the pool (in bytes). Allowed values are in 1TiB chunks (value must be multiple of 1099511627776). </param>
        /// <param name="qosType"> The qos type of the pool. </param>
        /// <param name="isCoolAccessEnabled"> If enabled (true) the pool can contain cool Access enabled volumes. </param>
        /// <param name="customThroughputMibps"> Maximum throughput in MiB/s that can be achieved by this pool and this will be accepted as input only for manual qosType pool with Flexible service level. </param>
        /// <returns> A new <see cref="Models.CapacityPoolPatch"/> instance for mocking. </returns>
        public static CapacityPoolPatch CapacityPoolPatch(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, long? size = null, CapacityPoolQosType? qosType = null, bool? isCoolAccessEnabled = null, float? customThroughputMibps = null)
        {
            tags ??= new Dictionary<string, string>();

            return CapacityPoolPatch(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                size: size,
                qosType: qosType,
                isCoolAccessEnabled: isCoolAccessEnabled,
                customThroughputMibpsInt: customThroughputMibps.HasValue ? (int?)Convert.ToInt32(customThroughputMibps.Value) : null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.NetAppVolumeBackupStatus"/>. </summary>
        /// <param name="isHealthy"> Backup health status. </param>
        /// <param name="relationshipStatus"> Status of the backup mirror relationship. </param>
        /// <param name="mirrorState"> The mirror state property describes the current status of data replication for a backup. It provides insight into whether the data is actively being mirrored, if the replication process has been paused, or if it has yet to be initialized. </param>
        /// <param name="unhealthyReason"> Reason for the unhealthy backup relationship. </param>
        /// <param name="errorMessage"> Displays error message if the backup is in an error state. </param>
        /// <param name="lastTransferSize"> Displays the last transfer size. </param>
        /// <param name="lastTransferType"> Displays the last transfer type. </param>
        /// <param name="totalTransferBytes"> Displays the total bytes transferred. </param>
        /// <param name="transferProgressBytes"> Displays the total number of bytes transferred for the ongoing operation. </param>
        /// <returns> A new <see cref="Models.NetAppVolumeBackupStatus"/> instance for mocking. </returns>
        public static NetAppVolumeBackupStatus NetAppVolumeBackupStatus(bool? isHealthy = null, NetAppRelationshipStatus? relationshipStatus = null, NetAppMirrorState? mirrorState = null, string unhealthyReason = null, string errorMessage = null, long? lastTransferSize = null, string lastTransferType = null, long? totalTransferBytes = null, long? transferProgressBytes = null)
        {
            return new NetAppVolumeBackupStatus(
                isHealthy,
                relationshipStatus.HasValue ? new VolumeBackupRelationshipStatus(relationshipStatus.Value.ToString()) : (VolumeBackupRelationshipStatus?)null,
                mirrorState,
                unhealthyReason,
                errorMessage,
                lastTransferSize,
                lastTransferType,
                totalTransferBytes,
                transferProgressBytes,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of NetAppVolumeBackupStatus. </summary>
        /// <param name="isHealthy"> Backup health status. </param>
        /// <param name="relationshipStatus"> Status of the backup mirror relationship. </param>
        /// <param name="mirrorState"> The status of the backup. </param>
        /// <param name="unhealthyReason"> Reason for the unhealthy backup relationship. </param>
        /// <param name="errorMessage"> Displays error message if the backup is in an error state. </param>
        /// <param name="lastTransferSize"> Displays the last transfer size. </param>
        /// <param name="lastTransferType"> Displays the last transfer type. </param>
        /// <param name="totalTransferBytes"> Displays the total bytes transferred. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupStatus" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeBackupStatus NetAppVolumeBackupStatus(bool? isHealthy, NetAppRelationshipStatus? relationshipStatus, NetAppMirrorState? mirrorState, string unhealthyReason, string errorMessage, long? lastTransferSize, string lastTransferType, long? totalTransferBytes)
        {
            return NetAppVolumeBackupStatus(isHealthy: isHealthy, relationshipStatus: relationshipStatus, mirrorState: mirrorState, unhealthyReason: unhealthyReason, errorMessage: errorMessage, lastTransferSize: lastTransferSize, lastTransferType: lastTransferType, totalTransferBytes: totalTransferBytes, transferProgressBytes: default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.NetAppRestoreStatus"/>. </summary>
        /// <param name="isHealthy"> Restore health status. </param>
        /// <param name="relationshipStatus"> Status of the restore SnapMirror relationship. </param>
        /// <param name="mirrorState"> The mirror state property describes the current status of data replication for a restore. It provides insight into whether the data is actively being mirrored, if the replication process has been paused, or if it has yet to be initialized. </param>
        /// <param name="unhealthyReason"> Reason for the unhealthy restore relationship. </param>
        /// <param name="errorMessage"> Displays error message if the restore is in an error state. </param>
        /// <param name="totalTransferBytes"> Displays the total bytes transferred. </param>
        /// <returns> A new <see cref="Models.NetAppRestoreStatus"/> instance for mocking. </returns>
        public static NetAppRestoreStatus NetAppRestoreStatus(bool? isHealthy = null, NetAppRelationshipStatus? relationshipStatus = null, NetAppMirrorState? mirrorState = null, string unhealthyReason = null, string errorMessage = null, long? totalTransferBytes = null)
        {
            return new NetAppRestoreStatus(
                isHealthy,
                relationshipStatus.HasValue ? new VolumeRestoreRelationshipStatus(relationshipStatus.Value.ToString()) : (VolumeRestoreRelationshipStatus?)null,
                mirrorState,
                unhealthyReason,
                errorMessage,
                totalTransferBytes,
                additionalBinaryDataProperties: null);
        }

        // Backward-compat ModelFactory overloads with specific status types
        // Backward-compat: NetAppVolumeReplicationStatus factory with VolumeReplicationRelationshipStatus.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeReplicationStatus NetAppVolumeReplicationStatus(bool? isHealthy, VolumeReplicationRelationshipStatus? relationshipStatus, NetAppMirrorState? mirrorState = null, string totalProgress = null, string errorMessage = null)
        {
            return new NetAppVolumeReplicationStatus(isHealthy, relationshipStatus, mirrorState, totalProgress, errorMessage, additionalBinaryDataProperties: null);
        }

        // Backward-compat: NetAppVolumeBackupStatus factory with VolumeBackupRelationshipStatus.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeBackupStatus NetAppVolumeBackupStatus(bool? isHealthy, VolumeBackupRelationshipStatus? relationshipStatus, NetAppMirrorState? mirrorState = null, string unhealthyReason = null, string errorMessage = null, long? lastTransferSize = null, string lastTransferType = null, long? totalTransferBytes = null, long? transferProgressBytes = null)
        {
            return new NetAppVolumeBackupStatus(isHealthy, relationshipStatus, mirrorState, unhealthyReason, errorMessage, lastTransferSize, lastTransferType, totalTransferBytes, transferProgressBytes, additionalBinaryDataProperties: null);
        }

        // Backward-compat: NetAppRestoreStatus factory with VolumeRestoreRelationshipStatus.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppRestoreStatus NetAppRestoreStatus(bool? isHealthy, VolumeRestoreRelationshipStatus? relationshipStatus, NetAppMirrorState? mirrorState = null, string unhealthyReason = null, string errorMessage = null, long? totalTransferBytes = null)
        {
            return new NetAppRestoreStatus(isHealthy, relationshipStatus, mirrorState, unhealthyReason, errorMessage, totalTransferBytes, additionalBinaryDataProperties: null);
        }

        // Backward-compat: NetAppSubscriptionQuotaItem factory (7-arg overload).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppSubscriptionQuotaItem NetAppSubscriptionQuotaItem(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, int? current, int? @default, int? usage)
        {
            return new NetAppSubscriptionQuotaItem(id, name, resourceType, systemData, current, @default, usage);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppAccountPatch NetAppAccountPatch(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string provisioningState = null, IEnumerable<NetAppAccountActiveDirectory> activeDirectories = null, NetAppAccountEncryption encryption = null, bool? disableShowmount = null, string nfsV4IdDomain = null, MultiAdStatus? multiAdStatus = null)
        {
            _ = provisioningState;
            _ = disableShowmount;
            _ = multiAdStatus;
            return NetAppAccountPatch(id: id, name: name, resourceType: resourceType, systemData: systemData, location: location, identity: identity, tags: tags, activeDirectories: activeDirectories, encryption: encryption, nfsV4IdDomain: nfsV4IdDomain, ldapConfiguration: default, entraIdConfig: default);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppAccountPatch NetAppAccountPatch(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string provisioningState = null, IEnumerable<NetAppAccountActiveDirectory> activeDirectories = null, NetAppAccountEncryption encryption = null, bool? disableShowmount = null)
        {
            _ = provisioningState;
            _ = disableShowmount;
            return NetAppAccountPatch(id: id, name: name, resourceType: resourceType, systemData: systemData, location: location, identity: identity, tags: tags, activeDirectories: activeDirectories, encryption: encryption, nfsV4IdDomain: default, ldapConfiguration: default, entraIdConfig: default);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CapacityPoolData CapacityPoolData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, Guid? poolId, long size, NetAppFileServiceLevel serviceLevel, string provisioningState, float? totalThroughputMibps, float? utilizedThroughputMibps, CapacityPoolQosType? qosType, bool? isCoolAccessEnabled, CapacityPoolEncryptionType? encryptionType)
        {
            return CapacityPoolData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, poolId: poolId, size: size, serviceLevel: serviceLevel, provisioningState: provisioningState, totalThroughputMibps: totalThroughputMibps, utilizedThroughputMibps: utilizedThroughputMibps, customThroughputMibpsInt: default, qosType: qosType, isCoolAccessEnabled: isCoolAccessEnabled, encryptionType: encryptionType, eTag: etag);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CapacityPoolData CapacityPoolData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, Guid? poolId, long size, NetAppFileServiceLevel serviceLevel, string provisioningState, float? totalThroughputMibps, float? utilizedThroughputMibps, int? customThroughputMibps, CapacityPoolQosType? qosType, bool? isCoolAccessEnabled, CapacityPoolEncryptionType? encryptionType)
        {
            return CapacityPoolData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, poolId: poolId, size: size, serviceLevel: serviceLevel, provisioningState: provisioningState, totalThroughputMibps: totalThroughputMibps, utilizedThroughputMibps: utilizedThroughputMibps, customThroughputMibpsInt: customThroughputMibps, qosType: qosType, isCoolAccessEnabled: isCoolAccessEnabled, encryptionType: encryptionType, eTag: etag);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumePatch NetAppVolumePatch(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, NetAppFileServiceLevel? serviceLevel, long? usageThreshold, IEnumerable<NetAppVolumeExportPolicyRule> exportRules, IEnumerable<string> protocolTypes, float? throughputMibps, NetAppVolumePatchDataProtection dataProtection, bool? isDefaultQuotaEnabled, long? defaultUserQuotaInKiBs, long? defaultGroupQuotaInKiBs, string unixPermissions, bool? isCoolAccessEnabled, int? coolnessPeriod, CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy, CoolAccessTieringPolicy? coolAccessTieringPolicy, bool? isSnapshotDirectoryVisible, SmbAccessBasedEnumeration? smbAccessBasedEnumeration, SmbNonBrowsable? smbNonBrowsable)
        {
            return CreateNetAppVolumePatchCompat(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                serviceLevel: serviceLevel,
                usageThreshold: usageThreshold,
                protocolTypes: protocolTypes,
                throughputMibps: throughputMibps,
                dataProtection: dataProtection,
                isDefaultQuotaEnabled: isDefaultQuotaEnabled,
                defaultUserQuotaInKiBs: defaultUserQuotaInKiBs,
                defaultGroupQuotaInKiBs: defaultGroupQuotaInKiBs,
                unixPermissions: unixPermissions,
                isCoolAccessEnabled: isCoolAccessEnabled,
                coolnessPeriod: coolnessPeriod,
                coolAccessRetrievalPolicy: coolAccessRetrievalPolicy,
                coolAccessTieringPolicy: coolAccessTieringPolicy,
                isSnapshotDirectoryVisible: isSnapshotDirectoryVisible,
                smbAccessBasedEnumeration: smbAccessBasedEnumeration,
                smbNonBrowsable: smbNonBrowsable,
                exportRules: exportRules);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumePatch NetAppVolumePatch(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, NetAppFileServiceLevel? serviceLevel, long? usageThreshold, IEnumerable<NetAppVolumeExportPolicyRule> exportRules, IEnumerable<string> protocolTypes, float? throughputMibps, NetAppVolumePatchDataProtection dataProtection, bool? isDefaultQuotaEnabled, long? defaultUserQuotaInKiBs, long? defaultGroupQuotaInKiBs, string unixPermissions, bool? isCoolAccessEnabled, int? coolnessPeriod, CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy, bool? isSnapshotDirectoryVisible, SmbAccessBasedEnumeration? smbAccessBasedEnumeration, SmbNonBrowsable? smbNonBrowsable)
        {
            return CreateNetAppVolumePatchCompat(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                serviceLevel: serviceLevel,
                usageThreshold: usageThreshold,
                protocolTypes: protocolTypes,
                throughputMibps: throughputMibps,
                dataProtection: dataProtection,
                isDefaultQuotaEnabled: isDefaultQuotaEnabled,
                defaultUserQuotaInKiBs: defaultUserQuotaInKiBs,
                defaultGroupQuotaInKiBs: defaultGroupQuotaInKiBs,
                unixPermissions: unixPermissions,
                isCoolAccessEnabled: isCoolAccessEnabled,
                coolnessPeriod: coolnessPeriod,
                coolAccessRetrievalPolicy: coolAccessRetrievalPolicy,
                coolAccessTieringPolicy: default,
                isSnapshotDirectoryVisible: isSnapshotDirectoryVisible,
                smbAccessBasedEnumeration: smbAccessBasedEnumeration,
                smbNonBrowsable: smbNonBrowsable,
                exportRules: exportRules);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppBackupData NetAppBackupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string backupId, DateTimeOffset? createdOn, DateTimeOffset? snapshotCreationOn, DateTimeOffset? completionOn, string provisioningState, long? size, string label, NetAppBackupType? backupType, string failureReason, ResourceIdentifier volumeResourceId, bool? useExistingSnapshot, string snapshotName, ResourceIdentifier backupPolicyResourceId, bool? isLargeVolume)
        {
            return CreateNetAppBackupDataCompat(id, name, resourceType, systemData, backupId, createdOn, snapshotCreationOn, completionOn, provisioningState, size, label, backupType, failureReason, volumeResourceId, useExistingSnapshot, snapshotName, backupPolicyResourceId, isLargeVolume);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppBackupData NetAppBackupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string backupId, DateTimeOffset? createdOn, string provisioningState, long? size, string label, NetAppBackupType? backupType, string failureReason, ResourceIdentifier volumeResourceId, bool? useExistingSnapshot, string snapshotName, ResourceIdentifier backupPolicyResourceId)
        {
            return CreateNetAppBackupDataCompat(id, name, resourceType, systemData, backupId, createdOn, snapshotCreationOn: null, completionOn: null, provisioningState, size, label, backupType, failureReason, volumeResourceId, useExistingSnapshot, snapshotName, backupPolicyResourceId, isLargeVolume: null);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeData NetAppVolumeData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, IEnumerable<string> zones, Guid? fileSystemId, string creationToken, NetAppFileServiceLevel? serviceLevel, long usageThreshold, IEnumerable<NetAppVolumeExportPolicyRule> exportRules, IEnumerable<string> protocolTypes, string provisioningState, string snapshotId, bool? deleteBaseSnapshot, string backupId, string baremetalTenantId, ResourceIdentifier subnetId, NetAppNetworkFeature? networkFeatures, NetAppNetworkFeature? effectiveNetworkFeatures, Guid? networkSiblingSetId, NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity, IEnumerable<NetAppVolumeMountTarget> mountTargets, string volumeType, NetAppVolumeDataProtection dataProtection, AcceptGrowCapacityPoolForShortTermCloneSplit? acceptGrowCapacityPoolForShortTermCloneSplit, bool? isRestoring, bool? isSnapshotDirectoryVisible, bool? isKerberosEnabled, NetAppVolumeSecurityStyle? securityStyle, bool? isSmbEncryptionEnabled, SmbAccessBasedEnumeration? smbAccessBasedEnumeration, SmbNonBrowsable? smbNonBrowsable, bool? isSmbContinuouslyAvailable, float? throughputMibps, float? actualThroughputMibps, NetAppEncryptionKeySource? encryptionKeySource, ResourceIdentifier keyVaultPrivateEndpointResourceId, bool? isLdapEnabled, bool? isCoolAccessEnabled, int? coolnessPeriod, CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy, CoolAccessTieringPolicy? coolAccessTieringPolicy, string unixPermissions, int? cloneProgress, NetAppFileAccessLog? fileAccessLogs, NetAppAvsDataStore? avsDataStore, IEnumerable<ResourceIdentifier> dataStoreResourceId, bool? isDefaultQuotaEnabled, long? defaultUserQuotaInKiBs, long? defaultGroupQuotaInKiBs, long? maximumNumberOfFiles, string volumeGroupName, ResourceIdentifier capacityPoolResourceId, ResourceIdentifier proximityPlacementGroupId, string t2Network, string volumeSpecName, bool? isEncrypted, IEnumerable<NetAppVolumePlacementRule> placementRules, EnableNetAppSubvolume? enableSubvolumes, string provisionedAvailabilityZone, bool? isLargeVolume, ResourceIdentifier originatingResourceId, long? inheritedSizeInBytes)
        {
            return CreateNetAppVolumeDataCompat(id, name, resourceType, systemData, tags, location, etag, zones, fileSystemId, creationToken, serviceLevel, usageThreshold, exportRules, protocolTypes, provisioningState, snapshotId, deleteBaseSnapshot, backupId, baremetalTenantId, subnetId, networkFeatures, effectiveNetworkFeatures, networkSiblingSetId, storageToNetworkProximity, mountTargets, volumeType, dataProtection, acceptGrowCapacityPoolForShortTermCloneSplit, isRestoring, isSnapshotDirectoryVisible, isKerberosEnabled, securityStyle, isSmbEncryptionEnabled, smbAccessBasedEnumeration, smbNonBrowsable, isSmbContinuouslyAvailable, throughputMibps, actualThroughputMibps, encryptionKeySource, keyVaultPrivateEndpointResourceId, isLdapEnabled, isCoolAccessEnabled, coolnessPeriod, coolAccessRetrievalPolicy, coolAccessTieringPolicy, unixPermissions, cloneProgress, fileAccessLogs, avsDataStore, dataStoreResourceId, isDefaultQuotaEnabled, defaultUserQuotaInKiBs, defaultGroupQuotaInKiBs, maximumNumberOfFiles, volumeGroupName, capacityPoolResourceId, proximityPlacementGroupId, t2Network, volumeSpecName, isEncrypted, placementRules, enableSubvolumes, provisionedAvailabilityZone, isLargeVolume, originatingResourceId, inheritedSizeInBytes);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeData NetAppVolumeData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, IEnumerable<string> zones, Guid? fileSystemId, string creationToken, NetAppFileServiceLevel? serviceLevel, long usageThreshold, IEnumerable<NetAppVolumeExportPolicyRule> exportRules, IEnumerable<string> protocolTypes, string provisioningState, string snapshotId, bool? deleteBaseSnapshot, string backupId, string baremetalTenantId, ResourceIdentifier subnetId, NetAppNetworkFeature? networkFeatures, NetAppNetworkFeature? effectiveNetworkFeatures, Guid? networkSiblingSetId, NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity, IEnumerable<NetAppVolumeMountTarget> mountTargets, string volumeType, NetAppVolumeDataProtection dataProtection, bool? isRestoring, bool? isSnapshotDirectoryVisible, bool? isKerberosEnabled, NetAppVolumeSecurityStyle? securityStyle, bool? isSmbEncryptionEnabled, SmbAccessBasedEnumeration? smbAccessBasedEnumeration, SmbNonBrowsable? smbNonBrowsable, bool? isSmbContinuouslyAvailable, float? throughputMibps, float? actualThroughputMibps, NetAppEncryptionKeySource? encryptionKeySource, ResourceIdentifier keyVaultPrivateEndpointResourceId, bool? isLdapEnabled, bool? isCoolAccessEnabled, int? coolnessPeriod, CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy, CoolAccessTieringPolicy? coolAccessTieringPolicy, string unixPermissions, int? cloneProgress, NetAppFileAccessLog? fileAccessLogs, NetAppAvsDataStore? avsDataStore, IEnumerable<ResourceIdentifier> dataStoreResourceId, bool? isDefaultQuotaEnabled, long? defaultUserQuotaInKiBs, long? defaultGroupQuotaInKiBs, long? maximumNumberOfFiles, string volumeGroupName, ResourceIdentifier capacityPoolResourceId, ResourceIdentifier proximityPlacementGroupId, string t2Network, string volumeSpecName, bool? isEncrypted, IEnumerable<NetAppVolumePlacementRule> placementRules, EnableNetAppSubvolume? enableSubvolumes, string provisionedAvailabilityZone, bool? isLargeVolume, ResourceIdentifier originatingResourceId)
        {
            return CreateNetAppVolumeDataCompat(id, name, resourceType, systemData, tags, location, etag, zones, fileSystemId, creationToken, serviceLevel, usageThreshold, exportRules, protocolTypes, provisioningState, snapshotId, deleteBaseSnapshot, backupId, baremetalTenantId, subnetId, networkFeatures, effectiveNetworkFeatures, networkSiblingSetId, storageToNetworkProximity, mountTargets, volumeType, dataProtection, default, isRestoring, isSnapshotDirectoryVisible, isKerberosEnabled, securityStyle, isSmbEncryptionEnabled, smbAccessBasedEnumeration, smbNonBrowsable, isSmbContinuouslyAvailable, throughputMibps, actualThroughputMibps, encryptionKeySource, keyVaultPrivateEndpointResourceId, isLdapEnabled, isCoolAccessEnabled, coolnessPeriod, coolAccessRetrievalPolicy, coolAccessTieringPolicy, unixPermissions, cloneProgress, fileAccessLogs, avsDataStore, dataStoreResourceId, isDefaultQuotaEnabled, defaultUserQuotaInKiBs, defaultGroupQuotaInKiBs, maximumNumberOfFiles, volumeGroupName, capacityPoolResourceId, proximityPlacementGroupId, t2Network, volumeSpecName, isEncrypted, placementRules, enableSubvolumes, provisionedAvailabilityZone, isLargeVolume, originatingResourceId, default);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeData NetAppVolumeData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, IEnumerable<string> zones, Guid? fileSystemId, string creationToken, NetAppFileServiceLevel? serviceLevel, long usageThreshold, IEnumerable<NetAppVolumeExportPolicyRule> exportRules, IEnumerable<string> protocolTypes, string provisioningState, string snapshotId, bool? deleteBaseSnapshot, string backupId, string baremetalTenantId, ResourceIdentifier subnetId, NetAppNetworkFeature? networkFeatures, NetAppNetworkFeature? effectiveNetworkFeatures, Guid? networkSiblingSetId, NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity, IEnumerable<NetAppVolumeMountTarget> mountTargets, string volumeType, NetAppVolumeDataProtection dataProtection, bool? isRestoring, bool? isSnapshotDirectoryVisible, bool? isKerberosEnabled, NetAppVolumeSecurityStyle? securityStyle, bool? isSmbEncryptionEnabled, SmbAccessBasedEnumeration? smbAccessBasedEnumeration, SmbNonBrowsable? smbNonBrowsable, bool? isSmbContinuouslyAvailable, float? throughputMibps, float? actualThroughputMibps, NetAppEncryptionKeySource? encryptionKeySource, ResourceIdentifier keyVaultPrivateEndpointResourceId, bool? isLdapEnabled, bool? isCoolAccessEnabled, int? coolnessPeriod, CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy, string unixPermissions, int? cloneProgress, NetAppFileAccessLog? fileAccessLogs, NetAppAvsDataStore? avsDataStore, IEnumerable<ResourceIdentifier> dataStoreResourceId, bool? isDefaultQuotaEnabled, long? defaultUserQuotaInKiBs, long? defaultGroupQuotaInKiBs, long? maximumNumberOfFiles, string volumeGroupName, ResourceIdentifier capacityPoolResourceId, ResourceIdentifier proximityPlacementGroupId, string t2Network, string volumeSpecName, bool? isEncrypted, IEnumerable<NetAppVolumePlacementRule> placementRules, EnableNetAppSubvolume? enableSubvolumes, string provisionedAvailabilityZone, bool? isLargeVolume, ResourceIdentifier originatingResourceId)
        {
            return CreateNetAppVolumeDataCompat(id, name, resourceType, systemData, tags, location, etag, zones, fileSystemId, creationToken, serviceLevel, usageThreshold, exportRules, protocolTypes, provisioningState, snapshotId, deleteBaseSnapshot, backupId, baremetalTenantId, subnetId, networkFeatures, effectiveNetworkFeatures, networkSiblingSetId, storageToNetworkProximity, mountTargets, volumeType, dataProtection, default, isRestoring, isSnapshotDirectoryVisible, isKerberosEnabled, securityStyle, isSmbEncryptionEnabled, smbAccessBasedEnumeration, smbNonBrowsable, isSmbContinuouslyAvailable, throughputMibps, actualThroughputMibps, encryptionKeySource, keyVaultPrivateEndpointResourceId, isLdapEnabled, isCoolAccessEnabled, coolnessPeriod, coolAccessRetrievalPolicy, default, unixPermissions, cloneProgress, fileAccessLogs, avsDataStore, dataStoreResourceId, isDefaultQuotaEnabled, defaultUserQuotaInKiBs, defaultGroupQuotaInKiBs, maximumNumberOfFiles, volumeGroupName, capacityPoolResourceId, proximityPlacementGroupId, t2Network, volumeSpecName, isEncrypted, placementRules, enableSubvolumes, provisionedAvailabilityZone, isLargeVolume, originatingResourceId, default);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeData NetAppVolumeData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, IEnumerable<string> zones, Guid? fileSystemId, string creationToken, NetAppFileServiceLevel? serviceLevel, long usageThreshold, IEnumerable<NetAppVolumeExportPolicyRule> exportRules, IEnumerable<string> protocolTypes, string provisioningState, string snapshotId, bool? deleteBaseSnapshot, string backupId, string baremetalTenantId, ResourceIdentifier subnetId, NetAppNetworkFeature? networkFeatures, Guid? networkSiblingSetId, NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity, IEnumerable<NetAppVolumeMountTarget> mountTargets, string volumeType, NetAppVolumeDataProtection dataProtection, bool? isRestoring, bool? isSnapshotDirectoryVisible, bool? isKerberosEnabled, NetAppVolumeSecurityStyle? securityStyle, bool? isSmbEncryptionEnabled, SmbAccessBasedEnumeration? smbAccessBasedEnumeration, SmbNonBrowsable? smbNonBrowsable, bool? isSmbContinuouslyAvailable, float? throughputMibps, float? actualThroughputMibps, NetAppEncryptionKeySource? encryptionKeySource, ResourceIdentifier keyVaultPrivateEndpointResourceId, bool? isLdapEnabled, bool? isCoolAccessEnabled, int? coolnessPeriod, CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy, string unixPermissions, int? cloneProgress, NetAppFileAccessLog? fileAccessLogs, NetAppAvsDataStore? avsDataStore, IEnumerable<ResourceIdentifier> dataStoreResourceId, bool? isDefaultQuotaEnabled, long? defaultUserQuotaInKiBs, long? defaultGroupQuotaInKiBs, long? maximumNumberOfFiles, string volumeGroupName, ResourceIdentifier capacityPoolResourceId, ResourceIdentifier proximityPlacementGroupId, string t2Network, string volumeSpecName, bool? isEncrypted, IEnumerable<NetAppVolumePlacementRule> placementRules, EnableNetAppSubvolume? enableSubvolumes, string provisionedAvailabilityZone, bool? isLargeVolume, ResourceIdentifier originatingResourceId)
        {
            return CreateNetAppVolumeDataCompat(id, name, resourceType, systemData, tags, location, etag, zones, fileSystemId, creationToken, serviceLevel, usageThreshold, exportRules, protocolTypes, provisioningState, snapshotId, deleteBaseSnapshot, backupId, baremetalTenantId, subnetId, networkFeatures, default, networkSiblingSetId, storageToNetworkProximity, mountTargets, volumeType, dataProtection, default, isRestoring, isSnapshotDirectoryVisible, isKerberosEnabled, securityStyle, isSmbEncryptionEnabled, smbAccessBasedEnumeration, smbNonBrowsable, isSmbContinuouslyAvailable, throughputMibps, actualThroughputMibps, encryptionKeySource, keyVaultPrivateEndpointResourceId, isLdapEnabled, isCoolAccessEnabled, coolnessPeriod, coolAccessRetrievalPolicy, default, unixPermissions, cloneProgress, fileAccessLogs, avsDataStore, dataStoreResourceId, isDefaultQuotaEnabled, defaultUserQuotaInKiBs, defaultGroupQuotaInKiBs, maximumNumberOfFiles, volumeGroupName, capacityPoolResourceId, proximityPlacementGroupId, t2Network, volumeSpecName, isEncrypted, placementRules, enableSubvolumes, provisionedAvailabilityZone, isLargeVolume, originatingResourceId, default);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeData NetAppVolumeData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, IEnumerable<string> zones, Guid? fileSystemId, string creationToken, NetAppFileServiceLevel? serviceLevel, long usageThreshold, IEnumerable<NetAppVolumeExportPolicyRule> exportRules, IEnumerable<string> protocolTypes, string provisioningState, string snapshotId, bool? deleteBaseSnapshot, string backupId, string baremetalTenantId, ResourceIdentifier subnetId, NetAppNetworkFeature? networkFeatures, Guid? networkSiblingSetId, NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity, IEnumerable<NetAppVolumeMountTarget> mountTargets, string volumeType, NetAppVolumeDataProtection dataProtection, bool? isRestoring, bool? isSnapshotDirectoryVisible, bool? isKerberosEnabled, NetAppVolumeSecurityStyle? securityStyle, bool? isSmbEncryptionEnabled, SmbAccessBasedEnumeration? smbAccessBasedEnumeration, SmbNonBrowsable? smbNonBrowsable, bool? isSmbContinuouslyAvailable, float? throughputMibps, float? actualThroughputMibps, NetAppEncryptionKeySource? encryptionKeySource, ResourceIdentifier keyVaultPrivateEndpointResourceId, bool? isLdapEnabled, bool? isCoolAccessEnabled, int? coolnessPeriod, string unixPermissions, int? cloneProgress, NetAppFileAccessLog? fileAccessLogs, NetAppAvsDataStore? avsDataStore, IEnumerable<ResourceIdentifier> dataStoreResourceId, bool? isDefaultQuotaEnabled, long? defaultUserQuotaInKiBs, long? defaultGroupQuotaInKiBs, long? maximumNumberOfFiles, string volumeGroupName, ResourceIdentifier capacityPoolResourceId, ResourceIdentifier proximityPlacementGroupId, string t2Network, string volumeSpecName, bool? isEncrypted, IEnumerable<NetAppVolumePlacementRule> placementRules, EnableNetAppSubvolume? enableSubvolumes, string provisionedAvailabilityZone, bool? isLargeVolume, ResourceIdentifier originatingResourceId)
        {
            return CreateNetAppVolumeDataCompat(id, name, resourceType, systemData, tags, location, etag, zones, fileSystemId, creationToken, serviceLevel, usageThreshold, exportRules, protocolTypes, provisioningState, snapshotId, deleteBaseSnapshot, backupId, baremetalTenantId, subnetId, networkFeatures, default, networkSiblingSetId, storageToNetworkProximity, mountTargets, volumeType, dataProtection, default, isRestoring, isSnapshotDirectoryVisible, isKerberosEnabled, securityStyle, isSmbEncryptionEnabled, smbAccessBasedEnumeration, smbNonBrowsable, isSmbContinuouslyAvailable, throughputMibps, actualThroughputMibps, encryptionKeySource, keyVaultPrivateEndpointResourceId, isLdapEnabled, isCoolAccessEnabled, coolnessPeriod, default, default, unixPermissions, cloneProgress, fileAccessLogs, avsDataStore, dataStoreResourceId, isDefaultQuotaEnabled, defaultUserQuotaInKiBs, defaultGroupQuotaInKiBs, maximumNumberOfFiles, volumeGroupName, capacityPoolResourceId, proximityPlacementGroupId, t2Network, volumeSpecName, isEncrypted, placementRules, enableSubvolumes, provisionedAvailabilityZone, isLargeVolume, originatingResourceId, default);
        }

        private static NetAppVolumePatch CreateNetAppVolumePatchCompat(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, NetAppFileServiceLevel? serviceLevel, long? usageThreshold, IEnumerable<string> protocolTypes, float? throughputMibps, NetAppVolumePatchDataProtection dataProtection, bool? isDefaultQuotaEnabled, long? defaultUserQuotaInKiBs, long? defaultGroupQuotaInKiBs, string unixPermissions, bool? isCoolAccessEnabled, int? coolnessPeriod, CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy, CoolAccessTieringPolicy? coolAccessTieringPolicy, bool? isSnapshotDirectoryVisible, SmbAccessBasedEnumeration? smbAccessBasedEnumeration, SmbNonBrowsable? smbNonBrowsable, IEnumerable<NetAppVolumeExportPolicyRule> exportRules)
        {
            tags ??= new Dictionary<string, string>();
            return new NetAppVolumePatch(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                serviceLevel is null && usageThreshold is null && protocolTypes is null && throughputMibps is null && dataProtection is null && isDefaultQuotaEnabled is null && defaultUserQuotaInKiBs is null && defaultGroupQuotaInKiBs is null && unixPermissions is null && isCoolAccessEnabled is null && coolnessPeriod is null && coolAccessRetrievalPolicy is null && coolAccessTieringPolicy is null && isSnapshotDirectoryVisible is null && smbAccessBasedEnumeration is null && smbNonBrowsable is null && exportRules is null ? default : new VolumePatchProperties(
                    serviceLevel,
                    usageThreshold,
                    new VolumePatchPropertiesExportPolicy((exportRules ?? Array.Empty<NetAppVolumeExportPolicyRule>()).ToList(), null),
                    (protocolTypes ?? Array.Empty<string>()).ToList(),
                    throughputMibps,
                    dataProtection,
                    isDefaultQuotaEnabled,
                    defaultUserQuotaInKiBs,
                    defaultGroupQuotaInKiBs,
                    unixPermissions,
                    isCoolAccessEnabled,
                    coolnessPeriod,
                    coolAccessRetrievalPolicy,
                    coolAccessTieringPolicy,
                    isSnapshotDirectoryVisible,
                    smbAccessBasedEnumeration,
                    smbNonBrowsable,
                    null),
                additionalBinaryDataProperties: null);
        }

        private static NetAppVolumeData CreateNetAppVolumeDataCompat(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, IEnumerable<string> zones, Guid? fileSystemId, string creationToken, NetAppFileServiceLevel? serviceLevel, long usageThreshold, IEnumerable<NetAppVolumeExportPolicyRule> exportRules, IEnumerable<string> protocolTypes, string provisioningState, string snapshotId, bool? deleteBaseSnapshot, string backupId, string baremetalTenantId, ResourceIdentifier subnetId, NetAppNetworkFeature? networkFeatures, NetAppNetworkFeature? effectiveNetworkFeatures, Guid? networkSiblingSetId, NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity, IEnumerable<NetAppVolumeMountTarget> mountTargets, string volumeType, NetAppVolumeDataProtection dataProtection, AcceptGrowCapacityPoolForShortTermCloneSplit? acceptGrowCapacityPoolForShortTermCloneSplit, bool? isRestoring, bool? isSnapshotDirectoryVisible, bool? isKerberosEnabled, NetAppVolumeSecurityStyle? securityStyle, bool? isSmbEncryptionEnabled, SmbAccessBasedEnumeration? smbAccessBasedEnumeration, SmbNonBrowsable? smbNonBrowsable, bool? isSmbContinuouslyAvailable, float? throughputMibps, float? actualThroughputMibps, NetAppEncryptionKeySource? encryptionKeySource, ResourceIdentifier keyVaultPrivateEndpointResourceId, bool? isLdapEnabled, bool? isCoolAccessEnabled, int? coolnessPeriod, CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy, CoolAccessTieringPolicy? coolAccessTieringPolicy, string unixPermissions, int? cloneProgress, NetAppFileAccessLog? fileAccessLogs, NetAppAvsDataStore? avsDataStore, IEnumerable<ResourceIdentifier> dataStoreResourceId, bool? isDefaultQuotaEnabled, long? defaultUserQuotaInKiBs, long? defaultGroupQuotaInKiBs, long? maximumNumberOfFiles, string volumeGroupName, ResourceIdentifier capacityPoolResourceId, ResourceIdentifier proximityPlacementGroupId, string t2Network, string volumeSpecName, bool? isEncrypted, IEnumerable<NetAppVolumePlacementRule> placementRules, EnableNetAppSubvolume? enableSubvolumes, string provisionedAvailabilityZone, bool? isLargeVolume, ResourceIdentifier originatingResourceId, long? inheritedSizeInBytes)
        {
            _ = etag;
            return NetAppVolumeData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, fileSystemId: fileSystemId, creationToken: creationToken, serviceLevel: serviceLevel, usageThreshold: usageThreshold, protocolTypes: protocolTypes, provisioningState: provisioningState, snapshotId: snapshotId, deleteBaseSnapshot: deleteBaseSnapshot, backupId: backupId, baremetalTenantId: baremetalTenantId, subnetId: subnetId, networkFeatures: networkFeatures, effectiveNetworkFeatures: effectiveNetworkFeatures, networkSiblingSetId: networkSiblingSetId, storageToNetworkProximity: storageToNetworkProximity, mountTargets: mountTargets, volumeType: volumeType, dataProtection: dataProtection, acceptGrowCapacityPoolForShortTermCloneSplit: acceptGrowCapacityPoolForShortTermCloneSplit, isRestoring: isRestoring, isSnapshotDirectoryVisible: isSnapshotDirectoryVisible, isKerberosEnabled: isKerberosEnabled, securityStyle: securityStyle, isSmbEncryptionEnabled: isSmbEncryptionEnabled, smbAccessBasedEnumeration: smbAccessBasedEnumeration, smbNonBrowsable: smbNonBrowsable, isSmbContinuouslyAvailable: isSmbContinuouslyAvailable, throughputMibps: throughputMibps, actualThroughputMibps: actualThroughputMibps, encryptionKeySource: encryptionKeySource, keyVaultPrivateEndpointResourceId: keyVaultPrivateEndpointResourceId, isLdapEnabled: isLdapEnabled, ldapServerType: default, isCoolAccessEnabled: isCoolAccessEnabled, coolnessPeriod: coolnessPeriod, coolAccessRetrievalPolicy: coolAccessRetrievalPolicy, coolAccessTieringPolicy: coolAccessTieringPolicy, unixPermissions: unixPermissions, cloneProgress: cloneProgress, fileAccessLogs: fileAccessLogs, avsDataStore: avsDataStore, dataStoreResourceId: dataStoreResourceId, isDefaultQuotaEnabled: isDefaultQuotaEnabled, defaultUserQuotaInKiBs: defaultUserQuotaInKiBs, defaultGroupQuotaInKiBs: defaultGroupQuotaInKiBs, maximumNumberOfFiles: maximumNumberOfFiles, volumeGroupName: volumeGroupName, capacityPoolResourceId: capacityPoolResourceId, proximityPlacementGroupId: proximityPlacementGroupId, t2Network: t2Network, volumeSpecName: volumeSpecName, isEncrypted: isEncrypted, placementRules: placementRules, enableSubvolumes: enableSubvolumes, provisionedAvailabilityZone: provisionedAvailabilityZone, isLargeVolume: isLargeVolume, largeVolumeType: default, originatingResourceId: originatingResourceId, inheritedSizeInBytes: inheritedSizeInBytes, language: default, breakthroughMode: default, exportRules: exportRules, zones: zones);
        }

        private static NetAppBackupData CreateNetAppBackupDataCompat(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string backupId, DateTimeOffset? createdOn, DateTimeOffset? snapshotCreationOn, DateTimeOffset? completionOn, string provisioningState, long? size, string label, NetAppBackupType? backupType, string failureReason, ResourceIdentifier volumeResourceId, bool? useExistingSnapshot, string snapshotName, ResourceIdentifier backupPolicyResourceId, bool? isLargeVolume)
        {
            var properties = new BackupProperties(backupId, createdOn, snapshotCreationOn, completionOn, provisioningState, size, label, backupType, failureReason, volumeResourceId, useExistingSnapshot, snapshotName, backupPolicyResourceId, isLargeVolume, null);
            return new NetAppBackupData(id, name, resourceType, systemData, properties, additionalBinaryDataProperties: null);
        }
    }
}

// Test comment for batching validation - DO NOT MERGE
