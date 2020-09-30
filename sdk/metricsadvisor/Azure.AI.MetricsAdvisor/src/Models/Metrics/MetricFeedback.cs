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
        internal MetricFeedback(Guid metricId, FeedbackDimensionFilter dimensionFilter)
        {
            Argument.AssertNotNull(dimensionFilter, nameof(dimensionFilter));

            MetricId = metricId;
            DimensionFilter = dimensionFilter;
        }

        /// <summary> feedback type. </summary>
        public FeedbackType FeedbackType { get; internal set; }

        /// <summary> feedback unique id. </summary>
        public Guid? FeedbackId { get; internal set;}

        /// <summary> feedback created time. </summary>
        public DateTimeOffset? CreatedTime { get; }

        /// <summary> user who gives this feedback. </summary>
        public string UserPrincipal { get; }

        /// <summary> metric unique id. </summary>
        public Guid MetricId { get; internal set; }


        /// <summary> The dimension filter. </summary>
        public FeedbackDimensionFilter DimensionFilter { get; internal set; }
    }
}
