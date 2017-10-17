
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The metric availability.
    /// </summary>
    public partial class MetricAvailablity
    {
        /// <summary>
        /// Initializes a new instance of the MetricAvailablity class.
        /// </summary>
        public MetricAvailablity() { }

        /// <summary>
        /// Initializes a new instance of the MetricAvailablity class.
        /// </summary>
        /// <param name="timeGrain">The aggregation interval for the
        /// metric.</param>
        /// <param name="retention">The retention period for the metric at the
        /// specified timegrain.</param>
        public MetricAvailablity(string timeGrain = default(string), string retention = default(string))
        {
            TimeGrain = timeGrain;
            Retention = retention;
        }

        /// <summary>
        /// Gets or sets the aggregation interval for the metric.
        /// </summary>
        [JsonProperty(PropertyName = "timeGrain")]
        public string TimeGrain { get; set; }

        /// <summary>
        /// Gets or sets the retention period for the metric at the specified
        /// timegrain.
        /// </summary>
        [JsonProperty(PropertyName = "retention")]
        public string Retention { get; set; }

    }
}

