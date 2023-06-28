// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics
{
    [EventSource(Name = EventSourceName)]
    internal sealed partial class AzureMonitorExporterEventSource : EventSource
    {
        internal const string EventSourceName = "OpenTelemetry-AzureMonitor-Exporter";

        internal static readonly AzureMonitorExporterEventSource Log = new AzureMonitorExporterEventSource();
        internal static readonly AzureMonitorExporterEventListener Listener = new AzureMonitorExporterEventListener();

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal bool IsEnabled(EventLevel eventLevel) => IsEnabled(eventLevel, EventKeywords.All);
    }
}
