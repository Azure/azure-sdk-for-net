using System.Collections.Generic;

namespace Microsoft.Azure.ApplicationInsights.Models
{
    /// <summary>
    /// A nested segment.
    /// </summary>
    public class MetricsNestedSegment : MetricsBaseSegmentInfo
    {
        /// <summary>
        /// The segments of data
        /// </summary>
        public IList<MetricsBaseSegmentInfo> Segments { get; internal set; }
    }
}
