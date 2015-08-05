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
    public partial class JobMaxRecurrence
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

    }
}
