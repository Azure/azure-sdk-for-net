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
            Assert.That(updates, Is.Not.Empty);

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

            Assert.That(final.QueuedCount, Is.EqualTo(0));
            Assert.That(final.InProgressCount, Is.EqualTo(0));
            Assert.That(completed, Is.EqualTo(fileCount - skippedCount - failedCount));
            Assert.That(skipped, Is.EqualTo(skippedCount));
            Assert.That(failed, Is.EqualTo(failedCount));
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
            Assert.That(actualUpdates, Is.EqualTo(expectedUpdates).AsCollection);
        }

        private static void AssertProgressUpdates(IEnumerable<TransferProgress> updates, long fileCount)
        {
            long completed = 0;
            long skipped = 0;
            long failed = 0;
            foreach (TransferProgress update in updates)
            {
                // Queued/InProgress should never be below zero or above total
                Assert.That(update.QueuedCount, Is.GreaterThanOrEqualTo(0));
                Assert.That(update.QueuedCount, Is.LessThanOrEqualTo(fileCount));
                Assert.That(update.InProgressCount, Is.GreaterThanOrEqualTo(0));
                Assert.That(update.InProgressCount, Is.LessThanOrEqualTo(fileCount));

                // Completed, Skipped, and Failed should never go backwards
                Assert.That(update.CompletedCount, Is.GreaterThanOrEqualTo(completed));
                Assert.That(update.SkippedCount, Is.GreaterThanOrEqualTo(skipped));
                Assert.That(update.FailedCount, Is.GreaterThanOrEqualTo(failed));

                completed = update.CompletedCount;
                skipped = update.SkippedCount;
                failed = update.FailedCount;
            }
        }
    }
}
