﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> Rerun tumbling window trigger Parameters. </summary>
    public partial class RerunTumblingWindowTriggerActionParameters
    {
        /// <summary> Initializes a new instance of RerunTumblingWindowTriggerActionParameters. </summary>
        /// <param name="startTime"> The start time for the time period for which restatement is initiated. Only UTC time is currently supported. </param>
        /// <param name="endTime"> The end time for the time period for which restatement is initiated. Only UTC time is currently supported. </param>
        /// <param name="maxConcurrency"> The max number of parallel time windows (ready for execution) for which a rerun is triggered. </param>
        public RerunTumblingWindowTriggerActionParameters(DateTimeOffset startTime, DateTimeOffset endTime, int maxConcurrency)
        {
            StartTime = startTime;
            EndTime = endTime;
            MaxConcurrency = maxConcurrency;
        }
    }
}
