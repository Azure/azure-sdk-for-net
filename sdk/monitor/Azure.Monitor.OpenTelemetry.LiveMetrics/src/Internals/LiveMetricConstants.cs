﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    internal static class LiveMetricConstants
    {
        /// <summary>
        /// These are the values that are sent to Application Insights Live Metrics.
        /// </summary>
        internal static class MetricId
        {
            // REQUESTS
            internal const string RequestDurationMetricIdValue = @"\ApplicationInsights\Request Duration";
            internal const string RequestsPerSecondMetricIdValue = @"\ApplicationInsights\Requests/Sec";
            internal const string RequestsSucceededPerSecondMetricIdValue = @"\ApplicationInsights\Requests Succeeded/Sec";
            internal const string RequestsFailedPerSecondMetricIdValue = @"\ApplicationInsights\Requests Failed/Sec";

            // DEPENDENCIES
            internal const string DependencyDurationMetricIdValue = @"\ApplicationInsights\Dependency Call Duration";
            internal const string DependenciesPerSecondMetricIdValue = @"\ApplicationInsights\Dependency Calls/Sec";
            internal const string DependencySucceededPerSecondMetricIdValue = @"\ApplicationInsights\Dependency Calls Succeeded/Sec";
            internal const string DependencyFailedPerSecondMetricIdValue = @"\ApplicationInsights\Dependency Calls Failed/Sec";

            // EXCEPTIONS
            internal const string ExceptionsPerSecondMetricIdValue = @"\ApplicationInsights\Exceptions/Sec";

            // PERFORMANCE COUNTERS
            internal const string MemoryCommittedBytesMetricIdValue = @"\Memory\Committed Bytes";
            internal const string ProcessorTimeMetricIdValue = @"\Processor(_Total)\% Processor Time";
        }
    }
}
