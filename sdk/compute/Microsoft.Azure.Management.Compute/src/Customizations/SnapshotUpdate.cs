namespace Microsoft.Azure.Management.Compute.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Snapshot update resource.
    /// </summary>
    public partial class SnapshotUpdate
    {
        /// <summary>
        /// Initializes a new instance of the SnapshotUpdate class.
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
        /// <param name="encryption">Encryption property can be used to encrypt
        /// data at rest with customer managed keys or platform managed
        /// keys.</param>
        /// <param name="networkAccessPolicy">Possible values include:
        /// 'AllowAll', 'AllowPrivate', 'DenyAll'</param>
        /// <param name="diskAccessId">ARM id of the DiskAccess resource for
        /// using private endpoints on disks.</param>
        public SnapshotUpdate(OperatingSystemTypes? osType = default(OperatingSystemTypes?), int? diskSizeGB = default(int?), EncryptionSettingsCollection encryptionSettingsCollection = default(EncryptionSettingsCollection), Encryption encryption = default(Encryption), string networkAccessPolicy = default(string), string diskAccessId = default(string))
        {
            OsType = osType;
            DiskSizeGB = diskSizeGB;
            EncryptionSettingsCollection = encryptionSettingsCollection;
            Encryption = encryption;
            NetworkAccessPolicy = networkAccessPolicy;
            DiskAccessId = diskAccessId;
            CustomInit();
        }

        public SnapshotUpdate(OperatingSystemTypes? osType = default(OperatingSystemTypes?), int? diskSizeGB = default(int?), EncryptionSettingsCollection encryptionSettingsCollection = default(EncryptionSettingsCollection), Encryption encryption = default(Encryption), string networkAccessPolicy = default(string), string diskAccessId = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>))
        {
            OsType = osType;
            DiskSizeGB = diskSizeGB;
            EncryptionSettingsCollection = encryptionSettingsCollection;
            Encryption = encryption;
            NetworkAccessPolicy = networkAccessPolicy;
            DiskAccessId = diskAccessId;
            Tags = tags;
            CustomInit();
        }

        public SnapshotUpdate(OperatingSystemTypes? osType = default(OperatingSystemTypes?), int? diskSizeGB = default(int?), EncryptionSettingsCollection encryptionSettingsCollection = default(EncryptionSettingsCollection), Encryption encryption = default(Encryption), string networkAccessPolicy = default(string), string diskAccessId = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), SnapshotSku sku = default(SnapshotSku))
        {
            OsType = osType;
            DiskSizeGB = diskSizeGB;
            EncryptionSettingsCollection = encryptionSettingsCollection;
            Encryption = encryption;
            NetworkAccessPolicy = networkAccessPolicy;
            DiskAccessId = diskAccessId;
            Tags = tags;
            Sku = sku;
            CustomInit();
        }
    }
}
