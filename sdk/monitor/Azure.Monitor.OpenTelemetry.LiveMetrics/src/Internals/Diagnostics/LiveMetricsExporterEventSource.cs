// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Diagnostics
{
    [EventSource(Name = EventSourceName)]
    internal sealed class LiveMetricsExporterEventSource : EventSource
    {
        internal const string EventSourceName = "OpenTelemetry-AzureMonitor-LiveMetrics-Exporter";

        internal static readonly LiveMetricsExporterEventSource Log = new LiveMetricsExporterEventSource();

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool IsEnabled(EventLevel eventLevel) => IsEnabled(eventLevel, EventKeywords.All);

        [NonEvent]
        public void FailedToParseConnectionString(Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                FailedToParseConnectionString(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(1, Message = "Failed to parse ConnectionString due to an exception: {0}", Level = EventLevel.Error)]
        public void FailedToParseConnectionString(string exceptionMessage) => WriteEvent(1, exceptionMessage);

        [NonEvent]
        public void FailedToReadEnvironmentVariables(Exception ex)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                FailedToReadEnvironmentVariables(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(2, Message = "Failed to read environment variables due to an exception. This may prevent the Exporter from initializing. {0}", Level = EventLevel.Warning)]
        public void FailedToReadEnvironmentVariables(string errorMessage) => WriteEvent(2, errorMessage);
    }
}
