// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics
{
    /// <summary>
    /// EventSource for the AzureMonitorExporter.
    /// EventSource Guid at Runtime: bb5be13f-ec3a-5ab2-6a6a-0f881d6e0d5b.
    /// (This guid can be found by debugging this class and inspecting the "Log" singleton and reading the "Guid" property).
    /// </summary>
    /// <remarks>
    /// PerfView Instructions:
    /// <list type="bullet">
    /// <item>To collect all events: <code>PerfView.exe collect -MaxCollectSec:300 -NoGui /onlyProviders=*OpenTelemetry-AzureMonitor-Exporter</code></item>
    /// <item>To collect events based on LogLevel: <code>PerfView.exe collect -MaxCollectSec:300 -NoGui /onlyProviders:OpenTelemetry-AzureMonitor-Exporter::Verbose</code></item>
    /// </list>
    /// Dotnet-Trace Instructions:
    /// <list type="bullet">
    /// <item>To collect all events: <code>dotnet-trace collect --process-id PID --providers OpenTelemetry-AzureMonitor-Exporter</code></item>
    /// <item>To collect events based on LogLevel: <code>dotnet-trace collect --process-id PID --providers OpenTelemetry-AzureMonitor-Exporter::Verbose</code></item>
    /// </list>
    /// Logman Instructions:
    /// <list type="number">
    /// <item>Create a text file containing providers: <code>echo "{bb5be13f-ec3a-5ab2-6a6a-0f881d6e0d5b}" > providers.txt</code></item>
    /// <item>Start collecting: <code>logman -start exporter -pf providers.txt -ets -bs 1024 -nb 100 256</code></item>
    /// <item>Stop collecting: <code>logman -stop exporter -ets</code></item>
    /// </list>
    /// </remarks>
    [EventSource(Name = EventSourceName)]
    internal sealed class AzureMonitorExporterEventSource : EventSource
    {
        internal const string EventSourceName = "OpenTelemetry-AzureMonitor-Exporter";

        internal static readonly AzureMonitorExporterEventSource Log = new AzureMonitorExporterEventSource();
#if DEBUG
        internal static readonly AzureMonitorExporterEventListener Listener = new AzureMonitorExporterEventListener();
#endif

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool IsEnabled(EventLevel eventLevel) => IsEnabled(eventLevel, EventKeywords.All);

        [NonEvent]
        public void FailedToExport(string exporterName, string instrumentationKey, Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                FailedToExport(exporterName, instrumentationKey, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(6, Message = "{0} failed to export due to an exception. Instrumentation Key: {1}. {2}", Level = EventLevel.Error)]
        public void FailedToExport(string exporterName, string instrumentationKey, string exceptionMessage) => WriteEvent(6, exporterName, instrumentationKey, exceptionMessage);

        [NonEvent]
        public void FailedToTransmit(Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                FailedToTransmit(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(7, Message = "Failed to transmit due to an exception: {0}", Level = EventLevel.Error)]
        public void FailedToTransmit(string exceptionMessage) => WriteEvent(7, exceptionMessage);

        [NonEvent]
        public void TransmissionFailed(int statusCode, TelemetryItemOrigin origin, bool isAadEnabled, bool willRetry, ConnectionVars connectionVars, string? requestEndpoint, Response? response)
        {
            if (IsEnabled(EventLevel.Verbose))
            {
                var errorMessages = IngestionResponseHelper.GetErrorsFromResponse(response);

                if (errorMessages == null || errorMessages.Length == 0)
                {
                    TransmissionFailed(
                        statusCode: statusCode,
                        errorMessage: "N/A",
                        action: willRetry ? "Telemetry is stored offline for retry" : "Telemetry is dropped",
                        origin: origin.ToString(),
                        isAadEnabled: isAadEnabled,
                        instrumentationKey: connectionVars.InstrumentationKey,
                        configuredEndpoint: connectionVars.IngestionEndpoint,
                        actualEndpoint: requestEndpoint ?? "null");
                }
                else
                {
                    foreach (var error in errorMessages)
                    {
                        TransmissionFailed(
                            statusCode: statusCode,
                            errorMessage: error ?? "N/A",
                            action: willRetry ? "Telemetry is stored offline for retry" : "Telemetry is dropped",
                            origin: origin.ToString(),
                            isAadEnabled: isAadEnabled,
                            instrumentationKey: connectionVars.InstrumentationKey,
                            configuredEndpoint: connectionVars.IngestionEndpoint,
                            actualEndpoint: requestEndpoint ?? "null");
                    }
                }
            }
            else if (IsEnabled(EventLevel.Critical))
            {
                TransmissionFailed(
                    statusCode: statusCode,
                    errorMessage: "(To get exact error change LogLevel to Verbose)",
                    action: willRetry ? "Telemetry is stored offline for retry" : "Telemetry is dropped",
                    origin: origin.ToString(),
                    isAadEnabled: isAadEnabled,
                    instrumentationKey: connectionVars.InstrumentationKey,
                    configuredEndpoint: connectionVars.IngestionEndpoint,
                    actualEndpoint: requestEndpoint ?? "null");
            }
        }

        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Parameters to this method are primitive and are trimmer safe.")]
        [Event(8, Message = "Transmission failed. StatusCode: {0}. Error from Ingestion: {1}. Action: {2}. Origin: {3}. AAD Enabled: {4}. Instrumentation Key: {5}. Configured Endpoint: {6}. Actual Endpoint: {7}", Level = EventLevel.Critical)]
        public void TransmissionFailed(int statusCode, string errorMessage, string action, string origin, bool isAadEnabled, string instrumentationKey, string configuredEndpoint, string actualEndpoint)
            => WriteEvent(8, statusCode, errorMessage, action, origin, isAadEnabled, instrumentationKey, configuredEndpoint, actualEndpoint);

        [Event(9, Message = "{0} has been disposed.", Level = EventLevel.Informational)]
        public void DisposedObject(string name) => WriteEvent(9, name);

        [NonEvent]
        public void VmMetadataFailed(Exception ex)
        {
            if (IsEnabled(EventLevel.Informational))
            {
                VmMetadataFailed(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(10, Message = "Failed to get Azure VM Metadata due to an exception. This is only for internal telemetry and can safely be ignored. {0}", Level = EventLevel.Informational)]
        public void VmMetadataFailed(string exceptionMessage) => WriteEvent(10, exceptionMessage);

        [NonEvent]
        public void StatsbeatFailed(Exception ex)
        {
            if (IsEnabled(EventLevel.Informational))
            {
                StatsbeatFailed(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(11, Message = "Statsbeat failed to collect data due to an exception. This is only for internal telemetry and can safely be ignored. {0}", Level = EventLevel.Informational)]
        public void StatsbeatFailed(string exceptionMessage) => WriteEvent(11, exceptionMessage);

        [NonEvent]
        public void FailedToParseConnectionString(Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                FailedToParseConnectionString(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(12, Message = "Failed to parse ConnectionString due to an exception: {0}", Level = EventLevel.Error)]
        public void FailedToParseConnectionString(string exceptionMessage) => WriteEvent(12, exceptionMessage);

        [Event(13, Message = "Unsupported Metric Type '{0}' cannot be exported.", Level = EventLevel.Warning)]
        public void UnsupportedMetricType(string metricTypeName) => WriteEvent(13, metricTypeName);

        [NonEvent]
        public void FailedToConvertLogRecord(string instrumentationKey, Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                FailedToConvertLogRecord(instrumentationKey, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(14, Message = "Failed to convert Log Record due to an exception. This telemetry item will be lost. Instrumentation Key: {0}. {1}", Level = EventLevel.Error)]
        public void FailedToConvertLogRecord(string instrumentationKey, string exceptionMessage) => WriteEvent(14, instrumentationKey, exceptionMessage);

        [NonEvent]
        public void FailedToConvertMetricPoint(string meterName, string instrumentName, Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                FailedToConvertMetricPoint(meterName, instrumentName, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(15, Message = "Failed to convert Metric Point due to an exception. This telemetry item will be lost. MeterName: {0}. InstrumentName: {1}. {2}", Level = EventLevel.Error)]
        public void FailedToConvertMetricPoint(string meterName, string instrumentName, string exceptionMessage) => WriteEvent(15, meterName, instrumentName, exceptionMessage);

        [NonEvent]
        public void FailedToConvertActivity(string activitySourceName, string activityDisplayName, Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                FailedToConvertActivity(activitySourceName, activityDisplayName, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(16, Message = "Failed to convert Activity due to an exception. This telemetry item will be lost. ActivitySource: {0}. Activity: {1}. {2}", Level = EventLevel.Error)]
        public void FailedToConvertActivity(string activitySourceName, string activityDisplayName, string exceptionMessage) => WriteEvent(16, activitySourceName, activityDisplayName, exceptionMessage);

        [NonEvent]
        public void FailedToExtractActivityEvent(string activitySourceName, string activityDisplayName, Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                FailedToExtractActivityEvent(activitySourceName, activityDisplayName, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(17, Message = "Failed to extract Activity Event due to an exception. This telemetry item will be lost. ActivitySource: {0}. Activity: {1}. {2}", Level = EventLevel.Error)]
        public void FailedToExtractActivityEvent(string activitySourceName, string activityDisplayName, string exceptionMessage) => WriteEvent(17, activitySourceName, activityDisplayName, exceptionMessage);

        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Parameters to this method are primitive and are trimmer safe.")]
        [Event(18, Message = "Maximum count of {0} Activity Links reached. Excess Links are dropped. ActivitySource: {1}. Activity: {2}.", Level = EventLevel.Warning)]
        public void ActivityLinksIgnored(int maxLinksAllowed, string activitySourceName, string activityDisplayName) => WriteEvent(18, maxLinksAllowed, activitySourceName, activityDisplayName);

        [Event(19, Message = "Failed to parse redirect headers. Not user actionable.", Level = EventLevel.Warning)]
        public void RedirectHeaderParseFailed() => WriteEvent(19);

        [Event(20, Message = "Failed to parse redirect cache, using default. Not user actionable.", Level = EventLevel.Warning)]
        public void ParseRedirectCacheFailed() => WriteEvent(20);

        [NonEvent]
        public void ErrorCreatingStorageFolder(string path, Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                ErrorCreatingStorageFolder(path, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(21, Message = "Failed to create a storage directory at path '{0}' due to an exception. If a storage directory cannot be created, telemetry may be lost. {1}", Level = EventLevel.Error)]
        public void ErrorCreatingStorageFolder(string path, string exceptionMessage) => WriteEvent(21, path, exceptionMessage);

        [NonEvent]
        public void ErrorInitializingRoleInstanceToHostName(Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                ErrorInitializingRoleInstanceToHostName(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(22, Message = "Failed to initialize Role Instance due to an exception. Role Instance will be missing from telemetry. {0}", Level = EventLevel.Error)]
        public void ErrorInitializingRoleInstanceToHostName(string exceptionMessage) => WriteEvent(22, exceptionMessage);

        [NonEvent]
        public void ErrorInitializingPartOfSdkVersion(string typeName, Exception ex)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                ErrorInitializingPartOfSdkVersion(typeName, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(23, Message = "Failed to get Type version while initialize SDK version due to an exception. Not user actionable. Type: {0}. {1}", Level = EventLevel.Warning)]
        public void ErrorInitializingPartOfSdkVersion(string typeName, string exceptionMessage) => WriteEvent(23, typeName, exceptionMessage);

        [NonEvent]
        public void SdkVersionCreateFailed(Exception ex)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                SdkVersionCreateFailed(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(24, Message = "Failed to create an SDK version due to an exception. Not user actionable. {0}", Level = EventLevel.Warning)]
        public void SdkVersionCreateFailed(string exceptionMessage) => WriteEvent(24, exceptionMessage);

        [NonEvent]
        public void FailedToTransmitFromStorage(bool isAadEnabled, string instrumentationKey, Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                FailedToTransmitFromStorage(isAadEnabled, instrumentationKey, ex.FlattenException().ToInvariantString());
            }
        }

        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Parameters to this method are primitive and are trimmer safe.")]
        [Event(25, Message = "Failed to transmit from storage due to an exception. AAD Enabled: {0}. Instrumentation Key: {1}. {2}", Level = EventLevel.Error)]
        public void FailedToTransmitFromStorage(bool isAadEnabled, string instrumentationKey, string exceptionMessage) => WriteEvent(25, isAadEnabled, instrumentationKey, exceptionMessage);

        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Parameters to this method are primitive and are trimmer safe.")]
        [Event(26, Message = "Successfully transmitted a blob from storage. AAD Enabled: {0}. Instrumentation Key: {1}", Level = EventLevel.Verbose)]
        public void TransmitFromStorageSuccess(bool isAadEnabled, string instrumentationKey) => WriteEvent(26, isAadEnabled, instrumentationKey);

        [Event(27, Message = "HttpPipelineBuilder is built with AAD Credentials. TokenCredential: {0} Scope: {1}", Level = EventLevel.Informational)]
        public void SetAADCredentialsToPipeline(string credentialTypeName, string scope) => WriteEvent(27, credentialTypeName, scope);

        [Event(28, Message = "Storage initialized. Data for Instrumentation Key '{0}' will be stored at: {1}", Level = EventLevel.Informational)]
        public void InitializedPersistentStorage(string instrumentationKey, string storageDirectory) => WriteEvent(28, instrumentationKey, storageDirectory);

        [NonEvent]
        public void FailedToInitializePersistentStorage(string instrumentationKey, Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                FailedToInitializePersistentStorage(instrumentationKey, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(29, Message = "Failed to initialize PersistentStorage due to an exception. If a storage directory cannot be created, telemetry may be lost. Instrumentation Key: {0}. {1}", Level = EventLevel.Error)]
        public void FailedToInitializePersistentStorage(string instrumentationKey, string exceptionMessage) => WriteEvent(29, instrumentationKey, exceptionMessage);

        [Event(30, Message = "Statsbeat was disabled via environment variable.", Level = EventLevel.Informational)]
        public void StatsbeatDisabled() => WriteEvent(30);

        [NonEvent]
        public void ErrorInitializingStatsbeat(ConnectionVars connectionVars, Exception ex)
        {
            if (IsEnabled(EventLevel.Informational))
            {
                ErrorInitializingStatsbeat(connectionVars.InstrumentationKey, connectionVars.IngestionEndpoint, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(31, Message = "Failed to initialize Statsbeat due to an exception. This is only for internal telemetry and can safely be ignored. Instrumentation Key: {0}. Configured Endpoint: {1}. {2}", Level = EventLevel.Informational)]
        public void ErrorInitializingStatsbeat(string instrumentationKey, string configuredEndpoint, string exceptionMessage) => WriteEvent(31, instrumentationKey, configuredEndpoint, exceptionMessage);

        [NonEvent]
        public void TransmissionSuccess(TelemetryItemOrigin origin, bool isAadEnabled, string instrumentationKey)
        {
            if (IsEnabled(EventLevel.Verbose))
            {
                TransmissionSuccess(origin.ToString(), isAadEnabled, instrumentationKey);
            }
        }

        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Parameters to this method are primitive and are trimmer safe.")]
        [Event(32, Message = "Successfully transmitted a batch of telemetry Items. Origin: {0}. AAD: {1}. Instrumentation Key: {2}", Level = EventLevel.Verbose)]
        public void TransmissionSuccess(string origin, bool isAadEnabled, string instrumentationKey) => WriteEvent(32, origin, isAadEnabled, instrumentationKey);

        [NonEvent]
        public void TransmitterFailed(TelemetryItemOrigin origin, bool isAadEnabled, string instrumentationKey, Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                TransmitterFailed(origin.ToString(), isAadEnabled, instrumentationKey, ex.FlattenException().ToInvariantString());
            }
        }

        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Parameters to this method are primitive and are trimmer safe.")]
        [Event(33, Message = "Transmitter failed due to an exception. Origin: {0}. AAD: {1}. Instrumentation Key: {2}. {3}", Level = EventLevel.Error)]
        public void TransmitterFailed(string origin, bool isAadEnabled, string instrumentationKey, string exceptionMessage) => WriteEvent(33, origin, isAadEnabled, instrumentationKey, exceptionMessage);

        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Parameters to this method are primitive and are trimmer safe.")]
        [Event(34, Message = "Exporter encountered a transmission failure and will wait {0} milliseconds before transmitting again.", Level = EventLevel.Warning)]
        public void BackoffEnabled(double milliseconds) => WriteEvent(34, milliseconds);

        [NonEvent]
        public void FailedToDeserializeIngestionResponse(Exception ex)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                FailedToDeserializeIngestionResponse(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(35, Message = "Failed to deserialize response from ingestion due to an exception. Not user actionable. {0}", Level = EventLevel.Warning)]
        public void FailedToDeserializeIngestionResponse(string exceptionMessage) => WriteEvent(35, exceptionMessage);

        [Event(36, Message = "Version string exceeds expected length. This is only for internal telemetry and can safely be ignored. Type Name: {0}. Version: {1}", Level = EventLevel.Verbose)]
        public void VersionStringUnexpectedLength(string typeName, string value) => WriteEvent(36, typeName, value);

        [Event(37, Message = "Failed to delete telemetry from storage. This may result in duplicate telemetry if the file is processed again. Not user actionable.", Level = EventLevel.Warning)]
        public void DeletedFailed() => WriteEvent(37);

        [NonEvent]
        public void PartialContentResponseInvalid(int totalTelemetryItems, TelemetryErrorDetails error)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                PartialContentResponseInvalid(totalTelemetryItems, error.Index?.ToString() ?? "N/A", error.StatusCode?.ToString() ?? "N/A", error.Message);
            }
        }

        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Parameters to this method are primitive and are trimmer safe.")]
        [Event(38, Message = "Received a partial success from ingestion that does not match telemetry that was sent. Total telemetry items sent: {0}. Error Index: {1}. Error StatusCode: {2}. Error Message: {3}", Level = EventLevel.Warning)]
        public void PartialContentResponseInvalid(int totalTelemetryItems, string errorIndex, string errorStatusCode, string errorMessage) => WriteEvent(38, totalTelemetryItems, errorIndex, errorStatusCode, errorMessage);

        [NonEvent]
        public void PartialContentResponseUnhandled(TelemetryErrorDetails error)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                PartialContentResponseUnhandled(error.StatusCode?.ToString() ?? "N/A", error.Message);
            }
        }

        [Event(39, Message = "Received a partial success from ingestion. This status code is not handled and telemetry will be lost. Error StatusCode: {0}. Error Message: {1}", Level = EventLevel.Warning)]
        public void PartialContentResponseUnhandled(string errorStatusCode, string errorMessage) => WriteEvent(39, errorStatusCode, errorMessage);

        [NonEvent]
        public void FailedToAddScopeItem(string key, Exception ex)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                FailedToAddScopeItem(key, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(40, Message = "An exception {1} occurred while adding the scope value associated with the key {0}", Level = EventLevel.Warning)]
        public void FailedToAddScopeItem(string key, string exceptionMessage) => WriteEvent(40, key, exceptionMessage);

        [NonEvent]
        public void FailedToAddLogAttribute(string key, Exception ex)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                FailedToAddLogAttribute(key, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(41, Message = "An exception {1} occurred while adding the log attribute associated with the key {0}", Level = EventLevel.Warning)]
        public void FailedToAddLogAttribute(string key, string exceptionMessage) => WriteEvent(41, key, exceptionMessage);

        [NonEvent]
        public void FailedToReadEnvironmentVariables(Exception ex)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                FailedToReadEnvironmentVariables(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(42, Message = "Failed to read environment variables due to an exception. This may prevent the Exporter from initializing. {0}", Level = EventLevel.Warning)]
        public void FailedToReadEnvironmentVariables(string errorMessage) => WriteEvent(42, errorMessage);

        [NonEvent]
        public void ErrorAddingActivityTagsAsCustomProperties(Exception ex)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                ErrorAddingActivityTagsAsCustomProperties(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(43, Message = "Error while adding activity tags as custom property: {0}", Level = EventLevel.Warning)]
        public void ErrorAddingActivityTagsAsCustomProperties(string errorMessage) => WriteEvent(43, errorMessage);

        [NonEvent]
        public void ConfigureFailed(System.Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                ConfigureFailed(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(44, Message = "Failed to configure AzureMonitorExporterOptions using the connection string from environment variables due to an exception: {0}", Level = EventLevel.Error)]
        public void ConfigureFailed(string exceptionMessage) => WriteEvent(44, exceptionMessage);

        [Event(45, Message = "The {0} method received an AzureMonitorExporterOptions with EnableLiveMetrics set to true, which isn't supported. Note that LiveMetrics is only available via the UseAzureMonitorExporter API.", Level = EventLevel.Warning)]
        public void LiveMetricsNotSupported(string methodName) => WriteEvent(45, methodName);

        [NonEvent]
        public void CustomerSdkStatsTrackingFailed(string metricType, Exception ex)
        {
            if (IsEnabled(EventLevel.Informational))
            {
                CustomerSdkStatsTrackingFailed(metricType, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(46, Message = "Customer SDK stats tracking failed for metric type '{0}' due to an exception. This is only for internal telemetry and can safely be ignored. {1}", Level = EventLevel.Informational)]
        public void CustomerSdkStatsTrackingFailed(string metricType, string exceptionMessage) => WriteEvent(46, metricType, exceptionMessage);

        [Event(47, Message = "Customer SDK stats enabled with export interval of {0} milliseconds.", Level = EventLevel.Informational)]
        public void CustomerSdkStatsEnabled(int exportIntervalMilliseconds) => WriteEvent(47, exportIntervalMilliseconds);

        [NonEvent]
        public void CustomerSdkStatsInitializationFailed(Exception ex)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                CustomerSdkStatsInitializationFailed(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(48, Message = "Customer SDK stats initialization failed due to an exception. This is only for internal telemetry and can safely be ignored. {0}", Level = EventLevel.Warning)]
        public void CustomerSdkStatsInitializationFailed(string exceptionMessage) => WriteEvent(48, exceptionMessage);

        [Event(51, Message = "Failure to calculate CPU Counter. Unexpected negative timespan: PreviousCollectedTime: {0}. RecentCollectedTime: {1}. Not user actionable.", Level = EventLevel.Error)]
        public void ProcessCountersUnexpectedNegativeTimeSpan(long previousCollectedTime, long recentCollectedTime) => WriteEvent(46, previousCollectedTime, recentCollectedTime);

        [Event(52, Message = "Failure to calculate CPU Counter. Unexpected negative value: PreviousCollectedValue: {0}. RecentCollectedValue: {1}. Not user actionable.", Level = EventLevel.Error)]
        public void ProcessCountersUnexpectedNegativeValue(long previousCollectedValue, long recentCollectedValue) => WriteEvent(47, previousCollectedValue, recentCollectedValue);

        [Event(53, Message = "Calculated Cpu Counter: Period: {0}. DiffValue: {1}. CalculatedValue: {2}. ProcessorCount: {3}. NormalizedValue: {4}", Level = EventLevel.Verbose)]
        public void ProcessCountersCpuCounter(long period, long diffValue, double calculatedValue, int processorCount, double normalizedValue) => WriteEvent(48, period, diffValue, calculatedValue, processorCount, normalizedValue);

        [NonEvent]
        public void FailedToCollectProcessPrivateBytes(System.Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                FailedToCollectProcessPrivateBytes(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(54, Message = "Failed to collect Process Private Bytes due to an exception. {0}", Level = EventLevel.Warning)]
        public void FailedToCollectProcessPrivateBytes(string exceptionMessage) => WriteEvent(49, exceptionMessage);

        [NonEvent]
        public void FailedToCalculateRequestRate(Exception ex)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                FailedToCalculateRequestRate(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(55, Message = "Failed to calculate request rate due to an exception. {0}", Level = EventLevel.Warning)]
        public void FailedToCalculateRequestRate(string exceptionMessage) => WriteEvent(55, exceptionMessage);

        [NonEvent]
        public void FailedToCalculateExceptionRate(Exception ex)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                FailedToCalculateExceptionRate(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(56, Message = "Failed to calculate exception rate due to an exception. {0}", Level = EventLevel.Warning)]
        public void FailedToCalculateExceptionRate(string exceptionMessage) => WriteEvent(56, exceptionMessage);
    }
}
