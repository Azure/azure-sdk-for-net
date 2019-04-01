using System.Collections.Generic;

namespace Microsoft.Azure.ApplicationInsights.Query.Models
{
    /// <summary>
    /// A nested segment.
    /// </summary>
    public class MetricsNestedSegment : IMetricsBaseSegmentInfo
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
        /// The segments of data
        /// </summary>
        public IList<IMetricsBaseSegmentInfo> Segments { get; internal set; }
    }
}
