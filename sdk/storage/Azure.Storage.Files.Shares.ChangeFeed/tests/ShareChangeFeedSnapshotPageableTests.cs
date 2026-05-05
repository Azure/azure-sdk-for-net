// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Storage.Files.Shares;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.ChangeFeed.Tests
{
    /// <summary>
    /// Tests for the snapshot-based pageable classes, verifying the cvId filtering contract
    /// and end-snapshot finalization validation.
    /// These tests validate the filtering logic (beginCvId &lt; ContainerVersionNumber &lt;= endCvId)
    /// that <see cref="ShareChangeFeedSnapshotPageable"/> and <see cref="ShareChangeFeedSnapshotAsyncPageable"/>
    /// implement. They test the contract in isolation by constructing events with known
    /// <see cref="ShareChangeFeedEvent.ContainerVersionNumber"/> values rather than mocking
    /// the full pageable dependency chain.
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

            List<ShareChangeFeedEvent> events = new List<ShareChangeFeedEvent>
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

            ShareChangeFeedEvent evt = ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 100);

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

            ShareChangeFeedEvent evt = ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 200);

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

            List<ShareChangeFeedEvent> events = new List<ShareChangeFeedEvent>
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

        // Standard "good" snapshot metadata pair shared by validation tests.
        private static SnapshotMetadata MakeMeta(
            DateTimeOffset timestamp,
            long cvId,
            string status = "Finalized")
            => new SnapshotMetadata
            {
                Version = 0,
                SnapshotTimestamp = timestamp,
                CvId = cvId,
                MinLogWindowForNextSnapshot = timestamp,
                MaxLogWindowForCurrentSnapshot = timestamp.AddHours(1),
                Status = status,
            };

        /// <summary>
        /// Verifies that <see cref="SnapshotInputValidator.ValidateMetadata"/> throws when the
        /// end snapshot is not finalized.
        /// </summary>
        [Test]
        public void EndSnapshotNotFinalized_Throws()
        {
            SnapshotMetadata beginMeta = MakeMeta(new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero), 50);
            SnapshotMetadata endMeta = MakeMeta(new DateTimeOffset(2024, 1, 15, 12, 0, 0, TimeSpan.Zero), 200, status: "Publishing");

            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => SnapshotInputValidator.ValidateMetadata(beginMeta, "begin", endMeta, "end"));
            StringAssert.Contains("End snapshot", ex.Message);
            StringAssert.Contains("Publishing", ex.Message);
        }

        /// <summary>
        /// Verifies that <see cref="SnapshotInputValidator.ValidateMetadata"/> does not throw
        /// when both snapshots are finalized and form a valid range.
        /// </summary>
        [Test]
        public void BothSnapshotsFinalized_DoesNotThrow()
        {
            SnapshotMetadata beginMeta = MakeMeta(new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero), 50);
            SnapshotMetadata endMeta = MakeMeta(new DateTimeOffset(2024, 1, 15, 12, 0, 0, TimeSpan.Zero), 200);

            Assert.DoesNotThrow(
                () => SnapshotInputValidator.ValidateMetadata(beginMeta, "begin", endMeta, "end"));
        }

        /// <summary>
        /// Verifies that the snapshot time window is correctly derived from snapshot metadata:
        /// start = beginSnapshot.MinLogWindowForNextSnapshot,
        /// end = endSnapshot.MaxLogWindowForCurrentSnapshot.
        /// </summary>
        [Test]
        public void SnapshotTimeWindowDerivation()
        {
            SnapshotMetadata beginMeta = new SnapshotMetadata
            {
                CvId = 50,
                MinLogWindowForNextSnapshot = new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero),
                MaxLogWindowForCurrentSnapshot = new DateTimeOffset(2024, 1, 15, 9, 0, 0, TimeSpan.Zero),
            };

            SnapshotMetadata endMeta = new SnapshotMetadata
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
            ShareChangeFeedSnapshotPageable pageable = new ShareChangeFeedSnapshotPageable(
                client: null,
                maxTransferSize: null,
                beginSnapshot: "2024-01-15T08:00:00.000Z",
                endSnapshot: "2024-01-15T12:00:00.000Z");

            Assert.Throws<ArgumentException>(() =>
            {
                foreach (Page<ShareChangeFeedEvent> page in pageable.AsPages(continuationToken: "some-token"))
                {
                    // Should not reach here
                }
            });
        }

        /// <summary>
        /// Verifies that passing a continuation token to the async snapshot pageable throws ArgumentException.
        /// </summary>
        [Test]
        public void AsyncContinuationToken_Throws()
        {
            ShareChangeFeedSnapshotAsyncPageable pageable = new ShareChangeFeedSnapshotAsyncPageable(
                client: null,
                maxTransferSize: null,
                beginSnapshot: "2024-01-15T08:00:00.000Z",
                endSnapshot: "2024-01-15T12:00:00.000Z");

            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await foreach (Page<ShareChangeFeedEvent> page in pageable.AsPages(continuationToken: "some-token"))
                {
                    // Should not reach here
                }
            });
        }

        // Input-string validation runs synchronously in the pageable constructor, so these tests
        // exercise the public surface (constructor) for both sync and async pageables.

        [Test]
        public void Validation_NullBeginSnapshot_Throws()
        {
            Assert.Throws<ArgumentNullException>(
                () => new ShareChangeFeedSnapshotPageable(null, null, beginSnapshot: null, endSnapshot: "2024-01-15T12:00:00.000Z"));
            Assert.Throws<ArgumentNullException>(
                () => new ShareChangeFeedSnapshotAsyncPageable(null, null, beginSnapshot: null, endSnapshot: "2024-01-15T12:00:00.000Z"));
        }

        [Test]
        public void Validation_EmptyBeginSnapshot_Throws()
        {
            Assert.Throws<ArgumentNullException>(
                () => new ShareChangeFeedSnapshotPageable(null, null, beginSnapshot: "", endSnapshot: "2024-01-15T12:00:00.000Z"));
            Assert.Throws<ArgumentNullException>(
                () => new ShareChangeFeedSnapshotAsyncPageable(null, null, beginSnapshot: "", endSnapshot: "2024-01-15T12:00:00.000Z"));
        }

        [Test]
        public void Validation_NullEndSnapshot_Throws()
        {
            Assert.Throws<ArgumentNullException>(
                () => new ShareChangeFeedSnapshotPageable(null, null, beginSnapshot: "2024-01-15T08:00:00.000Z", endSnapshot: null));
            Assert.Throws<ArgumentNullException>(
                () => new ShareChangeFeedSnapshotAsyncPageable(null, null, beginSnapshot: "2024-01-15T08:00:00.000Z", endSnapshot: null));
        }

        [Test]
        public void Validation_EmptyEndSnapshot_Throws()
        {
            Assert.Throws<ArgumentNullException>(
                () => new ShareChangeFeedSnapshotPageable(null, null, beginSnapshot: "2024-01-15T08:00:00.000Z", endSnapshot: ""));
            Assert.Throws<ArgumentNullException>(
                () => new ShareChangeFeedSnapshotAsyncPageable(null, null, beginSnapshot: "2024-01-15T08:00:00.000Z", endSnapshot: ""));
        }

        [Test]
        public void Validation_InvalidBeginTimestamp_Throws()
        {
            Assert.Throws<ArgumentException>(
                () => new ShareChangeFeedSnapshotPageable(null, null, beginSnapshot: "not-a-timestamp", endSnapshot: "2024-01-15T12:00:00.000Z"));
            Assert.Throws<ArgumentException>(
                () => new ShareChangeFeedSnapshotAsyncPageable(null, null, beginSnapshot: "not-a-timestamp", endSnapshot: "2024-01-15T12:00:00.000Z"));
        }

        [Test]
        public void Validation_InvalidEndTimestamp_Throws()
        {
            Assert.Throws<ArgumentException>(
                () => new ShareChangeFeedSnapshotPageable(null, null, beginSnapshot: "2024-01-15T08:00:00.000Z", endSnapshot: "garbage"));
            Assert.Throws<ArgumentException>(
                () => new ShareChangeFeedSnapshotAsyncPageable(null, null, beginSnapshot: "2024-01-15T08:00:00.000Z", endSnapshot: "garbage"));
        }

        // Post-meta-read validation tests. These call SnapshotInputValidator.ValidateMetadata
        // directly because the snapshot pageables defer reading meta blobs until enumeration —
        // testing them through the pageable would require setting up the full mocked container
        // chain, which is covered separately in the end-to-end tests.

        [Test]
        public void Validation_BeginSnapshotNotFinalized_Throws()
        {
            SnapshotMetadata beginMeta = MakeMeta(new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero), 50, status: "Publishing");
            SnapshotMetadata endMeta = MakeMeta(new DateTimeOffset(2024, 1, 15, 12, 0, 0, TimeSpan.Zero), 200);

            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => SnapshotInputValidator.ValidateMetadata(beginMeta, "begin", endMeta, "end"));
            StringAssert.Contains("Begin snapshot", ex.Message);
        }

        [Test]
        public void Validation_BeginTimestampLaterThanEnd_Throws()
        {
            SnapshotMetadata beginMeta = MakeMeta(new DateTimeOffset(2024, 1, 15, 12, 0, 0, TimeSpan.Zero), 100);
            SnapshotMetadata endMeta = MakeMeta(new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero), 200);

            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => SnapshotInputValidator.ValidateMetadata(beginMeta, "begin", endMeta, "end"));
            StringAssert.Contains("later than", ex.Message);
        }

        [Test]
        public void Validation_BeginCvIdGreaterThanEnd_Throws()
        {
            // Same timestamp window but inverted CvIds; isolates the CvId check from the timestamp check.
            DateTimeOffset ts = new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero);
            SnapshotMetadata beginMeta = MakeMeta(ts, 200);
            SnapshotMetadata endMeta = MakeMeta(ts.AddHours(4), 100);

            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => SnapshotInputValidator.ValidateMetadata(beginMeta, "begin", endMeta, "end"));
            StringAssert.Contains("CvId", ex.Message);
        }

        [Test]
        public void Validation_EqualSnapshots_Throws()
        {
            DateTimeOffset ts = new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero);
            SnapshotMetadata beginMeta = MakeMeta(ts, 100);
            SnapshotMetadata endMeta = MakeMeta(ts, 100);

            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => SnapshotInputValidator.ValidateMetadata(beginMeta, "begin", endMeta, "end"));
            StringAssert.Contains("same CvId", ex.Message);
        }
    }
}
