// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    public class GetAlertsOptions
    {
        /// <summary>
        /// </summary>
        public GetAlertsOptions(DateTimeOffset startTime, DateTimeOffset endTime, TimeMode timeMode)
        {
            StartTime = startTime;
            EndTime = endTime;
            TimeMode = timeMode;
        }

        /// <summary>
        /// </summary>
        public DateTimeOffset StartTime { get; }

        /// <summary>
        /// </summary>
        public DateTimeOffset EndTime { get; }

        /// <summary>
        /// </summary>
        public TimeMode TimeMode { get; }

        /// <summary>
        /// </summary>
        public int? SkipCount { get; set; }

        /// <summary>
        /// </summary>
        public int? TopCount { get; set; }
    }
}
