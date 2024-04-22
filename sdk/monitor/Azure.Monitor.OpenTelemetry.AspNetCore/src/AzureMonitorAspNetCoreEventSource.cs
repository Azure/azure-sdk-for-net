// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using Azure.Monitor.OpenTelemetry.AspNetCore.Models;
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

        [NonEvent]
        public void GetEnvironmentVariableFailed(string envVarName, System.Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                GetEnvironmentVariableFailed(envVarName, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(5, Message = "Failed to Read environment variable {0}, exception: {1}", Level = EventLevel.Error)]
        public void GetEnvironmentVariableFailed(string envVarName, string exceptionMessage) => WriteEvent(5, envVarName, exceptionMessage);

        [Event(6, Message = "Failed to map unknown EventSource log level in AzureEventSourceLogForwarder {0}", Level = EventLevel.Warning)]
        public void MapLogLevelFailed(string level) => WriteEvent(6, level);

        [Event(7, Message = "Found existing Microsoft.Extensions.Azure.AzureEventSourceLogForwarder registration.", Level = EventLevel.Informational)]
        public void LogForwarderIsAlreadyRegistered() => WriteEvent(7);

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
        public void AccessingEnvironmentVariableFailedWarning(string environmentVariable, System.Exception ex)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                AccessingEnvironmentVariableFailedWarning(environmentVariable, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(10, Message = "Accessing environment variable - {0} failed with exception: {1}.", Level = EventLevel.Warning)]
        public void AccessingEnvironmentVariableFailedWarning(string environmentVariable, string exceptionMessage) => WriteEvent(10, environmentVariable, exceptionMessage);

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

        [Event(14, Message = "HttpPipelineBuilder is built with AAD Credentials. TokenCredential: {0} Scope: {1}", Level = EventLevel.Informational)]
        public void SetAADCredentialsToPipeline(string credentialTypeName, string scope) => WriteEvent(14, credentialTypeName, scope);

        [NonEvent]
        public void PingFailed(Response response)
        {
            if (IsEnabled(EventLevel.Error))
            {
                ServiceCallFailed(name: "Ping", response.Status, response.ReasonPhrase);
            }
        }

        [NonEvent]
        public void PostFailed(Response response)
        {
            if (IsEnabled(EventLevel.Error))
            {
                ServiceCallFailed(name: "Post", response.Status, response.ReasonPhrase);
            }
        }

        [NonEvent]
        public void PingFailedWithUnknownException(System.Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                ServiceCallFailedWithUnknownException(name: "Ping", ex.ToInvariantString());
            }
        }

        [NonEvent]
        public void PostFailedWithUnknownException(System.Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                ServiceCallFailedWithUnknownException(name: "Post", ex.ToInvariantString());
            }
        }

        [NonEvent]
        public void PingFailedWithServiceError(int statusCode, ServiceError serviceError)
        {
            if (IsEnabled(EventLevel.Error))
            {
                ServiceCallFailedWithServiceError(name: "Ping", statusCode, serviceError.Code, serviceError.Exception, serviceError.Message);
            }
        }

        [NonEvent]
        public void PostFailedWithServiceError(int statusCode, ServiceError serviceError)
        {
            if (IsEnabled(EventLevel.Error))
            {
                ServiceCallFailedWithServiceError(name: "Post", statusCode, serviceError.Code, serviceError.Exception, serviceError.Message);
            }
        }

        [Event(15, Message = "Service call failed. Name: {0}. Status Code: {1} Reason: {2}.", Level = EventLevel.Error)]
        public void ServiceCallFailed(string name, int statusCode, string reasonPhrase) => WriteEvent(15, name, statusCode, reasonPhrase);

        [Event(16, Message = "Service call failed with exception. Name: {0}. Exception: {1}", Level = EventLevel.Error)]
        public void ServiceCallFailedWithUnknownException(string name, string exceptionMessage) => WriteEvent(16, name, exceptionMessage);

        [Event(17, Message = "Service call failed. Name: {0}. Status Code: {1}. Code: {2}. Message: {3}. Exception: {4}.", Level = EventLevel.Error)]
        public void ServiceCallFailedWithServiceError(string name, int statusCode, string code, string message, string exception) => WriteEvent(17, name, statusCode, code, message, exception);

        [NonEvent]
        public void StateMachineFailedWithUnknownException(System.Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                StateMachineFailedWithUnknownException(ex.ToInvariantString());
            }
        }

        [Event(18, Message = "LiveMetrics State Machine failed with exception: {0}", Level = EventLevel.Error)]
        public void StateMachineFailedWithUnknownException(string exceptionMessage) => WriteEvent(18, exceptionMessage);

        [NonEvent]
        public void DroppedDocument(DocumentType documentType)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                DroppedDocument(documentType.ToString());
            }
        }

        [Event(19, Message = "Document was dropped. DocumentType: {0}. Not user actionable.", Level = EventLevel.Warning)]
        public void DroppedDocument(string documentType) => WriteEvent(19, documentType);

        [Event(20, Message = "Failure to calculate CPU Counter. Unexpected negative timespan: PreviousCollectedTime: {0}. RecentCollectedTime: {0}. Not user actionable.", Level = EventLevel.Error)]
        public void ProcessCountersUnexpectedNegativeTimeSpan(long previousCollectedTime, long recentCollectedTime) => WriteEvent(20, previousCollectedTime, recentCollectedTime);

        [Event(21, Message = "Failure to calculate CPU Counter. Unexpected negative value: PreviousCollectedValue: {0}. RecentCollectedValue: {0}. Not user actionable.", Level = EventLevel.Error)]
        public void ProcessCountersUnexpectedNegativeValue(long previousCollectedValue, long recentCollectedValue) => WriteEvent(21, previousCollectedValue, recentCollectedValue);

        [Event(22, Message = "Calculated Cpu Counter: Period: {0}. DiffValue: {1}. CalculatedValue: {2}. ProcessorCount: {3}. NormalizedValue: {4}", Level = EventLevel.Verbose)]
        public void ProcessCountersCpuCounter(long period, long diffValue, double calculatedValue, int processorCount, double normalizedValue) => WriteEvent(22, period, diffValue, calculatedValue, processorCount, normalizedValue);

        [NonEvent]
        public void FailedToCreateTelemetryDocument(string documentTypeName, System.Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                FailedToCreateTelemetryDocument(documentTypeName, ex.ToInvariantString());
            }
        }

        [Event(23, Message = "Failed to create telemetry document due to an exception. DocumentType: {0}. Exception: {1}", Level = EventLevel.Error)]
        public void FailedToCreateTelemetryDocument(string documentTypeName, string exceptionMessage) => WriteEvent(23, documentTypeName, exceptionMessage);
    }
}
