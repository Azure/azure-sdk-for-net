// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class StorageTransmissionEvaluator
    {
        private int _sampleSize;
        private double[] _transmissionDurationsInSeconds;
        private double[] _exportIntervalsInSeconds;
        private int _transmissionDurationIndex = -1;
        private int _exportIntervalIndex = -1;
        private long _prevExportTimestampTicks;
        private double _currentBatchExportDuration;
        private double _runningExportIntervalSum;
        private double _runningTransmissionDurationSum;
        private bool _enoughSampleSize;

        internal StorageTransmissionEvaluator(int sampleSize)
        {
            _sampleSize = sampleSize;
            _transmissionDurationsInSeconds = new double[sampleSize];
            _exportIntervalsInSeconds = new double[sampleSize];
        }

        internal void UpdateTransmissionDuration(double currentExportDuration)
        {
            _transmissionDurationIndex++;
            // if we run out of elements, start from beginning
            if (_transmissionDurationIndex == _transmissionDurationsInSeconds.Length)
            {
                _transmissionDurationIndex = 0;
            }

            _runningTransmissionDurationSum -= _transmissionDurationsInSeconds[_transmissionDurationIndex];
            _transmissionDurationsInSeconds[_transmissionDurationIndex] = currentExportDuration;
            _runningTransmissionDurationSum += currentExportDuration;
        }

        internal void UpdateExportInterval()
        {
            long curExportTimestampTicks = Stopwatch.GetTimestamp();
            // todo: check if this can fail
            double exportIntervalSeconds = TimeSpan.FromTicks(curExportTimestampTicks - _prevExportTimestampTicks).TotalSeconds;

            _prevExportTimestampTicks = curExportTimestampTicks;

            // If total time elapsed > 2 days
            // set export interval to 0
            // This can happen if
            // 1) there was no export in 2 days of application run
            // 2) Application just started and prevExportTime is default which = 1/1/0001 12:00:00 AM
            if (exportIntervalSeconds > 172800)
            {
                exportIntervalSeconds = 0;
            }

            _exportIntervalIndex++;

            // if we run out of elements, start from beginning
            // This also means we now have enough samples to start calculating avg.
            if (_exportIntervalIndex == _exportIntervalsInSeconds.Length)
            {
                _enoughSampleSize = true;
                _exportIntervalIndex = 0;
            }

            _runningExportIntervalSum -= _exportIntervalsInSeconds[_exportIntervalIndex];
            _exportIntervalsInSeconds[_exportIntervalIndex] = exportIntervalSeconds;
            _runningExportIntervalSum += exportIntervalSeconds;
        }

        internal long MaxFilesToTransmitFromStorage()
        {
            long totalFiles = 0;

            // Check if we have enough sample size to decide
            // otherwise, simply return 0.
            if (_enoughSampleSize)
            {
                double avgDurationPerExport = CalculateAverage(_runningTransmissionDurationSum, _sampleSize);
                double avgExportInterval = CalculateAverage(_runningExportIntervalSum, _sampleSize);
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

        private static double CalculateAverage(double sum, int length)
        {
            return (sum / length);
        }

        internal double CurrentBatchExportDuration { get => _currentBatchExportDuration; set => _currentBatchExportDuration = value; }
    }
}
