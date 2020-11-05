// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary> The GetEnrichmentStatusesOptions. </summary>
    public class GetMetricEnrichmentStatusesOptions
    {
        /// <summary> Initializes a new instance of <see cref="GetMetricEnrichmentStatusesOptions"/>. </summary>
        /// <param name="startTime"> the start point of time range to query anomaly detection status. </param>
        /// <param name="endTime"> the end point of time range to query anomaly detection status. </param>
        public GetMetricEnrichmentStatusesOptions(DateTimeOffset startTime, DateTimeOffset endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        /// <summary> the start point of time range to query anomaly detection status. </summary>
        public DateTimeOffset StartTime { get; }

        /// <summary> the end point of time range to query anomaly detection status. </summary>
        public DateTimeOffset EndTime { get; }

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
