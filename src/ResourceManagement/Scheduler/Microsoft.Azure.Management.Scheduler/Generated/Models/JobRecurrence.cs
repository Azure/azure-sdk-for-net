
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class JobRecurrence
    {
        /// <summary>
        /// Initializes a new instance of the JobRecurrence class.
        /// </summary>
        public JobRecurrence() { }

        /// <summary>
        /// Initializes a new instance of the JobRecurrence class.
        /// </summary>
        public JobRecurrence(RecurrenceFrequency? frequency = default(RecurrenceFrequency?), int? interval = default(int?), int? count = default(int?), DateTime? endTime = default(DateTime?), JobRecurrenceSchedule schedule = default(JobRecurrenceSchedule))
        {
            Frequency = frequency;
            Interval = interval;
            Count = count;
            EndTime = endTime;
            Schedule = schedule;
        }

        /// <summary>
        /// Gets or sets the frequency of recurrence (second, minute, hour,
        /// day, week, month). Possible values include: 'Minute', 'Hour',
        /// 'Day', 'Week', 'Month'
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
