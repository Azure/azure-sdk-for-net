
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class JobStatus
    {
        /// <summary>
        /// Initializes a new instance of the JobStatus class.
        /// </summary>
        public JobStatus() { }

        /// <summary>
        /// Initializes a new instance of the JobStatus class.
        /// </summary>
        public JobStatus(int? executionCount = default(int?), int? failureCount = default(int?), int? faultedCount = default(int?), DateTime? lastExecutionTime = default(DateTime?), DateTime? nextExecutionTime = default(DateTime?))
        {
            ExecutionCount = executionCount;
            FailureCount = failureCount;
            FaultedCount = faultedCount;
            LastExecutionTime = lastExecutionTime;
            NextExecutionTime = nextExecutionTime;
        }

        /// <summary>
        /// Gets the number of times this job has executed.
        /// </summary>
        [JsonProperty(PropertyName = "executionCount")]
        public int? ExecutionCount { get; private set; }

        /// <summary>
        /// Gets the number of times this job has failed.
        /// </summary>
        [JsonProperty(PropertyName = "failureCount")]
        public int? FailureCount { get; private set; }

        /// <summary>
        /// Gets the number of faulted occurrences (occurrences that were
        /// retried and failed as many times as the retry policy states).
        /// </summary>
        [JsonProperty(PropertyName = "faultedCount")]
        public int? FaultedCount { get; private set; }

        /// <summary>
        /// Gets the time the last occurrence executed in ISO-8601 format.
        /// Could be empty if job has not run yet.
        /// </summary>
        [JsonProperty(PropertyName = "lastExecutionTime")]
        public DateTime? LastExecutionTime { get; private set; }

        /// <summary>
        /// Gets the time of the next occurrence in ISO-8601 format. Could be
        /// empty if the job is completed.
        /// </summary>
        [JsonProperty(PropertyName = "nextExecutionTime")]
        public DateTime? NextExecutionTime { get; private set; }

    }
}
