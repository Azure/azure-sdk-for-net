
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
    /// The job.
    /// </summary>
    [JsonTransformation]
    public partial class Job : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the Job class.
        /// </summary>
        public Job() { }

        /// <summary>
        /// Initializes a new instance of the Job class.
        /// </summary>
        /// <param name="status">The current status of the job. Possible values
        /// include: 'Running', 'Succeeded', 'Failed', 'Canceled'</param>
        /// <param name="percentComplete">The percentage of the job that is
        /// already complete.</param>
        /// <param name="jobType">The type of the job. Possible values include:
        /// 'ScheduledBackup', 'ManualBackup', 'RestoreBackup', 'CloneVolume',
        /// 'FailoverVolumeContainers', 'CreateLocallyPinnedVolume',
        /// 'ModifyVolume', 'InstallUpdates', 'SupportPackageLogs',
        /// 'CreateCloudAppliance'</param>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        /// <param name="startTime">The UTC time at which the job was
        /// started.</param>
        /// <param name="endTime">The UTC time at which the job
        /// completed.</param>
        /// <param name="error">The error details, if any, for the job.</param>
        /// <param name="dataStats">The data statistics properties of the
        /// job.</param>
        /// <param name="entityLabel">The entity identifier for which the job
        /// ran.</param>
        /// <param name="entityType">The entity type for which the job
        /// ran.</param>
        /// <param name="jobStages">The job stages.</param>
        /// <param name="deviceId">The device ID in which the job ran.</param>
        /// <param name="isCancellable">Represents whether the job is
        /// cancellable or not.</param>
        /// <param name="backupType">The backup type (CloudSnapshot |
        /// LocalSnapshot). Applicable only for backup jobs. Possible values
        /// include: 'LocalSnapshot', 'CloudSnapshot'</param>
        /// <param name="sourceDeviceId">The source device ID of the failover
        /// job.</param>
        /// <param name="backupPointInTime">The time of the backup used for the
        /// failover.</param>
        public Job(JobStatus status, int percentComplete, JobType jobType, string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?), System.DateTime? startTime = default(System.DateTime?), System.DateTime? endTime = default(System.DateTime?), JobErrorDetails error = default(JobErrorDetails), DataStatistics dataStats = default(DataStatistics), string entityLabel = default(string), string entityType = default(string), IList<JobStage> jobStages = default(IList<JobStage>), string deviceId = default(string), bool? isCancellable = default(bool?), BackupType? backupType = default(BackupType?), string sourceDeviceId = default(string), System.DateTime? backupPointInTime = default(System.DateTime?))
            : base(id, name, type, kind)
        {
            Status = status;
            StartTime = startTime;
            EndTime = endTime;
            PercentComplete = percentComplete;
            Error = error;
            JobType = jobType;
            DataStats = dataStats;
            EntityLabel = entityLabel;
            EntityType = entityType;
            JobStages = jobStages;
            DeviceId = deviceId;
            IsCancellable = isCancellable;
            BackupType = backupType;
            SourceDeviceId = sourceDeviceId;
            BackupPointInTime = backupPointInTime;
        }

        /// <summary>
        /// Gets or sets the current status of the job. Possible values
        /// include: 'Running', 'Succeeded', 'Failed', 'Canceled'
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public JobStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the UTC time at which the job was started.
        /// </summary>
        [JsonProperty(PropertyName = "startTime")]
        public System.DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the UTC time at which the job completed.
        /// </summary>
        [JsonProperty(PropertyName = "endTime")]
        public System.DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the percentage of the job that is already complete.
        /// </summary>
        [JsonProperty(PropertyName = "percentComplete")]
        public int PercentComplete { get; set; }

        /// <summary>
        /// Gets or sets the error details, if any, for the job.
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public JobErrorDetails Error { get; set; }

        /// <summary>
        /// Gets or sets the type of the job. Possible values include:
        /// 'ScheduledBackup', 'ManualBackup', 'RestoreBackup', 'CloneVolume',
        /// 'FailoverVolumeContainers', 'CreateLocallyPinnedVolume',
        /// 'ModifyVolume', 'InstallUpdates', 'SupportPackageLogs',
        /// 'CreateCloudAppliance'
        /// </summary>
        [JsonProperty(PropertyName = "properties.jobType")]
        public JobType JobType { get; set; }

        /// <summary>
        /// Gets or sets the data statistics properties of the job.
        /// </summary>
        [JsonProperty(PropertyName = "properties.dataStats")]
        public DataStatistics DataStats { get; set; }

        /// <summary>
        /// Gets or sets the entity identifier for which the job ran.
        /// </summary>
        [JsonProperty(PropertyName = "properties.entityLabel")]
        public string EntityLabel { get; set; }

        /// <summary>
        /// Gets or sets the entity type for which the job ran.
        /// </summary>
        [JsonProperty(PropertyName = "properties.entityType")]
        public string EntityType { get; set; }

        /// <summary>
        /// Gets or sets the job stages.
        /// </summary>
        [JsonProperty(PropertyName = "properties.jobStages")]
        public IList<JobStage> JobStages { get; set; }

        /// <summary>
        /// Gets or sets the device ID in which the job ran.
        /// </summary>
        [JsonProperty(PropertyName = "properties.deviceId")]
        public string DeviceId { get; set; }

        /// <summary>
        /// Gets or sets represents whether the job is cancellable or not.
        /// </summary>
        [JsonProperty(PropertyName = "properties.isCancellable")]
        public bool? IsCancellable { get; set; }

        /// <summary>
        /// Gets or sets the backup type (CloudSnapshot | LocalSnapshot).
        /// Applicable only for backup jobs. Possible values include:
        /// 'LocalSnapshot', 'CloudSnapshot'
        /// </summary>
        [JsonProperty(PropertyName = "properties.backupType")]
        public BackupType? BackupType { get; set; }

        /// <summary>
        /// Gets or sets the source device ID of the failover job.
        /// </summary>
        [JsonProperty(PropertyName = "properties.sourceDeviceId")]
        public string SourceDeviceId { get; set; }

        /// <summary>
        /// Gets or sets the time of the backup used for the failover.
        /// </summary>
        [JsonProperty(PropertyName = "properties.backupPointInTime")]
        public System.DateTime? BackupPointInTime { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Error != null)
            {
                Error.Validate();
            }
            if (JobStages != null)
            {
                foreach (var element in JobStages)
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

