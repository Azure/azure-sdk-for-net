// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class StorageTransmissionEvaluator
    {
        private int _sampleSize;
        private double[] _exportDurationsInSeconds;
        private double[] _exportIntervalsInSeconds;
        private int _exportDurationIndex = -1;
        private int _exportIntervalIndex = -1;
        private long _prevExportTimestampTicks;
        private double _currentBatchExportDuration;
        private double _exportIntervalRunningSum;
        private double _exportDurationRunningSum;
        private bool _enoughSampleSize;

        /// <summary> Initializes a new instance of Storage Transmission Evaluator. </summary>
        /// <param name="sampleSize"> Number of data samples to be used for evaluation. </param>
        internal StorageTransmissionEvaluator(int sampleSize)
        {
            _sampleSize = sampleSize;

            // Array to store time duration in seconds for export
            _exportDurationsInSeconds = new double[sampleSize];

            // Array to store time interval in seconds between each export
            _exportIntervalsInSeconds = new double[sampleSize];
            _prevExportTimestampTicks = Stopwatch.GetTimestamp();
        }

        /// <summary>
        /// Adds current export duration in seconds to the sample size.
        /// Also, removes the oldest record from the sample.
        /// </summary>
        internal void AddExportDurationToDataSample(double currentBatchExportDuration)
        {
            _currentBatchExportDuration = currentBatchExportDuration;

            _exportDurationIndex++;

            // if we run out of elements, start from beginning
            if (_exportDurationIndex == _sampleSize)
            {
                _exportDurationIndex = 0;
            }

            _exportDurationRunningSum -= _exportDurationsInSeconds[_exportDurationIndex];
            _exportDurationsInSeconds[_exportDurationIndex] = currentBatchExportDuration;
            _exportDurationRunningSum += currentBatchExportDuration;
        }

        /// <summary>
        /// Adds current export time interval in seconds to the sample size.
        /// Also, removes the oldest record from the sample.
        /// </summary>
        internal void AddExportIntervalToDataSample()
        {
            long curExportTimestampTicks = Stopwatch.GetTimestamp();

            // todo: check if this can fail
            double exportIntervalSeconds = TimeSpan.FromTicks(curExportTimestampTicks - _prevExportTimestampTicks).TotalSeconds;

            _prevExportTimestampTicks = curExportTimestampTicks;

            // If total time elapsed > 2 days
            // Set exportIntervalSeconds to 0
            // This can happen if there was no export in 2 days of application run.
            if (exportIntervalSeconds > 172800)
            {
                exportIntervalSeconds = 0;
            }

            _exportIntervalIndex++;

            // if we run out of elements, start from beginning
            // This also means we now have enough samples to start calculating avg.
            if (_exportIntervalIndex == _sampleSize)
            {
                _enoughSampleSize = true;
                _exportIntervalIndex = 0;
            }

            _exportIntervalRunningSum -= _exportIntervalsInSeconds[_exportIntervalIndex];
            _exportIntervalsInSeconds[_exportIntervalIndex] = exportIntervalSeconds;
            _exportIntervalRunningSum += exportIntervalSeconds;
        }

        internal long GetNumberOfFilesToTransmitFromStorage()
        {
            long totalFiles = 0;

            // Check if we have enough sample size to decide
            // otherwise, simply return 0.
            if (_enoughSampleSize)
            {
                double avgDurationPerExport = CalculateAverage(_exportDurationRunningSum, _sampleSize);
                double avgExportInterval = CalculateAverage(_exportIntervalRunningSum, _sampleSize);
                if (avgExportInterval > _currentBatchExportDuration)
                {
                    // remove currentBatchExportDuration from avg ExportInterval first
                    // e.g. avg export interval is 10 secs and time it took to export current batch is 5 secs
                    // we have 5 secs left before we expect next batch
                    // so, we can transmit 1 file (if avg duration per export is 5 secs)
                    totalFiles = (long)((avgExportInterval - _currentBatchExportDuration) / avgDurationPerExport);
                }
            }

            return totalFiles;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double CalculateAverage(double sum, int length)
        {
            return (sum / length);
        }
    }
}
