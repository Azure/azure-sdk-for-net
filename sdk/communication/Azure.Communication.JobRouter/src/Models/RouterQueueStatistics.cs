// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class RouterQueueStatistics
    {
        [CodeGenMember("EstimatedWaitTimeMinutes")]
        internal IDictionary<string, double> _estimatedWaitTimeMinutes
        {
            get
            {
                return EstimatedWaitTimes != null && EstimatedWaitTimes.Count != 0
                    ? EstimatedWaitTimes.ToDictionary(x => x.Key.ToString(), x => x.Value.TotalMinutes)
                    : new ChangeTrackingDictionary<string, double>();
            }
            set
            {
                if (value != null && value.Count != 0)
                {
                    foreach (var estimatedWaitTime in value)
                    {
                        EstimatedWaitTimes[int.Parse(estimatedWaitTime.Key)] = TimeSpan.FromMinutes(estimatedWaitTime.Value);
                    }
                }
            }
        }

        /// <summary>
        /// The estimated wait time of this queue rounded up to the nearest minute, grouped
        /// by job priority
        /// </summary>
        public IDictionary<int, TimeSpan> EstimatedWaitTimes { get; } = new Dictionary<int, TimeSpan>();
    }
}
