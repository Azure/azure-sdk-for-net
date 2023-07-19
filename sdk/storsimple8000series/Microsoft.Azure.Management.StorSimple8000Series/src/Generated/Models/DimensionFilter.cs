
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The dimension filter.
    /// </summary>
    public partial class DimensionFilter
    {
        /// <summary>
        /// Initializes a new instance of the DimensionFilter class.
        /// </summary>
        public DimensionFilter() { }

        /// <summary>
        /// Initializes a new instance of the DimensionFilter class.
        /// </summary>
        /// <param name="name">Specifies the dimension name. E.g.,
        /// NetworkInterface. Valid values are the ones specified in the field
        /// "dimensions" in the ListMetricDefinitions call. Only 'Equality'
        /// operator is supported for this property.</param>
        /// <param name="values">Specifies the dimension value. E.g., Data0.
        /// Valid values are the ones returned in the field "dimensions" in the
        /// ListMetricDefinitions call. Only 'Equality' operator is supported
        /// for this property.</param>
        public DimensionFilter(string name = default(string), string values = default(string))
        {
            Name = name;
            Values = values;
        }

        /// <summary>
        /// Gets or sets specifies the dimension name. E.g., NetworkInterface.
        /// Valid values are the ones specified in the field "dimensions" in
        /// the ListMetricDefinitions call. Only 'Equality' operator is
        /// supported for this property.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets specifies the dimension value. E.g., Data0. Valid
        /// values are the ones returned in the field "dimensions" in the
        /// ListMetricDefinitions call. Only 'Equality' operator is supported
        /// for this property.
        /// </summary>
        [JsonProperty(PropertyName = "values")]
        public string Values { get; set; }

    }
}

