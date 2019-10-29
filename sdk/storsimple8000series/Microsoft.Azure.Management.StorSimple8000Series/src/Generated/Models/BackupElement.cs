
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The backup element.
    /// </summary>
    public partial class BackupElement
    {
        /// <summary>
        /// Initializes a new instance of the BackupElement class.
        /// </summary>
        public BackupElement() { }

        /// <summary>
        /// Initializes a new instance of the BackupElement class.
        /// </summary>
        /// <param name="elementId">The path ID that uniquely identifies the
        /// backup element.</param>
        /// <param name="elementName">The name of the backup element.</param>
        /// <param name="elementType">The hierarchical type of the backup
        /// element.</param>
        /// <param name="sizeInBytes">The size in bytes.</param>
        /// <param name="volumeName">The name of the volume.</param>
        /// <param name="volumeContainerId">The path ID of the volume
        /// container.</param>
        /// <param name="volumeType">The volume type. Possible values include:
        /// 'Tiered', 'Archival', 'LocallyPinned'</param>
        public BackupElement(string elementId, string elementName, string elementType, long sizeInBytes, string volumeName, string volumeContainerId, VolumeType? volumeType = default(VolumeType?))
        {
            ElementId = elementId;
            ElementName = elementName;
            ElementType = elementType;
            SizeInBytes = sizeInBytes;
            VolumeName = volumeName;
            VolumeContainerId = volumeContainerId;
            VolumeType = volumeType;
        }

        /// <summary>
        /// Gets or sets the path ID that uniquely identifies the backup
        /// element.
        /// </summary>
        [JsonProperty(PropertyName = "elementId")]
        public string ElementId { get; set; }

        /// <summary>
        /// Gets or sets the name of the backup element.
        /// </summary>
        [JsonProperty(PropertyName = "elementName")]
        public string ElementName { get; set; }

        /// <summary>
        /// Gets or sets the hierarchical type of the backup element.
        /// </summary>
        [JsonProperty(PropertyName = "elementType")]
        public string ElementType { get; set; }

        /// <summary>
        /// Gets or sets the size in bytes.
        /// </summary>
        [JsonProperty(PropertyName = "sizeInBytes")]
        public long SizeInBytes { get; set; }

        /// <summary>
        /// Gets or sets the name of the volume.
        /// </summary>
        [JsonProperty(PropertyName = "volumeName")]
        public string VolumeName { get; set; }

        /// <summary>
        /// Gets or sets the path ID of the volume container.
        /// </summary>
        [JsonProperty(PropertyName = "volumeContainerId")]
        public string VolumeContainerId { get; set; }

        /// <summary>
        /// Gets or sets the volume type. Possible values include: 'Tiered',
        /// 'Archival', 'LocallyPinned'
        /// </summary>
        [JsonProperty(PropertyName = "volumeType")]
        public VolumeType? VolumeType { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ElementId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ElementId");
            }
            if (ElementName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ElementName");
            }
            if (ElementType == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ElementType");
            }
            if (VolumeName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "VolumeName");
            }
            if (VolumeContainerId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "VolumeContainerId");
            }
        }
    }
}

