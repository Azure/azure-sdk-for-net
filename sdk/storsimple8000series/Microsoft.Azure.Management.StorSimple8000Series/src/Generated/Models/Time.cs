
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The time.
    /// </summary>
    public partial class Time
    {
        /// <summary>
        /// Initializes a new instance of the Time class.
        /// </summary>
        public Time() { }

        /// <summary>
        /// Initializes a new instance of the Time class.
        /// </summary>
        /// <param name="hours">The hour.</param>
        /// <param name="minutes">The minute.</param>
        /// <param name="seconds">The second.</param>
        public Time(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        /// <summary>
        /// Gets or sets the hour.
        /// </summary>
        [JsonProperty(PropertyName = "hours")]
        public int Hours { get; set; }

        /// <summary>
        /// Gets or sets the minute.
        /// </summary>
        [JsonProperty(PropertyName = "minutes")]
        public int Minutes { get; set; }

        /// <summary>
        /// Gets or sets the second.
        /// </summary>
        [JsonProperty(PropertyName = "seconds")]
        public int Seconds { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Hours > 23)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "Hours", 23);
            }
            if (Hours < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Hours", 0);
            }
            if (Minutes > 59)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "Minutes", 59);
            }
            if (Minutes < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Minutes", 0);
            }
            if (Seconds > 59)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "Seconds", 59);
            }
            if (Seconds < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Seconds", 0);
            }
        }
    }
}

