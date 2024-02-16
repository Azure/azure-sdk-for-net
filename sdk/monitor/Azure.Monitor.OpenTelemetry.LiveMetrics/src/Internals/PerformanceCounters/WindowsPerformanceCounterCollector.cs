// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.PerformanceCounters
{
    /// <summary>
    /// Use System.Diagnostics.PerformanceCounter to read performance counters in Windows.
    /// </summary>
    internal class WindowsPerformanceCounterCollector : IPerformanceCounterCollector
    {
        public IEnumerable<Models.MetricPoint> Collect()
        {
            throw new NotImplementedException();
        }
    }
}
