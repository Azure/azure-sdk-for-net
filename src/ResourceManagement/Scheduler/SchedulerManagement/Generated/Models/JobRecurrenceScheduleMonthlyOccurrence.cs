
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class JobRecurrenceScheduleMonthlyOccurrence
    {
        /// <summary>
        /// Initializes a new instance of the
        /// JobRecurrenceScheduleMonthlyOccurrence class.
        /// </summary>
        public JobRecurrenceScheduleMonthlyOccurrence() { }

        /// <summary>
        /// Initializes a new instance of the
        /// JobRecurrenceScheduleMonthlyOccurrence class.
        /// </summary>
        public JobRecurrenceScheduleMonthlyOccurrence(JobScheduleDay? day = default(JobScheduleDay?), int? occurrence = default(int?))
        {
            Day = day;
            Occurrence = occurrence;
        }

        /// <summary>
        /// Gets or sets the day. Must be one of monday, tuesday, wednesday,
        /// thursday, friday, saturday, sunday. Possible values include:
        /// 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday',
        /// 'Saturday', 'Sunday'
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
