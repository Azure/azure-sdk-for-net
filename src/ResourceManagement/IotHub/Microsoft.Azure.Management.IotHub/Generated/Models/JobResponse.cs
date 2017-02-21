// MIT

namespace Microsoft.Azure.Management.IotHub.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The properties of the Job Response object.
    /// </summary>
    public partial class JobResponse
    {
        /// <summary>
        /// Initializes a new instance of the JobResponse class.
        /// </summary>
        public JobResponse() { }

        /// <summary>
        /// Initializes a new instance of the JobResponse class.
        /// </summary>
        public JobResponse(string jobId = default(string), DateTime? startTimeUtc = default(DateTime?), DateTime? endTimeUtc = default(DateTime?), string type = default(string), JobStatus? status = default(JobStatus?), string failureReason = default(string), string statusMessage = default(string), string parentJobId = default(string))
        {
            JobId = jobId;
            StartTimeUtc = startTimeUtc;
            EndTimeUtc = endTimeUtc;
            Type = type;
            Status = status;
            FailureReason = failureReason;
            StatusMessage = statusMessage;
            ParentJobId = parentJobId;
        }

        /// <summary>
        /// The job identifier.
        /// </summary>
        [JsonProperty(PropertyName = "jobId")]
        public string JobId { get; private set; }

        /// <summary>
        /// The start time of the Job.
        /// </summary>
        [JsonConverter(typeof(DateTimeRfc1123JsonConverter))]
        [JsonProperty(PropertyName = "startTimeUtc")]
        public DateTime? StartTimeUtc { get; private set; }

        /// <summary>
        /// The time the job stopped processing.
        /// </summary>
        [JsonConverter(typeof(DateTimeRfc1123JsonConverter))]
        [JsonProperty(PropertyName = "endTimeUtc")]
        public DateTime? EndTimeUtc { get; private set; }

        /// <summary>
        /// The type of the job. Possible values include: 'unknown', 'export',
        /// 'import', 'backup', 'readDeviceProperties',
        /// 'writeDeviceProperties', 'updateDeviceConfiguration',
        /// 'rebootDevice', 'factoryResetDevice', 'firmwareUpdate'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

        /// <summary>
        /// The status of the job. Possible values include: 'unknown',
        /// 'enqueued', 'running', 'completed', 'failed', 'cancelled'
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public JobStatus? Status { get; private set; }

        /// <summary>
        /// If status == failed, this string containing the reason for the
        /// failure.
        /// </summary>
        [JsonProperty(PropertyName = "failureReason")]
        public string FailureReason { get; private set; }

        /// <summary>
        /// The status message for the job.
        /// </summary>
        [JsonProperty(PropertyName = "statusMessage")]
        public string StatusMessage { get; private set; }

        /// <summary>
        /// The job identifier of the parent job, if any.
        /// </summary>
        [JsonProperty(PropertyName = "parentJobId")]
        public string ParentJobId { get; private set; }

    }
}
