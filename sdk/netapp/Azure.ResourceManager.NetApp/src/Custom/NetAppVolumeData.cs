// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    /// <summary>
    /// A class representing the NetAppVolume data model.
    /// Volume resource
    /// This type is deprecated. Use <see cref="VolumeData"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [CodeGenSerialization(nameof(IsRestoring), "isRestoring")]
    public partial class NetAppVolumeData : TrackedResourceData, IJsonModel<NetAppVolumeData>, IPersistableModel<NetAppVolumeData>
    {
        /// <summary> Initializes a new instance of <see cref="NetAppVolumeData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="creationToken"> A unique file path for the volume. </param>
        /// <param name="usageThreshold"> Maximum storage quota allowed for a file system in bytes. </param>
        /// <param name="subnetId"> The Azure Resource URI for a delegated subnet. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppVolumeData(AzureLocation location, string creationToken, long usageThreshold, ResourceIdentifier subnetId) : base(location)
        {
            CreationToken = creationToken;
            UsageThreshold = usageThreshold;
            SubnetId = subnetId?.ToString();
        }

        /// <summary> A unique file path for the volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CreationToken { get; set; }

        /// <summary> Maximum storage quota allowed for a file system in bytes. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long UsageThreshold { get; set; }

        /// <summary> The Azure Resource URI for a delegated subnet. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SubnetId { get; set; }

        /// <summary> Restoring. ReadOnly property indicating if volume is being restored. </summary>
        public bool? IsRestoring
        {
            get;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set;
        }

        /// <summary> Accept any grow capacity pool for short term clone split. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AcceptGrowCapacityPoolForShortTermCloneSplit? AcceptGrowCapacityPoolForShortTermCloneSplit { get; set; }

        /// <summary> Actual throughput in MiB/s for auto qosType volumes calculated based on size and serviceLevel. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ActualThroughputMibps { get; }

        /// <summary> Specifies whether the volume is enabled for Azure VMware Solution (AVS) datastore purpose. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppAvsDataStore? NetAppAvsDataStore { get; set; }

        /// <summary> UUID v4 or resource identifier used to identify the Backup. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BackupId { get; set; }

        /// <summary> Unique Baremetal Tenant Identifier. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BaremetalTenantId { get; }

        /// <summary> Pool Resource Id used in case of creating a volume through volume group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier CapacityPoolResourceId { get; set; }

        /// <summary> When a volume is being restored from another volume's snapshot, will show the percentage completion of this cloning process. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? CloneProgress { get; }

        /// <summary> Specifies the number of days after which data that is not accessed by clients will be tiered. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? CoolnessPeriod { get; set; }

        /// <summary> coolAccessRetrievalPolicy determines the data retrieval behavior from the cool tier to standard storage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CoolAccessRetrievalPolicy? CoolAccessRetrievalPolicy { get; set; }

        /// <summary> Tiering policy for a volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CoolAccessTieringPolicy? CoolAccessTieringPolicy { get; set; }

        /// <summary> Specifies whether the volume is enabled for Azure VMware Solution (AVS) datastore purpose. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppAvsDataStore? AvsDataStore { get; set; }

        /// <summary> DataProtection type volumes include an object containing details of the replication. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppVolumeDataProtection DataProtection { get; set; }

        /// <summary> Data store resource unique identifier. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<string> DataStoreResourceId { get; }

        /// <summary> Default group quota for volume in KiBs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? DefaultGroupQuotaInKiBs { get; set; }

        /// <summary> Default user quota for volume in KiBs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? DefaultUserQuotaInKiBs { get; set; }

        /// <summary> If enabled (true) the snapshot the volume was created from will be automatically deleted after the volume create operation has finished. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? DeleteBaseSnapshot { get; set; }

        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ETag { get; }

        /// <summary> The effective value of the network features type available to the volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppNetworkFeature? EffectiveNetworkFeatures { get; }

        /// <summary> Flag indicating whether subvolume operations are enabled on the volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EnableNetAppSubvolume? EnableSubvolumes { get; set; }

        /// <summary> Source of key used to encrypt data in volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppEncryptionKeySource? EncryptionKeySource { get; set; }

        /// <summary> Export policy rule. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<NetAppVolumeExportPolicyRule> ExportRules { get; }

        /// <summary> Flag indicating whether file access logs are enabled for the volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppFileAccessLog? FileAccessLogs { get; }

        /// <summary> Unique FileSystem Identifier. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FileSystemId { get; }

        /// <summary> Space shared by short term clone volume with parent volume in bytes. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? InheritedSizeInBytes { get; }

        /// <summary> Specifies whether Cool Access(tiering) is enabled for the volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsCoolAccessEnabled { get; set; }

        /// <summary> Specifies if default quota is enabled for the volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsDefaultQuotaEnabled { get; set; }

        /// <summary> Specifies if the volume is encrypted or not. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsEncrypted { get; }

        /// <summary> Describe if a volume is KerberosEnabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsKerberosEnabled { get; set; }

        /// <summary> Specifies whether volume is a Large Volume or Regular Volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsLargeVolume { get; set; }

        /// <summary> Specifies whether LDAP is enabled or not for a given NFS volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsLdapEnabled { get; set; }

        /// <summary> Enables continuously available share property for smb volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsSmbContinuouslyAvailable { get; set; }

        /// <summary> Enables encryption for in-flight smb3 data. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsSmbEncryptionEnabled { get; set; }

        /// <summary> If enabled (true) the volume will contain a read-only snapshot directory. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsSnapshotDirectoryVisible { get; set; }

        /// <summary> The resource ID of private endpoint for KeyVault. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier KeyVaultPrivateEndpointResourceId { get; set; }

        /// <summary> Maximum number of files allowed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? MaximumNumberOfFiles { get; }

        /// <summary> List of mount targets. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<NetAppVolumeMountTarget> MountTargets { get; }

        /// <summary> The original value of the network features type available to the volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppNetworkFeature? NetworkFeatures { get; set; }

        /// <summary> Network Sibling Set ID for the group of volumes sharing networking resources. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string NetworkSiblingSetId { get; }

        /// <summary> Id of the snapshot or backup that the volume is restored from. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier OriginatingResourceId { get; }

        /// <summary> Application specific placement rules for the particular volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<NetAppVolumePlacementRule> PlacementRules { get; }

        /// <summary> Set of protocol types. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> ProtocolTypes { get; }

        /// <summary> The availability zone where the volume is provisioned. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProvisionedAvailabilityZone { get; }

        /// <summary> Azure lifecycle management. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProvisioningState { get; }

        /// <summary> Proximity placement group associated with the volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier ProximityPlacementGroupId { get; set; }

        /// <summary> The security style of volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppVolumeSecurityStyle? SecurityStyle { get; set; }

        /// <summary> The service level of the file system. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppFileServiceLevel? ServiceLevel { get; set; }

        /// <summary> Enables access-based enumeration share property for SMB Shares. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SmbAccessBasedEnumeration? SmbAccessBasedEnumeration { get; set; }

        /// <summary> Enables non-browsable property for SMB Shares. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SmbNonBrowsable? SmbNonBrowsable { get; set; }

        /// <summary> Resource identifier used to identify the Snapshot. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier SnapshotId { get; set; }

        /// <summary> Provides storage to network proximity information for the volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetAppVolumeStorageToNetworkProximity? StorageToNetworkProximity { get; }

        /// <summary> T2 network information. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string T2Network { get; }

        /// <summary> Maximum throughput in MiB/s that can be achieved by this volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ThroughputMibps { get; set; }

        /// <summary> UNIX permissions for NFS volume accepted in octal 4 digit format. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string UnixPermissions { get; set; }

        /// <summary> Volume Group Name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string VolumeGroupName { get; }

        /// <summary> Volume spec name is the application specific designation or identifier for the particular volume. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string VolumeSpecName { get; set; }

        /// <summary> What type of volume is this. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string VolumeType { get; set; }

        /// <summary> The availability zones. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> Zones { get; }

        NetAppVolumeData IJsonModel<NetAppVolumeData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("NetAppVolumeData is deprecated. Use VolumeData instead.");
        }

        void IJsonModel<NetAppVolumeData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("NetAppVolumeData is deprecated. Use VolumeData instead.");
        }

        NetAppVolumeData IPersistableModel<NetAppVolumeData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("NetAppVolumeData is deprecated. Use VolumeData instead.");
        }

        string IPersistableModel<NetAppVolumeData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<NetAppVolumeData>.Write(ModelReaderWriterOptions options)
        {
            throw new NotSupportedException("NetAppVolumeData is deprecated. Use VolumeData instead.");
        }
    }
}
