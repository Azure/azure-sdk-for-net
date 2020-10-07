﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Defines which conditions a data point must satisfy to be considered an anomaly. Applied to a group
    /// of time series.
    /// </summary>
    [CodeGenModel("DimensionGroupConfiguration")]
    public partial class MetricSeriesGroupDetectionCondition : MetricWholeSeriesDetectionCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricSeriesGroupDetectionCondition"/> class.
        /// </summary>
        /// <param name="seriesGroupKey">The key that identifies the group of time series to which these conditions apply within a metric. A subset of the possible dimensions of the associated data feed must be set.</param>
        /// <exception cref="ArgumentNullException"><paramref name="seriesGroupKey"/> is null.</exception>
        public MetricSeriesGroupDetectionCondition(DimensionKey seriesGroupKey)
        {
            Argument.AssertNotNull(seriesGroupKey, nameof(seriesGroupKey));

            SeriesGroupKey = seriesGroupKey;
        }

        /// <summary>
        /// The key that identifies the group of time series to which these conditions apply within a metric.
        /// A subset of the possible dimensions of the associated data feed must be set.
        /// </summary>
        [CodeGenMember("Group")]
        public DimensionKey SeriesGroupKey { get; }
    }
}
