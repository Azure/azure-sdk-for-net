namespace Microsoft.Azure.ApplicationInsights.Models
{
    /// <summary>
    /// Contains fields common between nested segmented data and segmented metric data.
    /// </summary>
    public class MetricsBaseSegmentInfo
    {
        /// <summary>
        /// The name of the segment.
        /// </summary>
        public string SegmentId { get; internal set; }

        /// <summary>
        /// The value of the segment.
        /// </summary>
        public string SegmentValue { get; internal set; }
    }
}
