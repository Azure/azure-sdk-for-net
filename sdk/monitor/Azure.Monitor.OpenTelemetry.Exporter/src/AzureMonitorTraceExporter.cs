// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class AzureMonitorTraceExporter : BaseExporter<Activity>
    {
        private readonly ITransmitter _transmitter;
        private readonly string _instrumentationKey;
        private readonly AzureMonitorPersistentStorage? _persistentStorage;
        private AzureMonitorResource? _resource;

        public AzureMonitorTraceExporter(AzureMonitorExporterOptions options, TokenCredential? credential = null) : this(TransmitterFactory.Instance.Get(options, credential))
        {
        }

        internal AzureMonitorTraceExporter(ITransmitter transmitter)
        {
            _transmitter = transmitter;
            _instrumentationKey = transmitter.InstrumentationKey;

            if (transmitter is AzureMonitorTransmitter azureMonitorTransmitter && azureMonitorTransmitter._fileBlobProvider != null)
            {
                _persistentStorage = new AzureMonitorPersistentStorage(transmitter);
            }
        }

        internal AzureMonitorResource? TraceResource => _resource ??= ParentProvider?.GetResource().UpdateRoleNameAndInstance();

        /// <inheritdoc/>
        public override ExportResult Export(in Batch<Activity> batch)
        {
            _persistentStorage?.StartExporterTimer();

            // Prevent Azure Monitor's HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            try
            {
                var telemetryItems = TraceHelper.OtelToAzureMonitorTrace(batch, TraceResource, _instrumentationKey);
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
