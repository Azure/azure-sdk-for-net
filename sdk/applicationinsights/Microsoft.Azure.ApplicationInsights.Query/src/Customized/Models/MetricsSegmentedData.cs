namespace Microsoft.Azure.ApplicationInsights.Query.Models
{
    /// <summary>
    /// The metric values for a segment.
    /// </summary>
    public class MetricsSegmentedData : IMetricsBaseSegmentInfo, IMetricData
    {
        /// <summary>
        /// The name of the segment.
        /// </summary>
        public string SegmentId { get; internal set; }

        /// <summary>
        /// The value of the segment.
        /// </summary>
        public string SegmentValue { get; internal set; }

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
