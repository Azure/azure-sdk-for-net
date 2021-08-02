// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// The set of options that can be specified when calling <see cref="MetricsAdvisorClient.GetMetricSeriesData"/>
    /// or <see cref="MetricsAdvisorClient.GetMetricSeriesDataAsync"/> to configure the behavior of the request.
    /// </summary>
    public class GetMetricSeriesDataOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMetricSeriesDataOptions"/> class.
        /// </summary>
        /// <param name="startsOn">Filters the result. Only data points ingested from this point in time, in UTC, will be returned.</param>
        /// <param name="endsOn">Filters the result. Only data points ingested up to this point in time, in UTC, will be returned.</param>
        public GetMetricSeriesDataOptions(DateTimeOffset startsOn, DateTimeOffset endsOn)
        {
            SeriesKeys = new ChangeTrackingList<DimensionKey>();
            StartsOn = startsOn;
            EndsOn = endsOn;
        }

        /// <summary>
        /// Filters the result by time series. Each element in this list represents a single time series, and only
        /// anomalies detected in one of these series will be returned. For every element, all possible dimensions
        /// must be set.
        /// </summary>
        public IList<DimensionKey> SeriesKeys { get; }

        /// <summary>
        /// Filters the result. Only data points ingested from this point in time, in UTC, will be returned.
        /// </summary>
        public DateTimeOffset StartsOn { get; }

        /// <summary>
        /// Filters the result. Only data points ingested up to this point in time, in UTC, will be returned.
        /// </summary>
        public DateTimeOffset EndsOn { get; }
    }
}
