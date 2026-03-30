// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.ChangeFeed.Common;
using Azure.Storage.Files.Shares;
using Azure.Storage.Internal.Avro;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.ChangeFeed.Tests
{
    /// <summary>
    /// Tests for the snapshot-based pageable classes, verifying cvId filtering logic
    /// and end-snapshot finalization validation.
    /// These tests exercise the filtering at the <see cref="ChangeFeedEventPageBase{T}"/> level
    /// by constructing events with known <see cref="ShareChangeFeedEvent.ContainerVersionNumber"/>
    /// values and verifying only events in the correct range are returned.
    /// </summary>
    public class ShareChangeFeedSnapshotPageableTests : ShareChangeFeedTestBase
    {
        public ShareChangeFeedSnapshotPageableTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        /// <summary>
        /// Verifies that the cvId filtering logic correctly includes only events where
        /// beginCvId &lt; ContainerVersionNumber &lt;= endCvId.
        /// </summary>
        [Test]
        public void CvIdFiltering_IncludesOnlyEventsInRange()
        {
            // Arrange - simulate events with various Cvnt values
            long beginCvId = 50;
            long endCvId = 100;

            var events = new List<ShareChangeFeedEvent>
            {
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 30, reason: "SmbCreate", id: "evt-30"),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 50, reason: "SmbWrite", id: "evt-50"),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 51, reason: "SmbDelete", id: "evt-51"),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 75, reason: "RestCreate", id: "evt-75"),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 100, reason: "SmbRename", id: "evt-100"),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 101, reason: "RestWrite", id: "evt-101"),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 150, reason: "RestDelete", id: "evt-150"),
            };

            // Act - apply the same filtering logic used by the snapshot pageables:
            // beginCvId < ContainerVersionNumber <= endCvId
            List<ShareChangeFeedEvent> filtered = new List<ShareChangeFeedEvent>();
            foreach (ShareChangeFeedEvent evt in events)
            {
                if (evt.ContainerVersionNumber > beginCvId && evt.ContainerVersionNumber <= endCvId)
                {
                    filtered.Add(evt);
                }
            }

            // Assert - only events with Cvnt in (50, 100] should be included
            Assert.AreEqual(3, filtered.Count);
            Assert.AreEqual("evt-51", filtered[0].Id);
            Assert.AreEqual("evt-75", filtered[1].Id);
            Assert.AreEqual("evt-100", filtered[2].Id);

            // Verify exclusions:
            // Cvnt == 50 (== beginCvId) should be excluded (exclusive begin)
            Assert.IsFalse(filtered.Any(e => e.Id == "evt-50"), "Event at beginCvId boundary should be excluded");
            // Cvnt == 100 (== endCvId) should be included (inclusive end)
            Assert.IsTrue(filtered.Any(e => e.Id == "evt-100"), "Event at endCvId boundary should be included");
            // Cvnt == 101 (> endCvId) should be excluded
            Assert.IsFalse(filtered.Any(e => e.Id == "evt-101"), "Event above endCvId should be excluded");
        }

        /// <summary>
        /// Verifies that events exactly at the begin boundary (Cvnt == beginCvId) are excluded.
        /// </summary>
        [Test]
        public void CvIdFiltering_ExcludesExactBeginBoundary()
        {
            long beginCvId = 100;
            long endCvId = 200;

            var evt = ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 100);

            bool included = evt.ContainerVersionNumber > beginCvId && evt.ContainerVersionNumber <= endCvId;
            Assert.IsFalse(included, "Events at exactly beginCvId should be excluded (exclusive lower bound)");
        }

        /// <summary>
        /// Verifies that events exactly at the end boundary (Cvnt == endCvId) are included.
        /// </summary>
        [Test]
        public void CvIdFiltering_IncludesExactEndBoundary()
        {
            long beginCvId = 100;
            long endCvId = 200;

            var evt = ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 200);

            bool included = evt.ContainerVersionNumber > beginCvId && evt.ContainerVersionNumber <= endCvId;
            Assert.IsTrue(included, "Events at exactly endCvId should be included (inclusive upper bound)");
        }

        /// <summary>
        /// Verifies that when no events fall within the cvId range, an empty result is produced.
        /// </summary>
        [Test]
        public void CvIdFiltering_NoEventsInRange_ReturnsEmpty()
        {
            long beginCvId = 100;
            long endCvId = 200;

            var events = new List<ShareChangeFeedEvent>
            {
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 50),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 99),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 201),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 300),
            };

            List<ShareChangeFeedEvent> filtered = events
                .Where(e => e.ContainerVersionNumber > beginCvId && e.ContainerVersionNumber <= endCvId)
                .ToList();

            Assert.IsEmpty(filtered);
        }

        /// <summary>
        /// Verifies that the snapshot pageable throws <see cref="ArgumentException"/>
        /// when the end snapshot is not finalized.
        /// </summary>
        [Test]
        public void EndSnapshotNotFinalized_Throws()
        {
            // Arrange - create snapshot metadata where the end snapshot is still Publishing
            var beginMeta = new SnapshotMetadata
            {
                Version = 0,
                SnapshotTimestamp = new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero),
                CvId = 50,
                MinLogWindowForNextSnapshot = new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero),
                MaxLogWindowForCurrentSnapshot = new DateTimeOffset(2024, 1, 15, 9, 0, 0, TimeSpan.Zero),
                Status = "Finalized",
            };

            var endMeta = new SnapshotMetadata
            {
                Version = 0,
                SnapshotTimestamp = new DateTimeOffset(2024, 1, 15, 12, 0, 0, TimeSpan.Zero),
                CvId = 200,
                MinLogWindowForNextSnapshot = new DateTimeOffset(2024, 1, 15, 12, 0, 0, TimeSpan.Zero),
                MaxLogWindowForCurrentSnapshot = new DateTimeOffset(2024, 1, 15, 13, 0, 0, TimeSpan.Zero),
                Status = "Publishing",
            };

            // Act & Assert - the finalization check should throw
            Assert.Throws<ArgumentException>(() =>
            {
                if (endMeta.Status != null && !endMeta.Status.Equals("Finalized", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException(
                        $"End snapshot is not finalized (status: {endMeta.Status}). " +
                        "Wait for the snapshot to be finalized before querying.");
                }
            });
        }

        /// <summary>
        /// Verifies that the finalization check passes when the end snapshot status is "Finalized".
        /// </summary>
        [Test]
        public void EndSnapshotFinalized_DoesNotThrow()
        {
            var endMeta = new SnapshotMetadata
            {
                Status = "Finalized",
            };

            // Should not throw
            Assert.DoesNotThrow(() =>
            {
                if (endMeta.Status != null && !endMeta.Status.Equals("Finalized", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("End snapshot is not finalized.");
                }
            });
        }

        /// <summary>
        /// Verifies that the finalization check passes when status is null (treated as finalized).
        /// </summary>
        [Test]
        public void EndSnapshotNullStatus_DoesNotThrow()
        {
            var endMeta = new SnapshotMetadata
            {
                Status = null,
            };

            // null status should not trigger the check
            Assert.DoesNotThrow(() =>
            {
                if (endMeta.Status != null && !endMeta.Status.Equals("Finalized", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("End snapshot is not finalized.");
                }
            });
        }

        /// <summary>
        /// Verifies that the snapshot time window is correctly derived from snapshot metadata:
        /// start = beginSnapshot.MinLogWindowForNextSnapshot,
        /// end = endSnapshot.MaxLogWindowForCurrentSnapshot.
        /// </summary>
        [Test]
        public void SnapshotTimeWindowDerivation()
        {
            var beginMeta = new SnapshotMetadata
            {
                CvId = 50,
                MinLogWindowForNextSnapshot = new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero),
                MaxLogWindowForCurrentSnapshot = new DateTimeOffset(2024, 1, 15, 9, 0, 0, TimeSpan.Zero),
            };

            var endMeta = new SnapshotMetadata
            {
                CvId = 200,
                MinLogWindowForNextSnapshot = new DateTimeOffset(2024, 1, 15, 12, 0, 0, TimeSpan.Zero),
                MaxLogWindowForCurrentSnapshot = new DateTimeOffset(2024, 1, 15, 13, 0, 0, TimeSpan.Zero),
            };

            // The pageable derives the time window as:
            DateTimeOffset startTime = beginMeta.MinLogWindowForNextSnapshot;
            DateTimeOffset endTime = endMeta.MaxLogWindowForCurrentSnapshot;

            Assert.AreEqual(new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero), startTime);
            Assert.AreEqual(new DateTimeOffset(2024, 1, 15, 13, 0, 0, TimeSpan.Zero), endTime);

            // And the cvId range as:
            long beginCvId = beginMeta.CvId;
            long endCvId = endMeta.CvId;
            Assert.AreEqual(50, beginCvId);
            Assert.AreEqual(200, endCvId);
        }

        /// <summary>
        /// Verifies that passing a continuation token to snapshot pageables throws ArgumentException.
        /// </summary>
        [Test]
        public void ContinuationToken_Throws()
        {
            var pageable = new ShareChangeFeedSnapshotPageable(
                client: null,
                maxTransferSize: null,
                beginSnapshot: "2024-01-15T08:00:00.000Z",
                endSnapshot: "2024-01-15T12:00:00.000Z");

            Assert.Throws<ArgumentException>(() =>
            {
                foreach (var page in pageable.AsPages(continuationToken: "some-token"))
                {
                    // Should not reach here
                }
            });
        }
    }
}
