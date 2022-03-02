// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter
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
            var prevExportTimestampTicks = typeof(StorageTransmissionEvaluator)
                .GetField("_prevExportTimestampTicks", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(storageTransmissionEvaluator);
            var exportDurationInSeconds = typeof(StorageTransmissionEvaluator)
                .GetField("_exportDurationsInSeconds", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(storageTransmissionEvaluator) as double[];
            var exportIntervalsInSeconds = typeof(StorageTransmissionEvaluator)
                .GetField("_exportIntervalsInSeconds", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(storageTransmissionEvaluator) as double[];

            Assert.Equal(SampleSize, (int)sampleSize);
            Assert.True((long)prevExportTimestampTicks > 0);
            Assert.NotNull(exportIntervalsInSeconds);
            Assert.NotNull(exportDurationInSeconds);
            Assert.Equal(SampleSize, exportIntervalsInSeconds.Length);
            Assert.Equal(SampleSize, exportDurationInSeconds.Length);
        }

        [Fact]
        public void MaxFilesToBeTransmittedIsNonZeroWhenExportDurationIsLessThanExportInterval()
        {
            var storageTransmissionEvaluator = new StorageTransmissionEvaluator(SampleSize);

            for (int i = 0; i < SampleSize; i++)
            {
                storageTransmissionEvaluator.UpdateExportInterval();

                // Mock delay of 3 secs
                Task.Delay(3000).Wait();
            }

            for (int i = 0; i < SampleSize; i++)
            {
                // Considering export duration of 1 sec.
                storageTransmissionEvaluator.AddExportDurationToDataSample(1);
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
                storageTransmissionEvaluator.UpdateExportInterval();

                // Mock delay of 1 sec
                Task.Delay(1000).Wait();
            }

            for (int i = 0; i < SampleSize; i++)
            {
                // Considering export duration of 2 secs.
                storageTransmissionEvaluator.AddExportDurationToDataSample(2);
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
                storageTransmissionEvaluator.UpdateExportInterval();

                // Mock delay of 3 secs
                Task.Delay(3000).Wait();
            }

            for (int i = 0; i < SampleSize; i++)
            {
                // Considering export duration of 1 secs.
                storageTransmissionEvaluator.AddExportDurationToDataSample(1);
            }

            // Update the currentBatchExportDuration to a greater value
            // than avg export interval.
            typeof(StorageTransmissionEvaluator)
                .GetField("_currentBatchExportDuration", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(storageTransmissionEvaluator, 10);

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
                storageTransmissionEvaluator.UpdateExportInterval();

                // Mock delay of 3 secs
                Task.Delay(3000).Wait();
            }

            for (int i = 0; i < 4; i++)
            {
                // Considering export duration of 1 secs < export interval.
                storageTransmissionEvaluator.AddExportDurationToDataSample(1);
            }

            var maxFiles = storageTransmissionEvaluator.GetMaxFilesToTransmitFromStorage();
            Assert.Equal(0, maxFiles);
        }

        [Fact]
        public void ExportIntervalAndDurationsAreUpdatedInCircularManner()
        {
            var storageTransmissionEvaluator = new StorageTransmissionEvaluator(SampleSize);
            double timeInSeconds = 2;

            // Add data points equal to sample size
            for (int i = 0; i < SampleSize; i++)
            {
                storageTransmissionEvaluator.AddExportIntervalToDataSample(timeInSeconds);
                storageTransmissionEvaluator.AddExportDurationToDataSample(timeInSeconds);
            }

            var exportIntervalsInSecondsBefore = typeof(StorageTransmissionEvaluator)
                .GetField("_exportIntervalsInSeconds", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(storageTransmissionEvaluator) as double[];

            var exportDurationInSecondsBefore = typeof(StorageTransmissionEvaluator)
                .GetField("_exportIntervalsInSeconds", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(storageTransmissionEvaluator) as double[];

            // Add data points equal to sample size
            for (int i = 0; i < SampleSize; i++)
            {
                Assert.Equal(2, exportDurationInSecondsBefore[i]);
                Assert.Equal(2, exportIntervalsInSecondsBefore[i]);
            }

            // Add 3 more data points with different time values
            for (int i = 0; i < 3; i++)
            {
                storageTransmissionEvaluator.AddExportIntervalToDataSample(1);
                storageTransmissionEvaluator.AddExportDurationToDataSample(1);
            }

            // First 3 elements should be updated
            for (int i = 0; i < 3; i++)
            {
                Assert.Equal(1, exportDurationInSecondsBefore[i]);
                Assert.Equal(1, exportIntervalsInSecondsBefore[i]);
            }

            // Last two should remain the same
            for (int i = 3; i < SampleSize; i++)
            {
                Assert.Equal(2, exportDurationInSecondsBefore[i]);
                Assert.Equal(2, exportIntervalsInSecondsBefore[i]);
            }

            // Adding samples more than sample szie should not throw any exception
            for (int i = 3; i < 2*SampleSize; i++)
            {
                storageTransmissionEvaluator.AddExportIntervalToDataSample(timeInSeconds);
                storageTransmissionEvaluator.AddExportDurationToDataSample(timeInSeconds);
            }
        }
    }
}
