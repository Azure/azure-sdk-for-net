namespace Microsoft.Azure.Management.Compute.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Disk update resource.
    /// </summary>
    public partial class DiskUpdate
    {
        /// <summary>
        /// Initializes a new instance of the DiskUpdate class.
        /// </summary>
        /// <param name="osType">the Operating System type. Possible values
        /// include: 'Windows', 'Linux'</param>
        /// <param name="diskSizeGB">If creationData.createOption is Empty,
        /// this field is mandatory and it indicates the size of the disk to
        /// create. If this field is present for updates or creation with other
        /// options, it indicates a resize. Resizes are only allowed if the
        /// disk is not attached to a running VM, and can only increase the
        /// disk's size.</param>
        /// <param name="encryptionSettingsCollection">Encryption settings
        /// collection used be Azure Disk Encryption, can contain multiple
        /// encryption settings per disk or snapshot.</param>
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
        /// <param name="maxShares">The maximum number of VMs that can attach
        /// to the disk at the same time. Value greater than one indicates a
        /// disk that can be mounted on multiple VMs at the same time.</param>
        /// <param name="encryption">Encryption property can be used to encrypt
        /// data at rest with customer managed keys or platform managed
        /// keys.</param>
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
        /// <param name="purchasePlan">Purchase plan information to be added on
        public DiskUpdate(OperatingSystemTypes? osType, int? diskSizeGB, EncryptionSettingsCollection encryptionSettingsCollection, long? diskIOPSReadWrite, long? diskMBpsReadWrite, long? diskIOPSReadOnly, long? diskMBpsReadOnly, int? maxShares, Encryption encryption, string networkAccessPolicy, string diskAccessId, string tier, bool? burstingEnabled, PurchasePlan purchasePlan)
        {
            OsType = osType;
            DiskSizeGB = diskSizeGB;
            EncryptionSettingsCollection = encryptionSettingsCollection;
            DiskIOPSReadWrite = diskIOPSReadWrite;
            DiskMBpsReadWrite = diskMBpsReadWrite;
            DiskIOPSReadOnly = diskIOPSReadOnly;
            DiskMBpsReadOnly = diskMBpsReadOnly;
            MaxShares = maxShares;
            Encryption = encryption;
            NetworkAccessPolicy = networkAccessPolicy;
            DiskAccessId = diskAccessId;
            Tier = tier;
            BurstingEnabled = burstingEnabled;
            PurchasePlan = purchasePlan;
            CustomInit();
        }

        public DiskUpdate(OperatingSystemTypes? osType, int? diskSizeGB, EncryptionSettingsCollection encryptionSettingsCollection, long? diskIOPSReadWrite, long? diskMBpsReadWrite, long? diskIOPSReadOnly, long? diskMBpsReadOnly, int? maxShares, Encryption encryption, string networkAccessPolicy, string diskAccessId, string tier, bool? burstingEnabled, PurchasePlan purchasePlan, IDictionary<string, string> tags)
        {
            OsType = osType;
            DiskSizeGB = diskSizeGB;
            EncryptionSettingsCollection = encryptionSettingsCollection;
            DiskIOPSReadWrite = diskIOPSReadWrite;
            DiskMBpsReadWrite = diskMBpsReadWrite;
            DiskIOPSReadOnly = diskIOPSReadOnly;
            DiskMBpsReadOnly = diskMBpsReadOnly;
            MaxShares = maxShares;
            Encryption = encryption;
            NetworkAccessPolicy = networkAccessPolicy;
            DiskAccessId = diskAccessId;
            Tier = tier;
            BurstingEnabled = burstingEnabled;
            PurchasePlan = purchasePlan;
            Tags = tags;
            CustomInit();
        }

        public DiskUpdate(OperatingSystemTypes? osType, int? diskSizeGB, EncryptionSettingsCollection encryptionSettingsCollection, long? diskIOPSReadWrite, long? diskMBpsReadWrite, long? diskIOPSReadOnly, long? diskMBpsReadOnly, int? maxShares, Encryption encryption, string networkAccessPolicy, string diskAccessId, string tier, bool? burstingEnabled, PurchasePlan purchasePlan, IDictionary<string, string> tags, DiskSku sku)
        {
            OsType = osType;
            DiskSizeGB = diskSizeGB;
            EncryptionSettingsCollection = encryptionSettingsCollection;
            DiskIOPSReadWrite = diskIOPSReadWrite;
            DiskMBpsReadWrite = diskMBpsReadWrite;
            DiskIOPSReadOnly = diskIOPSReadOnly;
            DiskMBpsReadOnly = diskMBpsReadOnly;
            MaxShares = maxShares;
            Encryption = encryption;
            NetworkAccessPolicy = networkAccessPolicy;
            DiskAccessId = diskAccessId;
            Tier = tier;
            BurstingEnabled = burstingEnabled;
            PurchasePlan = purchasePlan;
            Tags = tags;
            Sku = sku;
            CustomInit();
        }

        public DiskUpdate(OperatingSystemTypes? osType, int? diskSizeGB, EncryptionSettingsCollection encryptionSettingsCollection, long? diskIOPSReadWrite, long? diskMBpsReadWrite, long? diskIOPSReadOnly, long? diskMBpsReadOnly, int? maxShares, Encryption encryption, string networkAccessPolicy, string diskAccessId, string tier, bool? burstingEnabled, PurchasePlan purchasePlan, PropertyUpdatesInProgress propertyUpdatesInProgress, bool? supportsHibernation = default(bool?), IDictionary<string, string> tags = default(IDictionary<string, string>), DiskSku sku = default(DiskSku))
        {
            OsType = osType;
            DiskSizeGB = diskSizeGB;
            EncryptionSettingsCollection = encryptionSettingsCollection;
            DiskIOPSReadWrite = diskIOPSReadWrite;
            DiskMBpsReadWrite = diskMBpsReadWrite;
            DiskIOPSReadOnly = diskIOPSReadOnly;
            DiskMBpsReadOnly = diskMBpsReadOnly;
            MaxShares = maxShares;
            Encryption = encryption;
            NetworkAccessPolicy = networkAccessPolicy;
            DiskAccessId = diskAccessId;
            Tier = tier;
            BurstingEnabled = burstingEnabled;
            PurchasePlan = purchasePlan;
            PropertyUpdatesInProgress = propertyUpdatesInProgress;
            SupportsHibernation = supportsHibernation;
            Tags = tags;
            Sku = sku;
            CustomInit();
        }

        public DiskUpdate(OperatingSystemTypes? osType, int? diskSizeGB, EncryptionSettingsCollection encryptionSettingsCollection,long? diskIOPSReadWrite, long? diskMBpsReadWrite, long? diskIOPSReadOnly, long? diskMBpsReadOnly, int? maxShares, Encryption encryption, string networkAccessPolicy, string diskAccessId, string tier, bool? burstingEnabled, PurchasePlan purchasePlan, SupportedCapabilities supportedCapabilities, PropertyUpdatesInProgress propertyUpdatesInProgress, bool? supportsHibernation, string publicNetworkAccess, IDictionary<string, string> tags, DiskSku sku = default(DiskSku))
        {
            OsType = osType;
            DiskSizeGB = diskSizeGB;
            EncryptionSettingsCollection = encryptionSettingsCollection;
            DiskIOPSReadWrite = diskIOPSReadWrite;
            DiskMBpsReadWrite = diskMBpsReadWrite;
            DiskIOPSReadOnly = diskIOPSReadOnly;
            DiskMBpsReadOnly = diskMBpsReadOnly;
            MaxShares = maxShares;
            Encryption = encryption;
            NetworkAccessPolicy = networkAccessPolicy;
            DiskAccessId = diskAccessId;
            Tier = tier;
            BurstingEnabled = burstingEnabled;
            PurchasePlan = purchasePlan;
            SupportedCapabilities = supportedCapabilities;
            PropertyUpdatesInProgress = propertyUpdatesInProgress;
            SupportsHibernation = supportsHibernation;
            PublicNetworkAccess = publicNetworkAccess;
            Tags = tags;
            Sku = sku;
            CustomInit();
        }

        public DiskUpdate(OperatingSystemTypes? osType , int? diskSizeGB , EncryptionSettingsCollection encryptionSettingsCollection , long? diskIOPSReadWrite , long? diskMBpsReadWrite , long? diskIOPSReadOnly , long? diskMBpsReadOnly , int? maxShares , Encryption encryption , string networkAccessPolicy , string diskAccessId , string tier , bool? burstingEnabled , PurchasePlan purchasePlan , SupportedCapabilities supportedCapabilities , PropertyUpdatesInProgress propertyUpdatesInProgress , bool? supportsHibernation , string publicNetworkAccess , string dataAccessAuthMode , IDictionary<string, string> tags , DiskSku sku = default(DiskSku))
        {
            OsType = osType;
            DiskSizeGB = diskSizeGB;
            EncryptionSettingsCollection = encryptionSettingsCollection;
            DiskIOPSReadWrite = diskIOPSReadWrite;
            DiskMBpsReadWrite = diskMBpsReadWrite;
            DiskIOPSReadOnly = diskIOPSReadOnly;
            DiskMBpsReadOnly = diskMBpsReadOnly;
            MaxShares = maxShares;
            Encryption = encryption;
            NetworkAccessPolicy = networkAccessPolicy;
            DiskAccessId = diskAccessId;
            Tier = tier;
            BurstingEnabled = burstingEnabled;
            PurchasePlan = purchasePlan;
            SupportedCapabilities = supportedCapabilities;
            PropertyUpdatesInProgress = propertyUpdatesInProgress;
            SupportsHibernation = supportsHibernation;
            PublicNetworkAccess = publicNetworkAccess;
            DataAccessAuthMode = dataAccessAuthMode;
            Tags = tags;
            Sku = sku;
            CustomInit();
        }
    }
}
