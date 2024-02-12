// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;

namespace Azure.Monitor.OpenTelemetry.AspNetCore
{
    /// <summary>
    /// EventSource for the AzureMonitor AspNetCore Distro.
    /// EventSource Guid at Runtime: 928cf0a7-3e20-5f5d-a14f-0e62fdc972e6.
    /// (This guid can be found by debugging this class and inspecting the "Log" singleton and reading the "Guid" property).
    /// </summary>
    /// <remarks>
    /// PerfView Instructions:
    /// <list type="bullet">
    /// <item>To collect all events: <code>PerfView.exe collect -MaxCollectSec:300 -NoGui /onlyProviders=*OpenTelemetry-AzureMonitor-AspNetCore</code></item>
    /// <item>To collect events based on LogLevel: <code>PerfView.exe collect -MaxCollectSec:300 -NoGui /onlyProviders:OpenTelemetry-AzureMonitor-AspNetCore::Verbose</code></item>
    /// </list>
    /// Dotnet-Trace Instructions:
    /// <list type="bullet">
    /// <item>To collect all events: <code>dotnet-trace collect --process-id PID --providers OpenTelemetry-AzureMonitor-AspNetCore</code></item>
    /// <item>To collect events based on LogLevel: <code>dotnet-trace collect --process-id PID --providers OpenTelemetry-AzureMonitor-AspNetCore::Verbose</code></item>
    /// </list>
    /// Logman Instructions:
    /// <list type="number">
    /// <item>Create a text file containing providers: <code>echo "{928cf0a7-3e20-5f5d-a14f-0e62fdc972e6}" > providers.txt</code></item>
    /// <item>Start collecting: <code>logman -start exporter -pf providers.txt -ets -bs 1024 -nb 100 256</code></item>
    /// <item>Stop collecting: <code>logman -stop exporter -ets</code></item>
    /// </list>
    /// </remarks>
    [EventSource(Name = EventSourceName)]
    internal sealed class AzureMonitorAspNetCoreEventSource : EventSource
    {
        internal const string EventSourceName = "OpenTelemetry-AzureMonitor-AspNetCore";

        internal static readonly AzureMonitorAspNetCoreEventSource Log = new AzureMonitorAspNetCoreEventSource();

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool IsEnabled(EventLevel eventLevel) => IsEnabled(eventLevel, EventKeywords.All);

        [NonEvent]
        public void ConfigureFailed(Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                ConfigureFailed(ex.FlattenException().ToInvariantString());
            }
        }

        [NonEvent]
        public void GetEnvironmentVariableFailed(string envVarName, Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                GetEnvironmentVariableFailed(envVarName, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(1, Message = "Failed to configure AzureMonitorOptions using the connection string from environment variables due to an exception: {0}", Level = EventLevel.Error)]
        public void ConfigureFailed(string exceptionMessage) => WriteEvent(1, exceptionMessage);

        [Event(2, Message = "Package reference for {0} found. Backing off from default included instrumentation. Action Required: You must manually configure this instrumentation.", Level = EventLevel.Warning)]
        public void FoundInstrumentationPackageReference(string packageName) => WriteEvent(2, packageName);

        [Event(3, Message = "No instrumentation package found with name: {0}.", Level = EventLevel.Verbose)]
        public void NoInstrumentationPackageReference(string packageName) => WriteEvent(3, packageName);

        [Event(4, Message = "Vendor instrumentation added for: {0}.", Level = EventLevel.Verbose)]
        public void VendorInstrumentationAdded(string packageName) => WriteEvent(4, packageName);

        [Event(5, Message = "Failed to Read environment variable {0}, exception: {1}", Level = EventLevel.Error)]
        public void GetEnvironmentVariableFailed(string envVarName, string exceptionMessage) => WriteEvent(5, envVarName, exceptionMessage);
    }
}
