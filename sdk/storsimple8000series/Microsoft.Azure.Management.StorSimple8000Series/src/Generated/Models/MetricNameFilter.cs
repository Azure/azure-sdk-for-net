
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The metric name filter, specifying the name of the metric to be
    /// filtered on.
    /// </summary>
    public partial class MetricNameFilter
    {
        /// <summary>
        /// Initializes a new instance of the MetricNameFilter class.
        /// </summary>
        public MetricNameFilter() { }

        /// <summary>
        /// Initializes a new instance of the MetricNameFilter class.
        /// </summary>
        /// <param name="value">Specifies the metric name to be filtered on.
        /// E.g., CloudStorageUsed. Valid values are the ones returned in the
        /// field "name" in the ListMetricDefinitions call. Only 'Equality'
        /// operator is supported for this property.</param>
        public MetricNameFilter(string value = default(string))
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets specifies the metric name to be filtered on. E.g.,
        /// CloudStorageUsed. Valid values are the ones returned in the field
        /// "name" in the ListMetricDefinitions call. Only 'Equality' operator
        /// is supported for this property.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

    }
}

