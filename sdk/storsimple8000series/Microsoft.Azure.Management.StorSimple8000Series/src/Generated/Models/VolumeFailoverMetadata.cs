
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The metadata of a volume that has valid cloud snapshot.
    /// </summary>
    public partial class VolumeFailoverMetadata
    {
        /// <summary>
        /// Initializes a new instance of the VolumeFailoverMetadata class.
        /// </summary>
        public VolumeFailoverMetadata() { }

        /// <summary>
        /// Initializes a new instance of the VolumeFailoverMetadata class.
        /// </summary>
        /// <param name="volumeId">The path ID of the volume.</param>
        /// <param name="volumeType">The type of the volume. Possible values
        /// include: 'Tiered', 'Archival', 'LocallyPinned'</param>
        /// <param name="sizeInBytes">The size of the volume in bytes at the
        /// time the snapshot was taken.</param>
        /// <param name="backupCreatedDate">The date at which the snapshot was
        /// taken.</param>
        /// <param name="backupElementId">The path ID of the backup-element for
        /// this volume, inside the backup set.</param>
        /// <param name="backupId">The path ID of the backup set.</param>
        /// <param name="backupPolicyId">The path ID of the backup policy using
        /// which the snapshot was taken.</param>
        public VolumeFailoverMetadata(string volumeId = default(string), VolumeType? volumeType = default(VolumeType?), long? sizeInBytes = default(long?), System.DateTime? backupCreatedDate = default(System.DateTime?), string backupElementId = default(string), string backupId = default(string), string backupPolicyId = default(string))
        {
            VolumeId = volumeId;
            VolumeType = volumeType;
            SizeInBytes = sizeInBytes;
            BackupCreatedDate = backupCreatedDate;
            BackupElementId = backupElementId;
            BackupId = backupId;
            BackupPolicyId = backupPolicyId;
        }

        /// <summary>
        /// Gets or sets the path ID of the volume.
        /// </summary>
        [JsonProperty(PropertyName = "volumeId")]
        public string VolumeId { get; set; }

        /// <summary>
        /// Gets or sets the type of the volume. Possible values include:
        /// 'Tiered', 'Archival', 'LocallyPinned'
        /// </summary>
        [JsonProperty(PropertyName = "volumeType")]
        public VolumeType? VolumeType { get; set; }

        /// <summary>
        /// Gets or sets the size of the volume in bytes at the time the
        /// snapshot was taken.
        /// </summary>
        [JsonProperty(PropertyName = "sizeInBytes")]
        public long? SizeInBytes { get; set; }

        /// <summary>
        /// Gets or sets the date at which the snapshot was taken.
        /// </summary>
        [JsonProperty(PropertyName = "backupCreatedDate")]
        public System.DateTime? BackupCreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the path ID of the backup-element for this volume,
        /// inside the backup set.
        /// </summary>
        [JsonProperty(PropertyName = "backupElementId")]
        public string BackupElementId { get; set; }

        /// <summary>
        /// Gets or sets the path ID of the backup set.
        /// </summary>
        [JsonProperty(PropertyName = "backupId")]
        public string BackupId { get; set; }

        /// <summary>
        /// Gets or sets the path ID of the backup policy using which the
        /// snapshot was taken.
        /// </summary>
        [JsonProperty(PropertyName = "backupPolicyId")]
        public string BackupPolicyId { get; set; }

    }
}

