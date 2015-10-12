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
    public partial class JobRecurrence
    {
        /// <summary>
        /// Gets or sets the frequency of recurrence (second, minute, hour,
        /// day, week, month). Possible values for this property include:
        /// 'Minute', 'Hour', 'Day', 'Week', 'Month'
        /// </summary>
        [JsonProperty(PropertyName = "frequency")]
        public RecurrenceFrequency? Frequency { get; set; }

        /// <summary>
        /// Gets or sets the interval between retries.
        /// </summary>
        [JsonProperty(PropertyName = "interval")]
        public int? Interval { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of times that the job should run.
        /// </summary>
        [JsonProperty(PropertyName = "count")]
        public int? Count { get; set; }

        /// <summary>
        /// Gets or sets the time at which the job will complete.
        /// </summary>
        [JsonProperty(PropertyName = "endTime")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "schedule")]
        public JobRecurrenceSchedule Schedule { get; set; }

    }
}
