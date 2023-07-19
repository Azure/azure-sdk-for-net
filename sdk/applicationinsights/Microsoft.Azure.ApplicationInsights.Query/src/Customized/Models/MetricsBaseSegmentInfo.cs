namespace Microsoft.Azure.ApplicationInsights.Query.Models
{
    /// <summary>
    /// Contains fields common between nested segmented data and segmented metric data.
    /// </summary>
    public interface IMetricsBaseSegmentInfo
    {
        /// <summary>
        /// The name of the segment.
        /// </summary>
        string SegmentId { get; }

        /// <summary>
        /// The value of the segment.
        /// </summary>
        string SegmentValue { get; }
    }
}
