
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class JobHistoryDefinitionProperties
    {
        /// <summary>
        /// Initializes a new instance of the JobHistoryDefinitionProperties
        /// class.
        /// </summary>
        public JobHistoryDefinitionProperties() { }

        /// <summary>
        /// Initializes a new instance of the JobHistoryDefinitionProperties
        /// class.
        /// </summary>
        public JobHistoryDefinitionProperties(DateTime? startTime = default(DateTime?), DateTime? endTime = default(DateTime?), DateTime? expectedExecutionTime = default(DateTime?), JobHistoryActionName? actionName = default(JobHistoryActionName?), JobExecutionStatus? status = default(JobExecutionStatus?), string message = default(string), int? retryCount = default(int?), int? repeatCount = default(int?))
        {
            StartTime = startTime;
            EndTime = endTime;
            ExpectedExecutionTime = expectedExecutionTime;
            ActionName = actionName;
            Status = status;
            Message = message;
            RetryCount = retryCount;
            RepeatCount = repeatCount;
        }

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
        /// Gets the job history action name. Possible values include:
        /// 'MainAction', 'ErrorAction'
        /// </summary>
        [JsonProperty(PropertyName = "actionName")]
        public JobHistoryActionName? ActionName { get; private set; }

        /// <summary>
        /// Gets the job history status. Possible values include: 'Completed',
        /// 'Failed', 'Postponed'
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
