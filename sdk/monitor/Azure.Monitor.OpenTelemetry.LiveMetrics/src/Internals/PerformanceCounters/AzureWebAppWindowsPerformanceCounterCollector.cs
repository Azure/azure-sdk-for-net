// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.PerformanceCounters
{
    /// <summary>
    /// Read fake environment variables from a Windows-based Azure App Service.
    /// </summary>
    /// <remarks>
    /// Azure App Service doc:
    /// <see href="https://learn.microsoft.com/azure/app-service/reference-app-settings#performance-counters"/>.
    /// </remarks>
    internal class AzureWebAppWindowsPerformanceCounterCollector : IPerformanceCounterCollector
    {
        public IEnumerable<Models.MetricPoint> Collect()
        {
            throw new NotImplementedException();
        }
    }
}
