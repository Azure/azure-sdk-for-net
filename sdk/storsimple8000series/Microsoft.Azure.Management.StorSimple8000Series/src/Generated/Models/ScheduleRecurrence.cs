
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The schedule recurrence.
    /// </summary>
    public partial class ScheduleRecurrence
    {
        /// <summary>
        /// Initializes a new instance of the ScheduleRecurrence class.
        /// </summary>
        public ScheduleRecurrence() { }

        /// <summary>
        /// Initializes a new instance of the ScheduleRecurrence class.
        /// </summary>
        /// <param name="recurrenceType">The recurrence type. Possible values
        /// include: 'Minutes', 'Hourly', 'Daily', 'Weekly'</param>
        /// <param name="recurrenceValue">The recurrence value.</param>
        /// <param name="weeklyDaysList">The week days list. Applicable only
        /// for schedules of recurrence type 'weekly'.</param>
        public ScheduleRecurrence(RecurrenceType recurrenceType, int recurrenceValue, IList<DayOfWeek?> weeklyDaysList = default(IList<DayOfWeek?>))
        {
            RecurrenceType = recurrenceType;
            RecurrenceValue = recurrenceValue;
            WeeklyDaysList = weeklyDaysList;
        }

        /// <summary>
        /// Gets or sets the recurrence type. Possible values include:
        /// 'Minutes', 'Hourly', 'Daily', 'Weekly'
        /// </summary>
        [JsonProperty(PropertyName = "recurrenceType")]
        public RecurrenceType RecurrenceType { get; set; }

        /// <summary>
        /// Gets or sets the recurrence value.
        /// </summary>
        [JsonProperty(PropertyName = "recurrenceValue")]
        public int RecurrenceValue { get; set; }

        /// <summary>
        /// Gets or sets the week days list. Applicable only for schedules of
        /// recurrence type 'weekly'.
        /// </summary>
        [JsonProperty(PropertyName = "weeklyDaysList")]
        public IList<DayOfWeek?> WeeklyDaysList { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
        }
    }
}

