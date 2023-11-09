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
    }
}
