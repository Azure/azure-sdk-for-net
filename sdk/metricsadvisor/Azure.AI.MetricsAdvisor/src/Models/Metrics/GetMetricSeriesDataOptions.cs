// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
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
        /// <param name="seriesToFilter">Only time series with the specified series keys will be returned. These keys uniquely identify a time series within a metric. Every dimension contained in the associated <see cref="DataFeed"/> must be assigned a value.</param>
        /// <param name="startTime">Filters the result. Only data points ingested from this point in time, in UTC, will be returned.</param>
        /// <param name="endTime">Filters the result. Only data points ingested up to this point in time, in UTC, will be returned.</param>
        public GetMetricSeriesDataOptions(IEnumerable<DimensionKey> seriesToFilter, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            Argument.AssertNotNull(seriesToFilter, nameof(seriesToFilter));

            SeriesToFilter = seriesToFilter;
            StartTime = startTime;
            EndTime = endTime;
        }

        /// <summary>
        /// Only time series with the specified series keys will be returned. These keys uniquely identify
        /// a time series within a metric. Every dimension contained in the associated <see cref="DataFeed"/>
        /// must be assigned a value.
        /// </summary>
        public IEnumerable<DimensionKey> SeriesToFilter { get; }

        /// <summary>
        /// Filters the result. Only data points ingested from this point in time, in UTC, will be returned.
        /// </summary>
        public DateTimeOffset StartTime { get; }

        /// <summary>
        /// Filters the result. Only data points ingested up to this point in time, in UTC, will be returned.
        /// </summary>
        public DateTimeOffset EndTime { get; }
    }
}
