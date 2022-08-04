using Microsoft.Rest.Azure;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.NetApp.Models
{
    /// <summary>
    /// Volume resource
    /// </summary>
    public partial class Volume : IResource
    {
        /// <summary>
        /// Initializes a new instance of the Volume class.
        /// </summary>
        /// <param name="location">Resource location</param>
        /// <param name="creationToken">Creation Token or File Path</param>
        /// <param name="usageThreshold">usageThreshold</param>
        /// <param name="subnetId">The Azure Resource URI for a delegated
        /// subnet. Must have the delegation Microsoft.NetApp/volumes</param>
        /// <param name="id">Resource Id</param>
        /// <param name="name">Resource name</param>
        /// <param name="etag">A unique read-only string that changes whenever
        /// the resource is updated.</param>
        /// <param name="type">Resource type</param>
        /// <param name="tags">Resource tags</param>
        /// <param name="fileSystemId">FileSystem ID</param>
        /// <param name="serviceLevel">serviceLevel</param>
        /// <param name="exportPolicy">exportPolicy</param>
        /// <param name="protocolTypes">protocolTypes</param>
        /// <param name="provisioningState">Azure lifecycle management</param>
        /// <param name="snapshotId">Snapshot ID</param>
        /// <param name="backupId">Backup ID</param>
        /// <param name="baremetalTenantId">Baremetal Tenant ID</param>
        /// <param name="networkFeatures">Network features</param>
        /// <param name="networkSiblingSetId">Network Sibling Set ID</param>
        /// <param name="storageToNetworkProximity">Storage to Network
        /// Proximity</param>
        /// <param name="mountTargets">mountTargets</param>
        /// <param name="volumeType">What type of volume is this. For
        /// destination volumes in Cross Region Replication, set type to
        /// DataProtection</param>
        /// <param name="dataProtection">DataProtection</param>
        /// <param name="isRestoring">Restoring</param>
        /// <param name="snapshotDirectoryVisible">If enabled (true) the volume
        /// will contain a read-only snapshot directory which provides access
        /// to each of the volume's snapshots (default to true).</param>
        /// <param name="kerberosEnabled">Describe if a volume is
        /// KerberosEnabled. To be use with swagger version 2020-05-01 or
        /// later</param>
        /// <param name="securityStyle">The security style of volume, default
        /// unix, defaults to ntfs for dual protocol or CIFS protocol. Possible
        /// values include: 'ntfs', 'unix'</param>
        /// <param name="smbEncryption">Enables encryption for in-flight smb3
        /// data. Only applicable for SMB/DualProtocol volume. To be used with
        /// swagger version 2020-08-01 or later</param>
        /// <param name="smbContinuouslyAvailable">Enables continuously
        /// available share property for smb volume. Only applicable for SMB
        /// volume</param>
        /// <param name="throughputMibps">Maximum throughput in Mibps that can
        /// be achieved by this volume and this will be accepted as input only
        /// for manual qosType volume</param>
        /// <param name="encryptionKeySource">Encryption Key Source. Possible
        /// values are: 'Microsoft.NetApp'</param>
        /// <param name="ldapEnabled">Specifies whether LDAP is enabled or not
        /// for a given NFS volume.</param>
        /// <param name="coolAccess">Specifies whether Cool Access(tiering) is
        /// enabled for the volume.</param>
        /// <param name="coolnessPeriod">Specifies the number of days after
        /// which data that is not accessed by clients will be tiered.</param>
        /// <param name="unixPermissions">UNIX permissions for NFS volume
        /// accepted in octal 4 digit format. First digit selects the set user
        /// ID(4), set group ID (2) and sticky (1) attributes. Second digit
        /// selects permission for the owner of the file: read (4), write (2)
        /// and execute (1). Third selects permissions for other users in the
        /// same group. the fourth for other users not in the group. 0755 -
        /// gives read/write/execute permissions to owner and read/execute to
        /// group and other users.</param>
        /// <param name="cloneProgress">When a volume is being restored from
        /// another volume's snapshot, will show the percentage completion of
        /// this cloning process. When this value is empty/null there is no
        /// cloning process currently happening on this volume. This value will
        /// update every 5 minutes during cloning.</param>
        /// <param name="avsDataStore">avsDataStore</param>
        /// <param name="isDefaultQuotaEnabled">Specifies if default quota is
        /// enabled for the volume.</param>
        /// <param name="defaultUserQuotaInKiBs">Default user quota for volume
        /// in KiBs. If isDefaultQuotaEnabled is set, the minimum value of 4
        /// KiBs applies .</param>
        /// <param name="defaultGroupQuotaInKiBs">Default group quota for
        /// volume in KiBs. If isDefaultQuotaEnabled is set, the minimum value
        /// of 4 KiBs applies.</param>
        /// <param name="volumeGroupName">Volume Group Name</param>
        /// <param name="capacityPoolResourceId">Pool Resource Id used in case
        /// of creating a volume through volume group</param>
        /// <param name="proximityPlacementGroup">Proximity placement group
        /// associated with the volume</param>
        /// <param name="t2Network">T2 network information</param>
        /// <param name="volumeSpecName">Volume spec name is the application
        /// specific designation or identifier for the particular volume in a
        /// volume group for e.g. data, log</param>
        /// <param name="placementRules">Volume placement rules</param>
        public Volume(string location, string creationToken, long usageThreshold, string subnetId, string id = default(string), string name = default(string), string etag = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), string fileSystemId = default(string), string serviceLevel = default(string), VolumePropertiesExportPolicy exportPolicy = default(VolumePropertiesExportPolicy), IList<string> protocolTypes = default(IList<string>), string provisioningState = default(string), string snapshotId = default(string), string backupId = default(string), string baremetalTenantId = default(string), string networkFeatures = default(string), string networkSiblingSetId = default(string), string storageToNetworkProximity = default(string), IList<MountTargetProperties> mountTargets = default(IList<MountTargetProperties>), string volumeType = default(string), VolumePropertiesDataProtection dataProtection = default(VolumePropertiesDataProtection), bool? isRestoring = default(bool?), bool? snapshotDirectoryVisible = default(bool?), bool? kerberosEnabled = default(bool?), string securityStyle = default(string), bool? smbEncryption = default(bool?), bool? smbContinuouslyAvailable = default(bool?), double? throughputMibps = default(double?), string encryptionKeySource = default(string), bool? ldapEnabled = default(bool?), bool? coolAccess = default(bool?), int? coolnessPeriod = default(int?), string unixPermissions = default(string), int? cloneProgress = default(int?), string avsDataStore = default(string), bool? isDefaultQuotaEnabled = default(bool?), long? defaultUserQuotaInKiBs = default(long?), long? defaultGroupQuotaInKiBs = default(long?), string volumeGroupName = default(string), string capacityPoolResourceId = default(string), string proximityPlacementGroup = default(string), string t2Network = default(string), string volumeSpecName = default(string), IList<PlacementKeyValuePairs> placementRules = default(IList<PlacementKeyValuePairs>))
        {
            Location = location;
            Id = id;
            Name = name;
            Etag = etag;
            Type = type;
            Tags = tags;
            FileSystemId = fileSystemId;
            CreationToken = creationToken;
            ServiceLevel = serviceLevel;
            UsageThreshold = usageThreshold;
            ExportPolicy = exportPolicy;
            ProtocolTypes = protocolTypes;
            ProvisioningState = provisioningState;
            SnapshotId = snapshotId;
            BackupId = backupId;
            BaremetalTenantId = baremetalTenantId;
            SubnetId = subnetId;
            NetworkFeatures = networkFeatures;
            NetworkSiblingSetId = networkSiblingSetId;
            StorageToNetworkProximity = storageToNetworkProximity;
            MountTargets = mountTargets;
            VolumeType = volumeType;
            DataProtection = dataProtection;
            IsRestoring = isRestoring;
            SnapshotDirectoryVisible = snapshotDirectoryVisible;
            KerberosEnabled = kerberosEnabled;
            SecurityStyle = securityStyle;
            SmbEncryption = smbEncryption;
            SmbContinuouslyAvailable = smbContinuouslyAvailable;
            ThroughputMibps = throughputMibps;
            EncryptionKeySource = encryptionKeySource;
            LdapEnabled = ldapEnabled;
            CoolAccess = coolAccess;
            CoolnessPeriod = coolnessPeriod;
            UnixPermissions = unixPermissions;
            CloneProgress = cloneProgress;
            AvsDataStore = avsDataStore;
            IsDefaultQuotaEnabled = isDefaultQuotaEnabled;
            DefaultUserQuotaInKiBs = defaultUserQuotaInKiBs;
            DefaultGroupQuotaInKiBs = defaultGroupQuotaInKiBs;
            VolumeGroupName = volumeGroupName;
            CapacityPoolResourceId = capacityPoolResourceId;
            ProximityPlacementGroup = proximityPlacementGroup;
            T2Network = t2Network;
            VolumeSpecName = volumeSpecName;
            PlacementRules = placementRules;
            CustomInit();
        }
    }
}