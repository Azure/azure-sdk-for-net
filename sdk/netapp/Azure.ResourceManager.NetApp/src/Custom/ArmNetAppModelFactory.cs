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
        /// <summary> Initializes a new instance of NetAppVolumeBackupStatus. </summary>
        /// <param name="isHealthy"> Backup health status. </param>
        /// <param name="relationshipStatus"> Status of the backup mirror relationship. </param>
        /// <param name="mirrorState"> The status of the backup. </param>
        /// <param name="unhealthyReason"> Reason for the unhealthy backup relationship. </param>
        /// <param name="errorMessage"> Displays error message if the backup is in an error state. </param>
        /// <param name="lastTransferSize"> Displays the last transfer size. </param>
        /// <param name="lastTransferType"> Displays the last transfer type. </param>
        /// <param name="totalTransferBytes"> Displays the total bytes transferred. </param>
        /// <returns> A new <see cref="Models.NetAppVolumeBackupStatus"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeBackupStatus NetAppVolumeBackupStatus(bool? isHealthy = null, NetAppRelationshipStatus? relationshipStatus = null, NetAppMirrorState? mirrorState = null, string unhealthyReason = null, string errorMessage = null, long? lastTransferSize = null, string lastTransferType = null, long? totalTransferBytes = null)
        {
            return new NetAppVolumeBackupStatus(isHealthy, relationshipStatus, mirrorState, unhealthyReason, errorMessage, lastTransferSize, lastTransferType, totalTransferBytes, null, serializedAdditionalRawData: null);
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

        public static NetAppBackupData NetAppBackupData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, AzureLocation location = default, string backupId = null, DateTimeOffset? createdOn = null, string provisioningState = null, long? size = null, string label = null, NetAppBackupType? backupType = null, string failureReason = null, string volumeName = null, bool? useExistingSnapshot = null)
        {
            return new NetAppBackupData(id, name, resourceType, systemData, backupId, createdOn, provisioningState, size, label, backupType, failureReason, null, useExistingSnapshot, snapshotName: null, backupPolicyArmResourceId: null, isLargeVolume:null, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of NetAppVolumeGroupVolume. </summary>
        /// <param name="id"> Resource Id. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="fileSystemId"> Unique FileSystem Identifier. </param>
        /// <param name="creationToken"> A unique file path for the volume. Used when creating mount targets. </param>
        /// <param name="serviceLevel"> The service level of the file system. </param>
        /// <param name="usageThreshold"> Maximum storage quota allowed for a file system in bytes. This is a soft quota used for alerting only. Minimum size is 100 GiB. Upper limit is 100TiB, 500Tib for LargeVolume. Specified in bytes. </param>
        /// <param name="exportRules"> Set of export policy rules. </param>
        /// <param name="protocolTypes"> Set of protocol types, default NFSv3, CIFS for SMB protocol. </param>
        /// <param name="provisioningState"> Azure lifecycle management. </param>
        /// <param name="snapshotId"> UUID v4 or resource identifier used to identify the Snapshot. </param>
        /// <param name="deleteBaseSnapshot"> If enabled (true) the snapshot the volume was created from will be automatically deleted after the volume create operation has finished.  Defaults to false. </param>
        /// <param name="backupId"> UUID v4 or resource identifier used to identify the Backup. </param>
        /// <param name="baremetalTenantId"> Unique Baremetal Tenant Identifier. </param>
        /// <param name="subnetId"> The Azure Resource URI for a delegated subnet. Must have the delegation Microsoft.NetApp/volumes. </param>
        /// <param name="networkFeatures"> Basic network, or Standard features available to the volume. </param>
        /// <param name="networkSiblingSetId"> Network Sibling Set ID for the the group of volumes sharing networking resources. </param>
        /// <param name="storageToNetworkProximity"> Provides storage to network proximity information for the volume. </param>
        /// <param name="mountTargets"> List of mount targets. </param>
        /// <param name="volumeType"> What type of volume is this. For destination volumes in Cross Region Replication, set type to DataProtection. </param>
        /// <param name="dataProtection"> DataProtection type volumes include an object containing details of the replication. </param>
        /// <param name="isRestoring"> Restoring. </param>
        /// <param name="isSnapshotDirectoryVisible"> If enabled (true) the volume will contain a read-only snapshot directory which provides access to each of the volume's snapshots (defaults to true). </param>
        /// <param name="isKerberosEnabled"> Describe if a volume is KerberosEnabled. To be use with swagger version 2020-05-01 or later. </param>
        /// <param name="securityStyle"> The security style of volume, default unix, defaults to ntfs for dual protocol or CIFS protocol. </param>
        /// <param name="isSmbEncryptionEnabled"> Enables encryption for in-flight smb3 data. Only applicable for SMB/DualProtocol volume. To be used with swagger version 2020-08-01 or later. </param>
        /// <param name="smbAccessBasedEnumeration"> Enables access based enumeration share property for SMB Shares. Only applicable for SMB/DualProtocol volume. </param>
        /// <param name="smbNonBrowsable"> Enables non browsable property for SMB Shares. Only applicable for SMB/DualProtocol volume. </param>
        /// <param name="isSmbContinuouslyAvailable"> Enables continuously available share property for smb volume. Only applicable for SMB volume. </param>
        /// <param name="throughputMibps"> Maximum throughput in MiB/s that can be achieved by this volume and this will be accepted as input only for manual qosType volume. </param>
        /// <param name="actualThroughputMibps"> Actual throughput in MiB/s for auto qosType volumes calculated based on size and serviceLevel. </param>
        /// <param name="encryptionKeySource"> Source of key used to encrypt data in volume. Applicable if NetApp account has encryption.keySource = 'Microsoft.KeyVault'. Possible values (case-insensitive) are: 'Microsoft.NetApp, Microsoft.KeyVault'. </param>
        /// <param name="keyVaultPrivateEndpointResourceId"> The resource ID of private endpoint for KeyVault. It must reside in the same VNET as the volume. Only applicable if encryptionKeySource = 'Microsoft.KeyVault'. </param>
        /// <param name="isLdapEnabled"> Specifies whether LDAP is enabled or not for a given NFS volume. </param>
        /// <param name="isCoolAccessEnabled"> Specifies whether Cool Access(tiering) is enabled for the volume. </param>
        /// <param name="coolnessPeriod"> Specifies the number of days after which data that is not accessed by clients will be tiered. </param>
        /// <param name="unixPermissions"> UNIX permissions for NFS volume accepted in octal 4 digit format. First digit selects the set user ID(4), set group ID (2) and sticky (1) attributes. Second digit selects permission for the owner of the file: read (4), write (2) and execute (1). Third selects permissions for other users in the same group. the fourth for other users not in the group. 0755 - gives read/write/execute permissions to owner and read/execute to group and other users. </param>
        /// <param name="cloneProgress"> When a volume is being restored from another volume's snapshot, will show the percentage completion of this cloning process. When this value is empty/null there is no cloning process currently happening on this volume. This value will update every 5 minutes during cloning. </param>
        /// <param name="fileAccessLogs"> Flag indicating whether file access logs are enabled for the volume, based on active diagnostic settings present on the volume. </param>
        /// <param name="avsDataStore"> Specifies whether the volume is enabled for Azure VMware Solution (AVS) datastore purpose. </param>
        /// <param name="dataStoreResourceId"> Data store resource unique identifier. </param>
        /// <param name="isDefaultQuotaEnabled"> Specifies if default quota is enabled for the volume. </param>
        /// <param name="defaultUserQuotaInKiBs"> Default user quota for volume in KiBs. If isDefaultQuotaEnabled is set, the minimum value of 4 KiBs applies . </param>
        /// <param name="defaultGroupQuotaInKiBs"> Default group quota for volume in KiBs. If isDefaultQuotaEnabled is set, the minimum value of 4 KiBs applies. </param>
        /// <param name="maximumNumberOfFiles"> Maximum number of files allowed. Needs a service request in order to be changed. Only allowed to be changed if volume quota is more than 4TiB. </param>
        /// <param name="volumeGroupName"> Volume Group Name. </param>
        /// <param name="capacityPoolResourceId"> Pool Resource Id used in case of creating a volume through volume group. </param>
        /// <param name="proximityPlacementGroupId"> Proximity placement group associated with the volume. </param>
        /// <param name="t2Network"> T2 network information. </param>
        /// <param name="volumeSpecName"> Volume spec name is the application specific designation or identifier for the particular volume in a volume group for e.g. data, log. </param>
        /// <param name="isEncrypted"> Specifies if the volume is encrypted or not. Only available on volumes created or updated after 2022-01-01. </param>
        /// <param name="placementRules"> Application specific placement rules for the particular volume. </param>
        /// <param name="enableSubvolumes"> Flag indicating whether subvolume operations are enabled on the volume. </param>
        /// <param name="provisionedAvailabilityZone"> The availability zone where the volume is provisioned. This refers to the logical availability zone where the volume resides. </param>
        /// <param name="isLargeVolume"> Specifies whether volume is a Large Volume or Regular Volume. </param>
        /// <param name="originatingResourceId"> Id of the snapshot or backup that the volume is restored from. </param>
        /// <returns> A new <see cref="Models.NetAppVolumeGroupVolume"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeGroupVolume NetAppVolumeGroupVolume(ResourceIdentifier id = null, string name = null, ResourceType? resourceType = null, IDictionary<string, string> tags = null, Guid? fileSystemId = null, string creationToken = null, NetAppFileServiceLevel? serviceLevel = null, long usageThreshold = default, IEnumerable<NetAppVolumeExportPolicyRule> exportRules = null, IEnumerable<string> protocolTypes = null, string provisioningState = null, string snapshotId = null, bool? deleteBaseSnapshot = null, string backupId = null, string baremetalTenantId = null, ResourceIdentifier subnetId = null, NetAppNetworkFeature? networkFeatures = null, Guid? networkSiblingSetId = null, NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity = null, IEnumerable<NetAppVolumeMountTarget> mountTargets = null, string volumeType = null, NetAppVolumeDataProtection dataProtection = null, bool? isRestoring = null, bool? isSnapshotDirectoryVisible = null, bool? isKerberosEnabled = null, NetAppVolumeSecurityStyle? securityStyle = null, bool? isSmbEncryptionEnabled = null, SmbAccessBasedEnumeration? smbAccessBasedEnumeration = null, SmbNonBrowsable? smbNonBrowsable = null, bool? isSmbContinuouslyAvailable = null, float? throughputMibps = null, float? actualThroughputMibps = null, NetAppEncryptionKeySource? encryptionKeySource = null, ResourceIdentifier keyVaultPrivateEndpointResourceId = null, bool? isLdapEnabled = null, bool? isCoolAccessEnabled = null, int? coolnessPeriod = null, string unixPermissions = null, int? cloneProgress = null, NetAppFileAccessLog? fileAccessLogs = null, NetAppAvsDataStore? avsDataStore = null, IEnumerable<ResourceIdentifier> dataStoreResourceId = null, bool? isDefaultQuotaEnabled = null, long? defaultUserQuotaInKiBs = null, long? defaultGroupQuotaInKiBs = null, long? maximumNumberOfFiles = null, string volumeGroupName = null, ResourceIdentifier capacityPoolResourceId = null, ResourceIdentifier proximityPlacementGroupId = null, string t2Network = null, string volumeSpecName = null, bool? isEncrypted = null, IEnumerable<NetAppVolumePlacementRule> placementRules = null, EnableNetAppSubvolume? enableSubvolumes = null, string provisionedAvailabilityZone = null, bool? isLargeVolume = null, ResourceIdentifier originatingResourceId = null)
        {
            tags ??= new Dictionary<string, string>();
            exportRules ??= new List<NetAppVolumeExportPolicyRule>();
            protocolTypes ??= new List<string>();
            mountTargets ??= new List<NetAppVolumeMountTarget>();
            dataStoreResourceId ??= new List<ResourceIdentifier>();
            placementRules ??= new List<NetAppVolumePlacementRule>();
            //Set null for zones, coolAccessRetrievalPolicy and effectiveNetworkFeatures for backwards compat
            return new NetAppVolumeGroupVolume(id, name, resourceType, tags, null, fileSystemId, creationToken, serviceLevel, usageThreshold, exportRules != null ? new VolumePropertiesExportPolicy(exportRules?.ToList(), serializedAdditionalRawData: null) : null, protocolTypes?.ToList(), provisioningState, new ResourceIdentifier(snapshotId), deleteBaseSnapshot, new ResourceIdentifier(backupId), baremetalTenantId, subnetId, networkFeatures, null, networkSiblingSetId, storageToNetworkProximity, mountTargets?.ToList(), volumeType, dataProtection, acceptGrowCapacityPoolForShortTermCloneSplit: null, isRestoring, isSnapshotDirectoryVisible, isKerberosEnabled, securityStyle, isSmbEncryptionEnabled, smbAccessBasedEnumeration, smbNonBrowsable, isSmbContinuouslyAvailable, throughputMibps, actualThroughputMibps, encryptionKeySource, keyVaultPrivateEndpointResourceId, isLdapEnabled, isCoolAccessEnabled, coolnessPeriod, null, unixPermissions, cloneProgress, fileAccessLogs, avsDataStore, dataStoreResourceId?.ToList(), isDefaultQuotaEnabled, defaultUserQuotaInKiBs, defaultGroupQuotaInKiBs, maximumNumberOfFiles, volumeGroupName, capacityPoolResourceId, proximityPlacementGroupId, t2Network, volumeSpecName, isEncrypted: isEncrypted, placementRules: placementRules?.ToList(), enableSubvolumes: enableSubvolumes, provisionedAvailabilityZone: provisionedAvailabilityZone, isLargeVolume: isLargeVolume, originatingResourceId: originatingResourceId, inheritedSizeInBytes: null, language:null, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.NetAppVolumeGroupVolume"/>. </summary>
        /// <param name="id"> Resource Id. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="zones"> Availability Zone. </param>
        /// <param name="fileSystemId"> Unique FileSystem Identifier. </param>
        /// <param name="creationToken"> A unique file path for the volume. Used when creating mount targets. </param>
        /// <param name="serviceLevel"> The service level of the file system. </param>
        /// <param name="usageThreshold"> Maximum storage quota allowed for a file system in bytes. This is a soft quota used for alerting only. For regular volumes, valid values are in the range 50GiB to 100TiB. For large volumes, valid values are in the range 100TiB to 500TiB, and on an exceptional basis, from to 2400GiB to 2400TiB. Values expressed in bytes as multiples of 1 GiB. </param>
        /// <param name="exportRules"> Set of export policy rules. </param>
        /// <param name="protocolTypes"> Set of protocol types, default NFSv3, CIFS for SMB protocol. </param>
        /// <param name="provisioningState"> Azure lifecycle management. </param>
        /// <param name="snapshotId"> Resource identifier used to identify the Snapshot. </param>
        /// <param name="deleteBaseSnapshot"> If enabled (true) the snapshot the volume was created from will be automatically deleted after the volume create operation has finished.  Defaults to false. </param>
        /// <param name="backupId"> Resource identifier used to identify the Backup. </param>
        /// <param name="baremetalTenantId"> Unique Baremetal Tenant Identifier. </param>
        /// <param name="subnetId"> The Azure Resource URI for a delegated subnet. Must have the delegation Microsoft.NetApp/volumes. </param>
        /// <param name="networkFeatures"> Network features available to the volume, or current state of update. </param>
        /// <param name="networkSiblingSetId"> Network Sibling Set ID for the the group of volumes sharing networking resources. </param>
        /// <param name="storageToNetworkProximity"> Provides storage to network proximity information for the volume. </param>
        /// <param name="mountTargets"> List of mount targets. </param>
        /// <param name="volumeType"> What type of volume is this. For destination volumes in Cross Region Replication, set type to DataProtection. </param>
        /// <param name="dataProtection"> DataProtection type volumes include an object containing details of the replication. </param>
        /// <param name="isRestoring"> Restoring. </param>
        /// <param name="isSnapshotDirectoryVisible"> If enabled (true) the volume will contain a read-only snapshot directory which provides access to each of the volume's snapshots (defaults to true). </param>
        /// <param name="isKerberosEnabled"> Describe if a volume is KerberosEnabled. To be use with swagger version 2020-05-01 or later. </param>
        /// <param name="securityStyle"> The security style of volume, default unix, defaults to ntfs for dual protocol or CIFS protocol. </param>
        /// <param name="isSmbEncryptionEnabled"> Enables encryption for in-flight smb3 data. Only applicable for SMB/DualProtocol volume. To be used with swagger version 2020-08-01 or later. </param>
        /// <param name="smbAccessBasedEnumeration"> Enables access-based enumeration share property for SMB Shares. Only applicable for SMB/DualProtocol volume. </param>
        /// <param name="smbNonBrowsable"> Enables non-browsable property for SMB Shares. Only applicable for SMB/DualProtocol volume. </param>
        /// <param name="isSmbContinuouslyAvailable"> Enables continuously available share property for smb volume. Only applicable for SMB volume. </param>
        /// <param name="throughputMibps"> Maximum throughput in MiB/s that can be achieved by this volume and this will be accepted as input only for manual qosType volume. </param>
        /// <param name="actualThroughputMibps"> Actual throughput in MiB/s for auto qosType volumes calculated based on size and serviceLevel. </param>
        /// <param name="encryptionKeySource"> Source of key used to encrypt data in volume. Applicable if NetApp account has encryption.keySource = 'Microsoft.KeyVault'. Possible values (case-insensitive) are: 'Microsoft.NetApp, Microsoft.KeyVault'. </param>
        /// <param name="keyVaultPrivateEndpointResourceId"> The resource ID of private endpoint for KeyVault. It must reside in the same VNET as the volume. Only applicable if encryptionKeySource = 'Microsoft.KeyVault'. </param>
        /// <param name="isLdapEnabled"> Specifies whether LDAP is enabled or not for a given NFS volume. </param>
        /// <param name="isCoolAccessEnabled"> Specifies whether Cool Access(tiering) is enabled for the volume. </param>
        /// <param name="coolnessPeriod"> Specifies the number of days after which data that is not accessed by clients will be tiered. </param>
        /// <param name="coolAccessRetrievalPolicy">
        /// coolAccessRetrievalPolicy determines the data retrieval behavior from the cool tier to standard storage based on the read pattern for cool access enabled volumes. The possible values for this field are:
        ///  Default - Data will be pulled from cool tier to standard storage on random reads. This policy is the default.
        ///  OnRead - All client-driven data read is pulled from cool tier to standard storage on both sequential and random reads.
        ///  Never - No client-driven data is pulled from cool tier to standard storage.
        /// </param>
        /// <param name="unixPermissions"> UNIX permissions for NFS volume accepted in octal 4 digit format. First digit selects the set user ID(4), set group ID (2) and sticky (1) attributes. Second digit selects permission for the owner of the file: read (4), write (2) and execute (1). Third selects permissions for other users in the same group. the fourth for other users not in the group. 0755 - gives read/write/execute permissions to owner and read/execute to group and other users. </param>
        /// <param name="cloneProgress"> When a volume is being restored from another volume's snapshot, will show the percentage completion of this cloning process. When this value is empty/null there is no cloning process currently happening on this volume. This value will update every 5 minutes during cloning. </param>
        /// <param name="fileAccessLogs"> Flag indicating whether file access logs are enabled for the volume, based on active diagnostic settings present on the volume. </param>
        /// <param name="avsDataStore"> Specifies whether the volume is enabled for Azure VMware Solution (AVS) datastore purpose. </param>
        /// <param name="dataStoreResourceId"> Data store resource unique identifier. </param>
        /// <param name="isDefaultQuotaEnabled"> Specifies if default quota is enabled for the volume. </param>
        /// <param name="defaultUserQuotaInKiBs"> Default user quota for volume in KiBs. If isDefaultQuotaEnabled is set, the minimum value of 4 KiBs applies . </param>
        /// <param name="defaultGroupQuotaInKiBs"> Default group quota for volume in KiBs. If isDefaultQuotaEnabled is set, the minimum value of 4 KiBs applies. </param>
        /// <param name="maximumNumberOfFiles"> Maximum number of files allowed. Needs a service request in order to be changed. Only allowed to be changed if volume quota is more than 4TiB. </param>
        /// <param name="volumeGroupName"> Volume Group Name. </param>
        /// <param name="capacityPoolResourceId"> Pool Resource Id used in case of creating a volume through volume group. </param>
        /// <param name="proximityPlacementGroupId"> Proximity placement group associated with the volume. </param>
        /// <param name="t2Network"> T2 network information. </param>
        /// <param name="volumeSpecName"> Volume spec name is the application specific designation or identifier for the particular volume in a volume group for e.g. data, log. </param>
        /// <param name="isEncrypted"> Specifies if the volume is encrypted or not. Only available on volumes created or updated after 2022-01-01. </param>
        /// <param name="placementRules"> Application specific placement rules for the particular volume. </param>
        /// <param name="enableSubvolumes"> Flag indicating whether subvolume operations are enabled on the volume. </param>
        /// <param name="provisionedAvailabilityZone"> The availability zone where the volume is provisioned. This refers to the logical availability zone where the volume resides. </param>
        /// <param name="isLargeVolume"> Specifies whether volume is a Large Volume or Regular Volume. </param>
        /// <param name="originatingResourceId"> Id of the snapshot or backup that the volume is restored from. </param>
        /// <returns> A new <see cref="Models.NetAppVolumeGroupVolume"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeGroupVolume NetAppVolumeGroupVolume(ResourceIdentifier id = null, string name = null, ResourceType? resourceType = null, IDictionary<string, string> tags = null, IEnumerable<string> zones = null, Guid? fileSystemId = null, string creationToken = null, NetAppFileServiceLevel? serviceLevel = null, long usageThreshold = default, IEnumerable<NetAppVolumeExportPolicyRule> exportRules = null, IEnumerable<string> protocolTypes = null, string provisioningState = null, string snapshotId = null, bool? deleteBaseSnapshot = null, string backupId = null, string baremetalTenantId = null, ResourceIdentifier subnetId = null, NetAppNetworkFeature? networkFeatures = null, Guid? networkSiblingSetId = null, NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity = null, IEnumerable<NetAppVolumeMountTarget> mountTargets = null, string volumeType = null, NetAppVolumeDataProtection dataProtection = null, bool? isRestoring = null, bool? isSnapshotDirectoryVisible = null, bool? isKerberosEnabled = null, NetAppVolumeSecurityStyle? securityStyle = null, bool? isSmbEncryptionEnabled = null, SmbAccessBasedEnumeration? smbAccessBasedEnumeration = null, SmbNonBrowsable? smbNonBrowsable = null, bool? isSmbContinuouslyAvailable = null, float? throughputMibps = null, float? actualThroughputMibps = null, NetAppEncryptionKeySource? encryptionKeySource = null, ResourceIdentifier keyVaultPrivateEndpointResourceId = null, bool? isLdapEnabled = null, bool? isCoolAccessEnabled = null, int? coolnessPeriod = null, CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy = null, string unixPermissions = null, int? cloneProgress = null, NetAppFileAccessLog? fileAccessLogs = null, NetAppAvsDataStore? avsDataStore = null, IEnumerable<ResourceIdentifier> dataStoreResourceId = null, bool? isDefaultQuotaEnabled = null, long? defaultUserQuotaInKiBs = null, long? defaultGroupQuotaInKiBs = null, long? maximumNumberOfFiles = null, string volumeGroupName = null, ResourceIdentifier capacityPoolResourceId = null, ResourceIdentifier proximityPlacementGroupId = null, string t2Network = null, string volumeSpecName = null, bool? isEncrypted = null, IEnumerable<NetAppVolumePlacementRule> placementRules = null, EnableNetAppSubvolume? enableSubvolumes = null, string provisionedAvailabilityZone = null, bool? isLargeVolume = null, ResourceIdentifier originatingResourceId = null)
        {
            //For Backwards compatability sets effective networkfeatures to null
            tags ??= new Dictionary<string, string>();
            zones ??= new List<string>();
            exportRules ??= new List<NetAppVolumeExportPolicyRule>();
            protocolTypes ??= new List<string>();
            mountTargets ??= new List<NetAppVolumeMountTarget>();
            dataStoreResourceId ??= new List<ResourceIdentifier>();
            placementRules ??= new List<NetAppVolumePlacementRule>();

            return new NetAppVolumeGroupVolume(
                id,
                name,
                resourceType,
                tags,
                zones?.ToList(),
                fileSystemId,
                creationToken,
                serviceLevel,
                usageThreshold,
                exportRules != null ? new VolumePropertiesExportPolicy(exportRules?.ToList(), serializedAdditionalRawData: null) : null,
                protocolTypes?.ToList(),
                provisioningState,
                new ResourceIdentifier(snapshotId),
                deleteBaseSnapshot,
                new ResourceIdentifier(backupId),
                baremetalTenantId,
                subnetId,
                networkFeatures,
                null,
                networkSiblingSetId,
                storageToNetworkProximity,
                mountTargets?.ToList(),
                volumeType,
                dataProtection,
                acceptGrowCapacityPoolForShortTermCloneSplit: null,
                isRestoring,
                isSnapshotDirectoryVisible,
                isKerberosEnabled,
                securityStyle,
                isSmbEncryptionEnabled,
                smbAccessBasedEnumeration,
                smbNonBrowsable,
                isSmbContinuouslyAvailable,
                throughputMibps,
                actualThroughputMibps,
                encryptionKeySource,
                keyVaultPrivateEndpointResourceId,
                isLdapEnabled,
                isCoolAccessEnabled,
                coolnessPeriod,
                coolAccessRetrievalPolicy,
                unixPermissions,
                cloneProgress,
                fileAccessLogs,
                avsDataStore,
                dataStoreResourceId?.ToList(),
                isDefaultQuotaEnabled,
                defaultUserQuotaInKiBs,
                defaultGroupQuotaInKiBs,
                maximumNumberOfFiles,
                volumeGroupName,
                capacityPoolResourceId,
                proximityPlacementGroupId,
                t2Network,
                volumeSpecName,
                isEncrypted,
                placementRules?.ToList(),
                enableSubvolumes,
                provisionedAvailabilityZone,
                isLargeVolume,
                originatingResourceId: originatingResourceId,
                inheritedSizeInBytes: null,
                language: null,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of NetAppVolumeData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="zones"> Availability Zone. </param>
        /// <param name="fileSystemId"> Unique FileSystem Identifier. </param>
        /// <param name="creationToken"> A unique file path for the volume. Used when creating mount targets. </param>
        /// <param name="serviceLevel"> The service level of the file system. </param>
        /// <param name="usageThreshold"> Maximum storage quota allowed for a file system in bytes. This is a soft quota used for alerting only. Minimum size is 100 GiB. Upper limit is 100TiB, 500Tib for LargeVolume. Specified in bytes. </param>
        /// <param name="exportRules"> Set of export policy rules. </param>
        /// <param name="protocolTypes"> Set of protocol types, default NFSv3, CIFS for SMB protocol. </param>
        /// <param name="provisioningState"> Azure lifecycle management. </param>
        /// <param name="snapshotId"> UUID v4 or resource identifier used to identify the Snapshot. </param>
        /// <param name="deleteBaseSnapshot"> If enabled (true) the snapshot the volume was created from will be automatically deleted after the volume create operation has finished.  Defaults to false. </param>
        /// <param name="backupId"> UUID v4 or resource identifier used to identify the Backup. </param>
        /// <param name="baremetalTenantId"> Unique Baremetal Tenant Identifier. </param>
        /// <param name="subnetId"> The Azure Resource URI for a delegated subnet. Must have the delegation Microsoft.NetApp/volumes. </param>
        /// <param name="networkFeatures"> Basic network, or Standard features available to the volume. </param>
        /// <param name="networkSiblingSetId"> Network Sibling Set ID for the the group of volumes sharing networking resources. </param>
        /// <param name="storageToNetworkProximity"> Provides storage to network proximity information for the volume. </param>
        /// <param name="mountTargets"> List of mount targets. </param>
        /// <param name="volumeType"> What type of volume is this. For destination volumes in Cross Region Replication, set type to DataProtection. </param>
        /// <param name="dataProtection"> DataProtection type volumes include an object containing details of the replication. </param>
        /// <param name="isRestoring"> Restoring. </param>
        /// <param name="isSnapshotDirectoryVisible"> If enabled (true) the volume will contain a read-only snapshot directory which provides access to each of the volume's snapshots (defaults to true). </param>
        /// <param name="isKerberosEnabled"> Describe if a volume is KerberosEnabled. To be use with swagger version 2020-05-01 or later. </param>
        /// <param name="securityStyle"> The security style of volume, default unix, defaults to ntfs for dual protocol or CIFS protocol. </param>
        /// <param name="isSmbEncryptionEnabled"> Enables encryption for in-flight smb3 data. Only applicable for SMB/DualProtocol volume. To be used with swagger version 2020-08-01 or later. </param>
        /// <param name="smbAccessBasedEnumeration"> Enables access based enumeration share property for SMB Shares. Only applicable for SMB/DualProtocol volume. </param>
        /// <param name="smbNonBrowsable"> Enables non browsable property for SMB Shares. Only applicable for SMB/DualProtocol volume. </param>
        /// <param name="isSmbContinuouslyAvailable"> Enables continuously available share property for smb volume. Only applicable for SMB volume. </param>
        /// <param name="throughputMibps"> Maximum throughput in MiB/s that can be achieved by this volume and this will be accepted as input only for manual qosType volume. </param>
        /// <param name="actualThroughputMibps"> Actual throughput in MiB/s for auto qosType volumes calculated based on size and serviceLevel. </param>
        /// <param name="encryptionKeySource"> Source of key used to encrypt data in volume. Applicable if NetApp account has encryption.keySource = 'Microsoft.KeyVault'. Possible values (case-insensitive) are: 'Microsoft.NetApp, Microsoft.KeyVault'. </param>
        /// <param name="keyVaultPrivateEndpointResourceId"> The resource ID of private endpoint for KeyVault. It must reside in the same VNET as the volume. Only applicable if encryptionKeySource = 'Microsoft.KeyVault'. </param>
        /// <param name="isLdapEnabled"> Specifies whether LDAP is enabled or not for a given NFS volume. </param>
        /// <param name="isCoolAccessEnabled"> Specifies whether Cool Access(tiering) is enabled for the volume. </param>
        /// <param name="coolnessPeriod"> Specifies the number of days after which data that is not accessed by clients will be tiered. </param>
        /// <param name="unixPermissions"> UNIX permissions for NFS volume accepted in octal 4 digit format. First digit selects the set user ID(4), set group ID (2) and sticky (1) attributes. Second digit selects permission for the owner of the file: read (4), write (2) and execute (1). Third selects permissions for other users in the same group. the fourth for other users not in the group. 0755 - gives read/write/execute permissions to owner and read/execute to group and other users. </param>
        /// <param name="cloneProgress"> When a volume is being restored from another volume's snapshot, will show the percentage completion of this cloning process. When this value is empty/null there is no cloning process currently happening on this volume. This value will update every 5 minutes during cloning. </param>
        /// <param name="fileAccessLogs"> Flag indicating whether file access logs are enabled for the volume, based on active diagnostic settings present on the volume. </param>
        /// <param name="avsDataStore"> Specifies whether the volume is enabled for Azure VMware Solution (AVS) datastore purpose. </param>
        /// <param name="dataStoreResourceId"> Data store resource unique identifier. </param>
        /// <param name="isDefaultQuotaEnabled"> Specifies if default quota is enabled for the volume. </param>
        /// <param name="defaultUserQuotaInKiBs"> Default user quota for volume in KiBs. If isDefaultQuotaEnabled is set, the minimum value of 4 KiBs applies . </param>
        /// <param name="defaultGroupQuotaInKiBs"> Default group quota for volume in KiBs. If isDefaultQuotaEnabled is set, the minimum value of 4 KiBs applies. </param>
        /// <param name="maximumNumberOfFiles"> Maximum number of files allowed. Needs a service request in order to be changed. Only allowed to be changed if volume quota is more than 4TiB. </param>
        /// <param name="volumeGroupName"> Volume Group Name. </param>
        /// <param name="capacityPoolResourceId"> Pool Resource Id used in case of creating a volume through volume group. </param>
        /// <param name="proximityPlacementGroupId"> Proximity placement group associated with the volume. </param>
        /// <param name="t2Network"> T2 network information. </param>
        /// <param name="volumeSpecName"> Volume spec name is the application specific designation or identifier for the particular volume in a volume group for e.g. data, log. </param>
        /// <param name="isEncrypted"> Specifies if the volume is encrypted or not. Only available on volumes created or updated after 2022-01-01. </param>
        /// <param name="placementRules"> Application specific placement rules for the particular volume. </param>
        /// <param name="enableSubvolumes"> Flag indicating whether subvolume operations are enabled on the volume. </param>
        /// <param name="provisionedAvailabilityZone"> The availability zone where the volume is provisioned. This refers to the logical availability zone where the volume resides. </param>
        /// <param name="isLargeVolume"> Specifies whether volume is a Large Volume or Regular Volume. </param>
        /// <param name="originatingResourceId"> Id of the snapshot or backup that the volume is restored from. </param>
        /// <returns> A new <see cref="NetApp.NetAppVolumeData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeData NetAppVolumeData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, ETag? etag = null, IEnumerable<string> zones = null, Guid? fileSystemId = null, string creationToken = null, NetAppFileServiceLevel? serviceLevel = null, long usageThreshold = default, IEnumerable<NetAppVolumeExportPolicyRule> exportRules = null, IEnumerable<string> protocolTypes = null, string provisioningState = null, string snapshotId = null, bool? deleteBaseSnapshot = null, string backupId = null, string baremetalTenantId = null, ResourceIdentifier subnetId = null, NetAppNetworkFeature? networkFeatures = null, Guid? networkSiblingSetId = null, NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity = null, IEnumerable<NetAppVolumeMountTarget> mountTargets = null, string volumeType = null, NetAppVolumeDataProtection dataProtection = null, bool? isRestoring = null, bool? isSnapshotDirectoryVisible = null, bool? isKerberosEnabled = null, NetAppVolumeSecurityStyle? securityStyle = null, bool? isSmbEncryptionEnabled = null, SmbAccessBasedEnumeration? smbAccessBasedEnumeration = null, SmbNonBrowsable? smbNonBrowsable = null, bool? isSmbContinuouslyAvailable = null, float? throughputMibps = null, float? actualThroughputMibps = null, NetAppEncryptionKeySource? encryptionKeySource = null, ResourceIdentifier keyVaultPrivateEndpointResourceId = null, bool? isLdapEnabled = null, bool? isCoolAccessEnabled = null, int? coolnessPeriod = null, string unixPermissions = null, int? cloneProgress = null, NetAppFileAccessLog? fileAccessLogs = null, NetAppAvsDataStore? avsDataStore = null, IEnumerable<ResourceIdentifier> dataStoreResourceId = null, bool? isDefaultQuotaEnabled = null, long? defaultUserQuotaInKiBs = null, long? defaultGroupQuotaInKiBs = null, long? maximumNumberOfFiles = null, string volumeGroupName = null, ResourceIdentifier capacityPoolResourceId = null, ResourceIdentifier proximityPlacementGroupId = null, string t2Network = null, string volumeSpecName = null, bool? isEncrypted = null, IEnumerable<NetAppVolumePlacementRule> placementRules = null, EnableNetAppSubvolume? enableSubvolumes = null, string provisionedAvailabilityZone = null, bool? isLargeVolume = null, ResourceIdentifier originatingResourceId = null)
        {
            tags ??= new Dictionary<string, string>();
            zones ??= new List<string>();
            exportRules ??= new List<NetAppVolumeExportPolicyRule>();
            protocolTypes ??= new List<string>();
            mountTargets ??= new List<NetAppVolumeMountTarget>();
            dataStoreResourceId ??= new List<ResourceIdentifier>();
            placementRules ??= new List<NetAppVolumePlacementRule>();
            //Set null for zones and coolAccessRetrievalPolicy for backwards compat
            return new NetAppVolumeData(id, name, resourceType, systemData, tags, location, etag, zones?.ToList(), fileSystemId, creationToken, serviceLevel, usageThreshold, exportRules != null ? new VolumePropertiesExportPolicy(exportRules?.ToList(), serializedAdditionalRawData: null) : null, protocolTypes?.ToList(), provisioningState, new ResourceIdentifier(snapshotId), deleteBaseSnapshot, new ResourceIdentifier(backupId), baremetalTenantId, subnetId, networkFeatures, null, networkSiblingSetId, storageToNetworkProximity, mountTargets?.ToList(), volumeType, dataProtection, acceptGrowCapacityPoolForShortTermCloneSplit: null, isRestoring, isSnapshotDirectoryVisible, isKerberosEnabled, securityStyle, isSmbEncryptionEnabled, smbAccessBasedEnumeration, smbNonBrowsable, isSmbContinuouslyAvailable, throughputMibps, actualThroughputMibps, encryptionKeySource, keyVaultPrivateEndpointResourceId, isLdapEnabled, isCoolAccessEnabled, coolnessPeriod, null, unixPermissions, cloneProgress, fileAccessLogs, avsDataStore, dataStoreResourceId?.ToList(), isDefaultQuotaEnabled, defaultUserQuotaInKiBs, defaultGroupQuotaInKiBs, maximumNumberOfFiles, volumeGroupName, capacityPoolResourceId, proximityPlacementGroupId, t2Network, volumeSpecName, isEncrypted, placementRules?.ToList(), enableSubvolumes, provisionedAvailabilityZone, isLargeVolume, originatingResourceId, inheritedSizeInBytes: null, language: null, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="NetApp.NetAppVolumeData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="zones"> Availability Zone. </param>
        /// <param name="fileSystemId"> Unique FileSystem Identifier. </param>
        /// <param name="creationToken"> A unique file path for the volume. Used when creating mount targets. </param>
        /// <param name="serviceLevel"> The service level of the file system. </param>
        /// <param name="usageThreshold"> Maximum storage quota allowed for a file system in bytes. This is a soft quota used for alerting only. For regular volumes, valid values are in the range 50GiB to 100TiB. For large volumes, valid values are in the range 100TiB to 500TiB, and on an exceptional basis, from to 2400GiB to 2400TiB. Values expressed in bytes as multiples of 1 GiB. </param>
        /// <param name="exportRules"> Set of export policy rules. </param>
        /// <param name="protocolTypes"> Set of protocol types, default NFSv3, CIFS for SMB protocol. </param>
        /// <param name="provisioningState"> Azure lifecycle management. </param>
        /// <param name="snapshotId"> Resource identifier used to identify the Snapshot. </param>
        /// <param name="deleteBaseSnapshot"> If enabled (true) the snapshot the volume was created from will be automatically deleted after the volume create operation has finished.  Defaults to false. </param>
        /// <param name="backupId"> Resource identifier used to identify the Backup. </param>
        /// <param name="baremetalTenantId"> Unique Baremetal Tenant Identifier. </param>
        /// <param name="subnetId"> The Azure Resource URI for a delegated subnet. Must have the delegation Microsoft.NetApp/volumes. </param>
        /// <param name="networkFeatures"> Network features available to the volume, or current state of update. </param>
        /// <param name="networkSiblingSetId"> Network Sibling Set ID for the the group of volumes sharing networking resources. </param>
        /// <param name="storageToNetworkProximity"> Provides storage to network proximity information for the volume. </param>
        /// <param name="mountTargets"> List of mount targets. </param>
        /// <param name="volumeType"> What type of volume is this. For destination volumes in Cross Region Replication, set type to DataProtection. </param>
        /// <param name="dataProtection"> DataProtection type volumes include an object containing details of the replication. </param>
        /// <param name="isRestoring"> Restoring. </param>
        /// <param name="isSnapshotDirectoryVisible"> If enabled (true) the volume will contain a read-only snapshot directory which provides access to each of the volume's snapshots (defaults to true). </param>
        /// <param name="isKerberosEnabled"> Describe if a volume is KerberosEnabled. To be use with swagger version 2020-05-01 or later. </param>
        /// <param name="securityStyle"> The security style of volume, default unix, defaults to ntfs for dual protocol or CIFS protocol. </param>
        /// <param name="isSmbEncryptionEnabled"> Enables encryption for in-flight smb3 data. Only applicable for SMB/DualProtocol volume. To be used with swagger version 2020-08-01 or later. </param>
        /// <param name="smbAccessBasedEnumeration"> Enables access-based enumeration share property for SMB Shares. Only applicable for SMB/DualProtocol volume. </param>
        /// <param name="smbNonBrowsable"> Enables non-browsable property for SMB Shares. Only applicable for SMB/DualProtocol volume. </param>
        /// <param name="isSmbContinuouslyAvailable"> Enables continuously available share property for smb volume. Only applicable for SMB volume. </param>
        /// <param name="throughputMibps"> Maximum throughput in MiB/s that can be achieved by this volume and this will be accepted as input only for manual qosType volume. </param>
        /// <param name="actualThroughputMibps"> Actual throughput in MiB/s for auto qosType volumes calculated based on size and serviceLevel. </param>
        /// <param name="encryptionKeySource"> Source of key used to encrypt data in volume. Applicable if NetApp account has encryption.keySource = 'Microsoft.KeyVault'. Possible values (case-insensitive) are: 'Microsoft.NetApp, Microsoft.KeyVault'. </param>
        /// <param name="keyVaultPrivateEndpointResourceId"> The resource ID of private endpoint for KeyVault. It must reside in the same VNET as the volume. Only applicable if encryptionKeySource = 'Microsoft.KeyVault'. </param>
        /// <param name="isLdapEnabled"> Specifies whether LDAP is enabled or not for a given NFS volume. </param>
        /// <param name="isCoolAccessEnabled"> Specifies whether Cool Access(tiering) is enabled for the volume. </param>
        /// <param name="coolnessPeriod"> Specifies the number of days after which data that is not accessed by clients will be tiered. </param>
        /// <param name="coolAccessRetrievalPolicy">
        /// coolAccessRetrievalPolicy determines the data retrieval behavior from the cool tier to standard storage based on the read pattern for cool access enabled volumes. The possible values for this field are:
        ///  Default - Data will be pulled from cool tier to standard storage on random reads. This policy is the default.
        ///  OnRead - All client-driven data read is pulled from cool tier to standard storage on both sequential and random reads.
        ///  Never - No client-driven data is pulled from cool tier to standard storage.
        /// </param>
        /// <param name="unixPermissions"> UNIX permissions for NFS volume accepted in octal 4 digit format. First digit selects the set user ID(4), set group ID (2) and sticky (1) attributes. Second digit selects permission for the owner of the file: read (4), write (2) and execute (1). Third selects permissions for other users in the same group. the fourth for other users not in the group. 0755 - gives read/write/execute permissions to owner and read/execute to group and other users. </param>
        /// <param name="cloneProgress"> When a volume is being restored from another volume's snapshot, will show the percentage completion of this cloning process. When this value is empty/null there is no cloning process currently happening on this volume. This value will update every 5 minutes during cloning. </param>
        /// <param name="fileAccessLogs"> Flag indicating whether file access logs are enabled for the volume, based on active diagnostic settings present on the volume. </param>
        /// <param name="avsDataStore"> Specifies whether the volume is enabled for Azure VMware Solution (AVS) datastore purpose. </param>
        /// <param name="dataStoreResourceId"> Data store resource unique identifier. </param>
        /// <param name="isDefaultQuotaEnabled"> Specifies if default quota is enabled for the volume. </param>
        /// <param name="defaultUserQuotaInKiBs"> Default user quota for volume in KiBs. If isDefaultQuotaEnabled is set, the minimum value of 4 KiBs applies . </param>
        /// <param name="defaultGroupQuotaInKiBs"> Default group quota for volume in KiBs. If isDefaultQuotaEnabled is set, the minimum value of 4 KiBs applies. </param>
        /// <param name="maximumNumberOfFiles"> Maximum number of files allowed. Needs a service request in order to be changed. Only allowed to be changed if volume quota is more than 4TiB. </param>
        /// <param name="volumeGroupName"> Volume Group Name. </param>
        /// <param name="capacityPoolResourceId"> Pool Resource Id used in case of creating a volume through volume group. </param>
        /// <param name="proximityPlacementGroupId"> Proximity placement group associated with the volume. </param>
        /// <param name="t2Network"> T2 network information. </param>
        /// <param name="volumeSpecName"> Volume spec name is the application specific designation or identifier for the particular volume in a volume group for e.g. data, log. </param>
        /// <param name="isEncrypted"> Specifies if the volume is encrypted or not. Only available on volumes created or updated after 2022-01-01. </param>
        /// <param name="placementRules"> Application specific placement rules for the particular volume. </param>
        /// <param name="enableSubvolumes"> Flag indicating whether subvolume operations are enabled on the volume. </param>
        /// <param name="provisionedAvailabilityZone"> The availability zone where the volume is provisioned. This refers to the logical availability zone where the volume resides. </param>
        /// <param name="isLargeVolume"> Specifies whether volume is a Large Volume or Regular Volume. </param>
        /// <param name="originatingResourceId"> Id of the snapshot or backup that the volume is restored from. </param>
        /// <returns> A new <see cref="NetApp.NetAppVolumeData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeData NetAppVolumeData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, ETag? etag = null, IEnumerable<string> zones = null, Guid? fileSystemId = null, string creationToken = null, NetAppFileServiceLevel? serviceLevel = null, long usageThreshold = default, IEnumerable<NetAppVolumeExportPolicyRule> exportRules = null, IEnumerable<string> protocolTypes = null, string provisioningState = null, string snapshotId = null, bool? deleteBaseSnapshot = null, string backupId = null, string baremetalTenantId = null, ResourceIdentifier subnetId = null, NetAppNetworkFeature? networkFeatures = null, Guid? networkSiblingSetId = null, NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity = null, IEnumerable<NetAppVolumeMountTarget> mountTargets = null, string volumeType = null, NetAppVolumeDataProtection dataProtection = null, bool? isRestoring = null, bool? isSnapshotDirectoryVisible = null, bool? isKerberosEnabled = null, NetAppVolumeSecurityStyle? securityStyle = null, bool? isSmbEncryptionEnabled = null, SmbAccessBasedEnumeration? smbAccessBasedEnumeration = null, SmbNonBrowsable? smbNonBrowsable = null, bool? isSmbContinuouslyAvailable = null, float? throughputMibps = null, float? actualThroughputMibps = null, NetAppEncryptionKeySource? encryptionKeySource = null, ResourceIdentifier keyVaultPrivateEndpointResourceId = null, bool? isLdapEnabled = null, bool? isCoolAccessEnabled = null, int? coolnessPeriod = null, CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy = null, string unixPermissions = null, int? cloneProgress = null, NetAppFileAccessLog? fileAccessLogs = null, NetAppAvsDataStore? avsDataStore = null, IEnumerable<ResourceIdentifier> dataStoreResourceId = null, bool? isDefaultQuotaEnabled = null, long? defaultUserQuotaInKiBs = null, long? defaultGroupQuotaInKiBs = null, long? maximumNumberOfFiles = null, string volumeGroupName = null, ResourceIdentifier capacityPoolResourceId = null, ResourceIdentifier proximityPlacementGroupId = null, string t2Network = null, string volumeSpecName = null, bool? isEncrypted = null, IEnumerable<NetAppVolumePlacementRule> placementRules = null, EnableNetAppSubvolume? enableSubvolumes = null, string provisionedAvailabilityZone = null, bool? isLargeVolume = null, ResourceIdentifier originatingResourceId = null)
        {
            tags ??= new Dictionary<string, string>();
            exportRules ??= new List<NetAppVolumeExportPolicyRule>();
            protocolTypes ??= new List<string>();
            mountTargets ??= new List<NetAppVolumeMountTarget>();
            dataStoreResourceId ??= new List<ResourceIdentifier>();
            placementRules ??= new List<NetAppVolumePlacementRule>();
            return new NetAppVolumeData(id, name, resourceType, systemData, tags, location, etag, zones?.ToList(), fileSystemId, creationToken, serviceLevel, usageThreshold, exportRules != null ? new VolumePropertiesExportPolicy(exportRules?.ToList(), serializedAdditionalRawData: null) : null, protocolTypes?.ToList(), provisioningState, new ResourceIdentifier(snapshotId), deleteBaseSnapshot, new ResourceIdentifier(backupId), baremetalTenantId, subnetId, networkFeatures, null, networkSiblingSetId, storageToNetworkProximity, mountTargets?.ToList(), volumeType, dataProtection, acceptGrowCapacityPoolForShortTermCloneSplit:null, isRestoring, isSnapshotDirectoryVisible, isKerberosEnabled, securityStyle, isSmbEncryptionEnabled, smbAccessBasedEnumeration, smbNonBrowsable, isSmbContinuouslyAvailable, throughputMibps, actualThroughputMibps, encryptionKeySource, keyVaultPrivateEndpointResourceId, isLdapEnabled, isCoolAccessEnabled, coolnessPeriod, coolAccessRetrievalPolicy, unixPermissions, cloneProgress, fileAccessLogs, avsDataStore, dataStoreResourceId?.ToList(), isDefaultQuotaEnabled, defaultUserQuotaInKiBs, defaultGroupQuotaInKiBs, maximumNumberOfFiles, volumeGroupName, capacityPoolResourceId, proximityPlacementGroupId, t2Network, volumeSpecName, isEncrypted, placementRules?.ToList(), enableSubvolumes, provisionedAvailabilityZone, isLargeVolume, originatingResourceId, inheritedSizeInBytes: null, language: null, serializedAdditionalRawData: null);
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
        public static NetAppBackupData NetAppBackupData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string backupId = null, DateTimeOffset? createdOn = null, string provisioningState = null, long? size = null, string label = null, NetAppBackupType? backupType = null, string failureReason = null, ResourceIdentifier volumeResourceId = null, bool? useExistingSnapshot = null, string snapshotName = null, string backupPolicyResourceId = null)
        {
            ResourceIdentifier backupPolicyArmResourceId = new ResourceIdentifier(backupPolicyResourceId);
            return new NetAppBackupData(
                id,
                name,
                resourceType,
                systemData,
                backupId,
                createdOn,
                provisioningState,
                size,
                label,
                backupType,
                failureReason,
                volumeResourceId,
                useExistingSnapshot,
                snapshotName,
                backupPolicyArmResourceId,
                isLargeVolume: null,
                serializedAdditionalRawData: null);
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
    }
}
