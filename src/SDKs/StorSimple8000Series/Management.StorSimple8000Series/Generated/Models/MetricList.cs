
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
    /// The metric list.
    /// </summary>
    public partial class MetricList
    {
        /// <summary>
        /// Initializes a new instance of the MetricList class.
        /// </summary>
        public MetricList() { }

        /// <summary>
        /// Initializes a new instance of the MetricList class.
        /// </summary>
        /// <param name="value">The value.</param>
        public MetricList(IList<Metrics> value = default(IList<Metrics>))
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<Metrics> Value { get; set; }

    }
}

