// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The GetMetricFeedbackOptions. </summary>
    public class GetMetricFeedbacksOptions
    {
        internal MetricFeedbackFilter _metricFeedbackFilter;

        /// <summary> Initializes a new instance of GetMetricFeedbackOptions. </summary>
        /// <param name="metricId"> filter feedbacks by metric id. </param>
        public GetMetricFeedbacksOptions(string metricId)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));
            Guid metricIdGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));

            MetricId = metricIdGuid;
        }

        /// <summary> The metric Id used to filter the feedbacks. </summary>
        public Guid MetricId { get; }

        /// <summary> The dimension filter. </summary>
        internal FeedbackDimensionFilter DimensionFilter { get; set; }

        /// <summary> The dimension filter. </summary>
        public DimensionKey Filter
        {
            get => new DimensionKey(DimensionFilter.Dimension);
            set => DimensionFilter = new FeedbackDimensionFilter(value.Dimension);
        }

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
