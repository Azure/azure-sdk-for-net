
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
    /// The backup schedule.
    /// </summary>
    [JsonTransformation]
    public partial class BackupSchedule : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the BackupSchedule class.
        /// </summary>
        public BackupSchedule() { }

        /// <summary>
        /// Initializes a new instance of the BackupSchedule class.
        /// </summary>
        /// <param name="scheduleRecurrence">The schedule recurrence.</param>
        /// <param name="backupType">The type of backup which needs to be
        /// taken. Possible values include: 'LocalSnapshot',
        /// 'CloudSnapshot'</param>
        /// <param name="retentionCount">The number of backups to be
        /// retained.</param>
        /// <param name="startTime">The start time of the schedule.</param>
        /// <param name="scheduleStatus">The schedule status. Possible values
        /// include: 'Enabled', 'Disabled'</param>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        /// <param name="lastSuccessfulRun">The last successful backup run
        /// which was triggered for the schedule.</param>
        public BackupSchedule(ScheduleRecurrence scheduleRecurrence, BackupType backupType, long retentionCount, System.DateTime startTime, ScheduleStatus scheduleStatus, string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?), System.DateTime? lastSuccessfulRun = default(System.DateTime?))
            : base(id, name, type, kind)
        {
            ScheduleRecurrence = scheduleRecurrence;
            BackupType = backupType;
            RetentionCount = retentionCount;
            StartTime = startTime;
            ScheduleStatus = scheduleStatus;
            LastSuccessfulRun = lastSuccessfulRun;
        }

        /// <summary>
        /// Gets or sets the schedule recurrence.
        /// </summary>
        [JsonProperty(PropertyName = "properties.scheduleRecurrence")]
        public ScheduleRecurrence ScheduleRecurrence { get; set; }

        /// <summary>
        /// Gets or sets the type of backup which needs to be taken. Possible
        /// values include: 'LocalSnapshot', 'CloudSnapshot'
        /// </summary>
        [JsonProperty(PropertyName = "properties.backupType")]
        public BackupType BackupType { get; set; }

        /// <summary>
        /// Gets or sets the number of backups to be retained.
        /// </summary>
        [JsonProperty(PropertyName = "properties.retentionCount")]
        public long RetentionCount { get; set; }

        /// <summary>
        /// Gets or sets the start time of the schedule.
        /// </summary>
        [JsonProperty(PropertyName = "properties.startTime")]
        public System.DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the schedule status. Possible values include:
        /// 'Enabled', 'Disabled'
        /// </summary>
        [JsonProperty(PropertyName = "properties.scheduleStatus")]
        public ScheduleStatus ScheduleStatus { get; set; }

        /// <summary>
        /// Gets the last successful backup run which was triggered for the
        /// schedule.
        /// </summary>
        [JsonProperty(PropertyName = "properties.lastSuccessfulRun")]
        public System.DateTime? LastSuccessfulRun { get; protected set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ScheduleRecurrence == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ScheduleRecurrence");
            }
            if (ScheduleRecurrence != null)
            {
                ScheduleRecurrence.Validate();
            }
        }
    }
}

