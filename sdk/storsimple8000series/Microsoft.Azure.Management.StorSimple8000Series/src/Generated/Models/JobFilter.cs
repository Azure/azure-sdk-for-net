
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The OData filter to be used for jobs.
    /// </summary>
    public partial class JobFilter
    {
        /// <summary>
        /// Initializes a new instance of the JobFilter class.
        /// </summary>
        public JobFilter() { }

        /// <summary>
        /// Initializes a new instance of the JobFilter class.
        /// </summary>
        /// <param name="status">Specifies the status of the jobs to be
        /// filtered. For e.g., "Running", "Succeeded", "Failed" or "Canceled".
        /// Only 'Equality' operator is supported for this property.</param>
        /// <param name="jobType">Specifies the type of the jobs to be
        /// filtered. For e.g., "ScheduledBackup", "ManualBackup",
        /// "RestoreBackup", "CloneVolume", "FailoverVolumeContainers",
        /// "CreateLocallyPinnedVolume", "ModifyVolume", "InstallUpdates",
        /// "SupportPackageLogs", or "CreateCloudAppliance". Only 'Equality'
        /// operator can be used for this property.</param>
        /// <param name="startTime">Specifies the start time of the jobs to be
        /// filtered.  Only 'Greater Than or Equal To' and 'Lesser Than or
        /// Equal To' operators are supported for this property.</param>
        public JobFilter(string status = default(string), string jobType = default(string), System.DateTime? startTime = default(System.DateTime?))
        {
            Status = status;
            JobType = jobType;
            StartTime = startTime;
        }

        /// <summary>
        /// Gets or sets specifies the status of the jobs to be filtered. For
        /// e.g., "Running", "Succeeded", "Failed" or "Canceled". Only
        /// 'Equality' operator is supported for this property.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets specifies the type of the jobs to be filtered. For
        /// e.g., "ScheduledBackup", "ManualBackup", "RestoreBackup",
        /// "CloneVolume", "FailoverVolumeContainers",
        /// "CreateLocallyPinnedVolume", "ModifyVolume", "InstallUpdates",
        /// "SupportPackageLogs", or "CreateCloudAppliance". Only 'Equality'
        /// operator can be used for this property.
        /// </summary>
        [JsonProperty(PropertyName = "jobType")]
        public string JobType { get; set; }

        /// <summary>
        /// Gets or sets specifies the start time of the jobs to be filtered.
        /// Only 'Greater Than or Equal To' and 'Lesser Than or Equal To'
        /// operators are supported for this property.
        /// </summary>
        [JsonProperty(PropertyName = "startTime")]
        public System.DateTime? StartTime { get; set; }

    }
}

