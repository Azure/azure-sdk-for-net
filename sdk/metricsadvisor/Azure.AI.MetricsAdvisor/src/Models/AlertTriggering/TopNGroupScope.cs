// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// A scope containing only the top N series group. The service determines whether a time series is part of this group
    /// or not by following the algorithm below:
    /// <list type="number">
    ///   <item>
    ///   The service ranks every time series by data point value. A separate rank is done for each of the latest ingestion
    ///   timestamps. The amount of timestamps to consider is defined by the <see cref="Period"/> property.
    ///   </item>
    ///   <item>
    ///   If a time series is ranked among the top N series in M different timestamps, it is considered part of the top N
    ///   series group. N can be set with the <see cref="Top"/> property, and M with <see cref="MinimumTopCount"/>.
    ///   </item>
    /// </list>
    /// </summary>
    public partial class TopNGroupScope
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TopNGroupScope"/> class.
        /// </summary>
        /// <param name="top"> top N, value range : [1, +∞). </param>
        /// <param name="period"> point count used to look back, value range : [1, +∞). </param>
        /// <param name="minimumTopCount">
        /// min count should be in top N, value range : [1, +∞)
        /// should be less than or equal to period.
        /// </param>
        internal TopNGroupScope(int top, int period, int minimumTopCount)
        {
            Top = top;
            Period = period;
            MinimumTopCount = minimumTopCount;
        }

        /// <summary>
        /// The value of N in the top N series group.
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// The number of latest ingestion timestamps to consider when determining the top N series group.
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// The number of times a time series must be ranked among the highest series to be considered part of
        /// the top N series group. This value must be less than or equal to <see cref="Period"/>.
        /// </summary>
        [CodeGenMember("MinTopCount")]
        public int MinimumTopCount { get; set; }
    }
}
