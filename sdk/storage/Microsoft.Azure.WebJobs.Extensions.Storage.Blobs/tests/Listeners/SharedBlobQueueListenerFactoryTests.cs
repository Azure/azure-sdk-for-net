// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Host;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    public class SharedBlobQueueListenerFactoryTests
    {
        [TestCase(100, 32, 68, 6)]
        [TestCase(64, 32, 32, 5)]
        [TestCase(63, 32, 31, 4)]
        [TestCase(62, 32, 30, 4)]
        [TestCase(16, 9, 7, 3)]
        [TestCase(3, 2, 1, 1)]
        [TestCase(2, 2, 0, 1)]
        [TestCase(1, 1, 0, 1)]
        public void ConvertsBlobOptionsToQueueOptionsCorrectly(int maxDegreeOfParallelism, int expectedBatchSize, int expectedNewBatchThreshold, int poisonBlobThreshold)
        {
            // Arrange
            var blobOptions = new BlobsOptions()
            {
                MaxDegreeOfParallelism = maxDegreeOfParallelism,
                PoisonBlobThreshold = poisonBlobThreshold,
            };

            // Act
            var queueOptions = SharedBlobQueueListenerFactory.BlobsOptionsToQueuesOptions(blobOptions);

            // Assert
            Assert.AreEqual(expectedBatchSize, queueOptions.BatchSize);
            Assert.AreEqual(expectedNewBatchThreshold, queueOptions.NewBatchThreshold);
            Assert.AreEqual(poisonBlobThreshold, queueOptions.MaxDequeueCount);
        }
    }
}
