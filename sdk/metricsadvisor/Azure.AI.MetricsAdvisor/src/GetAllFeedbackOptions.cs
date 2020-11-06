// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.MetricsAdvisor.Models;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// The set of options that can be specified when calling <see cref="MetricsAdvisorClient.GetAllFeedback"/>
    /// or <see cref="MetricsAdvisorClient.GetAllFeedbackAsync"/> to configure the behavior of the request.
    /// </summary>
    public class GetAllFeedbackOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllFeedbackOptions"/> class.
        /// </summary>
        public GetAllFeedbackOptions()
        {
            Filter = new DimensionKey();
        }

        /// <summary> The dimension filter. </summary>
        internal FeedbackDimensionFilter DimensionFilter => Filter.Dimension.Count == 0 ? null : new FeedbackDimensionFilter(Filter.Dimension);

        /// <summary>
        /// Filters the result by series. Only feedbacks for the series in the time series group specified will
        /// be returned.
        /// </summary>
        public DimensionKey Filter { get; }

        /// <summary>
        /// Filters the result by <see cref="MetricFeedback.Type"/>.
        /// </summary>
        public FeedbackType? FeedbackType { get; set; }

        /// <summary>
        /// Filters the result under the chosen <see cref="TimeMode"/>. Only results from this point in time,
        /// in UTC, will be returned.
        /// </summary>
        public DateTimeOffset? StartTime { get; set; }

        /// <summary>
        /// Filters the result under the chosen <see cref="TimeMode"/>. Only results up to this point in time,
        /// in UTC, will be returned.
        /// </summary>
        public DateTimeOffset? EndTime { get; set; }

        /// <summary>
        /// Specifies to which time property of a <see cref="MetricFeedback"/> the filters <see cref="StartTime"/>
        /// and <see cref="EndTime"/> will be applied.
        /// </summary>
        public FeedbackQueryTimeMode? TimeMode { get; set; }

        /// <summary>
        /// If set, skips the first set of items returned. This property specifies the amount of items to
        /// be skipped.
        /// </summary>
        public int? SkipCount { get; set; }

        /// <summary>
        /// If set, specifies the maximum limit of items returned in each page of results. Note:
        /// unless the number of pages enumerated from the service is limited, the service will
        /// return an unlimited number of total items.
        /// </summary>
        public int? TopCount { get; set; }
    }
}
