
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The volume container.
    /// </summary>
    [JsonTransformation]
    public partial class VolumeContainer : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the VolumeContainer class.
        /// </summary>
        public VolumeContainer() { }

        /// <summary>
        /// Initializes a new instance of the VolumeContainer class.
        /// </summary>
        /// <param name="storageAccountCredentialId">The path ID of storage
        /// account associated with the volume container.</param>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        /// <param name="encryptionKey">The key used to encrypt data in the
        /// volume container. It is required when property 'EncryptionStatus'
        /// is "Enabled".</param>
        /// <param name="encryptionStatus">The flag to denote whether
        /// encryption is enabled or not. Possible values include: 'Enabled',
        /// 'Disabled'</param>
        /// <param name="volumeCount">The number of volumes in the volume
        /// Container.</param>
        /// <param name="ownerShipStatus">The owner ship status of the volume
        /// container. Only when the status is "NotOwned", the delete operation
        /// on the volume container is permitted. Possible values include:
        /// 'Owned', 'NotOwned'</param>
        /// <param name="bandWidthRateInMbps">The bandwidth-rate set on the
        /// volume container.</param>
        /// <param name="bandwidthSettingId">The ID of the bandwidth setting
        /// associated with the volume container.</param>
        /// <param name="totalCloudStorageUsageInBytes">The total cloud storage
        /// for the volume container.</param>
        public VolumeContainer(string storageAccountCredentialId, string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?), AsymmetricEncryptedSecret encryptionKey = default(AsymmetricEncryptedSecret), EncryptionStatus? encryptionStatus = default(EncryptionStatus?), int? volumeCount = default(int?), OwnerShipStatus? ownerShipStatus = default(OwnerShipStatus?), int? bandWidthRateInMbps = default(int?), string bandwidthSettingId = default(string), long? totalCloudStorageUsageInBytes = default(long?))
            : base(id, name, type, kind)
        {
            EncryptionKey = encryptionKey;
            EncryptionStatus = encryptionStatus;
            VolumeCount = volumeCount;
            StorageAccountCredentialId = storageAccountCredentialId;
            OwnerShipStatus = ownerShipStatus;
            BandWidthRateInMbps = bandWidthRateInMbps;
            BandwidthSettingId = bandwidthSettingId;
            TotalCloudStorageUsageInBytes = totalCloudStorageUsageInBytes;
        }

        /// <summary>
        /// Gets or sets the key used to encrypt data in the volume container.
        /// It is required when property 'EncryptionStatus' is "Enabled".
        /// </summary>
        [JsonProperty(PropertyName = "properties.encryptionKey")]
        public AsymmetricEncryptedSecret EncryptionKey { get; set; }

        /// <summary>
        /// Gets the flag to denote whether encryption is enabled or not.
        /// Possible values include: 'Enabled', 'Disabled'
        /// </summary>
        [JsonProperty(PropertyName = "properties.encryptionStatus")]
        public EncryptionStatus? EncryptionStatus { get; protected set; }

        /// <summary>
        /// Gets the number of volumes in the volume Container.
        /// </summary>
        [JsonProperty(PropertyName = "properties.volumeCount")]
        public int? VolumeCount { get; protected set; }

        /// <summary>
        /// Gets or sets the path ID of storage account associated with the
        /// volume container.
        /// </summary>
        [JsonProperty(PropertyName = "properties.storageAccountCredentialId")]
        public string StorageAccountCredentialId { get; set; }

        /// <summary>
        /// Gets the owner ship status of the volume container. Only when the
        /// status is "NotOwned", the delete operation on the volume container
        /// is permitted. Possible values include: 'Owned', 'NotOwned'
        /// </summary>
        [JsonProperty(PropertyName = "properties.ownerShipStatus")]
        public OwnerShipStatus? OwnerShipStatus { get; protected set; }

        /// <summary>
        /// Gets or sets the bandwidth-rate set on the volume container.
        /// </summary>
        [JsonProperty(PropertyName = "properties.bandWidthRateInMbps")]
        public int? BandWidthRateInMbps { get; set; }

        /// <summary>
        /// Gets or sets the ID of the bandwidth setting associated with the
        /// volume container.
        /// </summary>
        [JsonProperty(PropertyName = "properties.bandwidthSettingId")]
        public string BandwidthSettingId { get; set; }

        /// <summary>
        /// Gets the total cloud storage for the volume container.
        /// </summary>
        [JsonProperty(PropertyName = "properties.totalCloudStorageUsageInBytes")]
        public long? TotalCloudStorageUsageInBytes { get; protected set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (StorageAccountCredentialId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "StorageAccountCredentialId");
            }
            if (EncryptionKey != null)
            {
                EncryptionKey.Validate();
            }
        }
    }
}

