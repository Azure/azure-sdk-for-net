
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The metric name.
    /// </summary>
    public partial class MetricName
    {
        /// <summary>
        /// Initializes a new instance of the MetricName class.
        /// </summary>
        public MetricName() { }

        /// <summary>
        /// Initializes a new instance of the MetricName class.
        /// </summary>
        /// <param name="value">The metric name.</param>
        /// <param name="localizedValue">The localized metric name.</param>
        public MetricName(string value = default(string), string localizedValue = default(string))
        {
            Value = value;
            LocalizedValue = localizedValue;
        }

        /// <summary>
        /// Gets or sets the metric name.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the localized metric name.
        /// </summary>
        [JsonProperty(PropertyName = "localizedValue")]
        public string LocalizedValue { get; set; }

    }
}

