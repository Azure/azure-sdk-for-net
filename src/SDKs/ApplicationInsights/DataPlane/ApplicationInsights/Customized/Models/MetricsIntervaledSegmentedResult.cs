using System.Collections.Generic;

namespace Microsoft.Azure.ApplicationInsights.Query.Models
{
    /// <summary>
    /// An intervaled and segmented metric result.
    /// </summary>
    public class MetricsIntervaledSegmentedResult
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
        /// The interval used to segment the data.
        /// </summary>
        public System.TimeSpan? Interval { get; internal set; }

        /// <summary>
        /// The intervals of data.
        /// </summary>
        public IList<MetricsSegmentedIntervalData> Intervals { get; internal set; }
    }
}
