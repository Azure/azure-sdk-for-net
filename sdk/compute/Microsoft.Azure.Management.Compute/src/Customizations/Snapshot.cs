namespace Microsoft.Azure.Management.Compute.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Snapshot resource.
    /// </summary>
    public partial class Snapshot : Resource
    {
        /// <summary>
        /// Initializes a new instance of the Snapshot class.
        /// </summary>
        /// <param name="location">Resource location</param>
        /// <param name="creationData">Disk source information. CreationData
        /// information cannot be changed after the disk has been
        /// created.</param>
        /// <param name="id">Resource Id</param>
        /// <param name="name">Resource name</param>
        /// <param name="type">Resource type</param>
        /// <param name="tags">Resource tags</param>
        /// <param name="managedBy">Unused. Always Null.</param>
        /// <param name="extendedLocation">The extended location where the
        /// snapshot will be created. Extended location cannot be
        /// changed.</param>
        /// <param name="timeCreated">The time when the snapshot was
        /// created.</param>
        /// <param name="osType">The Operating System type. Possible values
        /// include: 'Windows', 'Linux'</param>
        /// <param name="hyperVGeneration">The hypervisor generation of the
        /// Virtual Machine. Applicable to OS disks only. Possible values
        /// include: 'V1', 'V2'</param>
        /// <param name="purchasePlan">Purchase plan information for the image
        /// from which the source disk for the snapshot was originally
        /// created.</param>
        /// <param name="diskSizeGB">If creationData.createOption is Empty,
        /// this field is mandatory and it indicates the size of the disk to
        /// create. If this field is present for updates or creation with other
        /// options, it indicates a resize. Resizes are only allowed if the
        /// disk is not attached to a running VM, and can only increase the
        /// disk's size.</param>
        /// <param name="diskSizeBytes">The size of the disk in bytes. This
        /// field is read only.</param>
        /// <param name="diskState">The state of the snapshot. Possible values
        /// include: 'Unattached', 'Attached', 'Reserved', 'Frozen',
        /// 'ActiveSAS', 'ActiveSASFrozen', 'ReadyToUpload',
        /// 'ActiveUpload'</param>
        /// <param name="uniqueId">Unique Guid identifying the
        /// resource.</param>
        /// <param name="encryptionSettingsCollection">Encryption settings
        /// collection used be Azure Disk Encryption, can contain multiple
        /// encryption settings per disk or snapshot.</param>
        /// <param name="provisioningState">The disk provisioning
        /// state.</param>
        /// <param name="incremental">Whether a snapshot is incremental.
        /// Incremental snapshots on the same disk occupy less space than full
        /// snapshots and can be diffed.</param>
        /// <param name="encryption">Encryption property can be used to encrypt
        /// data at rest with customer managed keys or platform managed
        /// keys.</param>
        /// <param name="networkAccessPolicy">Possible values include:
        /// 'AllowAll', 'AllowPrivate', 'DenyAll'</param>
        /// <param name="diskAccessId">ARM id of the DiskAccess resource for
        /// using private endpoints on disks.</param>
        /// <param name="supportsHibernation">Indicates the OS on a snapshot
        /// supports hibernation.</param>
        /// <param name="publicNetworkAccess">Possible values include:
        /// 'Enabled', 'Disabled'</param>
        /// <param name="completionPercent">Percentage complete for the
        /// background copy when a resource is created via the CopyStart
        /// operation.</param>
        /// <param name="supportedCapabilities">List of supported capabilities
        /// (like Accelerated Networking) for the image from which the source
        /// disk from the snapshot was originally created.</param>
        public Snapshot(string location, CreationData creationData, string id, string name, string type, IDictionary<string, string> tags, string managedBy, SnapshotSku sku, ExtendedLocation extendedLocation, System.DateTime? timeCreated, OperatingSystemTypes? osType, string hyperVGeneration, PurchasePlan purchasePlan, int? diskSizeGB, long? diskSizeBytes = default(long?), string diskState = default(string), string uniqueId = default(string), EncryptionSettingsCollection encryptionSettingsCollection = default(EncryptionSettingsCollection), string provisioningState = default(string), bool? incremental = default(bool?), Encryption encryption = default(Encryption), string networkAccessPolicy = default(string), string diskAccessId = default(string), bool? supportsHibernation = default(bool?))
                    : base(location, id, name, type, tags)
        {
            ManagedBy = managedBy;
            Sku = sku;
            ExtendedLocation = extendedLocation;
            TimeCreated = timeCreated;
            OsType = osType;
            HyperVGeneration = hyperVGeneration;
            PurchasePlan = purchasePlan;
            CreationData = creationData;
            DiskSizeGB = diskSizeGB;
            DiskSizeBytes = diskSizeBytes;
            DiskState = diskState;
            UniqueId = uniqueId;
            EncryptionSettingsCollection = encryptionSettingsCollection;
            ProvisioningState = provisioningState;
            Incremental = incremental;
            Encryption = encryption;
            NetworkAccessPolicy = networkAccessPolicy;
            DiskAccessId = diskAccessId;
            SupportsHibernation = supportsHibernation;
            CustomInit();
        }

        public Snapshot(string location, CreationData creationData, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), string managedBy = default(string), SnapshotSku sku = default(SnapshotSku), ExtendedLocation extendedLocation = default(ExtendedLocation), System.DateTime? timeCreated = default(System.DateTime?), OperatingSystemTypes? osType = default(OperatingSystemTypes?), string hyperVGeneration = default(string), PurchasePlan purchasePlan = default(PurchasePlan), SupportedCapabilities supportedCapabilities = default(SupportedCapabilities), int? diskSizeGB = default(int?), long? diskSizeBytes = default(long?), string diskState = default(string), string uniqueId = default(string), EncryptionSettingsCollection encryptionSettingsCollection = default(EncryptionSettingsCollection), string provisioningState = default(string), bool? incremental = default(bool?), Encryption encryption = default(Encryption), string networkAccessPolicy = default(string), string diskAccessId = default(string), DiskSecurityProfile securityProfile = default(DiskSecurityProfile), bool? supportsHibernation = default(bool?), string publicNetworkAccess = default(string), double? completionPercent = default(double?), string dataAccessAuthMode = default(string))
            : base(location, id, name, type, tags)
        {
            ManagedBy = managedBy;
            Sku = sku;
            ExtendedLocation = extendedLocation;
            TimeCreated = timeCreated;
            OsType = osType;
            HyperVGeneration = hyperVGeneration;
            PurchasePlan = purchasePlan;
            SupportedCapabilities = supportedCapabilities;
            CreationData = creationData;
            DiskSizeGB = diskSizeGB;
            DiskSizeBytes = diskSizeBytes;
            DiskState = diskState;
            UniqueId = uniqueId;
            EncryptionSettingsCollection = encryptionSettingsCollection;
            ProvisioningState = provisioningState;
            Incremental = incremental;
            Encryption = encryption;
            NetworkAccessPolicy = networkAccessPolicy;
            DiskAccessId = diskAccessId;
            SecurityProfile = securityProfile;
            SupportsHibernation = supportsHibernation;
            PublicNetworkAccess = publicNetworkAccess;
            CompletionPercent = completionPercent;
            DataAccessAuthMode = dataAccessAuthMode;
            CustomInit();
        }

        public Snapshot(string location, CreationData creationData, string id , string name , string type , IDictionary<string, string> tags , string managedBy , SnapshotSku sku , ExtendedLocation extendedLocation , System.DateTime? timeCreated , OperatingSystemTypes? osType , string hyperVGeneration , PurchasePlan purchasePlan , SupportedCapabilities supportedCapabilities , int? diskSizeGB , long? diskSizeBytes , string diskState , string uniqueId , EncryptionSettingsCollection encryptionSettingsCollection , string provisioningState , bool? incremental , Encryption encryption , string networkAccessPolicy = default(string), string diskAccessId = default(string), DiskSecurityProfile securityProfile = default(DiskSecurityProfile), bool? supportsHibernation = default(bool?), string publicNetworkAccess = default(string), double? completionPercent = default(double?), CopyCompletionError copyCompletionError = default(CopyCompletionError), string dataAccessAuthMode = default(string))
    : base(location, id, name, type, tags)
        {
            ManagedBy = managedBy;
            Sku = sku;
            ExtendedLocation = extendedLocation;
            TimeCreated = timeCreated;
            OsType = osType;
            HyperVGeneration = hyperVGeneration;
            PurchasePlan = purchasePlan;
            SupportedCapabilities = supportedCapabilities;
            CreationData = creationData;
            DiskSizeGB = diskSizeGB;
            DiskSizeBytes = diskSizeBytes;
            DiskState = diskState;
            UniqueId = uniqueId;
            EncryptionSettingsCollection = encryptionSettingsCollection;
            ProvisioningState = provisioningState;
            Incremental = incremental;
            Encryption = encryption;
            NetworkAccessPolicy = networkAccessPolicy;
            DiskAccessId = diskAccessId;
            SecurityProfile = securityProfile;
            SupportsHibernation = supportsHibernation;
            PublicNetworkAccess = publicNetworkAccess;
            CompletionPercent = completionPercent;
            CopyCompletionError = copyCompletionError;
            DataAccessAuthMode = dataAccessAuthMode;
            CustomInit();
        }
    }
}
