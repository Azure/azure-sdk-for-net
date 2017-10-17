
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The metric dimension. It indicates the source of the metric.
    /// </summary>
    public partial class MetricDimension
    {
        /// <summary>
        /// Initializes a new instance of the MetricDimension class.
        /// </summary>
        public MetricDimension() { }

        /// <summary>
        /// Initializes a new instance of the MetricDimension class.
        /// </summary>
        /// <param name="name">The metric dimension name.</param>
        /// <param name="value">The metric dimension values.</param>
        public MetricDimension(string name = default(string), string value = default(string))
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Gets or sets the metric dimension name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the metric dimension values.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

    }
}

