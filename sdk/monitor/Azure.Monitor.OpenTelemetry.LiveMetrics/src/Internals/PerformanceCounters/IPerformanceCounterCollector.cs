// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.PerformanceCounters
{
    internal interface IPerformanceCounterCollector
    {
        public IEnumerable<Models.MetricPoint> Collect();
    }
}
