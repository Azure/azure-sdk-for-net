// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics
{
    /// <summary>
    /// EventSource for the AzureMonitorExporter.
    /// EventSource Guid at Runtime: 05a8426d-9325-5bb7-5ceb-eeaa32afdc16.
    /// (This guid can be found by debugging this class and inspecting the "Log" singleton and reading the "Guid" property).
    /// </summary>
    /// <remarks>
    /// PerfView Instructions:
    /// <list type="bullet">
    /// <item>To collect all events: <code>PerfView.exe collect -MaxCollectSec:300 -NoGui /onlyProviders=*Azure.Monitor.OpenTelemetry.Exporter-Data</code></item>
    /// <item>To collect events based on LogLevel: <code>PerfView.exe collect -MaxCollectSec:300 -NoGui /onlyProviders:Azure.Monitor.OpenTelemetry.Exporter-Data::Verbose</code></item>
    /// </list>
    /// Dotnet-Trace Instructions:
    /// <list type="bullet">
    /// <item>To collect all events: <code>dotnet-trace collect --process-id PID --providers Azure.Monitor.OpenTelemetry.Exporter-Data</code></item>
    /// <item>To collect events based on LogLevel: <code>dotnet-trace collect --process-id PID --providers Azure.Monitor.OpenTelemetry.Exporter-Data::Verbose</code></item>
    /// </list>
    /// Logman Instructions:
    /// <list type="number">
    /// <item>Create a text file containing providers: <code>echo "{05a8426d-9325-5bb7-5ceb-eeaa32afdc16}" > providers.txt</code></item>
    /// <item>Start collecting: <code>logman -start exporter -pf providers.txt -ets -bs 1024 -nb 100 256</code></item>
    /// <item>Stop collecting: <code>logman -stop exporter -ets</code></item>
    /// </list>
    /// </remarks>
    [EventSource(Name = EventSourceName)]
    internal sealed class AzureMonitorOpenTelemetryExporterDataEventSource : EventSource
    {
        internal const string EventSourceName = "Azure.Monitor.OpenTelemetry.Exporter-Data";

        internal static readonly AzureMonitorOpenTelemetryExporterDataEventSource Log = new AzureMonitorOpenTelemetryExporterDataEventSource();

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool IsEnabled(EventLevel eventLevel) => IsEnabled(eventLevel, EventKeywords.All);

        [NonEvent]
        public void TelemetryItem(IEnumerable<TelemetryItem> telemetryItems)
        {
            if (IsEnabled(EventLevel.Verbose))
            {
                foreach (var item in telemetryItems)
                {
                    using var content = new NDJsonWriter();
                    content.JsonWriter.WriteObjectValue(item);
                    content.WriteNewLine();
                    TelemetryItem(content.ToString());
                }
            }
        }

        [Event(1, Message = "{0}", Level = EventLevel.Verbose)]
        public void TelemetryItem(string telemetryItem) => WriteEvent(1, telemetryItem);
    }
}
