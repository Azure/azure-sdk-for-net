// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class RouterJobPositionDetails
    {
        [CodeGenMember("EstimatedWaitTimeMinutes")]
        internal double _estimatedWaitTimeMinutes
        {
            get
            {
                return EstimatedWaitTime.TotalMinutes;
            }
            set
            {
                EstimatedWaitTime = TimeSpan.FromMinutes(value);
            }
        }

        /// <summary> Estimated wait time of the job rounded up to the nearest minute. </summary>
        public TimeSpan EstimatedWaitTime { get; internal set; }
    }
}
