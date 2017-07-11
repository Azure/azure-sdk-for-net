
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
    /// The backup policy.
    /// </summary>
    [JsonTransformation]
    public partial class BackupPolicy : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the BackupPolicy class.
        /// </summary>
        public BackupPolicy() { }

        /// <summary>
        /// Initializes a new instance of the BackupPolicy class.
        /// </summary>
        /// <param name="volumeIds">The path IDs of the volumes which are part
        /// of the backup policy.</param>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        /// <param name="nextBackupTime">The time of the next backup for the
        /// backup policy.</param>
        /// <param name="lastBackupTime">The time of the last backup for the
        /// backup policy.</param>
        /// <param name="schedulesCount">The count of schedules the backup
        /// policy contains.</param>
        /// <param name="scheduledBackupStatus">Indicates whether atleast one
        /// of the schedules in the backup policy is active or not. Possible
        /// values include: 'Disabled', 'Enabled'</param>
        /// <param name="backupPolicyCreationType">The backup policy creation
        /// type. Indicates whether this was created through SaaS or through
        /// StorSimple Snapshot Manager. Possible values include: 'BySaaS',
        /// 'BySSM'</param>
        /// <param name="ssmHostName">If the backup policy was created by
        /// StorSimple Snapshot Manager, then this field indicates the hostname
        /// of the StorSimple Snapshot Manager.</param>
        public BackupPolicy(IList<string> volumeIds, string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?), System.DateTime? nextBackupTime = default(System.DateTime?), System.DateTime? lastBackupTime = default(System.DateTime?), long? schedulesCount = default(long?), ScheduledBackupStatus? scheduledBackupStatus = default(ScheduledBackupStatus?), BackupPolicyCreationType? backupPolicyCreationType = default(BackupPolicyCreationType?), string ssmHostName = default(string))
            : base(id, name, type, kind)
        {
            VolumeIds = volumeIds;
            NextBackupTime = nextBackupTime;
            LastBackupTime = lastBackupTime;
            SchedulesCount = schedulesCount;
            ScheduledBackupStatus = scheduledBackupStatus;
            BackupPolicyCreationType = backupPolicyCreationType;
            SsmHostName = ssmHostName;
        }

        /// <summary>
        /// Gets or sets the path IDs of the volumes which are part of the
        /// backup policy.
        /// </summary>
        [JsonProperty(PropertyName = "properties.volumeIds")]
        public IList<string> VolumeIds { get; set; }

        /// <summary>
        /// Gets the time of the next backup for the backup policy.
        /// </summary>
        [JsonProperty(PropertyName = "properties.nextBackupTime")]
        public System.DateTime? NextBackupTime { get; protected set; }

        /// <summary>
        /// Gets the time of the last backup for the backup policy.
        /// </summary>
        [JsonProperty(PropertyName = "properties.lastBackupTime")]
        public System.DateTime? LastBackupTime { get; protected set; }

        /// <summary>
        /// Gets the count of schedules the backup policy contains.
        /// </summary>
        [JsonProperty(PropertyName = "properties.schedulesCount")]
        public long? SchedulesCount { get; protected set; }

        /// <summary>
        /// Gets indicates whether atleast one of the schedules in the backup
        /// policy is active or not. Possible values include: 'Disabled',
        /// 'Enabled'
        /// </summary>
        [JsonProperty(PropertyName = "properties.scheduledBackupStatus")]
        public ScheduledBackupStatus? ScheduledBackupStatus { get; protected set; }

        /// <summary>
        /// Gets the backup policy creation type. Indicates whether this was
        /// created through SaaS or through StorSimple Snapshot Manager.
        /// Possible values include: 'BySaaS', 'BySSM'
        /// </summary>
        [JsonProperty(PropertyName = "properties.backupPolicyCreationType")]
        public BackupPolicyCreationType? BackupPolicyCreationType { get; protected set; }

        /// <summary>
        /// Gets if the backup policy was created by StorSimple Snapshot
        /// Manager, then this field indicates the hostname of the StorSimple
        /// Snapshot Manager.
        /// </summary>
        [JsonProperty(PropertyName = "properties.ssmHostName")]
        public string SsmHostName { get; protected set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (VolumeIds == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "VolumeIds");
            }
        }
    }
}

