// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.LiveMetrics
{
    internal static class LiveMetricConstants
    {
        internal const string LiveMetricMeterName = "LiveMetricMeterName";
        internal const string RequestDurationInstrumentName = "RequestDurationLiveMetric";
        internal const string RequestsInstrumentName = "RequestsLiveMetric";
        internal const string RequestsSucceededPerSecondInstrumentName = "RequestsSucceededPerSecondLiveMetric";
        internal const string RequestsFailedPerSecondInstrumentName = "RequestsFailedPerSecondLiveMetric";
        internal const string DependencyDurationInstrumentName = "DependencyDurationLiveMetric";
        internal const string DependencyInstrumentName = "DependencyLiveMetric";
        internal const string DependencySucceededPerSecondInstrumentName = "DependencySucceededPerSecondLiveMetric";
        internal const string DependencyFailedPerSecondInstrumentName = "DependencyFailedPerSecondLiveMetric";
        internal const string ExceptionsPerSecondInstrumentName = "ExceptionsPerSecondLiveMetric";
        internal const string MemoryCommittedBytesInstrumentName = "CommittedBytesLiveMetric";
        internal const string ProcessorTimeInstrumentName = "ProcessorTimeBytesLiveMetric";

        internal const string RequestDurationMetricIdValue = @"\ApplicationInsights\Request Duration";
        internal const string RequestsMetricIdValue = @"\ApplicationInsights\Requests/Sec";
        internal const string RequestsSucceededPerSecondMetricIdValue = @"\ApplicationInsights\Requests Succeeded/Sec";
        internal const string RequestsFailedPerSecondMetricIdValue = @"\ApplicationInsights\Requests Failed/Sec";
        internal const string DependencyDurationMetricIdValue = @"\ApplicationInsights\Dependency Call Duration";
        internal const string DependencyMetricIdValue = @"\ApplicationInsights\Dependency Calls/Sec";
        internal const string DependencySucceededPerSecondMetricIdValue = @"\ApplicationInsights\Dependency Calls Succeeded/Sec";
        internal const string DependencyFailedPerSecondMetricIdValue = @"\ApplicationInsights\Dependency Calls Failed/Sec";
        internal const string ExceptionsPerSecondMetricIdValue = @"\ApplicationInsights\Exceptions/Sec";
        internal const string MemoryCommittedBytesMetricIdValue = @"\Memory\Committed Bytes";
        internal const string ProcessorTimeMetricIdValue = @"\Processor(_Total)\% Processor Time";
    }
}
