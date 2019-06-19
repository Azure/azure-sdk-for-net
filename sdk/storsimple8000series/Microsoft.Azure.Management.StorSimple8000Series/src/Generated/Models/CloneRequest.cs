
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The clone job request.
    /// </summary>
    public partial class CloneRequest
    {
        /// <summary>
        /// Initializes a new instance of the CloneRequest class.
        /// </summary>
        public CloneRequest() { }

        /// <summary>
        /// Initializes a new instance of the CloneRequest class.
        /// </summary>
        /// <param name="targetDeviceId">The path ID of the device which will
        /// act as the clone target.</param>
        /// <param name="targetVolumeName">The name of the new volume which
        /// will be created and the backup will be cloned into.</param>
        /// <param name="targetAccessControlRecordIds">The list of path IDs of
        /// the access control records to be associated to the new cloned
        /// volume.</param>
        /// <param name="backupElement">The backup element that is
        /// cloned.</param>
        public CloneRequest(string targetDeviceId, string targetVolumeName, IList<string> targetAccessControlRecordIds, BackupElement backupElement)
        {
            TargetDeviceId = targetDeviceId;
            TargetVolumeName = targetVolumeName;
            TargetAccessControlRecordIds = targetAccessControlRecordIds;
            BackupElement = backupElement;
        }

        /// <summary>
        /// Gets or sets the path ID of the device which will act as the clone
        /// target.
        /// </summary>
        [JsonProperty(PropertyName = "targetDeviceId")]
        public string TargetDeviceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the new volume which will be created and
        /// the backup will be cloned into.
        /// </summary>
        [JsonProperty(PropertyName = "targetVolumeName")]
        public string TargetVolumeName { get; set; }

        /// <summary>
        /// Gets or sets the list of path IDs of the access control records to
        /// be associated to the new cloned volume.
        /// </summary>
        [JsonProperty(PropertyName = "targetAccessControlRecordIds")]
        public IList<string> TargetAccessControlRecordIds { get; set; }

        /// <summary>
        /// Gets or sets the backup element that is cloned.
        /// </summary>
        [JsonProperty(PropertyName = "backupElement")]
        public BackupElement BackupElement { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (TargetDeviceId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "TargetDeviceId");
            }
            if (TargetVolumeName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "TargetVolumeName");
            }
            if (TargetAccessControlRecordIds == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "TargetAccessControlRecordIds");
            }
            if (BackupElement == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "BackupElement");
            }
            if (BackupElement != null)
            {
                BackupElement.Validate();
            }
        }
    }
}

