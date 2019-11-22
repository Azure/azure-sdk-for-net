using System.Collections.Generic;

namespace Microsoft.Azure.ApplicationInsights.Query.Models
{
    /// <summary>
    /// A segment of intervaled data.
    /// </summary>
    public class MetricsSegmentedIntervalData
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
        /// The segments of data
        /// </summary>
        public IList<IMetricsBaseSegmentInfo> Segments { get; internal set; }
    }
}
