
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
    /// The monitoring metric definition.
    /// </summary>
    public partial class MetricDefinition
    {
        /// <summary>
        /// Initializes a new instance of the MetricDefinition class.
        /// </summary>
        public MetricDefinition() { }

        /// <summary>
        /// Initializes a new instance of the MetricDefinition class.
        /// </summary>
        /// <param name="name">The metric name.</param>
        /// <param name="unit">The metric unit. Possible values include:
        /// 'Bytes', 'BytesPerSecond', 'Count', 'CountPerSecond', 'Percent',
        /// 'Seconds'</param>
        /// <param name="primaryAggregationType">The metric aggregation type.
        /// Possible values include: 'Average', 'Last', 'Maximum', 'Minimum',
        /// 'None', 'Total'</param>
        /// <param name="resourceId">The metric source ID.</param>
        /// <param name="metricAvailabilities">The available metric
        /// granularities.</param>
        /// <param name="dimensions">The available metric dimensions.</param>
        /// <param name="category">The category of the metric.</param>
        /// <param name="type">The metric definition type.</param>
        public MetricDefinition(MetricName name = default(MetricName), MetricUnit? unit = default(MetricUnit?), MetricAggregationType? primaryAggregationType = default(MetricAggregationType?), string resourceId = default(string), IList<MetricAvailablity> metricAvailabilities = default(IList<MetricAvailablity>), IList<MetricDimension> dimensions = default(IList<MetricDimension>), string category = default(string), string type = default(string))
        {
            Name = name;
            Unit = unit;
            PrimaryAggregationType = primaryAggregationType;
            ResourceId = resourceId;
            MetricAvailabilities = metricAvailabilities;
            Dimensions = dimensions;
            Category = category;
            Type = type;
        }

        /// <summary>
        /// Gets or sets the metric name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public MetricName Name { get; set; }

        /// <summary>
        /// Gets or sets the metric unit. Possible values include: 'Bytes',
        /// 'BytesPerSecond', 'Count', 'CountPerSecond', 'Percent', 'Seconds'
        /// </summary>
        [JsonProperty(PropertyName = "unit")]
        public MetricUnit? Unit { get; set; }

        /// <summary>
        /// Gets or sets the metric aggregation type. Possible values include:
        /// 'Average', 'Last', 'Maximum', 'Minimum', 'None', 'Total'
        /// </summary>
        [JsonProperty(PropertyName = "primaryAggregationType")]
        public MetricAggregationType? PrimaryAggregationType { get; set; }

        /// <summary>
        /// Gets or sets the metric source ID.
        /// </summary>
        [JsonProperty(PropertyName = "resourceId")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the available metric granularities.
        /// </summary>
        [JsonProperty(PropertyName = "metricAvailabilities")]
        public IList<MetricAvailablity> MetricAvailabilities { get; set; }

        /// <summary>
        /// Gets or sets the available metric dimensions.
        /// </summary>
        [JsonProperty(PropertyName = "dimensions")]
        public IList<MetricDimension> Dimensions { get; set; }

        /// <summary>
        /// Gets or sets the category of the metric.
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the metric definition type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

    }
}

