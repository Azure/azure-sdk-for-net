﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    public class GetDataFeedIngestionStatusesOptions
    {
        /// <summary>
        /// </summary>
        public GetDataFeedIngestionStatusesOptions(DateTimeOffset startTime, DateTimeOffset endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

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
