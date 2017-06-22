
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The OData filters to be used for backups.
    /// </summary>
    public partial class BackupFilter
    {
        /// <summary>
        /// Initializes a new instance of the BackupFilter class.
        /// </summary>
        public BackupFilter() { }

        /// <summary>
        /// Initializes a new instance of the BackupFilter class.
        /// </summary>
        /// <param name="backupPolicyId">Specifies the backupPolicyId of the
        /// backups to be filtered. Only 'Equality' operator is supported for
        /// this property.</param>
        /// <param name="volumeId">Specifies the volumeId of the backups to be
        /// filtered. Only 'Equality' operator is supported for this
        /// property.</param>
        /// <param name="createdTime">Specifies the creation time of the
        /// backups to be filtered. Only 'Greater Than or Equal To' and 'Lesser
        /// Than or Equal To' operators are supported for this
        /// property.</param>
        public BackupFilter(string backupPolicyId = default(string), string volumeId = default(string), System.DateTime? createdTime = default(System.DateTime?))
        {
            BackupPolicyId = backupPolicyId;
            VolumeId = volumeId;
            CreatedTime = createdTime;
        }

        /// <summary>
        /// Gets or sets specifies the backupPolicyId of the backups to be
        /// filtered. Only 'Equality' operator is supported for this property.
        /// </summary>
        [JsonProperty(PropertyName = "backupPolicyId")]
        public string BackupPolicyId { get; set; }

        /// <summary>
        /// Gets or sets specifies the volumeId of the backups to be filtered.
        /// Only 'Equality' operator is supported for this property.
        /// </summary>
        [JsonProperty(PropertyName = "volumeId")]
        public string VolumeId { get; set; }

        /// <summary>
        /// Gets or sets specifies the creation time of the backups to be
        /// filtered. Only 'Greater Than or Equal To' and 'Lesser Than or Equal
        /// To' operators are supported for this property.
        /// </summary>
        [JsonProperty(PropertyName = "createdTime")]
        public System.DateTime? CreatedTime { get; set; }

    }
}

