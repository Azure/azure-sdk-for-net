// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Scale;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.WebJobs.EventHubs.Listeners
{
    internal class EventHubsTriggerMetrics : ScaleMetrics
    {
        /// <summary>
        /// The total number of unprocessed events across all partitions.
        /// </summary>
        public long EventCount { get; set; }

        /// <summary>
        /// The number of partitions.
        /// </summary>
        public int PartitionCount { get; set; }
        /// <summary>
        /// The number of events per partition
        /// </summary>
        public Dictionary<uint, long> EventCountPerPartition { get; set; }
    }
}
