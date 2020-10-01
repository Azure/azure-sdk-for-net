// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    // TODODOCS: this whole class needs clarification.
    /// <summary>
    /// </summary>
    public partial class TopNGroupScope
    {
        /// <summary>
        /// Creates a new instance of the <see cref="TopNGroupScope"/> class.
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
        /// </summary>
        public int Top { get; }

        /// <summary>
        /// </summary>
        public int Period { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("MinTopCount")]
        public int MinimumTopCount { get; }
    }
}
