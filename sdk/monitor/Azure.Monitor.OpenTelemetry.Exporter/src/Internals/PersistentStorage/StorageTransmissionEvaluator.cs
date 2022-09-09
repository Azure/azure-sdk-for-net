// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage
{
    internal class StorageTransmissionEvaluator
    {
        private int _sampleSize;
        private long[] _exportDurationsInMilliseconds;
        private long[] _exportIntervalsInMilliseconds;
        private int _exportDurationIndex = -1;
        private int _exportIntervalIndex = -1;
        private long _previousExportStartTimeInMilliseconds;
        private long _currentBatchExportDurationInMilliseconds;
        private long _exportIntervalRunningSum;
        private long _exportDurationRunningSum;
        private bool _enoughSampleSize;

        /// <summary> Initializes a new instance of Storage Transmission Evaluator. </summary>
        /// <param name="sampleSize"> Number of data samples to be used for evaluation. </param>
        internal StorageTransmissionEvaluator(int sampleSize)
        {
            _sampleSize = sampleSize;

            // Array to store time duration in Milliseconds for export
            _exportDurationsInMilliseconds = new long[sampleSize];

            // Array to store time interval in Milliseconds between each export
            _exportIntervalsInMilliseconds = new long[sampleSize];
        }

        /// <summary>
        /// Adds current export duration in Milliseconds to the sample size.
        /// Also, removes the oldest record from the sample.
        /// </summary>
        internal void AddExportDurationToDataSample(long currentBatchExportDurationInMilliseconds)
        {
            _currentBatchExportDurationInMilliseconds = currentBatchExportDurationInMilliseconds;

            _exportDurationIndex++;

            // if we run out of elements, start from beginning
            if (_exportDurationIndex == _sampleSize)
            {
                _exportDurationIndex = 0;
            }

            _exportDurationRunningSum -= _exportDurationsInMilliseconds[_exportDurationIndex];
            _exportDurationsInMilliseconds[_exportDurationIndex] = currentBatchExportDurationInMilliseconds;
            _exportDurationRunningSum += currentBatchExportDurationInMilliseconds;
        }

        /// <summary>
        /// Adds current export time interval in Milliseconds to the sample size.
        /// Also, removes the oldest record from the sample.
        /// </summary>
        internal void AddExportIntervalToDataSample(long currentExportStartTimeInMilliseconds)
        {
            long exportIntervalInMilliseconds = (currentExportStartTimeInMilliseconds - _previousExportStartTimeInMilliseconds);

            _previousExportStartTimeInMilliseconds = currentExportStartTimeInMilliseconds;

            // If total time elapsed > 2 days
            // Set exportIntervalInMilliseconds to 0
            // This can happen if there was no export in 2 days of application run.
            if (exportIntervalInMilliseconds > 172800000)
            {
                exportIntervalInMilliseconds = 0;
            }

            _exportIntervalIndex++;

            // if we run out of elements, start from beginning
            if (_exportIntervalIndex == _sampleSize)
            {
                _exportIntervalIndex = 0;
            }

            // We have now enough samples to calculate avg.
            if (!_enoughSampleSize && _exportIntervalIndex == _sampleSize - 1)
            {
                _enoughSampleSize = true;
            }

            _exportIntervalRunningSum -= _exportIntervalsInMilliseconds[_exportIntervalIndex];
            _exportIntervalsInMilliseconds[_exportIntervalIndex] = exportIntervalInMilliseconds;
            _exportIntervalRunningSum += exportIntervalInMilliseconds;
        }

        internal long GetMaxFilesToTransmitFromStorage()
        {
            long totalFiles = 0;

            // Check if we have enough sample size to decide
            // otherwise, simply return 0.
            if (_enoughSampleSize)
            {
                double avgDurationPerExport = CalculateAverage(_exportDurationRunningSum, _sampleSize);
                double avgExportInterval = CalculateAverage(_exportIntervalRunningSum, _sampleSize);
                if (avgExportInterval > _currentBatchExportDurationInMilliseconds)
                {
                    // remove currentBatchExportDuration from avg ExportInterval first
                    // e.g. avg export interval is 10 secs and time it took to export current batch is 5 secs
                    // we have 5 secs left before we expect next batch
                    // so, we can transmit 1 file (if avg duration per export is 5 secs)
                    totalFiles = (long)((avgExportInterval - _currentBatchExportDurationInMilliseconds) / avgDurationPerExport);
                }
            }

            return totalFiles;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double CalculateAverage(long sum, int length)
        {
            return (sum / length);
        }
    }
}
