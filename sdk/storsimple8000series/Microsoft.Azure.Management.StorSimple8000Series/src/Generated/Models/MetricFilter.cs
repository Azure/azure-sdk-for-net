
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The OData filters to be used for metrics.
    /// </summary>
    public partial class MetricFilter
    {
        /// <summary>
        /// Initializes a new instance of the MetricFilter class.
        /// </summary>
        public MetricFilter() { }

        /// <summary>
        /// Initializes a new instance of the MetricFilter class.
        /// </summary>
        /// <param name="category">Specifies the category of the metrics to be
        /// filtered. E.g., "CapacityUtilization". Valid values are the ones
        /// returned as the field "category" in the ListMetricDefinitions call.
        /// Only 'Equality' operator is supported for this property.</param>
        /// <param name="name">Specifies the metric name filter specifying the
        /// name of the metric to be filtered on. Only 'Equality' operator is
        /// supported for this property.</param>
        /// <param name="startTime">Specifies the start time of the time range
        /// to be queried. Only 'Greater Than Or Equal To' operator is
        /// supported for this property.</param>
        /// <param name="endTime">Specifies the end time of the time range to
        /// be queried. Only 'Less Than Or Equal To' operator is supported for
        /// this property.</param>
        /// <param name="timeGrain">Specifies the time granularity of the
        /// metrics to be returned. E.g., "P1D". Valid values are the ones
        /// returned as the field "timeGrain" in the ListMetricDefinitions
        /// call. Only 'Equality' operator is supported for this
        /// property.</param>
        /// <param name="dimensions">Specifies the source(the dimension) of the
        /// metrics to be filtered. Only 'Equality' operator is supported for
        /// this property.</param>
        public MetricFilter(string category, MetricNameFilter name = default(MetricNameFilter), System.DateTime? startTime = default(System.DateTime?), System.DateTime? endTime = default(System.DateTime?), string timeGrain = default(string), DimensionFilter dimensions = default(DimensionFilter))
        {
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            TimeGrain = timeGrain;
            Category = category;
            Dimensions = dimensions;
        }

        /// <summary>
        /// Gets or sets specifies the metric name filter specifying the name
        /// of the metric to be filtered on. Only 'Equality' operator is
        /// supported for this property.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public MetricNameFilter Name { get; set; }

        /// <summary>
        /// Gets or sets specifies the start time of the time range to be
        /// queried. Only 'Greater Than Or Equal To' operator is supported for
        /// this property.
        /// </summary>
        [JsonProperty(PropertyName = "startTime")]
        public System.DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets specifies the end time of the time range to be
        /// queried. Only 'Less Than Or Equal To' operator is supported for
        /// this property.
        /// </summary>
        [JsonProperty(PropertyName = "endTime")]
        public System.DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets specifies the time granularity of the metrics to be
        /// returned. E.g., "P1D". Valid values are the ones returned as the
        /// field "timeGrain" in the ListMetricDefinitions call. Only
        /// 'Equality' operator is supported for this property.
        /// </summary>
        [JsonProperty(PropertyName = "timeGrain")]
        public string TimeGrain { get; set; }

        /// <summary>
        /// Gets or sets specifies the category of the metrics to be filtered.
        /// E.g., "CapacityUtilization". Valid values are the ones returned as
        /// the field "category" in the ListMetricDefinitions call. Only
        /// 'Equality' operator is supported for this property.
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets specifies the source(the dimension) of the metrics to
        /// be filtered. Only 'Equality' operator is supported for this
        /// property.
        /// </summary>
        [JsonProperty(PropertyName = "dimensions")]
        public DimensionFilter Dimensions { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Category == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Category");
            }
        }
    }
}

