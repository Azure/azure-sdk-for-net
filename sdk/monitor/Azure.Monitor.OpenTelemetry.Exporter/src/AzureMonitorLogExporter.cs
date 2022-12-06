// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;
using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class AzureMonitorLogExporter : BaseExporter<LogRecord>
    {
        private readonly ITransmitter _transmitter;
        private readonly string _instrumentationKey;
        private readonly ResourceParser _resourceParser;
        private readonly AzureMonitorPersistentStorage _persistentStorage;

        public AzureMonitorLogExporter(AzureMonitorExporterOptions options) : this(new AzureMonitorTransmitter(options))
        {
        }

        internal AzureMonitorLogExporter(ITransmitter transmitter)
        {
            _transmitter = transmitter;
            _instrumentationKey = transmitter.InstrumentationKey;
            _resourceParser = new ResourceParser();

            if (transmitter is AzureMonitorTransmitter azureMonitorTransmitter && azureMonitorTransmitter._fileBlobProvider != null)
            {
                _persistentStorage = new AzureMonitorPersistentStorage(transmitter);
            }
        }

        /// <inheritdoc/>
        public override ExportResult Export(in Batch<LogRecord> batch)
        {
            _persistentStorage?.StartExporterTimer();

            // Prevent Azure Monitor's HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            try
            {
                if (_resourceParser.RoleName is null && _resourceParser.RoleInstance is null)
                {
                    var resource = ParentProvider.GetResource();
                    _resourceParser.UpdateRoleNameAndInstance(resource);
                }

                var telemetryItems = LogsHelper.OtelToAzureMonitorLogs(batch, _resourceParser.RoleName, _resourceParser.RoleInstance, _instrumentationKey);
                var exportResult = _transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();
                _persistentStorage?.StopExporterTimerAndTransmitFromStorage();

                return exportResult;
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.WriteError("FailedToExport", ex);
                return ExportResult.Failure;
            }
        }
    }
}
