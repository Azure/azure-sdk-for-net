// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.ChangeFeed.Common;
using Azure.Storage.Files.Shares;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.ChangeFeed.Tests
{
    /// <summary>
    /// Mocked unit tests for the Files Change Feed reset-marker support
    /// (<see cref="ResetMarkerReader"/>, <see cref="ShareChangeFeedResetEvent"/>,
    /// <see cref="ShareChangeFeedResetException"/>, <see cref="ShareChangeFeedCursor"/>,
    /// <see cref="ShareChangeFeedSnapshotCursor"/> reset fields, and
    /// <see cref="ShareChangeFeedClient.ResolveEffectivePolicy(bool)"/>).
    /// The container client is mocked so no service traffic is generated.
    /// </summary>
    public class ShareChangeFeedResetTests : ShareChangeFeedTestBase
    {
        private static readonly Guid ResetIdFixture = Guid.Parse("A1B2C3D4-E5F6-7890-ABCD-EF0123456789");
        private const long ResetFileTimeFixture = 133871234567890123L;
        private static readonly DateTimeOffset ResetTimeUtcFixture =
            new DateTimeOffset(2025, 11, 19, 14, 32, 11, 456, TimeSpan.Zero);
        private const string ResetMarkerPathFixture = "meta/resets/00133871234567890123.json";
        private const string ResetReasonFixture = "Customer-managed unplanned failover";
        private const string AccountNameFixture = "contosostorage";
        private const string ContainerNameFixture = "mysharename";

        private static readonly Uri ChangeFeedContainerUri =
            new Uri("https://contosostorage.blob.core.windows.net/fileschangefeed-mysharename");

        public ShareChangeFeedResetTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        #region ResetMarkerReader parsing

        [Test]
        public async Task TryReadPointerAsync_BlobNotFound_ReturnsNull()
        {
            Mock<BlobContainerClient> container = MockContainer();
            SetupBlob(container, Constants.FilesChangeFeed.ResetLatestJsonPath, exists: false, json: null);

            ShareChangeFeedResetPointer result = await ResetMarkerReader.TryReadPointerAsync(
                container.Object,
                async: IsAsync,
                cancellationToken: default);

            Assert.IsNull(result);
        }

        [Test]
        public async Task TryReadPointerAsync_HappyPath_ParsesAllFields()
        {
            Mock<BlobContainerClient> container = MockContainer();
            SetupBlob(
                container,
                Constants.FilesChangeFeed.ResetLatestJsonPath,
                exists: true,
                json: BuildPointerJson());

            ShareChangeFeedResetPointer result = await ResetMarkerReader.TryReadPointerAsync(
                container.Object,
                async: IsAsync,
                cancellationToken: default);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.SchemaVersion);
            Assert.AreEqual(ResetIdFixture, result.LatestResetId);
            Assert.AreEqual(ResetFileTimeFixture, result.LatestResetFileTime);
            Assert.AreEqual(ResetTimeUtcFixture, result.LatestResetTimeUtc);
            Assert.AreEqual(ResetMarkerPathFixture, result.LatestMarkerPath);
            Assert.AreEqual(AccountNameFixture, result.AccountName);
            Assert.AreEqual(ContainerNameFixture, result.ContainerName);
            Assert.AreEqual(ResetReasonFixture, result.Reason);
        }

        [Test]
        public void TryReadPointer_MissingRequiredField_ThrowsFormatException()
        {
            // Drop "resetId" (LatestResetId key).
            string malformed = @"{""schemaVersion"":1,""latestResetFileTime"":133871234567890123,""latestResetTimeUtc"":""2025-11-19T14:32:11.456Z"",""latestMarkerPath"":""meta/resets/00133871234567890123.json"",""accountName"":""a"",""containerName"":""c"",""reason"":""r""}";

            Mock<BlobContainerClient> container = MockContainer();
            SetupBlob(container, Constants.FilesChangeFeed.ResetLatestJsonPath, exists: true, json: malformed);

            Assert.ThrowsAsync<FormatException>(async () =>
                await ResetMarkerReader.TryReadPointerAsync(container.Object, async: true, cancellationToken: default));
        }

        [Test]
        public void TryReadPointer_InvalidGuid_ThrowsFormatException()
        {
            string malformed = @"{""schemaVersion"":1,""latestResetId"":""not-a-guid"",""latestResetFileTime"":1,""latestResetTimeUtc"":""2025-11-19T14:32:11.456Z"",""latestMarkerPath"":""meta/resets/0.json"",""accountName"":""a"",""containerName"":""c"",""reason"":""r""}";

            Mock<BlobContainerClient> container = MockContainer();
            SetupBlob(container, Constants.FilesChangeFeed.ResetLatestJsonPath, exists: true, json: malformed);

            Assert.ThrowsAsync<FormatException>(async () =>
                await ResetMarkerReader.TryReadPointerAsync(container.Object, async: true, cancellationToken: default));
        }

        [Test]
        public async Task ReadPerEventAsync_HappyPath_ParsesAllFields()
        {
            Mock<BlobContainerClient> container = MockContainer();
            SetupBlob(container, ResetMarkerPathFixture, exists: true, json: BuildPerEventJson());

            ShareChangeFeedResetMarker result = await ResetMarkerReader.ReadPerEventAsync(
                container.Object,
                ResetMarkerPathFixture,
                async: IsAsync,
                cancellationToken: default);

            Assert.AreEqual(1, result.SchemaVersion);
            Assert.AreEqual(ResetIdFixture, result.ResetId);
            Assert.AreEqual(ResetFileTimeFixture, result.ResetFileTime);
            Assert.AreEqual(ResetTimeUtcFixture, result.ResetTimeUtc);
            Assert.AreEqual(AccountNameFixture, result.AccountName);
            Assert.AreEqual(ContainerNameFixture, result.ContainerName);
            Assert.AreEqual(ResetReasonFixture, result.Reason);
        }

        [Test]
        public void ReadPerEventAsync_PathOutsideResetPrefix_Throws()
        {
            Mock<BlobContainerClient> container = MockContainer();
            // The mock does not need to actually serve this blob; the reader must reject
            // the malformed path before it issues the download.

            InvalidOperationException ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await ResetMarkerReader.ReadPerEventAsync(
                    container.Object,
                    markerPath: "meta/segments/2025/attack.json",
                    async: true,
                    cancellationToken: default));

            StringAssert.Contains(Constants.FilesChangeFeed.ResetEventPrefix, ex.Message);
        }

        [Test]
        public void ReadPerEventAsync_EmptyPath_Throws()
        {
            Mock<BlobContainerClient> container = MockContainer();

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await ResetMarkerReader.ReadPerEventAsync(
                    container.Object,
                    markerPath: null,
                    async: true,
                    cancellationToken: default));
        }

        [Test]
        public void ReadPerEventAsync_BlobNotFound_ThrowsInvalidOperation()
        {
            Mock<BlobContainerClient> container = MockContainer();
            SetupBlob(container, ResetMarkerPathFixture, exists: false, json: null);

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await ResetMarkerReader.ReadPerEventAsync(
                    container.Object,
                    ResetMarkerPathFixture,
                    async: true,
                    cancellationToken: default));
        }

        #endregion ResetMarkerReader parsing

        #region ShareChangeFeedResetEvent

        [Test]
        public void BuildResetEvent_PopulatesAllFieldsFromPointerAndMarker()
        {
            ShareChangeFeedResetPointer pointer = BuildPointer();
            ShareChangeFeedResetMarker perEvent = BuildPerEvent();

            ShareChangeFeedResetEvent evt = ResetMarkerReader.BuildResetEvent(pointer, perEvent);

            Assert.AreEqual(ResetIdFixture, evt.ResetId);
            Assert.AreEqual(ResetFileTimeFixture, evt.ResetFileTime);
            Assert.AreEqual(AccountNameFixture, evt.AccountName);
            Assert.AreEqual(ContainerNameFixture, evt.ContainerName);
            Assert.AreEqual(ResetReasonFixture, evt.ResetReason);
            // Base fields populated from the per-event marker.
            Assert.AreEqual(ShareChangeFeedReasonType.Reset, evt.Reason);
            Assert.AreEqual(ResetTimeUtcFixture, evt.EventTime);
            Assert.AreEqual(ResetIdFixture.ToString(), evt.Id);
            Assert.AreEqual(1, evt.SchemaVersion);
        }

        [Test]
        public void BuildResetEvent_NullPointer_Throws()
            => Assert.Throws<ArgumentNullException>(() => ResetMarkerReader.BuildResetEvent(null, BuildPerEvent()));

        [Test]
        public void BuildResetEvent_NullPerEvent_Throws()
            => Assert.Throws<ArgumentNullException>(() => ResetMarkerReader.BuildResetEvent(BuildPointer(), null));

        [Test]
        public void ShareChangeFeedResetException_PopulatesResetEvent()
        {
            ShareChangeFeedResetEvent evt = ResetMarkerReader.BuildResetEvent(BuildPointer(), BuildPerEvent());
            ShareChangeFeedResetException ex = new ShareChangeFeedResetException(evt);

            Assert.AreSame(evt, ex.ResetEvent);
            StringAssert.Contains(ResetIdFixture.ToString(), ex.Message);
            StringAssert.Contains(ResetReasonFixture, ex.Message);
        }

        #endregion ShareChangeFeedResetEvent

        #region ShareChangeFeedCursor round-trip

        [Test]
        public void ShareChangeFeedCursor_SerializeThenDeserialize_PreservesAllFields()
        {
            ChangeFeedCursor inner = new ChangeFeedCursor(
                urlHost: ChangeFeedContainerUri.Host,
                endDateTime: new DateTimeOffset(2025, 11, 20, 0, 0, 0, TimeSpan.Zero),
                currentSegmentCursor: new SegmentCursor("idx/segments/2025/11/19/1500/meta.json", null, null));

            ShareChangeFeedCursor original = new ShareChangeFeedCursor(
                urlHost: ChangeFeedContainerUri.Host,
                innerCursor: inner,
                lastSeenResetId: ResetIdFixture,
                lastSeenResetFileTime: ResetFileTimeFixture);

            string serialized = ShareChangeFeedCursorSerializer.Serialize(original);
            ShareChangeFeedCursor round = ShareChangeFeedCursorSerializer.Deserialize(serialized);

            Assert.AreEqual(1, round.CursorVersion);
            Assert.AreEqual(ChangeFeedContainerUri.Host, round.UrlHost);
            Assert.IsNotNull(round.InnerCursor);
            Assert.AreEqual(inner.UrlHost, round.InnerCursor.UrlHost);
            Assert.AreEqual(inner.EndTime, round.InnerCursor.EndTime);
            Assert.AreEqual(ResetIdFixture, round.LastSeenResetId);
            Assert.AreEqual(ResetFileTimeFixture, round.LastSeenResetFileTime);
        }

        [Test]
        public void ShareChangeFeedCursor_Deserialize_NullOrGarbage_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => ShareChangeFeedCursorSerializer.Deserialize(null));
            Assert.Throws<ArgumentException>(() => ShareChangeFeedCursorSerializer.Deserialize("not-a-json-doc"));
            // Valid JSON but missing required InnerCursor / UrlHost.
            Assert.Throws<ArgumentException>(() => ShareChangeFeedCursorSerializer.Deserialize("{}"));
        }

        [Test]
        public void ShareChangeFeedCursor_Validate_MismatchedHost_Throws()
        {
            ShareChangeFeedCursor cursor = new ShareChangeFeedCursor(
                urlHost: "otheraccount.blob.core.windows.net",
                innerCursor: new ChangeFeedCursor(ChangeFeedContainerUri.Host, null, null),
                lastSeenResetId: null,
                lastSeenResetFileTime: null);

            Mock<BlobContainerClient> container = MockContainer();

            Assert.Throws<ArgumentException>(() =>
                ShareChangeFeedCursorSerializer.Validate(container.Object, cursor));
        }

        [Test]
        public void ShareChangeFeedCursor_Validate_UnsupportedVersion_Throws()
        {
            ShareChangeFeedCursor cursor = new ShareChangeFeedCursor(
                urlHost: ChangeFeedContainerUri.Host,
                innerCursor: new ChangeFeedCursor(ChangeFeedContainerUri.Host, null, null),
                lastSeenResetId: null,
                lastSeenResetFileTime: null)
            {
                CursorVersion = 999,
            };

            Mock<BlobContainerClient> container = MockContainer();

            Assert.Throws<ArgumentException>(() =>
                ShareChangeFeedCursorSerializer.Validate(container.Object, cursor));
        }

        #endregion ShareChangeFeedCursor round-trip

        #region ShareChangeFeedSnapshotCursor reset fields

        [Test]
        public void ShareChangeFeedSnapshotCursor_SerializeThenDeserialize_PreservesResetFields()
        {
            ChangeFeedCursor inner = new ChangeFeedCursor(
                urlHost: ChangeFeedContainerUri.Host,
                endDateTime: null,
                currentSegmentCursor: new SegmentCursor("idx/segments/2025/11/19/1500/meta.json", null, null));

            ShareChangeFeedSnapshotCursor original = new ShareChangeFeedSnapshotCursor(
                urlHost: ChangeFeedContainerUri.Host,
                beginSnapshot: "2025-11-19T13:00:00.000Z",
                endSnapshot: "2025-11-19T15:00:00.000Z",
                beginCvId: 100,
                endCvId: 200,
                innerCursor: inner,
                lastSeenResetId: ResetIdFixture,
                lastSeenResetFileTime: ResetFileTimeFixture);

            string serialized = SnapshotCursorSerializer.Serialize(original);
            ShareChangeFeedSnapshotCursor round = SnapshotCursorSerializer.Deserialize(serialized);

            Assert.AreEqual(ResetIdFixture, round.LastSeenResetId);
            Assert.AreEqual(ResetFileTimeFixture, round.LastSeenResetFileTime);
            Assert.AreEqual("2025-11-19T13:00:00.000Z", round.BeginSnapshot);
            Assert.AreEqual("2025-11-19T15:00:00.000Z", round.EndSnapshot);
            Assert.AreEqual(100, round.BeginCvId);
            Assert.AreEqual(200, round.EndCvId);
        }

        #endregion ShareChangeFeedSnapshotCursor reset fields

        #region ResolveEffectivePolicy

        [Test]
        public void ResolveEffectivePolicy_NoOptions_DefaultsToPerApi()
        {
            ShareChangeFeedClient client = new ShareChangeFeedClient(
                new Uri("https://account.file.core.windows.net"),
                "myshare");

            Assert.AreEqual(ShareChangeFeedResetPolicy.ThrowOnReset, client.ResolveEffectivePolicy(isBatched: true));
            Assert.AreEqual(ShareChangeFeedResetPolicy.ContinueOnReset, client.ResolveEffectivePolicy(isBatched: false));
        }

        [Test]
        public void ResolveEffectivePolicy_ExplicitOverride_AppliesToAllApis()
        {
            ShareChangeFeedClient client = new ShareChangeFeedClient(
                new Uri("https://account.file.core.windows.net"),
                "myshare",
                new ShareChangeFeedClientOptions
                {
                    ResetPolicy = ShareChangeFeedResetPolicy.ContinueOnReset,
                });

            Assert.AreEqual(ShareChangeFeedResetPolicy.ContinueOnReset, client.ResolveEffectivePolicy(isBatched: true));
            Assert.AreEqual(ShareChangeFeedResetPolicy.ContinueOnReset, client.ResolveEffectivePolicy(isBatched: false));
        }

        [Test]
        public void ResolveEffectivePolicy_ExplicitThrow_AppliesToStreaming()
        {
            ShareChangeFeedClient client = new ShareChangeFeedClient(
                new Uri("https://account.file.core.windows.net"),
                "myshare",
                new ShareChangeFeedClientOptions
                {
                    ResetPolicy = ShareChangeFeedResetPolicy.ThrowOnReset,
                });

            Assert.AreEqual(ShareChangeFeedResetPolicy.ThrowOnReset, client.ResolveEffectivePolicy(isBatched: false));
            Assert.AreEqual(ShareChangeFeedResetPolicy.ThrowOnReset, client.ResolveEffectivePolicy(isBatched: true));
        }

        #endregion ResolveEffectivePolicy

        #region Helpers

        private static Mock<BlobContainerClient> MockContainer()
        {
            Mock<BlobContainerClient> container = new Mock<BlobContainerClient>(MockBehavior.Loose);
            container.Setup(c => c.Uri).Returns(ChangeFeedContainerUri);
            return container;
        }

        private static void SetupBlob(
            Mock<BlobContainerClient> container,
            string path,
            bool exists,
            string json)
        {
            Mock<BlobClient> blob = new Mock<BlobClient>(MockBehavior.Loose);
            container.Setup(c => c.GetBlobClient(path)).Returns(blob.Object);

            if (exists)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(json);
                blob.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                    .Returns(() => Task.FromResult(Response.FromValue(
                        BlobsModelFactory.BlobDownloadStreamingResult(content: new MemoryStream(bytes)),
                        (Response)null)));
                blob.Setup(b => b.DownloadStreaming(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                    .Returns(() => Response.FromValue(
                        BlobsModelFactory.BlobDownloadStreamingResult(content: new MemoryStream(bytes)),
                        (Response)null));
            }
            else
            {
                RequestFailedException notFound = new RequestFailedException(
                    status: 404,
                    message: "The specified blob does not exist.",
                    errorCode: BlobErrorCode.BlobNotFound.ToString(),
                    innerException: null);
                blob.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                    .ThrowsAsync(notFound);
                blob.Setup(b => b.DownloadStreaming(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                    .Throws(notFound);
            }
        }

        private static string BuildPointerJson()
            => JsonSerializer.Serialize(new
            {
                schemaVersion = 1,
                latestResetId = ResetIdFixture.ToString(),
                latestResetFileTime = ResetFileTimeFixture,
                latestResetTimeUtc = ResetTimeUtcFixture.ToString("O"),
                latestMarkerPath = ResetMarkerPathFixture,
                accountName = AccountNameFixture,
                containerName = ContainerNameFixture,
                reason = ResetReasonFixture,
            });

        private static string BuildPerEventJson()
            => JsonSerializer.Serialize(new
            {
                schemaVersion = 1,
                resetId = ResetIdFixture.ToString(),
                resetFileTime = ResetFileTimeFixture,
                resetTimeUtc = ResetTimeUtcFixture.ToString("O"),
                accountName = AccountNameFixture,
                containerName = ContainerNameFixture,
                reason = ResetReasonFixture,
            });

        private static ShareChangeFeedResetPointer BuildPointer()
            => new ShareChangeFeedResetPointer
            {
                SchemaVersion = 1,
                LatestResetId = ResetIdFixture,
                LatestResetFileTime = ResetFileTimeFixture,
                LatestResetTimeUtc = ResetTimeUtcFixture,
                LatestMarkerPath = ResetMarkerPathFixture,
                AccountName = AccountNameFixture,
                ContainerName = ContainerNameFixture,
                Reason = ResetReasonFixture,
            };

        private static ShareChangeFeedResetMarker BuildPerEvent()
            => new ShareChangeFeedResetMarker
            {
                SchemaVersion = 1,
                ResetId = ResetIdFixture,
                ResetFileTime = ResetFileTimeFixture,
                ResetTimeUtc = ResetTimeUtcFixture,
                AccountName = AccountNameFixture,
                ContainerName = ContainerNameFixture,
                Reason = ResetReasonFixture,
            };

        #endregion Helpers
    }
}
