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
            if (IsEnabled(EventLevel.Warning))
            {
                TransmissionFailed(
                    message: fromStorage ? "Transmission from storage failed." : "Transmission failed.",
                    retryDetails: willRetry ? "Telemetry is stored offline for retry." : "Telemetry is dropped.",
                    metaData: $"Instrumentation Key: {connectionVars.InstrumentationKey}, Configured Endpoint: {connectionVars.IngestionEndpoint}, Actual Endpoint: {requestEndpoint}"
                    );
            }
        }

        [Event(8, Message = "{0} {1} {2}")]
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
    }
}
