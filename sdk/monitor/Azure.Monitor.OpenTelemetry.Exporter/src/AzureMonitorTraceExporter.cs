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
        private readonly Stopwatch _stopwatch;
        private const int StorageTransmissionEvaluatorSampleSize = 10;

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
            _stopwatch = Stopwatch.StartNew();

            _storageTransmissionEvaluator = new StorageTransmissionEvaluator(StorageTransmissionEvaluatorSampleSize);
        }

        /// <inheritdoc/>
        public override ExportResult Export(in Batch<Activity> batch)
        {
            // Get export start time
            long exportStartTimeInMilliseconds = _stopwatch.ElapsedMilliseconds;

            // Add export time interval to data sample
            _storageTransmissionEvaluator.AddExportIntervalToDataSample(exportStartTimeInMilliseconds);

            // Prevent Azure Monitor's HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            try
            {
                var resource = ParentProvider.GetResource();
                _resourceParser.UpdateRoleNameAndInstance(resource);
                var telemetryItems = TraceHelper.OtelToAzureMonitorTrace(batch, _resourceParser.RoleName, _resourceParser.RoleInstance, _instrumentationKey);

                // TODO: Handle return value, it can be converted as metrics.
                // TODO: Validate CancellationToken and async pattern here.
                var exportResult = _transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();

                // Get export end time
                long exportEndTimeInMilliseconds = _stopwatch.ElapsedMilliseconds;

                // Calculate duration and add it to data sample
                long currentBatchExportDurationInMilliseconds = exportEndTimeInMilliseconds - exportStartTimeInMilliseconds;
                _storageTransmissionEvaluator.AddExportDurationToDataSample(currentBatchExportDurationInMilliseconds);

                // Get max number of files we can transmit in this export and start transmitting
                long maxFilesToTransmit = _storageTransmissionEvaluator.GetMaxFilesToTransmitFromStorage();
                _transmitter.TransmitFromStorage(maxFilesToTransmit, false, CancellationToken.None);

                return exportResult;
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.Write($"FailedToExport{EventLevelSuffix.Error}", ex.LogAsyncException());
                return ExportResult.Failure;
            }
        }
    }
}
