// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    internal static class ProgressHandlerAsserts
    {
        public static void AssertFileProgress(
            IEnumerable<TransferProgress> updates,
            long fileCount,
            long skippedCount = 0,
            long failedCount = 0,
            params int[] pauseIndexes)
        {
            Assert.IsNotEmpty(updates);

            long completed = 0;
            long skipped = 0;
            long failed = 0;

            // Treat before each pause as separate update list
            foreach (int index in pauseIndexes)
            {
                // There could be no updates before the pause
                if (index == 0)
                {
                    continue;
                }

                IEnumerable<TransferProgress> before = updates.Take(index);
                AssertProgressUpdates(before, fileCount);

                TransferProgress lastBeforePause = before.Last();
                completed += lastBeforePause.CompletedCount;
                skipped += lastBeforePause.SkippedCount;
                failed += lastBeforePause.FailedCount;
            }

            // Grab the final set of updates (all the updates if there were no pauses)
            IEnumerable<TransferProgress> finalUpdates =
                pauseIndexes.Length > 0 ? updates.Skip(pauseIndexes.Last()) : updates;

            AssertProgressUpdates(finalUpdates, fileCount);

            // Check final update for goal state
            TransferProgress final = finalUpdates.Last();
            completed += final.CompletedCount;
            skipped += final.SkippedCount;
            failed += final.FailedCount;

            Assert.AreEqual(0, final.QueuedCount);
            Assert.AreEqual(0, final.InProgressCount);
            Assert.AreEqual(fileCount - skippedCount - failedCount, completed);
            Assert.AreEqual(skippedCount, skipped);
            Assert.AreEqual(failedCount, failed);
        }

        public static void AssertBytesTransferred(
            IEnumerable<TransferProgress> updates,
            long[] expectedUpdates)
        {
            IEnumerable<long?> bytesUpdates = updates.Select(x => x.BytesTransferred);

            // If we are not tracking BytesTransferred, is should be null in all updates
            if (expectedUpdates == null)
            {
                bytesUpdates.All(null);
            }

            // Get only changes in BytesTransferred
            IEnumerable<long> actualUpdates = bytesUpdates.Select(u => u.Value).Distinct();
            CollectionAssert.AreEqual(expectedUpdates, actualUpdates);
        }

        private static void AssertProgressUpdates(IEnumerable<TransferProgress> updates, long fileCount)
        {
            long completed = 0;
            long skipped = 0;
            long failed = 0;
            foreach (TransferProgress update in updates)
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
