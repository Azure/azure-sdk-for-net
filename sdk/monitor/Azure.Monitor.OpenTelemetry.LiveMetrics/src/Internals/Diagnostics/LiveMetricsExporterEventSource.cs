// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Diagnostics
{
    /// <summary>
    /// EventSource for the AzureMonitorExporter.
    /// EventSource Guid at Runtime: 72f5588f-fa1c-502e-0627-e13dd2bd67c9.
    /// (This guid can be found by debugging this class and inspecting the "Log" singleton and reading the "Guid" property).
    /// </summary>
    /// <remarks>
    /// PerfView Instructions:
    /// <list type="bullet">
    /// <item>To collect all events: <code>PerfView.exe collect -MaxCollectSec:300 -NoGui /onlyProviders=*OpenTelemetry-AzureMonitor-LiveMetrics</code></item>
    /// <item>To collect events based on LogLevel: <code>PerfView.exe collect -MaxCollectSec:300 -NoGui /onlyProviders:OpenTelemetry-AzureMonitor-LiveMetrics::Verbose</code></item>
    /// </list>
    /// Dotnet-Trace Instructions:
    /// <list type="bullet">
    /// <item>To collect all events: <code>dotnet-trace collect --process-id PID --providers OpenTelemetry-AzureMonitor-LiveMetrics</code></item>
    /// <item>To collect events based on LogLevel: <code>dotnet-trace collect --process-id PID --providers OpenTelemetry-AzureMonitor-LiveMetrics::Verbose</code></item>
    /// </list>
    /// Logman Instructions:
    /// <list type="number">
    /// <item>Create a text file containing providers: <code>echo "{72f5588f-fa1c-502e-0627-e13dd2bd67c9}" > providers.txt</code></item>
    /// <item>Start collecting: <code>logman -start exporter -pf providers.txt -ets -bs 1024 -nb 100 256</code></item>
    /// <item>Stop collecting: <code>logman -stop exporter -ets</code></item>
    /// </list>
    /// </remarks>
    [EventSource(Name = EventSourceName)]
    internal sealed class LiveMetricsExporterEventSource : EventSource
    {
        internal const string EventSourceName = "OpenTelemetry-AzureMonitor-LiveMetrics";

        internal static readonly LiveMetricsExporterEventSource Log = new LiveMetricsExporterEventSource();

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool IsEnabled(EventLevel eventLevel) => IsEnabled(eventLevel, EventKeywords.All);

        [NonEvent]
        public void FailedToParseConnectionString(System.Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                FailedToParseConnectionString(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(1, Message = "Failed to parse ConnectionString due to an exception: {0}", Level = EventLevel.Error)]
        public void FailedToParseConnectionString(string exceptionMessage) => WriteEvent(1, exceptionMessage);

        [NonEvent]
        public void FailedToReadEnvironmentVariables(System.Exception ex)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                FailedToReadEnvironmentVariables(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(2, Message = "Failed to read environment variables due to an exception. This may prevent the Exporter from initializing. {0}", Level = EventLevel.Warning)]
        public void FailedToReadEnvironmentVariables(string errorMessage) => WriteEvent(2, errorMessage);

        [NonEvent]
        public void AccessingEnvironmentVariableFailedWarning(string environmentVariable, System.Exception ex)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                AccessingEnvironmentVariableFailedWarning(environmentVariable, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(3, Message = "Accessing environment variable - {0} failed with exception: {1}.", Level = EventLevel.Warning)]
        public void AccessingEnvironmentVariableFailedWarning(string environmentVariable, string exceptionMessage) => WriteEvent(3, environmentVariable, exceptionMessage);

        [NonEvent]
        public void SdkVersionCreateFailed(System.Exception ex)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                SdkVersionCreateFailed(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(4, Message = "Failed to create an SDK version due to an exception. Not user actionable. {0}", Level = EventLevel.Warning)]
        public void SdkVersionCreateFailed(string exceptionMessage) => WriteEvent(4, exceptionMessage);

        [Event(5, Message = "Version string exceeds expected length. This is only for internal telemetry and can safely be ignored. Type Name: {0}. Version: {1}", Level = EventLevel.Verbose)]
        public void VersionStringUnexpectedLength(string typeName, string value) => WriteEvent(5, typeName, value);

        [NonEvent]
        public void ErrorInitializingPartOfSdkVersion(string typeName, System.Exception ex)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                ErrorInitializingPartOfSdkVersion(typeName, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(6, Message = "Failed to get Type version while initialize SDK version due to an exception. Not user actionable. Type: {0}. {1}", Level = EventLevel.Warning)]
        public void ErrorInitializingPartOfSdkVersion(string typeName, string exceptionMessage) => WriteEvent(6, typeName, exceptionMessage);

        [Event(7, Message = "HttpPipelineBuilder is built with AAD Credentials. TokenCredential: {0} Scope: {1}", Level = EventLevel.Informational)]
        public void SetAADCredentialsToPipeline(string credentialTypeName, string scope) => WriteEvent(7, credentialTypeName, scope);

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

        [Event(8, Message = "Service call failed. Name: {0}. Status Code: {1} Reason: {2}.", Level = EventLevel.Error)]
        public void ServiceCallFailed(string name, int statusCode, string reasonPhrase) => WriteEvent(8, name, statusCode, reasonPhrase);

        [Event(9, Message = "Service call failed with exception. Name: {0}. Exception: {1}", Level = EventLevel.Error)]
        public void ServiceCallFailedWithUnknownException(string name, string exceptionMessage) => WriteEvent(9, name, exceptionMessage);

        [Event(10, Message = "Service call failed. Name: {0}. Status Code: {1}. Code: {2}. Message: {3}. Exception: {4}.", Level = EventLevel.Error)]
        public void ServiceCallFailedWithServiceError(string name, int statusCode, string code, string message, string exception) => WriteEvent(10, name, statusCode, code, message, exception);

        [NonEvent]
        public void StateMachineFailedWithUnknownException(System.Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                StateMachineFailedWithUnknownException(ex.ToInvariantString());
            }
        }

        [Event(11, Message = "LiveMetrics State Machine failed with exception: {0}", Level = EventLevel.Error)]
        public void StateMachineFailedWithUnknownException(string exceptionMessage) => WriteEvent(11, exceptionMessage);

        [NonEvent]
        public void DroppedDocument(DocumentIngressDocumentType documentType)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                DroppedDocument(documentType.ToString());
            }
        }

        [Event(12, Message = "Document was dropped. DocumentType: {0}. Not user actionable.", Level = EventLevel.Warning)]
        public void DroppedDocument(string documentType) => WriteEvent(12, documentType);
    }
}
