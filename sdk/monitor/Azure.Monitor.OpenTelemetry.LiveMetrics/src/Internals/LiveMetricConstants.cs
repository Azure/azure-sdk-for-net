// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    internal static class LiveMetricConstants
    {
        internal const string LiveMetricMeterName = "LiveMetricMeterName";

        /// <summary>
        /// These values are used for Metric Instruments.
        /// </summary>
        internal static class InstrumentName
        {
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
        }

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

        /// <summary>
        /// This dictionary maps Instrumentation-Safe names (key)
        /// to Application Insights Live Metrics names (value).
        /// </summary>
        internal static readonly IReadOnlyDictionary<string, string> InstrumentNameToMetricId = new Dictionary<string, string>()
        {
            // REQUESTS
            [InstrumentName.RequestDurationInstrumentName] = MetricId.RequestDurationMetricIdValue,
            [InstrumentName.RequestsInstrumentName] = MetricId.RequestsPerSecondMetricIdValue,
            [InstrumentName.RequestsSucceededPerSecondInstrumentName] = MetricId.RequestsSucceededPerSecondMetricIdValue,
            [InstrumentName.RequestsFailedPerSecondInstrumentName] = MetricId.RequestsFailedPerSecondMetricIdValue,

            // DEPENDENCIES
            [InstrumentName.DependencyDurationInstrumentName] = MetricId.DependencyDurationMetricIdValue,
            [InstrumentName.DependencyInstrumentName] = MetricId.DependenciesPerSecondMetricIdValue,
            [InstrumentName.DependencySucceededPerSecondInstrumentName] = MetricId.DependencySucceededPerSecondMetricIdValue,
            [InstrumentName.DependencyFailedPerSecondInstrumentName] = MetricId.DependencyFailedPerSecondMetricIdValue,

            // EXCEPTIONS
            [InstrumentName.ExceptionsPerSecondInstrumentName] = MetricId.ExceptionsPerSecondMetricIdValue,

            // PERFORMANCE COUNTERS
            [InstrumentName.MemoryCommittedBytesInstrumentName] = MetricId.MemoryCommittedBytesMetricIdValue,
            [InstrumentName.ProcessorTimeInstrumentName] = MetricId.ProcessorTimeMetricIdValue,
        };
    }
}
