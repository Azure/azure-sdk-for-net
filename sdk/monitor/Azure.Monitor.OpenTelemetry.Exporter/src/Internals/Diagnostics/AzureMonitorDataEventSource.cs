// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System.Text;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics
{
    /// <summary>
    /// EventSource for the AzureMonitor Telemetry.
    /// This can be used to collect telemetry that should be emitted by the exporter.
    /// EventSource Guid at Runtime: cf17323b-4fb7-53b5-2824-934d0ce75082.
    /// </summary>
    /// <remarks>
    /// PerfView Instructions:
    /// <list type="bullet">
    /// <item>To collect all events: <code>PerfView.exe collect -MaxCollectSec:300 -NoGui /onlyProviders=*AzureMonitor-Exporter-Data</code></item>
    /// <item>To collect events based on LogLevel: <code>PerfView.exe collect -MaxCollectSec:300 -NoGui /onlyProviders:AzureMonitor-Exporter-Data::Verbose</code></item>
    /// </list>
    /// Dotnet-Trace Instructions:
    /// <list type="bullet">
    /// <item>To collect all events: <code>dotnet-trace collect --process-id PID --providers AzureMonitor-Exporter-Data</code></item>
    /// <item>To collect events based on LogLevel: <code>dotnet-trace collect --process-id PID --providers AzureMonitor-Exporter-Data::Verbose</code></item>
    /// </list>
    /// Logman Instructions:
    /// <list type="number">
    /// <item>Create a text file containing providers: <code>echo "{cf17323b-4fb7-53b5-2824-934d0ce75082}" > providers.txt</code></item>
    /// <item>Start collecting: <code>logman -start exporter -pf providers.txt -ets -bs 1024 -nb 100 256</code></item>
    /// <item>Stop collecting: <code>logman -stop exporter -ets</code></item>
    /// </list>
    /// </remarks>
    [EventSource(Name = EventSourceName)]
    internal sealed class AzureMonitorDataEventSource : EventSource
    {
        internal const string EventSourceName = "AzureMonitor-Exporter-Data";

        internal static readonly AzureMonitorDataEventSource Log = new AzureMonitorDataEventSource();

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool IsEnabled(EventLevel eventLevel) => IsEnabled(eventLevel, EventKeywords.All);

        [NonEvent]
        public void Telemetry(NDJsonWriter content)
        {
            if (IsEnabled(EventLevel.Verbose))
            {
                Telemetry(content.ToString());
            }
        }

        [Event(1, Message = "{0}", Level = EventLevel.Verbose)]
        public void Telemetry(string telemetry) => WriteEvent(1, telemetry);

        [NonEvent]
        public void TelemetryFromStorage(ReadOnlyMemory<byte> content)
        {
            if (IsEnabled(EventLevel.Verbose))
            {
                TelemetryFromStorage(Encoding.UTF8.GetString(content.ToArray()));
            }
        }

        [Event(2, Message = "{0}", Level = EventLevel.Verbose)]
        public void TelemetryFromStorage(string telemetry) => WriteEvent(2, telemetry);
    }
}
