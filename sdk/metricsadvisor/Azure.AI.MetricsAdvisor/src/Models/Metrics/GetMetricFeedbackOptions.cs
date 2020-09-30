// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{

    /// <summary> The GetMetricFeedbackOptions. </summary>
    public partial class GetMetricFeedbackOptions
    {
        internal MetricFeedbackFilter _metricFeedbackFilter;

        /// <summary> Initializes a new instance of GetMetricFeedbackOptions. </summary>
        /// <param name="metricId"> filter feedbacks by metric id. </param>
        public GetMetricFeedbackOptions(string metricId)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));
            Guid metricIdGuid = ClientCommon.ValidateGuid(metricId, nameof(metricId));

            MetricId = metricIdGuid;
        }

        /// <summary> The metric Id used to filter the feedbacks. </summary>
        public Guid MetricId { get; }


        /// <summary> The dimension filter. </summary>
        public FeedbackDimensionFilter DimensionFilter { get; set; }

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
