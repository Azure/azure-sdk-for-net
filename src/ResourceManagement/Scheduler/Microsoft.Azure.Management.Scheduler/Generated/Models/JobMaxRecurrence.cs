
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class JobMaxRecurrence
    {
        /// <summary>
        /// Initializes a new instance of the JobMaxRecurrence class.
        /// </summary>
        public JobMaxRecurrence() { }

        /// <summary>
        /// Initializes a new instance of the JobMaxRecurrence class.
        /// </summary>
        public JobMaxRecurrence(RecurrenceFrequency? frequency = default(RecurrenceFrequency?), int? interval = default(int?))
        {
            Frequency = frequency;
            Interval = interval;
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

    }
}
