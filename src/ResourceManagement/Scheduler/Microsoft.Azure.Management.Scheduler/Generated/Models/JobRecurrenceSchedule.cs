
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class JobRecurrenceSchedule
    {
        /// <summary>
        /// Initializes a new instance of the JobRecurrenceSchedule class.
        /// </summary>
        public JobRecurrenceSchedule() { }

        /// <summary>
        /// Initializes a new instance of the JobRecurrenceSchedule class.
        /// </summary>
        public JobRecurrenceSchedule(IList<DayOfWeek?> weekDays = default(IList<DayOfWeek?>), IList<int?> hours = default(IList<int?>), IList<int?> minutes = default(IList<int?>), IList<int?> monthDays = default(IList<int?>), IList<JobRecurrenceScheduleMonthlyOccurrence> monthlyOccurrences = default(IList<JobRecurrenceScheduleMonthlyOccurrence>))
        {
            WeekDays = weekDays;
            Hours = hours;
            Minutes = minutes;
            MonthDays = monthDays;
            MonthlyOccurrences = monthlyOccurrences;
        }

        /// <summary>
        /// Gets or sets the days of the week that the job should execute on.
        /// </summary>
        [JsonProperty(PropertyName = "weekDays")]
        public IList<DayOfWeek?> WeekDays { get; set; }

        /// <summary>
        /// Gets or sets the hours of the day that the job should execute at.
        /// </summary>
        [JsonProperty(PropertyName = "hours")]
        public IList<int?> Hours { get; set; }

        /// <summary>
        /// Gets or sets the minutes of the hour that the job should execute
        /// at.
        /// </summary>
        [JsonProperty(PropertyName = "minutes")]
        public IList<int?> Minutes { get; set; }

        /// <summary>
        /// Gets or sets the days of the month that the job should execute on.
        /// Must be between 1 and 31.
        /// </summary>
        [JsonProperty(PropertyName = "monthDays")]
        public IList<int?> MonthDays { get; set; }

        /// <summary>
        /// Gets or sets the occurrences of days within a month.
        /// </summary>
        [JsonProperty(PropertyName = "monthlyOccurrences")]
        public IList<JobRecurrenceScheduleMonthlyOccurrence> MonthlyOccurrences { get; set; }

    }
}
