namespace Microsoft.Azure.Management.Compute.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Disk resource.
    /// </summary>
    public partial class Disk : Resource
    {
        /// <summary>
        /// Initializes a new instance of the Disk class.
        /// </summary>
        /// <param name="location">Resource location</param>
        /// <param name="creationData">Disk source information. CreationData
        /// information cannot be changed after the disk has been
        /// created.</param>
        /// <param name="id">Resource Id</param>
        /// <param name="name">Resource name</param>
        /// <param name="type">Resource type</param>
        /// <param name="tags">Resource tags</param>
        /// <param name="managedBy">A relative URI containing the ID of the VM
        /// that has the disk attached.</param>
        /// <param name="managedByExtended">List of relative URIs containing
        /// the IDs of the VMs that have the disk attached. maxShares should be
        /// set to a value greater than one for disks to allow attaching them
        /// to multiple VMs.</param>
        /// <param name="zones">The Logical zone list for Disk.</param>
        /// <param name="extendedLocation">The extended location where the disk
        /// will be created. Extended location cannot be changed.</param>
        /// <param name="timeCreated">The time when the disk was
        /// created.</param>
        /// <param name="osType">The Operating System type. Possible values
        /// include: 'Windows', 'Linux'</param>
        /// <param name="hyperVGeneration">The hypervisor generation of the
        /// Virtual Machine. Applicable to OS disks only. Possible values
        /// include: 'V1', 'V2'</param>
        /// <param name="purchasePlan">Purchase plan information for the the
        /// image from which the OS disk was created. E.g. - {name:
        /// 2019-Datacenter, publisher: MicrosoftWindowsServer, product:
        /// WindowsServer}</param>
        /// <param name="diskSizeGB">If creationData.createOption is Empty,
        /// this field is mandatory and it indicates the size of the disk to
        /// create. If this field is present for updates or creation with other
        /// options, it indicates a resize. Resizes are only allowed if the
        /// disk is not attached to a running VM, and can only increase the
        /// disk's size.</param>
        /// <param name="diskSizeBytes">The size of the disk in bytes. This
        /// field is read only.</param>
        /// <param name="uniqueId">Unique Guid identifying the
        /// resource.</param>
        /// <param name="encryptionSettingsCollection">Encryption settings
        /// collection used for Azure Disk Encryption, can contain multiple
        /// encryption settings per disk or snapshot.</param>
        /// <param name="provisioningState">The disk provisioning
        /// state.</param>
        /// <param name="diskIOPSReadWrite">The number of IOPS allowed for this
        /// disk; only settable for UltraSSD disks. One operation can transfer
        /// between 4k and 256k bytes.</param>
        /// <param name="diskMBpsReadWrite">The bandwidth allowed for this
        /// disk; only settable for UltraSSD disks. MBps means millions of
        /// bytes per second - MB here uses the ISO notation, of powers of
        /// 10.</param>
        /// <param name="diskIOPSReadOnly">The total number of IOPS that will
        /// be allowed across all VMs mounting the shared disk as ReadOnly. One
        /// operation can transfer between 4k and 256k bytes.</param>
        /// <param name="diskMBpsReadOnly">The total throughput (MBps) that
        /// will be allowed across all VMs mounting the shared disk as
        /// ReadOnly. MBps means millions of bytes per second - MB here uses
        /// the ISO notation, of powers of 10.</param>
        /// <param name="diskState">The state of the disk. Possible values
        /// include: 'Unattached', 'Attached', 'Reserved', 'Frozen',
        /// 'ActiveSAS', 'ActiveSASFrozen', 'ReadyToUpload',
        /// 'ActiveUpload'</param>
        /// <param name="encryption">Encryption property can be used to encrypt
        /// data at rest with customer managed keys or platform managed
        /// keys.</param>
        /// <param name="maxShares">The maximum number of VMs that can attach
        /// to the disk at the same time. Value greater than one indicates a
        /// disk that can be mounted on multiple VMs at the same time.</param>
        /// <param name="shareInfo">Details of the list of all VMs that have
        /// the disk attached. maxShares should be set to a value greater than
        /// one for disks to allow attaching them to multiple VMs.</param>
        /// <param name="networkAccessPolicy">Possible values include:
        /// 'AllowAll', 'AllowPrivate', 'DenyAll'</param>
        /// <param name="diskAccessId">ARM id of the DiskAccess resource for
        /// using private endpoints on disks.</param>
        /// <param name="tier">Performance tier of the disk (e.g, P4, S10) as
        /// described here:
        /// https://azure.microsoft.com/en-us/pricing/details/managed-disks/.
        /// Does not apply to Ultra disks.</param>
        /// <param name="burstingEnabled">Set to true to enable bursting beyond
        /// the provisioned performance target of the disk. Bursting is
        /// disabled by default. Does not apply to Ultra disks.</param>
        /// <param name="propertyUpdatesInProgress">Properties of the disk for
        /// which update is pending.</param>
        /// <param name="supportsHibernation">Indicates the OS on a disk
        /// supports hibernation.</param>
        /// <param name="securityProfile">Contains the security related
        /// information for the resource.</param>
        /// <param name="supportedCapabilities">List of supported capabilities
        /// for the image from which the OS disk was created.</param>
        /// <param name="completionPercent">Percentage complete for the
        /// background copy when a resource is created via the CopyStart
        /// operation.</param>
        /// <param name="publicNetworkAccess">Possible values include:
        /// 'Enabled', 'Disabled'</param>
        public Disk(string location, CreationData creationData, string id, string name, string type, IDictionary<string, string> tags, string managedBy, IList<string> managedByExtended, DiskSku sku, IList<string> zones, ExtendedLocation extendedLocation, System.DateTime? timeCreated, OperatingSystemTypes? osType, string hyperVGeneration, PurchasePlan purchasePlan, int? diskSizeGB, long? diskSizeBytes = default(long?), string uniqueId = default(string), EncryptionSettingsCollection encryptionSettingsCollection = default(EncryptionSettingsCollection), string provisioningState = default(string), long? diskIOPSReadWrite = default(long?), long? diskMBpsReadWrite = default(long?), long? diskIOPSReadOnly = default(long?), long? diskMBpsReadOnly = default(long?), string diskState = default(string), Encryption encryption = default(Encryption), int? maxShares = default(int?), IList<ShareInfoElement> shareInfo = default(IList<ShareInfoElement>), string networkAccessPolicy = default(string), string diskAccessId = default(string), string tier = default(string), bool? burstingEnabled = default(bool?), PropertyUpdatesInProgress propertyUpdatesInProgress = default(PropertyUpdatesInProgress), bool? supportsHibernation = default(bool?), DiskSecurityProfile securityProfile = default(DiskSecurityProfile))
                    : base(location, id, name, type, tags)
        {
            ManagedBy = managedBy;
            ManagedByExtended = managedByExtended;
            Sku = sku;
            Zones = zones;
            ExtendedLocation = extendedLocation;
            TimeCreated = timeCreated;
            OsType = osType;
            HyperVGeneration = hyperVGeneration;
            PurchasePlan = purchasePlan;
            CreationData = creationData;
            DiskSizeGB = diskSizeGB;
            DiskSizeBytes = diskSizeBytes;
            UniqueId = uniqueId;
            EncryptionSettingsCollection = encryptionSettingsCollection;
            ProvisioningState = provisioningState;
            DiskIOPSReadWrite = diskIOPSReadWrite;
            DiskMBpsReadWrite = diskMBpsReadWrite;
            DiskIOPSReadOnly = diskIOPSReadOnly;
            DiskMBpsReadOnly = diskMBpsReadOnly;
            DiskState = diskState;
            Encryption = encryption;
            MaxShares = maxShares;
            ShareInfo = shareInfo;
            NetworkAccessPolicy = networkAccessPolicy;
            DiskAccessId = diskAccessId;
            Tier = tier;
            BurstingEnabled = burstingEnabled;
            PropertyUpdatesInProgress = propertyUpdatesInProgress;
            SupportsHibernation = supportsHibernation;
            SecurityProfile = securityProfile;
            CustomInit();
        }

        public Disk(string location, CreationData creationData, string id, string name, string type, IDictionary<string, string> tags, string managedBy, IList<string> managedByExtended, DiskSku sku, IList<string> zones, ExtendedLocation extendedLocation, System.DateTime? timeCreated, OperatingSystemTypes? osType, string hyperVGeneration, PurchasePlan purchasePlan, SupportedCapabilities supportedCapabilities, int? diskSizeGB, long? diskSizeBytes, string uniqueId, EncryptionSettingsCollection encryptionSettingsCollection, string provisioningState, long? diskIOPSReadWrite, long? diskMBpsReadWrite, long? diskIOPSReadOnly, long? diskMBpsReadOnly, string diskState, Encryption encryption, int? maxShares, IList<ShareInfoElement> shareInfo, string networkAccessPolicy, string diskAccessId, string tier, bool? burstingEnabled = default(bool?), PropertyUpdatesInProgress propertyUpdatesInProgress = default(PropertyUpdatesInProgress), bool? supportsHibernation = default(bool?), DiskSecurityProfile securityProfile = default(DiskSecurityProfile), double? completionPercent = default(double?), string publicNetworkAccess = default(string), string dataAccessAuthMode = default(string), bool? optimizedForFrequentAttach = default(bool?))
            : base(location, id, name, type, tags)
        {
            ManagedBy = managedBy;
            ManagedByExtended = managedByExtended;
            Sku = sku;
            Zones = zones;
            ExtendedLocation = extendedLocation;
            TimeCreated = timeCreated;
            OsType = osType;
            HyperVGeneration = hyperVGeneration;
            PurchasePlan = purchasePlan;
            SupportedCapabilities = supportedCapabilities;
            CreationData = creationData;
            DiskSizeGB = diskSizeGB;
            DiskSizeBytes = diskSizeBytes;
            UniqueId = uniqueId;
            EncryptionSettingsCollection = encryptionSettingsCollection;
            ProvisioningState = provisioningState;
            DiskIOPSReadWrite = diskIOPSReadWrite;
            DiskMBpsReadWrite = diskMBpsReadWrite;
            DiskIOPSReadOnly = diskIOPSReadOnly;
            DiskMBpsReadOnly = diskMBpsReadOnly;
            DiskState = diskState;
            Encryption = encryption;
            MaxShares = maxShares;
            ShareInfo = shareInfo;
            NetworkAccessPolicy = networkAccessPolicy;
            DiskAccessId = diskAccessId;
            Tier = tier;
            BurstingEnabled = burstingEnabled;
            PropertyUpdatesInProgress = propertyUpdatesInProgress;
            SupportsHibernation = supportsHibernation;
            SecurityProfile = securityProfile;
            CompletionPercent = completionPercent;
            PublicNetworkAccess = publicNetworkAccess;
            DataAccessAuthMode = dataAccessAuthMode;
            OptimizedForFrequentAttach = optimizedForFrequentAttach;
            CustomInit();
        }
    }
}