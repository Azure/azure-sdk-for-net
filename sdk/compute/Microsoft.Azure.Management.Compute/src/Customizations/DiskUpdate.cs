namespace Microsoft.Azure.Management.Compute.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

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
        /// the OS disk</param>
        public DiskUpdate(OperatingSystemTypes? osType = default(OperatingSystemTypes?), int? diskSizeGB = default(int?), EncryptionSettingsCollection encryptionSettingsCollection = default(EncryptionSettingsCollection), long? diskIOPSReadWrite = default(long?), long? diskMBpsReadWrite = default(long?), long? diskIOPSReadOnly = default(long?), long? diskMBpsReadOnly = default(long?), int? maxShares = default(int?), Encryption encryption = default(Encryption), string networkAccessPolicy = default(string), string diskAccessId = default(string), string tier = default(string), bool? burstingEnabled = default(bool?), PurchasePlan purchasePlan = default(PurchasePlan))
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

        public DiskUpdate(OperatingSystemTypes? osType = default(OperatingSystemTypes?), int? diskSizeGB = default(int?), EncryptionSettingsCollection encryptionSettingsCollection = default(EncryptionSettingsCollection), long? diskIOPSReadWrite = default(long?), long? diskMBpsReadWrite = default(long?), long? diskIOPSReadOnly = default(long?), long? diskMBpsReadOnly = default(long?), int? maxShares = default(int?), Encryption encryption = default(Encryption), string networkAccessPolicy = default(string), string diskAccessId = default(string), string tier = default(string), bool? burstingEnabled = default(bool?), PurchasePlan purchasePlan = default(PurchasePlan), IDictionary<string, string> tags = default(IDictionary<string, string>))
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

        public DiskUpdate(OperatingSystemTypes? osType = default(OperatingSystemTypes?), int? diskSizeGB = default(int?), EncryptionSettingsCollection encryptionSettingsCollection = default(EncryptionSettingsCollection), long? diskIOPSReadWrite = default(long?), long? diskMBpsReadWrite = default(long?), long? diskIOPSReadOnly = default(long?), long? diskMBpsReadOnly = default(long?), int? maxShares = default(int?), Encryption encryption = default(Encryption), string networkAccessPolicy = default(string), string diskAccessId = default(string), string tier = default(string), bool? burstingEnabled = default(bool?), PurchasePlan purchasePlan = default(PurchasePlan), IDictionary<string, string> tags = default(IDictionary<string, string>), DiskSku sku = default(DiskSku))
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
    }
}
