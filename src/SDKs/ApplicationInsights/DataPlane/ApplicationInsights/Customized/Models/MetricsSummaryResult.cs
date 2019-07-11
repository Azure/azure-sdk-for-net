namespace Microsoft.Azure.ApplicationInsights.Query.Models
{
    /// <summary>
    /// A metric summary result.
    /// </summary>
    public class MetricsSummaryResult : IMetricData
    {
        /// <summary>
        /// Gets start time of the metric.
        /// </summary>
        public System.DateTime? Start { get; internal set; }

        /// <summary>
        /// Gets start time of the metric.
        /// </summary>
        public System.DateTime? End { get; internal set; }

        /// <summary>
        /// Gets sum of the metric (if requested).
        /// </summary>
        public float? Sum { get; internal set; }

        /// <summary>
        /// Gets average of the metric (if requested).
        /// </summary>
        public float? Average { get; internal set; }

        /// <summary>
        /// Gets minof the metric (if requested).
        /// </summary>
        public float? Min { get; internal set; }

        /// <summary>
        /// Gets max of the metric (if requested).
        /// </summary>
        public float? Max { get; internal set; }

        /// <summary>
        /// Gets count of the metric (if requested).
        /// </summary>
        public int? Count { get; internal set; }
    }
}
