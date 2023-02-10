// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Threading;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage
{
    internal class AzureMonitorPersistentStorage
    {
        private const int StorageTransmissionEvaluatorSampleSize = 10;
        private readonly Stopwatch _stopwatch;
        private readonly StorageTransmissionEvaluator _storageTransmissionEvaluator;
        private readonly ITransmitter _transmitter;
        private long _exportStartTimeInMilliseconds;

        public AzureMonitorPersistentStorage(ITransmitter transmitter)
        {
            _transmitter = transmitter;
            _stopwatch = Stopwatch.StartNew();
            _storageTransmissionEvaluator = new StorageTransmissionEvaluator(StorageTransmissionEvaluatorSampleSize);
        }

        internal void StartExporterTimer()
        {
            // Get export start time
            _exportStartTimeInMilliseconds = _stopwatch.ElapsedMilliseconds;

            // Add export time interval to data sample
            _storageTransmissionEvaluator.AddExportIntervalToDataSample(_exportStartTimeInMilliseconds);
        }

        internal void StopExporterTimerAndTransmitFromStorage()
        {
            // Get export end time
            long exportEndTimeInMilliseconds = _stopwatch.ElapsedMilliseconds;

            // Calculate duration and add it to data sample
            long currentBatchExportDurationInMilliseconds = exportEndTimeInMilliseconds - _exportStartTimeInMilliseconds;
            _storageTransmissionEvaluator.AddExportDurationToDataSample(currentBatchExportDurationInMilliseconds);

            // Get max number of files we can transmit in this export and start transmitting
            long maxFilesToTransmit = _storageTransmissionEvaluator.GetMaxFilesToTransmitFromStorage();
            _transmitter.TransmitFromStorage(maxFilesToTransmit, false, CancellationToken.None);
        }
    }
}
