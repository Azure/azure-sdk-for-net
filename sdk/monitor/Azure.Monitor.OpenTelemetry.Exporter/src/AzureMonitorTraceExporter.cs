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
        private readonly ITransmitter Transmitter;
        private readonly AzureMonitorExporterOptions options;
        private readonly string instrumentationKey;
        private readonly ResourceParser resourceParser;
        private double[] transmissionDurationsInSeconds;
        private double[] exportIntervalsInSeconds;
        private int transmissionIndex = -1;
        private int exportIntervalIndex = -1;
        private DateTime prevExportTime;
        private double currentBatchExportDuration;

        public AzureMonitorTraceExporter(AzureMonitorExporterOptions options) : this(options, new AzureMonitorTransmitter(options))
        {
        }

        internal AzureMonitorTraceExporter(AzureMonitorExporterOptions options, ITransmitter transmitter)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            ConnectionString.ConnectionStringParser.GetValues(this.options.ConnectionString, out this.instrumentationKey, out _);
            this.Transmitter = transmitter;
            resourceParser = new ResourceParser();
            transmissionDurationsInSeconds = new double[5];
            exportIntervalsInSeconds = new double[5];
        }

        /// <inheritdoc/>
        public override ExportResult Export(in Batch<Activity> batch)
        {
            // Prevent Azure Monitor's HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            try
            {
                // Start the stopwatch to calculate export duration
                Stopwatch stopWatch = Stopwatch.StartNew();

                // Update export interval
                UpdateExportInterval();

                var resource = this.ParentProvider.GetResource();
                resourceParser.UpdateRoleNameAndInstance(resource);
                var telemetryItems = TraceHelper.OtelToAzureMonitorTrace(batch, resourceParser.RoleName, resourceParser.RoleInstance, instrumentationKey);

                // TODO: Handle return value, it can be converted as metrics.
                // TODO: Validate CancellationToken and async pattern here.
                this.Transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();

                // Export is completed, stop the watch
                stopWatch.Stop();

                currentBatchExportDuration = stopWatch.Elapsed.TotalSeconds;

                // Update transmission duration so that it can used in avg calculation
                UpdateTransmissionDuration(currentBatchExportDuration);

                long filesToTransmit = MaxFilesToTransmitFromStorage();

                // todo: call transmit from storage here

                return ExportResult.Success;
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.Write($"FailedToExport{EventLevelSuffix.Error}", ex.LogAsyncException());
                return ExportResult.Failure;
            }
        }

        private void UpdateTransmissionDuration(double currentExportDuration)
        {
            transmissionIndex++;
            // if we run out of elements, start from beginning
            if (transmissionIndex >= transmissionDurationsInSeconds.Length)
            {
                transmissionIndex = 0;
            }

            transmissionDurationsInSeconds[transmissionIndex] = currentExportDuration;
        }

        private void UpdateExportInterval()
        {
            // No export available, we just started
            if (prevExportTime == default)
            {
                prevExportTime = DateTime.UtcNow;
                exportIntervalIndex++;
                exportIntervalsInSeconds[exportIntervalIndex] = 0;
            }
            else
            {
                // todo: check if this can fail
                double exportInterval = (DateTime.UtcNow - prevExportTime).TotalSeconds;
                // if total time elapsed > 2 days
                // set export interval to 2 days
                if (exportInterval > 172800)
                {
                    exportInterval = 172800;
                }

                exportIntervalIndex++;

                // if we run out of elements, start from beginning
                if (exportIntervalIndex >= exportIntervalsInSeconds.Length)
                {
                    exportIntervalIndex = 0;
                }
                exportIntervalsInSeconds[exportIntervalIndex] = exportInterval;
                prevExportTime = DateTime.UtcNow;
            }
        }

        private long MaxFilesToTransmitFromStorage()
        {
            long totalFiles = 0;
            double avgDurationPerExport = CalculateAverage(transmissionDurationsInSeconds);
            double avgExportInterval = CalculateAverage(exportIntervalsInSeconds);
            if (avgExportInterval > currentBatchExportDuration)
            {
                // remove currentBatchExportDuration from avg ExportInterval first
                // e.g. avg export interval is 10 secs and time it took to export current batch is 5 secs
                // we have 5 secs left before we expect next batch
                // so, we can transmit 1 file (if avg duration per export is 5 secs)
                totalFiles =  (long)((avgExportInterval - currentBatchExportDuration) / avgDurationPerExport);
            }

            return totalFiles;
        }

        private static double CalculateAverage(double[] arr)
        {
            int len = arr.Length;
            double sum = 0;
            for (int i = 0; i < len; i++)
            {
                sum += arr[i];
            }

            return sum/len;
        }
    }
}
