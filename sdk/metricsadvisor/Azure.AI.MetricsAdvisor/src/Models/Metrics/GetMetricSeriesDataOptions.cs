// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    public class GetMetricSeriesDataOptions
    {
        /// <summary>
        /// </summary>
        public GetMetricSeriesDataOptions(IEnumerable<DimensionKey> seriesToFilter, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            Argument.AssertNotNull(seriesToFilter, nameof(seriesToFilter));

            SeriesToFilter = seriesToFilter;
            StartTime = startTime;
            EndTime = endTime;
        }

        /// <summary>
        /// </summary>
        public IEnumerable<DimensionKey> SeriesToFilter { get; }

        /// <summary>
        /// </summary>
        public DateTimeOffset StartTime { get; }

        /// <summary>
        /// </summary>
        public DateTimeOffset EndTime { get; }

        /// <summary>
        /// </summary>
        public int? SkipCount { get; set; }

        /// <summary>
        /// </summary>
        public int? TopCount { get; set; }
    }
}
