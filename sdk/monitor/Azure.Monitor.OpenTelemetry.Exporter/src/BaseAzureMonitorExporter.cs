// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal abstract class BaseAzureMonitorExporter<T> : BaseExporter<T>
        where T : class
    {
        private readonly ITransmitter _transmitter;
        private readonly string _instrumentationKey;
        private readonly ResourceParser _resourceParser;
        private readonly AzureMonitorPersistentStorage _persistentStorage;
        private readonly Func<Batch<T>, string, string, string, List<TelemetryItem>> _convertToTelemetryItemsFunc;

        internal BaseAzureMonitorExporter(ITransmitter transmitter, Func<Batch<T>, string, string, string, List<TelemetryItem>> convertToTelemetryItemsFunc)
        {
            _transmitter = transmitter;
            _instrumentationKey = transmitter.InstrumentationKey;
            _resourceParser = new ResourceParser();
            _convertToTelemetryItemsFunc = convertToTelemetryItemsFunc;

            if (transmitter is AzureMonitorTransmitter azureMonitorTransmitter && azureMonitorTransmitter._fileBlobProvider != null)
            {
                _persistentStorage = new AzureMonitorPersistentStorage(transmitter);
            }
        }

        /// <inheritdoc/>
        public override ExportResult Export(in Batch<T> batch)
        {
            _persistentStorage?.StartExporterTimer();

            // Prevent Azure Monitor's HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            try
            {
                // Export may be called even if there are no items in batch.
                if (batch.Count > 0)
                {
                    if (_resourceParser.RoleName is null && _resourceParser.RoleInstance is null)
                    {
                        var resource = ParentProvider.GetResource();
                        _resourceParser.UpdateRoleNameAndInstance(resource);
                    }

                    var telemetryItems = _convertToTelemetryItemsFunc(batch, _resourceParser.RoleName, _resourceParser.RoleInstance, _instrumentationKey);
                    return _transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();
                }

                return ExportResult.Success;
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.WriteError("FailedToExport", ex);
                return ExportResult.Failure;
            }
            finally
            {
                _persistentStorage?.StopExporterTimerAndTransmitFromStorage();
            }
        }
    }
}
