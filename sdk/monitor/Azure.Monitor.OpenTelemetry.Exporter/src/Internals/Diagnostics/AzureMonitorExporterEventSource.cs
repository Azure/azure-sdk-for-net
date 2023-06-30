// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics
{
    [EventSource(Name = EventSourceName)]
    internal sealed class AzureMonitorExporterEventSource : EventSource
    {
        internal const string EventSourceName = "OpenTelemetry-AzureMonitor-Exporter";

        internal static readonly AzureMonitorExporterEventSource Log = new AzureMonitorExporterEventSource();
        internal static readonly AzureMonitorExporterEventListener Listener = new AzureMonitorExporterEventListener();

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
        public void TransmissionFailed(bool fromStorage, int statusCode, ConnectionVars connectionVars, string? requestEndpoint, bool willRetry)
        {
            // TODO: INCLUDE EXACT ERROR MESSAGE FROM INGESTION
            if (IsEnabled(EventLevel.Error))
            {
                TransmissionFailed(
                    message: fromStorage ? "Transmission from storage failed." : "Transmission failed.",
                    retryDetails: willRetry ? "Telemetry is stored offline for retry." : "Telemetry is dropped.",
                    metaData: $"Instrumentation Key: {connectionVars.InstrumentationKey}, Configured Endpoint: {connectionVars.IngestionEndpoint}, Actual Endpoint: {requestEndpoint}"
                    );
            }
        }

        [Event(8, Message = "{0} {1} {2}", Level = EventLevel.Error)]
        public void TransmissionFailed(string message, string retryDetails, string metaData) => WriteEvent(8, message, retryDetails, metaData);

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

        [Event(10, Message = "Failed to get Azure VM Metadata due to an exception. If not hosted in an Azure VM this can safely be ignored. {0}", Level = EventLevel.Informational)]
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
        public void FailedToTransmitFromStorage(string instrumentationKey, Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                FailedToTransmitFromStorage(instrumentationKey, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(25, Message = "Failed to transmit from storage due to an exception. Instrumentation Key: {0}. {1}", Level = EventLevel.Error)]
        public void FailedToTransmitFromStorage(string instrumentationKey, string exceptionMessage) => WriteEvent(25, instrumentationKey, exceptionMessage);

        [Event(26, Message = "Successfully transmitted a blob from storage. Instrumentation Key: {0}", Level = EventLevel.Verbose)]
        public void TransmitFromStorageSuccess(string instrumentationKey) => WriteEvent(26, instrumentationKey);

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
        public void ErrorInitializingStatsbeat(string instrumentationKey, Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                ErrorInitializingStatsbeat(instrumentationKey, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(31, Message = "Failed to initialize Statsbeat due to an exception. Instrumentation Key: {0}. {1}", Level = EventLevel.Error)]
        public void ErrorInitializingStatsbeat(string instrumentationKey, string exceptionMessage) => WriteEvent(31, instrumentationKey, exceptionMessage);

        [Event(32, Message = "Successfully transmitted a batch of telemetry Items. Instrumentation Key: {0}", Level = EventLevel.Verbose)]
        public void TransmissionSuccess(string instrumentationKey) => WriteEvent(32, instrumentationKey);

        [NonEvent]
        public void TransmitterFailed(string instrumentationKey, Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                TransmitterFailed(instrumentationKey, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(33, Message = "Transmitter failed due to an exception. Instrumentation Key: {0}. {1}", Level = EventLevel.Error)]
        public void TransmitterFailed(string instrumentationKey, string exceptionMessage) => WriteEvent(33, instrumentationKey, exceptionMessage);

        [Event(34, Message = "Exporter encountered a transmission failure and will wait {0} milliseconds before transmitting again.", Level = EventLevel.Warning)]
        public void BackoffEnabled(double milliseconds) => WriteEvent(34, milliseconds);
    }
}
