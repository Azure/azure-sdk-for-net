// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Storage.Blobs;
using Azure.Storage.Files.Shares;
using Moq;
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
        /// Verifies that a <see cref="ShareChangeFeedSnapshotCursor"/> round-trips through
        /// <see cref="SnapshotCursorSerializer"/> with every field preserved. This pins the
        /// wire contract callers depend on when persisting a continuation token across runs.
        /// </summary>
        [Test]
        public void ContinuationToken_RoundTrips()
        {
            ShareChangeFeedSnapshotCursor original = new ShareChangeFeedSnapshotCursor(
                urlHost: "account.blob.core.windows.net",
                beginSnapshot: "2024-01-15T08:00:00.000Z",
                endSnapshot: "2024-01-15T12:00:00.000Z",
                beginCvId: 50,
                endCvId: 200,
                innerContinuation: @"{""CursorVersion"":1,""UrlHost"":""account.blob.core.windows.net""}");

            string serialized = SnapshotCursorSerializer.Serialize(original);
            ShareChangeFeedSnapshotCursor roundTripped = SnapshotCursorSerializer.Deserialize(serialized);

            Assert.AreEqual(original.CursorVersion, roundTripped.CursorVersion);
            Assert.AreEqual(original.UrlHost, roundTripped.UrlHost);
            Assert.AreEqual(original.BeginSnapshot, roundTripped.BeginSnapshot);
            Assert.AreEqual(original.EndSnapshot, roundTripped.EndSnapshot);
            Assert.AreEqual(original.BeginCvId, roundTripped.BeginCvId);
            Assert.AreEqual(original.EndCvId, roundTripped.EndCvId);
            Assert.AreEqual(original.InnerContinuation, roundTripped.InnerContinuation);
        }

        /// <summary>
        /// Garbage tokens are rejected with <see cref="ArgumentException"/> at the boundary
        /// rather than crashing the underlying <c>JsonSerializer</c>.
        /// </summary>
        [Test]
        public void ContinuationToken_MalformedJson_Throws()
        {
            Assert.Throws<ArgumentException>(
                () => SnapshotCursorSerializer.Deserialize("{not json"));
        }

        /// <summary>
        /// Cursors missing required snapshot context (e.g. an empty envelope) are rejected.
        /// </summary>
        [Test]
        public void ContinuationToken_MissingFields_Throws()
        {
            // Valid JSON but no snapshot context.
            Assert.Throws<ArgumentException>(
                () => SnapshotCursorSerializer.Deserialize("{}"));
        }

        /// <summary>
        /// Resuming a snapshot query against a different storage account is rejected by
        /// <see cref="SnapshotCursorSerializer.Validate"/>. Pins parity with the host check
        /// in the underlying change-feed cursor.
        /// </summary>
        [Test]
        public void ContinuationToken_UrlHostMismatch_Throws()
        {
            ShareChangeFeedSnapshotCursor cursor = new ShareChangeFeedSnapshotCursor(
                urlHost: "first.blob.core.windows.net",
                beginSnapshot: "2024-01-15T08:00:00.000Z",
                endSnapshot: "2024-01-15T12:00:00.000Z",
                beginCvId: 50,
                endCvId: 200,
                innerContinuation: "{}");

            Mock<BlobContainerClient> container = new Mock<BlobContainerClient>();
            container.Setup(c => c.Uri).Returns(new Uri("https://second.blob.core.windows.net/$changefeed"));

            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => SnapshotCursorSerializer.Validate(container.Object, cursor));
            StringAssert.Contains("URL Host", ex.Message);
        }

        /// <summary>
        /// Cursors with an unrecognized <c>CursorVersion</c> are rejected so future schema
        /// changes can fail fast instead of silently misinterpreting fields.
        /// </summary>
        [Test]
        public void ContinuationToken_UnsupportedVersion_Throws()
        {
            ShareChangeFeedSnapshotCursor cursor = new ShareChangeFeedSnapshotCursor(
                urlHost: "account.blob.core.windows.net",
                beginSnapshot: "2024-01-15T08:00:00.000Z",
                endSnapshot: "2024-01-15T12:00:00.000Z",
                beginCvId: 50,
                endCvId: 200,
                innerContinuation: "{}");
            cursor.CursorVersion = 99;

            Mock<BlobContainerClient> container = new Mock<BlobContainerClient>();
            container.Setup(c => c.Uri).Returns(new Uri("https://account.blob.core.windows.net/$changefeed"));

            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => SnapshotCursorSerializer.Validate(container.Object, cursor));
            StringAssert.Contains("version", ex.Message);
        }

        /// <summary>
        /// The construction-time continuation-only ctor rejects a null/empty token so callers
        /// see the problem at the <c>GetChangesBetweenSnapshots(string)</c> call site rather
        /// than deep inside enumeration.
        /// </summary>
        [Test]
        public void ContinuationOnlyCtor_NullToken_Throws()
        {
            Assert.Throws<ArgumentNullException>(
                () => new ShareChangeFeedSnapshotPageable(client: null, maxTransferSize: null, continuation: null));
            Assert.Throws<ArgumentNullException>(
                () => new ShareChangeFeedSnapshotAsyncPageable(client: null, maxTransferSize: null, continuation: null));
            Assert.Throws<ArgumentNullException>(
                () => new ShareChangeFeedSnapshotPageable(client: null, maxTransferSize: null, continuation: ""));
            Assert.Throws<ArgumentNullException>(
                () => new ShareChangeFeedSnapshotAsyncPageable(client: null, maxTransferSize: null, continuation: ""));
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

        // Snapshot strings must be in canonical UTC ISO 8601 form ('Z' suffix). The service emits
        // them this way, and the snapshot string is used verbatim to derive the meta blob path —
        // accepting other offsets would let two strings naming the same UTC instant resolve to
        // different paths. The cases below pin the strict-Z contract.

        [TestCase("2024-01-15T08:00:00+05:00")]   // valid offset, but not UTC
        [TestCase("2024-01-15T08:00:00+00:00")]   // semantically UTC, but no Z suffix
        [TestCase("2024-01-15T08:00:00")]         // no offset and no Z (would parse as local time)
        [TestCase("2024-01-15T08:00:00.000z")]    // lowercase z is non-canonical
        public void Validation_NonUtcSnapshot_Throws(string snapshot)
        {
            const string validUtc = "2024-01-15T12:00:00.000Z";

            ArgumentException beginEx = Assert.Throws<ArgumentException>(
                () => new ShareChangeFeedSnapshotPageable(null, null, beginSnapshot: snapshot, endSnapshot: validUtc));
            Assert.AreEqual("beginSnapshot", beginEx.ParamName);
            StringAssert.Contains("UTC", beginEx.Message);
            StringAssert.Contains("Z", beginEx.Message);

            ArgumentException endEx = Assert.Throws<ArgumentException>(
                () => new ShareChangeFeedSnapshotAsyncPageable(null, null, beginSnapshot: validUtc, endSnapshot: snapshot));
            Assert.AreEqual("endSnapshot", endEx.ParamName);
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
