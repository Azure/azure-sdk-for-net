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
        private List<StorageTransferProgress> _updatesBeforePause;

        public void Report(StorageTransferProgress progress)
        {
            _updates.Add(progress);
            string message = $"Event - Queued: {progress.QueuedCount}, InProgress: {progress.InProgressCount}, Completed: {progress.CompletedCount}, Skipped: {progress.SkippedCount}, Failed: {progress.FailedCount}, Bytes: {progress.BytesTransferred}";
            Console.WriteLine(message);
        }

        public void Pause()
        {
            _updatesBeforePause = new List<StorageTransferProgress>(_updates);
            _updates.Clear();
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

            AssertProgressUpdates(_updates, fileCount);
        }

        public void AssertProgressWithPause(long fileCount)
        {
            // Check last update for goal state
            StorageTransferProgress last = _updates.Last();
            Assert.AreEqual(0, last.QueuedCount);
            Assert.AreEqual(0, last.InProgressCount);
            Assert.AreEqual(0, last.SkippedCount);
            Assert.AreEqual(0, last.FailedCount);

            long completedCount = last.CompletedCount;
            StorageTransferProgress lastBeforePause = _updatesBeforePause.LastOrDefault();
            // It is possible there were no updates before pause
            if (lastBeforePause != null)
            {
                Assert.AreEqual(0, lastBeforePause.FailedCount);
                Assert.AreEqual(0, lastBeforePause.SkippedCount);
                // Add completed before and after pause
                completedCount += lastBeforePause.CompletedCount;
            }

            Assert.AreEqual(fileCount, completedCount);

            // Basic assertions for both lists
            AssertProgressUpdates(_updates, fileCount);
            AssertProgressUpdates(_updatesBeforePause, fileCount);
        }

        public void AssertBytesTransferred(long[] expectedUpdates)
        {
            // Combine before and after pause and pull out bytes
            IEnumerable<long?> allUpdates = _updates
                .Concat(_updatesBeforePause ?? Enumerable.Empty<StorageTransferProgress>())
                .Select(u => u.BytesTransferred);

            // If we are not tracking BytesTransferred, is should be null in all updates
            if (expectedUpdates == null)
            {
                allUpdates.All(null);
            }

            // Get only changes in BytesTransferred
            IEnumerable<long> actualUpdates = allUpdates.Select(u => u.Value).Distinct();

            CollectionAssert.AreEqual(expectedUpdates, actualUpdates);
        }

        private static void AssertProgressUpdates(List<StorageTransferProgress> updates, long fileCount)
        {
            long completed = 0;
            long skipped = 0;
            long failed = 0;
            foreach (StorageTransferProgress update in updates)
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
    }
}
