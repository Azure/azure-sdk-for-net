﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The GetEnrichmentStatusOptions. </summary>
    public partial class GetEnrichmentStatusOptions
    {
        /// <summary> Initializes a new instance of GetEnrichmentStatusOptions. </summary>
        /// <param name="startTime"> the start point of time range to query anomaly detection status. </param>
        /// <param name="endTime"> the end point of time range to query anomaly detection status. </param>
        public GetEnrichmentStatusOptions(DateTimeOffset startTime, DateTimeOffset endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        /// <summary> the start point of time range to query anomaly detection status. </summary>
        public DateTimeOffset StartTime { get; }
        /// <summary> the end point of time range to query anomaly detection status. </summary>
        public DateTimeOffset EndTime { get; }

        /// <summary>
        /// </summary>
        public int? SkipCount { get; set; }

        /// <summary>
        /// </summary>
        public int? TopCount { get; set; }
    }
}
