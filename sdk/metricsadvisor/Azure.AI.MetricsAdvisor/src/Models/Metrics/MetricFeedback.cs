// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The MetricFeedback. </summary>
    public partial class MetricFeedback
    {
        /// <summary> Initializes a new instance of MetricFeedback. </summary>
        /// <param name="metricId"> metric unique id. </param>
        /// <param name="dimensionFilter"> . </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimensionFilter"/> is null. </exception>
        internal MetricFeedback(string metricId, FeedbackDimensionFilter dimensionFilter)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));
            Argument.AssertNotNull(dimensionFilter, nameof(dimensionFilter));

            MetricId = metricId;
            DimensionFilter = dimensionFilter;
        }

        /// <summary> feedback type. </summary>
        [CodeGenMember("FeedbackType")]
        public FeedbackType Type { get; internal set; }

        /// <summary> feedback unique id. </summary>
        [CodeGenMember("FeedbackId")]
        public string Id { get; internal set; }

        /// <summary> feedback created time. </summary>
        public DateTimeOffset? CreatedTime { get; }

        /// <summary> user who gives this feedback. </summary>
        public string UserPrincipal { get; }

        /// <summary> metric unique id. </summary>
        public string MetricId { get; }

        /// <summary> The dimension filter. </summary>
        public FeedbackDimensionFilter DimensionFilter { get; internal set; }
    }
}
