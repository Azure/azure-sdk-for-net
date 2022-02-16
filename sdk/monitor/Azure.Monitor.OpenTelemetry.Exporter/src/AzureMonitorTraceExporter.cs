// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;

using Azure.Core.Pipeline;

using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    public class AzureMonitorTraceExporter : BaseExporter<Activity>
    {
        private readonly ITransmitter _transmitter;
        private readonly AzureMonitorExporterOptions _options;
        private readonly string _instrumentationKey;
        private readonly ResourceParser _resourceParser;
        private readonly StorageTransmissionEvaluator _storageTransmissionEvaluator;
        private readonly const int SampleSize = 10;

        public AzureMonitorTraceExporter(AzureMonitorExporterOptions options) : this(options, new AzureMonitorTransmitter(options))
        {
        }

        internal AzureMonitorTraceExporter(AzureMonitorExporterOptions options, ITransmitter transmitter)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            ConnectionString.ConnectionStringParser.GetValues(_options.ConnectionString, out _instrumentationKey, out _);
            _transmitter = transmitter;
            _resourceParser = new ResourceParser();

            // Todo: Add check if offline storage is enabled by user via options
            // then only initialize.
            _storageTransmissionEvaluator = new StorageTransmissionEvaluator(sampleSize: 10);
        }

        /// <inheritdoc/>
        public override ExportResult Export(in Batch<Activity> batch)
        {
            _storageTransmissionEvaluator?.UpdateExportInterval();

            // Prevent Azure Monitor's HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            try
            {
                // Get timestamp in ticks before export
                long timeStampInTicksBeforeExport =  Stopwatch.GetTimestamp();

                var resource = ParentProvider.GetResource();
                _resourceParser.UpdateRoleNameAndInstance(resource);
                var telemetryItems = TraceHelper.OtelToAzureMonitorTrace(batch, _resourceParser.RoleName, _resourceParser.RoleInstance, _instrumentationKey);

                // TODO: Handle return value, it can be converted as metrics.
                // TODO: Validate CancellationToken and async pattern here.
                _transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();

                // Get timestamp in ticks After export
                long timeStampInTicksAfterExport = Stopwatch.GetTimestamp();

                // Calculate duration
                double currentExportDuration = TimeSpan.FromTicks(timeStampInTicksAfterExport - timeStampInTicksBeforeExport).TotalSeconds;

                _storageTransmissionEvaluator.UpdateExportDuration(currentExportDuration);

                long maxFileToTransmit = _storageTransmissionEvaluator.MaxFilesToTransmitFromStorage();

                _transmitter.TransmitFromStorage(maxFileToTransmit);

                return ExportResult.Success;
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.Write($"FailedToExport{EventLevelSuffix.Error}", ex.LogAsyncException());
                return ExportResult.Failure;
            }
        }
    }
}
