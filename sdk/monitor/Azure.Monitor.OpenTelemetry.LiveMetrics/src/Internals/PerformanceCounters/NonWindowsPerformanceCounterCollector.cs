// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.PerformanceCounters
{
    /// <summary>
    /// Uses <see cref="System.Diagnostics.Process"/> to collect process metrics.
    /// </summary>
    internal class NonWindowsPerformanceCounterCollector : IPerformanceCounterCollector
    {
        public IEnumerable<Models.MetricPoint> Collect()
        {
            throw new NotImplementedException();
        }
    }
}
