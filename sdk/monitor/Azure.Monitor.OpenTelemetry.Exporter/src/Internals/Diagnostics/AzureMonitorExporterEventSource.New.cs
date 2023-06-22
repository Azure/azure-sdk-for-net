// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics
{
    internal sealed partial class AzureMonitorExporterEventSource : EventSource
    {
        [NonEvent]
        public void FailedToExport(Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                FailedToExport(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(6, Message = "Failed to export due to an exception: {0}", Level = EventLevel.Error)]
        public void FailedToExport(string exceptionMessage) => WriteEvent(6, exceptionMessage);

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
        public void DisposedObject(string name)
        {
            if (IsEnabled(EventLevel.Informational))
            {
                WriteEvent(9, name);
            }
        }

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
        public void UnsupportedMetricType(string metricTypeName)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                WriteEvent(13, metricTypeName);
            }
        }

        [NonEvent]
        public void FailedToConvertLogRecord(Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                FailedToConvertLogRecord(ex.FlattenException().ToInvariantString());
            }
        }

        [Event(14, Message = "Failed to convert Log Record due to an exception: {0}", Level = EventLevel.Error)]
        public void FailedToConvertLogRecord(string exceptionMessage) => WriteEvent(14, exceptionMessage);

        [NonEvent]
        public void FailedToConvertMetricPoint(string meterName, string instrumentName, Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                FailedToConvertMetricPoint(meterName, instrumentName, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(15, Message = "Failed to convert Metric Point due to an exception. MeterName: {0}. InstrumentName: {1}. {2}", Level = EventLevel.Error)]
        public void FailedToConvertMetricPoint(string meterName, string instrumentName, string exceptionMessage) => WriteEvent(15, meterName, instrumentName, exceptionMessage);

        [NonEvent]
        public void FailedToConvertActivity(string activityDisplayName, Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                FailedToConvertActivity(activityDisplayName, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(16, Message = "Failed to convert Activity due to an exception. Activity: {0}. {1}", Level = EventLevel.Error)]
        public void FailedToConvertActivity(string activityDisplayName, string exceptionMessage) => WriteEvent(16, activityDisplayName, exceptionMessage);

        [NonEvent]
        public void FailedToExtractActivityEvent(string activityDisplayName, Exception ex)
        {
            if (IsEnabled(EventLevel.Error))
            {
                FailedToExtractActivityEvent(activityDisplayName, ex.FlattenException().ToInvariantString());
            }
        }

        [Event(17, Message = "Failed to extract Activity Event due to an exception. Activity: {0}. {1}", Level = EventLevel.Error)]
        public void FailedToExtractActivityEvent(string activityDisplayName, string exceptionMessage) => WriteEvent(17, activityDisplayName, exceptionMessage);

        [Event(18, Message = "Maximum count of {0} Activity Links reached. Excess Links are dropped. Activity: {1}. ", Level = EventLevel.Warning)]
        public void ActivityLinksIgnored(int maxLinksAllowed, string activityDisplayName)
        {
            if (IsEnabled(EventLevel.Warning))
            {
                WriteEvent(18, maxLinksAllowed, activityDisplayName);
            }
        }
    }
}
