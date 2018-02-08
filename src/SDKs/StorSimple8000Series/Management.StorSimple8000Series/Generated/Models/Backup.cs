
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The backup.
    /// </summary>
    [JsonTransformation]
    public partial class Backup : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the Backup class.
        /// </summary>
        public Backup() { }

        /// <summary>
        /// Initializes a new instance of the Backup class.
        /// </summary>
        /// <param name="createdOn">The time when the backup was
        /// created.</param>
        /// <param name="sizeInBytes">The backup size in bytes.</param>
        /// <param name="elements">The backup elements.</param>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        /// <param name="backupType">The type of the backup. Possible values
        /// include: 'LocalSnapshot', 'CloudSnapshot'</param>
        /// <param name="backupJobCreationType">The backup job creation type.
        /// Possible values include: 'Adhoc', 'BySchedule', 'BySSM'</param>
        /// <param name="backupPolicyId">The path ID of the backup
        /// policy.</param>
        /// <param name="ssmHostName">The StorSimple Snapshot Manager host
        /// name.</param>
        public Backup(System.DateTime createdOn, long sizeInBytes, IList<BackupElement> elements, string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?), BackupType? backupType = default(BackupType?), BackupJobCreationType? backupJobCreationType = default(BackupJobCreationType?), string backupPolicyId = default(string), string ssmHostName = default(string))
            : base(id, name, type, kind)
        {
            CreatedOn = createdOn;
            SizeInBytes = sizeInBytes;
            BackupType = backupType;
            BackupJobCreationType = backupJobCreationType;
            BackupPolicyId = backupPolicyId;
            SsmHostName = ssmHostName;
            Elements = elements;
        }

        /// <summary>
        /// Gets or sets the time when the backup was created.
        /// </summary>
        [JsonProperty(PropertyName = "properties.createdOn")]
        public System.DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the backup size in bytes.
        /// </summary>
        [JsonProperty(PropertyName = "properties.sizeInBytes")]
        public long SizeInBytes { get; set; }

        /// <summary>
        /// Gets or sets the type of the backup. Possible values include:
        /// 'LocalSnapshot', 'CloudSnapshot'
        /// </summary>
        [JsonProperty(PropertyName = "properties.backupType")]
        public BackupType? BackupType { get; set; }

        /// <summary>
        /// Gets or sets the backup job creation type. Possible values include:
        /// 'Adhoc', 'BySchedule', 'BySSM'
        /// </summary>
        [JsonProperty(PropertyName = "properties.backupJobCreationType")]
        public BackupJobCreationType? BackupJobCreationType { get; set; }

        /// <summary>
        /// Gets or sets the path ID of the backup policy.
        /// </summary>
        [JsonProperty(PropertyName = "properties.backupPolicyId")]
        public string BackupPolicyId { get; set; }

        /// <summary>
        /// Gets or sets the StorSimple Snapshot Manager host name.
        /// </summary>
        [JsonProperty(PropertyName = "properties.ssmHostName")]
        public string SsmHostName { get; set; }

        /// <summary>
        /// Gets or sets the backup elements.
        /// </summary>
        [JsonProperty(PropertyName = "properties.elements")]
        public IList<BackupElement> Elements { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Elements == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Elements");
            }
            if (Elements != null)
            {
                foreach (var element in Elements)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}

