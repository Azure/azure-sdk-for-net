// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// Filters the result of the <see cref="MetricsAdvisorClient.GetAllFeedback"/> and
    /// <see cref="MetricsAdvisorClient.GetAllFeedbackAsync"/> operations.
    /// </summary>
    [CodeGenModel("FeedbackDimensionFilter")]
    public partial class FeedbackFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeedbackFilter"/> class.
        /// </summary>
        public FeedbackFilter()
        {
        }

        /// <summary> Initializes a new instance of FeedbackDimensionFilter. </summary>
        /// <param name="dimension"> metric dimension filter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimension"/> is null. </exception>
        internal FeedbackFilter(IDictionary<string, string> dimension)
        {
            if (dimension == null)
            {
                throw new ArgumentNullException(nameof(dimension));
            }

            Dimension = dimension;
        }

        /// <summary>
        /// Filters the result by time series. Only feedback for the series in the time series specified will be
        /// returned. If all possible dimensions are set, this key uniquely identifies a single time series for the
        /// corresponding metric. If only a subset of dimensions are set, this key identifies a group of time series.
        /// </summary>
        public DimensionKey DimensionKey { get; set; }

        /// <summary>
        /// Filters the result by <see cref="MetricFeedback.FeedbackKind"/>.
        /// </summary>
        public MetricFeedbackKind? FeedbackKind { get; set; }

        /// <summary>
        /// Filters the result under the chosen <see cref="TimeMode"/>. Only results from this point in time,
        /// in UTC, will be returned. In order to filter by time, you also need to set the property
        /// <see cref="TimeMode"/>.
        /// </summary>
        public DateTimeOffset? StartsOn { get; set; }

        /// <summary>
        /// Filters the result under the chosen <see cref="TimeMode"/>. Only results up to this point in time,
        /// in UTC, will be returned. In order to filter by time, you also need to set the property
        /// <see cref="TimeMode"/>.
        /// </summary>
        public DateTimeOffset? EndsOn { get; set; }

        /// <summary>
        /// Specifies to which time property of a <see cref="MetricFeedback"/> the filters <see cref="StartsOn"/>
        /// and <see cref="EndsOn"/> will be applied.
        /// </summary>
        public FeedbackQueryTimeMode TimeMode { get; set; }

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal IDictionary<string, string> Dimension
        {
            get => DimensionKey?.Dimension ?? new Dictionary<string, string>();
            set => DimensionKey = new DimensionKey(value);
        }
    }
}
