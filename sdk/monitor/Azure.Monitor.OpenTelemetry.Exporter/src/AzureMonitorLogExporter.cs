﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;
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
        private readonly AzureMonitorPersistentStorage? _persistentStorage;
        private AzureMonitorResource? _resource;

        public AzureMonitorLogExporter(AzureMonitorExporterOptions options, TokenCredential? credential = null) : this(TransmitterFactory.Instance.Get(options, credential))
        {
        }

        internal AzureMonitorLogExporter(ITransmitter transmitter)
        {
            _transmitter = transmitter;
            _instrumentationKey = transmitter.InstrumentationKey;

            if (transmitter is AzureMonitorTransmitter azureMonitorTransmitter && azureMonitorTransmitter._fileBlobProvider != null)
            {
                _persistentStorage = new AzureMonitorPersistentStorage(transmitter);
            }
        }

        internal AzureMonitorResource? LogResource => _resource ??= ParentProvider?.GetResource().UpdateRoleNameAndInstance();

        /// <inheritdoc/>
        public override ExportResult Export(in Batch<LogRecord> batch)
        {
            _persistentStorage?.StartExporterTimer();

            // Prevent Azure Monitor's HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            ExportResult exportResult = ExportResult.Failure;

            try
            {
                var telemetryItems = LogsHelper.OtelToAzureMonitorLogs(batch, LogResource, _instrumentationKey);
                if (telemetryItems.Count > 0)
                {
                    exportResult = _transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();
                }

                _persistentStorage?.StopExporterTimerAndTransmitFromStorage();
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.WriteError("FailedToExport", ex);
            }

            return exportResult;
        }
    }
}
