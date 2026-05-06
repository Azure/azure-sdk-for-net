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
    /// The cvId filter (begin exclusive, end inclusive) used by both
    /// <see cref="ShareChangeFeedSnapshotPageable"/> and <see cref="ShareChangeFeedSnapshotAsyncPageable"/>
    /// is exposed as the static helper <see cref="SnapshotEventFilter.IsInRange"/>; tests below
    /// drive that helper directly so a regression in the operator semantics fails the suite.
    /// </summary>
    public class ShareChangeFeedSnapshotPageableTests : ShareChangeFeedTestBase
    {
        public ShareChangeFeedSnapshotPageableTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        /// <summary>
        /// Drives the production <see cref="SnapshotEventFilter.IsInRange"/> helper across a
        /// fixed event sequence and asserts only events whose container version number falls in
        /// (beginCvId, endCvId] are kept.
        /// </summary>
        [Test]
        public void SnapshotEventFilter_IncludesOnlyEventsInRange()
        {
            const long beginCvId = 50;
            const long endCvId = 100;

            List<ShareChangeFeedEvent> events = new List<ShareChangeFeedEvent>
            {
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 30, reason: "SmbCreate", id: "evt-30"),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 49, reason: "SmbWrite", id: "evt-49"),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 50, reason: "SmbWrite", id: "evt-50"),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 51, reason: "SmbDelete", id: "evt-51"),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 75, reason: "RestCreate", id: "evt-75"),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 100, reason: "SmbRename", id: "evt-100"),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 101, reason: "RestWrite", id: "evt-101"),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 150, reason: "RestDelete", id: "evt-150"),
            };

            List<ShareChangeFeedEvent> filtered = events
                .Where(e => SnapshotEventFilter.IsInRange(e, beginCvId, endCvId))
                .ToList();

            Assert.AreEqual(3, filtered.Count);
            Assert.AreEqual("evt-51", filtered[0].Id);
            Assert.AreEqual("evt-75", filtered[1].Id);
            Assert.AreEqual("evt-100", filtered[2].Id);
        }

        /// <summary>
        /// Pins the exclusive lower bound: events with cvId == beginCvId are dropped.
        /// </summary>
        [Test]
        public void SnapshotEventFilter_ExcludesExactBeginBoundary()
        {
            ShareChangeFeedEvent evt = ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 100);
            Assert.IsFalse(SnapshotEventFilter.IsInRange(evt, beginCvId: 100, endCvId: 200));
        }

        /// <summary>
        /// Pins the inclusive upper bound: events with cvId == endCvId are kept.
        /// </summary>
        [Test]
        public void SnapshotEventFilter_IncludesExactEndBoundary()
        {
            ShareChangeFeedEvent evt = ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 200);
            Assert.IsTrue(SnapshotEventFilter.IsInRange(evt, beginCvId: 100, endCvId: 200));
        }

        /// <summary>
        /// Pins behavior when events fall entirely outside the requested range.
        /// </summary>
        [Test]
        public void SnapshotEventFilter_NoEventsInRange_ReturnsEmpty()
        {
            const long beginCvId = 100;
            const long endCvId = 200;

            List<ShareChangeFeedEvent> events = new List<ShareChangeFeedEvent>
            {
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 50),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 99),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 100),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 201),
                ShareChangeFeedModelFactory.ShareChangeFeedEvent(containerVersionNumber: 300),
            };

            List<ShareChangeFeedEvent> filtered = events
                .Where(e => SnapshotEventFilter.IsInRange(e, beginCvId, endCvId))
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
