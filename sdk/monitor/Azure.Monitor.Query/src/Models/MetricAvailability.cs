// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    public partial class MetricAvailability
    {
        /// <summary> Specifies the aggregation interval for the metric. </summary>
        [CodeGenMember("TimeGrain")]
        public TimeSpan? Granularity { get; }
    }
}