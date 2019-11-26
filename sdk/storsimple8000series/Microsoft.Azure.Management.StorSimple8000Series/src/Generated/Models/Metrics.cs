
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
    /// The monitoring metric.
    /// </summary>
    public partial class Metrics
    {
        /// <summary>
        /// Initializes a new instance of the Metrics class.
        /// </summary>
        public Metrics() { }

        /// <summary>
        /// Initializes a new instance of the Metrics class.
        /// </summary>
        /// <param name="resourceId">The ID of metric source.</param>
        /// <param name="startTime">The start time of the metric data.</param>
        /// <param name="endTime">The end time of the metric data.</param>
        /// <param name="timeGrain">The time granularity of the metric
        /// data.</param>
        /// <param name="primaryAggregation">The metric aggregation type.
        /// Possible values include: 'Average', 'Last', 'Maximum', 'Minimum',
        /// 'None', 'Total'</param>
        /// <param name="name">The name of the metric.</param>
        /// <param name="dimensions">The metric dimensions.</param>
        /// <param name="unit">The unit of the metric data. Possible values
        /// include: 'Bytes', 'BytesPerSecond', 'Count', 'CountPerSecond',
        /// 'Percent', 'Seconds'</param>
        /// <param name="type">The type of the metric data.</param>
        /// <param name="values">The list of the metric data.</param>
        public Metrics(string resourceId = default(string), System.DateTime? startTime = default(System.DateTime?), System.DateTime? endTime = default(System.DateTime?), string timeGrain = default(string), MetricAggregationType? primaryAggregation = default(MetricAggregationType?), MetricName name = default(MetricName), IList<MetricDimension> dimensions = default(IList<MetricDimension>), MetricUnit? unit = default(MetricUnit?), string type = default(string), IList<MetricData> values = default(IList<MetricData>))
        {
            ResourceId = resourceId;
            StartTime = startTime;
            EndTime = endTime;
            TimeGrain = timeGrain;
            PrimaryAggregation = primaryAggregation;
            Name = name;
            Dimensions = dimensions;
            Unit = unit;
            Type = type;
            Values = values;
        }

        /// <summary>
        /// Gets or sets the ID of metric source.
        /// </summary>
        [JsonProperty(PropertyName = "resourceId")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the start time of the metric data.
        /// </summary>
        [JsonProperty(PropertyName = "startTime")]
        public System.DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time of the metric data.
        /// </summary>
        [JsonProperty(PropertyName = "endTime")]
        public System.DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the time granularity of the metric data.
        /// </summary>
        [JsonProperty(PropertyName = "timeGrain")]
        public string TimeGrain { get; set; }

        /// <summary>
        /// Gets or sets the metric aggregation type. Possible values include:
        /// 'Average', 'Last', 'Maximum', 'Minimum', 'None', 'Total'
        /// </summary>
        [JsonProperty(PropertyName = "primaryAggregation")]
        public MetricAggregationType? PrimaryAggregation { get; set; }

        /// <summary>
        /// Gets or sets the name of the metric.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public MetricName Name { get; set; }

        /// <summary>
        /// Gets or sets the metric dimensions.
        /// </summary>
        [JsonProperty(PropertyName = "dimensions")]
        public IList<MetricDimension> Dimensions { get; set; }

        /// <summary>
        /// Gets or sets the unit of the metric data. Possible values include:
        /// 'Bytes', 'BytesPerSecond', 'Count', 'CountPerSecond', 'Percent',
        /// 'Seconds'
        /// </summary>
        [JsonProperty(PropertyName = "unit")]
        public MetricUnit? Unit { get; set; }

        /// <summary>
        /// Gets or sets the type of the metric data.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the list of the metric data.
        /// </summary>
        [JsonProperty(PropertyName = "values")]
        public IList<MetricData> Values { get; set; }

    }
}

