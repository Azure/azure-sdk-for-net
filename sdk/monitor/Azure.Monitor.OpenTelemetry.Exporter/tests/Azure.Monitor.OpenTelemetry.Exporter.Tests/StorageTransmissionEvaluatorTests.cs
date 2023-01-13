// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

using System.Reflection;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class StorageTransmissionEvaluatorTests
    {
        private const int SampleSize = 5;

        [Fact]
        public void ConstructorInitializesInstanceVariablesForEvaluation()
        {
            var storageTransmissionEvaluator = new StorageTransmissionEvaluator(SampleSize);
            var sampleSize = typeof(StorageTransmissionEvaluator)
                .GetField("_sampleSize", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(storageTransmissionEvaluator);
            var previousExportStartTimeInMilliseconds = typeof(StorageTransmissionEvaluator)
                .GetField("_previousExportStartTimeInMilliseconds", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(storageTransmissionEvaluator);
            var exportDurationInSeconds = typeof(StorageTransmissionEvaluator)
                .GetField("_exportDurationsInMilliseconds", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(storageTransmissionEvaluator) as long[];
            var exportIntervalsInSeconds = typeof(StorageTransmissionEvaluator)
                .GetField("_exportIntervalsInMilliseconds", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(storageTransmissionEvaluator) as long[];

            Assert.Equal(SampleSize, (int)sampleSize);
            Assert.NotNull(exportIntervalsInSeconds);
            Assert.NotNull(exportDurationInSeconds);
            Assert.Equal(SampleSize, exportIntervalsInSeconds.Length);
            Assert.Equal(SampleSize, exportDurationInSeconds.Length);
            Assert.Equal(0, (long)previousExportStartTimeInMilliseconds);
        }

        [Fact]
        public void MaxFilesToBeTransmittedIsNonZeroWhenExportDurationIsLessThanExportInterval()
        {
            var storageTransmissionEvaluator = new StorageTransmissionEvaluator(SampleSize);
            for (int i = 0; i < SampleSize; i++)
            {
                storageTransmissionEvaluator.AddExportIntervalToDataSample((i+1)*3000);
                storageTransmissionEvaluator.AddExportDurationToDataSample(1000);
            }
            var maxFiles = storageTransmissionEvaluator.GetMaxFilesToTransmitFromStorage();

            Assert.True(maxFiles > 0);
        }

        [Fact]
        public void MaxFilesToBeTransmittedIsZeroWhenExportDurationIsGreaterThanExportInterval()
        {
            var storageTransmissionEvaluator = new StorageTransmissionEvaluator(SampleSize);
            for (int i = 0; i < SampleSize; i++)
            {
                storageTransmissionEvaluator.AddExportIntervalToDataSample((i+1)*1000);
                storageTransmissionEvaluator.AddExportDurationToDataSample(2000);
            }
            var maxFiles = storageTransmissionEvaluator.GetMaxFilesToTransmitFromStorage();

            Assert.Equal(0, maxFiles);
        }

        [Fact]
        public void MaxFilesToBeTransmittedIsZeroWhenCurrentBatchExportDurationIsGreaterThanExportInterval()
        {
            var storageTransmissionEvaluator = new StorageTransmissionEvaluator(SampleSize);

            for (int i = 0; i < SampleSize; i++)
            {
                storageTransmissionEvaluator.AddExportIntervalToDataSample((i+1)*3000);
                storageTransmissionEvaluator.AddExportDurationToDataSample(1000);
            }

            // Update the currentBatchExportDuration to a greater value
            // than avg export interval.
            typeof(StorageTransmissionEvaluator)
                .GetField("_currentBatchExportDurationInMilliseconds", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(storageTransmissionEvaluator, 10000);
            var maxFiles = storageTransmissionEvaluator.GetMaxFilesToTransmitFromStorage();

            Assert.Equal(0, maxFiles);
        }

        [Fact]
        public void MaxFilesToBeTransmittedIsZeroWhenDataSamplesAreLessThanSampleSize()
        {
            var storageTransmissionEvaluator = new StorageTransmissionEvaluator(SampleSize);
            //For Sample Size 5, 5th export will have enough samples to make the decision
            for (int i = 0; i < 4; i++)
            {
                storageTransmissionEvaluator.AddExportDurationToDataSample((i+1)*3000);
                storageTransmissionEvaluator.AddExportDurationToDataSample(1000);
            }
            var maxFiles = storageTransmissionEvaluator.GetMaxFilesToTransmitFromStorage();

            Assert.Equal(0, maxFiles);
        }

        [Fact]
        public void ExportIntervalAndDurationsAreUpdatedInCircularManner()
        {
            var storageTransmissionEvaluator = new StorageTransmissionEvaluator(SampleSize);
            long timeInMilliseconds = 2000;
            long exportInterval = 0;

            // Add data points equal to sample size
            for (int i = 0; i < SampleSize; i++)
            {
                exportInterval += 2000;
                storageTransmissionEvaluator.AddExportIntervalToDataSample(exportInterval);
                storageTransmissionEvaluator.AddExportDurationToDataSample(timeInMilliseconds);
            }

            var exportIntervalsInSecondsBefore = typeof(StorageTransmissionEvaluator)
                .GetField("_exportIntervalsInMilliseconds", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(storageTransmissionEvaluator) as long[];

            var exportDurationInSecondsBefore = typeof(StorageTransmissionEvaluator)
                .GetField("_exportDurationsInMilliseconds", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(storageTransmissionEvaluator) as long[];

            // Add data points equal to sample size
            for (int i = 0; i < SampleSize; i++)
            {
                Assert.Equal(2000, exportIntervalsInSecondsBefore[i]);
                Assert.Equal(2000, exportDurationInSecondsBefore[i]);
            }

            // Add 3 more data points with different time values
            for (int i = 0; i < 3; i++)
            {
                exportInterval += 1000;
                storageTransmissionEvaluator.AddExportIntervalToDataSample(exportInterval);
                storageTransmissionEvaluator.AddExportDurationToDataSample(1000);
            }

            // First 3 elements should be updated
            for (int i = 0; i < 3; i++)
            {
                Assert.Equal(1000, exportIntervalsInSecondsBefore[i]);
                Assert.Equal(1000, exportDurationInSecondsBefore[i]);
            }

            // Last two should remain the same
            for (int i = 3; i < SampleSize; i++)
            {
                Assert.Equal(2000, exportIntervalsInSecondsBefore[i]);
                Assert.Equal(2000, exportDurationInSecondsBefore[i]);
            }

            // Adding samples more than sample szie should not throw any exception
            for (int i = 3; i < 2*SampleSize; i++)
            {
                storageTransmissionEvaluator.AddExportIntervalToDataSample((i + 1) * timeInMilliseconds);
                storageTransmissionEvaluator.AddExportDurationToDataSample(timeInMilliseconds);
            }
        }
    }
}
