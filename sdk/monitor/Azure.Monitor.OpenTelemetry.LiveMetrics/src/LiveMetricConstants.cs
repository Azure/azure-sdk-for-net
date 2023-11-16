// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics
{
    internal static class LiveMetricConstants
    {
        internal const string LiveMetricMeterName = "LiveMetricMeterName";

        // REQUESTS
        internal const string RequestDurationInstrumentName = "RequestDurationLiveMetric";
        internal const string RequestsInstrumentName = "RequestsLiveMetric";
        internal const string RequestsSucceededPerSecondInstrumentName = "RequestsSucceededPerSecondLiveMetric";
        internal const string RequestsFailedPerSecondInstrumentName = "RequestsFailedPerSecondLiveMetric";

        // DEPENDENCIES
        internal const string DependencyDurationInstrumentName = "DependencyDurationLiveMetric";
        internal const string DependencyInstrumentName = "DependencyLiveMetric";
        internal const string DependencySucceededPerSecondInstrumentName = "DependencySucceededPerSecondLiveMetric";
        internal const string DependencyFailedPerSecondInstrumentName = "DependencyFailedPerSecondLiveMetric";

        // EXCEPTIONS
        internal const string ExceptionsPerSecondInstrumentName = "ExceptionsPerSecondLiveMetric";

        // PERFORMANCE COUNTERS
        internal const string MemoryCommittedBytesInstrumentName = "CommittedBytesLiveMetric";
        internal const string ProcessorTimeInstrumentName = "ProcessorTimeBytesLiveMetric";

        internal const string RequestDurationMetricIdValue = @"\ApplicationInsights\Request Duration";
        internal const string RequestsPerSecondMetricIdValue = @"\ApplicationInsights\Requests/Sec";
        internal const string RequestsSucceededPerSecondMetricIdValue = @"\ApplicationInsights\Requests Succeeded/Sec";
        internal const string RequestsFailedPerSecondMetricIdValue = @"\ApplicationInsights\Requests Failed/Sec";
        internal const string DependencyDurationMetricIdValue = @"\ApplicationInsights\Dependency Call Duration";
        internal const string DependenciesPerSecondMetricIdValue = @"\ApplicationInsights\Dependency Calls/Sec";
        internal const string DependencySucceededPerSecondMetricIdValue = @"\ApplicationInsights\Dependency Calls Succeeded/Sec";
        internal const string DependencyFailedPerSecondMetricIdValue = @"\ApplicationInsights\Dependency Calls Failed/Sec";
        internal const string ExceptionsPerSecondMetricIdValue = @"\ApplicationInsights\Exceptions/Sec";
        internal const string MemoryCommittedBytesMetricIdValue = @"\Memory\Committed Bytes";
        internal const string ProcessorTimeMetricIdValue = @"\Processor(_Total)\% Processor Time";

        /// <summary>
        /// This dictionary maps Instrumentation-Safe names (key)
        /// to Application Insights Live Metrics names (value).
        /// </summary>
        internal static readonly Dictionary<string, string> Mappings = new()
        {
            // REQUESTS
            {RequestsInstrumentName, "\\ApplicationInsights\\Requests/Sec" },
            {RequestDurationInstrumentName, "\\ApplicationInsights\\Request Duration" },
            {RequestsFailedPerSecondInstrumentName, "\\ApplicationInsights\\Requests Failed/Sec" },
            {RequestsSucceededPerSecondInstrumentName, "\\ApplicationInsights\\Requests Succeeded/Sec" },

            // DEPENDENCIES
            {DependencyInstrumentName, "\\ApplicationInsights\\Dependency Calls/Sec" },
            {DependencyDurationInstrumentName, "\\ApplicationInsights\\Dependency Call Duration" },
            {DependencyFailedPerSecondInstrumentName, "\\ApplicationInsights\\Dependency Calls Failed/Sec" },
            {DependencySucceededPerSecondInstrumentName, "\\ApplicationInsights\\Dependency Calls Succeeded/Sec" },

            // EXCEPTIONS
            {ExceptionsPerSecondInstrumentName, "\\ApplicationInsights\\Exceptions/Sec" },

            // PERFORMANCE COUNTERS
            {MemoryCommittedBytesInstrumentName, "\\Memory\\Committed Bytes"},
            {ProcessorTimeInstrumentName, "\\Processor(_Total)\\% Processor Time"},
        };
    }
}
