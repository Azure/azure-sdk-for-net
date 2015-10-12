namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// </summary>
    public partial class JobHistoryDefinitionProperties
    {
        /// <summary>
        /// Gets the start time for this job.
        /// </summary>
        [JsonProperty(PropertyName = "startTime")]
        public DateTime? StartTime { get; private set; }

        /// <summary>
        /// Gets the end time for this job.
        /// </summary>
        [JsonProperty(PropertyName = "endTime")]
        public DateTime? EndTime { get; private set; }

        /// <summary>
        /// Gets the expected execution time for this job.
        /// </summary>
        [JsonProperty(PropertyName = "expectedExecutionTime")]
        public DateTime? ExpectedExecutionTime { get; private set; }

        /// <summary>
        /// Gets the job history action name. Possible values for this
        /// property include: 'MainAction', 'ErrorAction'
        /// </summary>
        [JsonProperty(PropertyName = "actionName")]
        public JobHistoryActionName? ActionName { get; private set; }

        /// <summary>
        /// Gets the job history status. Possible values for this property
        /// include: 'Completed', 'Failed', 'Cancelled', 'CallbackNotFound',
        /// 'Postponed'
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public JobExecutionStatus? Status { get; private set; }

        /// <summary>
        /// Gets the message for the job history.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; private set; }

        /// <summary>
        /// Gets the retry count for job.
        /// </summary>
        [JsonProperty(PropertyName = "retryCount")]
        public int? RetryCount { get; private set; }

        /// <summary>
        /// Gets the repeat count for the job.
        /// </summary>
        [JsonProperty(PropertyName = "repeatCount")]
        public int? RepeatCount { get; private set; }

    }
}
