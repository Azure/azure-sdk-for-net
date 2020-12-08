// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The <see cref="GetMetricFeedbacksOptions" />. </summary>
    public class GetMetricFeedbacksOptions
    {
        /// <summary> Creates a new <see cref="GetMetricFeedbacksOptions" />. </summary>
        public GetMetricFeedbacksOptions()
        {
            Filter = new DimensionKey();
        }

        /// <summary> The dimension filter. </summary>
        internal FeedbackDimensionFilter DimensionFilter => Filter.Dimension.Count == 0 ? null : new FeedbackDimensionFilter(Filter.Dimension);

        /// <summary> The dimension filter. </summary>
        public DimensionKey Filter { get; }

        /// <summary> filter feedbacks by type. </summary>
        public FeedbackType? FeedbackType { get; set; }

        /// <summary> start time filter under chosen time mode. </summary>
        public DateTimeOffset? StartTime { get; set; }

        /// <summary> end time filter under chosen time mode. </summary>
        public DateTimeOffset? EndTime { get; set; }

        /// <summary> time mode to filter feedback. </summary>
        public FeedbackQueryTimeMode? TimeMode { get; set; }

        /// <summary>
        /// </summary>
        public int? SkipCount { get; set; }

        /// <summary>
        /// </summary>
        public int? TopCount { get; set; }
    }
}
