// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        public void MapLogLevelFailed(EventLevel level)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                MapLogLevelFailed(level.ToString());
            }
        }

        [NonEvent]
        public void ConfigureFailed(System.Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                ConfigureFailed(ex.FlattenException().ToInvariantString());
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

        [Event(5, Message = "Failed to map unknown EventSource log level in AzureEventSourceLogForwarder {0}", Level = EventLevel.Warning)]
        public void MapLogLevelFailed(string level) => WriteEvent(5, level);

        [Event(6, Message = "Found existing Microsoft.Extensions.Azure.AzureEventSourceLogForwarder registration.", Level = EventLevel.Informational)]
        public void LogForwarderIsAlreadyRegistered() => WriteEvent(6);

        [NonEvent]
        public void FailedToParseConnectionString(System.Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                FailedToParseConnectionString(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(8, Message = "Failed to parse ConnectionString due to an exception: {0}", Level = EventLevel.Error)]
        public void FailedToParseConnectionString(string exceptionMessage) => WriteEvent(8, exceptionMessage);

        [NonEvent]
        public void FailedToReadEnvironmentVariables(System.Exception ex)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                FailedToReadEnvironmentVariables(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(9, Message = "Failed to read environment variables due to an exception. This may prevent the Exporter from initializing. {0}", Level = EventLevel.Warning)]
        public void FailedToReadEnvironmentVariables(string errorMessage) => WriteEvent(9, errorMessage);

        [NonEvent]
        public void SdkVersionCreateFailed(System.Exception ex)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                SdkVersionCreateFailed(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(11, Message = "Failed to create an SDK version due to an exception. Not user actionable. {0}", Level = EventLevel.Warning)]
        public void SdkVersionCreateFailed(string exceptionMessage) => WriteEvent(11, exceptionMessage);

        [Event(12, Message = "Version string exceeds expected length. This is only for internal telemetry and can safely be ignored. Type Name: {0}. Version: {1}", Level = EventLevel.Verbose)]
        public void VersionStringUnexpectedLength(string typeName, string value) => WriteEvent(12, typeName, value);

        [NonEvent]
        public void ErrorInitializingPartOfSdkVersion(string typeName, System.Exception ex)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                ErrorInitializingPartOfSdkVersion(typeName, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(13, Message = "Failed to get Type version while initialize SDK version due to an exception. Not user actionable. Type: {0}. {1}", Level = EventLevel.Warning)]
        public void ErrorInitializingPartOfSdkVersion(string typeName, string exceptionMessage) => WriteEvent(13, typeName, exceptionMessage);

        [Event(14, Message = "Invalid sampler type '{0}'. Supported values: microsoft.rate_limited, microsoft.fixed_percentage", Level = EventLevel.Warning)]
        public void InvalidSamplerType(string samplerType) => WriteEvent(14, samplerType);

        [Event(15, Message = "Invalid sampler argument '{1}' for sampler '{0}'. Ignoring.", Level = EventLevel.Warning)]
        public void InvalidSamplerArgument(string samplerType, string samplerArg) => WriteEvent(15, samplerType, samplerArg);
    }
}
