// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Alerts will only be triggered for anomalies in the top N series.
    /// Use <see cref="Top"/> to specify the number of timestamps to take into account, and <see cref="MinimumTopCount"/>
    /// to specify how many anomalies must be in them to send the alert.
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
        public TopNGroupScope(int top, int period, int minimumTopCount)
        {
            Top = top;
            Period = period;
            MinimumTopCount = minimumTopCount;
        }

        /// <summary>
        /// The number of timestamps to take into account.
        /// </summary>
        public int Top { get; }

        /// <summary>
        /// The number of items a period contains.
        /// </summary>
        public int Period { get; }

        /// <summary>
        /// The number of anomalies that must be in the specified <see cref="Top"/> number of timestamps to send an alert.
        /// The number of anomalies that must be in the specified <see cref="Top"/> number of timestamps to send an alert.
        /// </summary>
        [CodeGenMember("MinTopCount")]
        public int MinimumTopCount { get; }
    }
}
