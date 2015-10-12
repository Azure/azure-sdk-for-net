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
    public partial class JobRecurrenceScheduleMonthlyOccurrence
    {
        /// <summary>
        /// Gets or sets the day. Must be one of monday, tuesday, wednesday,
        /// thursday, friday, saturday, sunday. Possible values for this
        /// property include: 'Monday', 'Tuesday', 'Wednesday', 'Thursday',
        /// 'Friday', 'Saturday', 'Sunday'
        /// </summary>
        [JsonProperty(PropertyName = "day")]
        public JobScheduleDay? Day { get; set; }

        /// <summary>
        /// Gets or sets the occurrence. Must be between -5 and 5.
        /// </summary>
        [JsonProperty(PropertyName = "Occurrence")]
        public int? Occurrence { get; set; }

    }
}
