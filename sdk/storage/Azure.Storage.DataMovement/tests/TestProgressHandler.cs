// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    internal class TestProgressHandler : IProgress<StorageTransferProgress>
    {
        private List<StorageTransferProgress> _updates = new List<StorageTransferProgress>();

        public void Report(StorageTransferProgress progress)
        {
            _updates.Add(progress);
            string message = $"Event - Queued: {progress.QueuedCount}, InProgress: {progress.InProgressCount}, Completed: {progress.CompletedCount}, Skipped: {progress.SkippedCount}, Failed: {progress.FailedCount}, Bytes: {progress.BytesTransferred}";
            Console.WriteLine(message);
        }

        public void AssertProgress(long fileCount, long skippedCount = 0, long failedCount = 0)
        {
            // Check last update for goal state
            StorageTransferProgress last = _updates.Last();
            Assert.AreEqual(0, last.QueuedCount);
            Assert.AreEqual(0, last.InProgressCount);
            Assert.AreEqual(fileCount - skippedCount - failedCount, last.CompletedCount);
            Assert.AreEqual(skippedCount, last.SkippedCount);
            Assert.AreEqual(failedCount, last.FailedCount);

            long completed = 0;
            long skipped = 0;
            long failed = 0;
            foreach (StorageTransferProgress update in _updates)
            {
                // Queued/InProgress should never be below zero or above total
                Assert.GreaterOrEqual(update.QueuedCount, 0);
                Assert.LessOrEqual(update.QueuedCount, fileCount);
                Assert.GreaterOrEqual(update.InProgressCount, 0);
                Assert.LessOrEqual(update.InProgressCount, fileCount);

                // Completed, Skipped, and Failed should never go backwards
                Assert.GreaterOrEqual(update.CompletedCount, completed);
                Assert.GreaterOrEqual(update.SkippedCount, skipped);
                Assert.GreaterOrEqual(update.FailedCount, failed);

                completed = update.CompletedCount;
                skipped = update.SkippedCount;
                failed = update.FailedCount;
            }
        }

        public void AssertBytesTransferred(long[] expectedUpdates)
        {
            // If we are not tracking BytesTransferred, is should be null in all updates
            if (expectedUpdates == null)
            {
                _updates.All(u => u.BytesTransferred == null);
            }

            // Reduce update list to list of BytesTransferred updates
            IEnumerable<long> actualUpdates = _updates.Select(u => u.BytesTransferred.Value).Distinct();

            Assert.IsTrue(actualUpdates.SequenceEqual(expectedUpdates));
        }
    }
}
