// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;
using System;
using Azure.ResourceManager.NetApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

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
        public static NetAppVolumePatch NetAppVolumePatch(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, NetAppFileServiceLevel? serviceLevel = null, long? usageThreshold = null, IEnumerable<NetAppVolumeExportPolicyRule> exportRules = null, float? throughputMibps = null, ResourceIdentifier snapshotPolicyId = null, bool? isDefaultQuotaEnabled = null, long? defaultUserQuotaInKiBs = null, long? defaultGroupQuotaInKiBs = null, string unixPermissions = null, bool? isCoolAccessEnabled = null, int? coolnessPeriod = null, CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy = null, bool? isSnapshotDirectoryVisible = null, SmbAccessBasedEnumeration? smbAccessBasedEnumeration = null, SmbNonBrowsable? smbNonBrowsable = null)
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
                snapshotPolicyId != null ? new NetAppVolumePatchDataProtection(null, new VolumeSnapshotProperties(snapshotPolicyId, serializedAdditionalRawData: null), serializedAdditionalRawData: null) : null,
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
        public static NetAppBackupData NetAppBackupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string backupId, DateTimeOffset? createdOn, string provisioningState = null, long? size = null, string label = null, NetAppBackupType? backupType = null, string failureReason = null, ResourceIdentifier volumeResourceId = null, bool? useExistingSnapshot = null, string snapshotName = null, string backupPolicyResourceId = null)
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

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem" />. </summary>
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
            return NetAppSubscriptionQuotaItem(id: id, name: name, resourceType: resourceType, systemData: systemData, current: current, @default: @default, usage: null);
        }
    }
}
