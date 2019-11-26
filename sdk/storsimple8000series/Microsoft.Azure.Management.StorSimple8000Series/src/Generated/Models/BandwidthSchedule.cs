
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The schedule for bandwidth setting.
    /// </summary>
    public partial class BandwidthSchedule
    {
        /// <summary>
        /// Initializes a new instance of the BandwidthSchedule class.
        /// </summary>
        public BandwidthSchedule() { }

        /// <summary>
        /// Initializes a new instance of the BandwidthSchedule class.
        /// </summary>
        /// <param name="start">The start time of the schdule.</param>
        /// <param name="stop">The stop time of the schedule.</param>
        /// <param name="rateInMbps">The rate in Mbps.</param>
        /// <param name="days">The days of the week when this schedule is
        /// applicable.</param>
        public BandwidthSchedule(Time start, Time stop, int rateInMbps, IList<DayOfWeek?> days)
        {
            Start = start;
            Stop = stop;
            RateInMbps = rateInMbps;
            Days = days;
        }

        /// <summary>
        /// Gets or sets the start time of the schdule.
        /// </summary>
        [JsonProperty(PropertyName = "start")]
        public Time Start { get; set; }

        /// <summary>
        /// Gets or sets the stop time of the schedule.
        /// </summary>
        [JsonProperty(PropertyName = "stop")]
        public Time Stop { get; set; }

        /// <summary>
        /// Gets or sets the rate in Mbps.
        /// </summary>
        [JsonProperty(PropertyName = "rateInMbps")]
        public int RateInMbps { get; set; }

        /// <summary>
        /// Gets or sets the days of the week when this schedule is applicable.
        /// </summary>
        [JsonProperty(PropertyName = "days")]
        public IList<DayOfWeek?> Days { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Start == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Start");
            }
            if (Stop == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Stop");
            }
            if (Days == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Days");
            }
            if (Start != null)
            {
                Start.Validate();
            }
            if (Stop != null)
            {
                Stop.Validate();
            }
        }
    }
}

