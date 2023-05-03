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
            string message = $"Event - Queued: {progress.QueuedCount}, InProgress: {progress.InProgressCount}, Completed: {progress.CompletedCount}";
            Console.WriteLine(message);
        }

        public void AssertProgress(long total, long skipped = 0, long failed = 0)
        {
            // Check last update for goal state
            StorageTransferProgress last = _updates.Last();
            Assert.AreEqual(0, last.QueuedCount);
            Assert.AreEqual(0, last.InProgressCount);
            Assert.AreEqual(total - skipped - failed, last.CompletedCount);

            long completedCount = 0;
            long skippedCount = 0;
            long failedCount = 0;
            foreach (StorageTransferProgress update in _updates)
            {
                // Queued/InProgress should never be below zero or above total
                Assert.GreaterOrEqual(update.QueuedCount, 0);
                Assert.LessOrEqual(update.QueuedCount, total);
                Assert.GreaterOrEqual(update.InProgressCount, 0);
                Assert.LessOrEqual(update.InProgressCount, total);

                // Completed, Skipped, and Failed should never go backwards
                Assert.GreaterOrEqual(update.CompletedCount, completedCount);
                Assert.GreaterOrEqual(update.SkippedCount, skippedCount);
                Assert.GreaterOrEqual(update.FailedCount, failedCount);

                completedCount = update.CompletedCount;
                skippedCount = update.SkippedCount;
                failedCount = update.FailedCount;
            }
        }
    }
}
