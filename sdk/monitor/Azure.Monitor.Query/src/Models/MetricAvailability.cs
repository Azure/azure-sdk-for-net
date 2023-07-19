// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    public partial class MetricAvailability
    {
        /// <summary> Specifies how often a metric value is stored. For example, every second, every 30 seconds, etc. </summary>
        [CodeGenMember("TimeGrain")]
        public TimeSpan? Granularity { get; }
    }
}