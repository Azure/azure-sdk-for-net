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
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.ChangeFeed.Tests
{
    /// <summary>
    /// Mocked unit tests for <see cref="ShareChangeFeedClient"/> public operations
    /// (GetLastConsumable, GetChangesBetweenSnapshots) and internal behaviors
    /// (container-discovery caching, flag/time-range interactions). Tests construct
    /// the client through its internal ctor with mocked <see cref="ShareClient"/>
    /// and <see cref="BlobServiceClient"/> dependencies so the entire pipeline
    /// can be exercised without hitting the service.
    /// </summary>
    public class ShareChangeFeedClientMockedTests : ShareChangeFeedTestBase
    {
        private const string ContainerName = "$fileschangefeed-testguid";
        private const string ContainerNameStripped = "fileschangefeed-testguid";

        public ShareChangeFeedClientMockedTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        // ---------- Gap 1: GetLastConsumable ----------

        [Test]
        public async Task GetLastConsumable_HappyPath_ReturnsTimestamp()
        {
            DateTimeOffset expected = new DateTimeOffset(2024, 1, 15, 8, 30, 0, TimeSpan.Zero);
            Harness h = Harness.Create(this, metaSegmentsJson: $@"{{""lastConsumable"":""{expected:O}""}}");

            DateTimeOffset? actual = IsAsync
                ? await h.Client.GetLastConsumableAsync()
                : h.Client.GetLastConsumable();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task GetLastConsumable_BlobNotFound_ReturnsNull()
        {
            Harness h = Harness.Create(this, metaBlobExists: false);

            DateTimeOffset? actual = IsAsync
                ? await h.Client.GetLastConsumableAsync()
                : h.Client.GetLastConsumable();

            Assert.IsNull(actual);
        }

        [Test]
        public void GetLastConsumable_MalformedJson_Throws()
        {
            Harness h = Harness.Create(this, metaSegmentsJson: "{not valid json");

            if (IsAsync)
                Assert.CatchAsync<System.Text.Json.JsonException>(async () => await h.Client.GetLastConsumableAsync());
            else
                Assert.Catch<System.Text.Json.JsonException>(() => h.Client.GetLastConsumable());
        }

        // ---------- Gap 32: container-discovery caching ----------

        [Test]
        public async Task GetContainerClient_CachedAcrossCalls()
        {
            Harness h = Harness.Create(this, metaSegmentsJson: @"{""lastConsumable"":""2024-01-15T08:30:00Z""}");

            // Call GetLastConsumable twice — the second call should not re-discover the container.
            if (IsAsync)
            {
                await h.Client.GetLastConsumableAsync();
                await h.Client.GetLastConsumableAsync();
                h.ShareClient.Verify(c => c.GetPropertiesAsync(It.IsAny<CancellationToken>()), Times.Once());
            }
            else
            {
                h.Client.GetLastConsumable();
                h.Client.GetLastConsumable();
                h.ShareClient.Verify(c => c.GetProperties(It.IsAny<CancellationToken>()), Times.Once());
            }
        }

        // ---------- Gaps 2 & 3: snapshot pageable end-to-end ----------

        // The full filter-and-emit path requires real Avro chunk reads, which can't be reached
        // through the public ShareChangeFeedClient surface without injecting a fake segment
        // factory. Instead, exercise everything up through factory.BuildChangeFeed: the pageable
        // reads both snapshot meta blobs, runs SnapshotInputValidator.ValidateMetadata, builds
        // the change-feed reader, and yields zero pages when no segments match. The cvId filter
        // math itself is covered separately in ShareChangeFeedSnapshotPageableTests.

        [Test]
        public async Task GetChangesBetweenSnapshots_EndToEnd_RunsValidation_AndEmitsEmpty()
        {
            string beginSnap = "2024-01-15T08:00:00.000Z";
            string endSnap = "2024-01-15T12:00:00.000Z";

            Harness h = Harness.Create(this);
            h.SetupSnapshotMeta(beginSnap, cvId: 50, status: "Finalized",
                snapshotTime: DateTimeOffset.Parse(beginSnap),
                minLog: DateTimeOffset.Parse(beginSnap),
                maxLog: DateTimeOffset.Parse(beginSnap).AddHours(1));
            h.SetupSnapshotMeta(endSnap, cvId: 100, status: "Finalized",
                snapshotTime: DateTimeOffset.Parse(endSnap),
                minLog: DateTimeOffset.Parse(endSnap),
                maxLog: DateTimeOffset.Parse(endSnap).AddHours(1));

            List<ShareChangeFeedEvent> collected = new List<ShareChangeFeedEvent>();
            if (IsAsync)
            {
                await foreach (ShareChangeFeedEvent e in h.Client.GetChangesBetweenSnapshotsAsync(beginSnap, endSnap))
                    collected.Add(e);
            }
            else
            {
                foreach (ShareChangeFeedEvent e in h.Client.GetChangesBetweenSnapshots(beginSnap, endSnap))
                    collected.Add(e);
            }

            Assert.IsEmpty(collected);
            // Both snapshot meta paths must have been fetched.
            h.Container.Verify(c => c.GetBlobClient(SnapshotQueryHelper.SnapshotTimestampToPath(beginSnap)), Times.AtLeastOnce);
            h.Container.Verify(c => c.GetBlobClient(SnapshotQueryHelper.SnapshotTimestampToPath(endSnap)), Times.AtLeastOnce);
        }

        [Test]
        public void GetChangesBetweenSnapshots_EndToEnd_PropagatesValidationFailure()
        {
            string beginSnap = "2024-01-15T12:00:00.000Z";  // intentionally later than end
            string endSnap = "2024-01-15T08:00:00.000Z";

            Harness h = Harness.Create(this);
            h.SetupSnapshotMeta(beginSnap, cvId: 200, status: "Finalized",
                snapshotTime: DateTimeOffset.Parse(beginSnap),
                minLog: DateTimeOffset.Parse(beginSnap),
                maxLog: DateTimeOffset.Parse(beginSnap).AddHours(1));
            h.SetupSnapshotMeta(endSnap, cvId: 50, status: "Finalized",
                snapshotTime: DateTimeOffset.Parse(endSnap),
                minLog: DateTimeOffset.Parse(endSnap),
                maxLog: DateTimeOffset.Parse(endSnap).AddHours(1));

            if (IsAsync)
            {
                Assert.ThrowsAsync<ArgumentException>(async () =>
                {
                    await foreach (ShareChangeFeedEvent _ in h.Client.GetChangesBetweenSnapshotsAsync(beginSnap, endSnap)) { }
                });
            }
            else
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    foreach (ShareChangeFeedEvent _ in h.Client.GetChangesBetweenSnapshots(beginSnap, endSnap)) { }
                });
            }
        }

        // ---------- Gap 30: flag OFF + no metadata returns empty ----------

        [Test]
        public async Task GetChanges_FlagOff_NoMetadata_ReturnsEmpty()
        {
            Harness h = Harness.Create(this, metaBlobExists: false, includeUnfinalizedEvents: false);

            List<ShareChangeFeedEvent> collected = new List<ShareChangeFeedEvent>();
            if (IsAsync)
            {
                await foreach (ShareChangeFeedEvent e in h.Client.GetChangesAsync())
                    collected.Add(e);
            }
            else
            {
                foreach (ShareChangeFeedEvent e in h.Client.GetChanges())
                    collected.Add(e);
            }

            Assert.IsEmpty(collected);
        }

        /// <summary>
        /// Set of helpers that wires <see cref="ShareChangeFeedClient"/> together with mocked
        /// share/blob clients so end-to-end pipelines can be exercised without service traffic.
        /// </summary>
        private class Harness
        {
            public Mock<ShareClient> ShareClient { get; private set; }
            public Mock<BlobServiceClient> BlobServiceClient { get; private set; }
            public Mock<BlobContainerClient> Container { get; private set; }
            public ShareChangeFeedClient Client { get; private set; }

            public static Harness Create(
                ShareChangeFeedClientMockedTests test,
                bool metaBlobExists = true,
                string metaSegmentsJson = null,
                bool includeUnfinalizedEvents = false)
            {
                Harness h = new Harness();

                h.ShareClient = new Mock<ShareClient>();
                h.ShareClient.Setup(c => c.Name).Returns("myshare");
                MockResponse rawResp = new MockResponse(200);
                rawResp.AddHeader("x-ms-file-blob-container-for-xfiles-change-feed", ContainerName);
                ShareProperties props = ShareModelFactory.ShareProperties(enableSnapshotVirtualDirectoryAccess: default);
                Response<ShareProperties> propResp = Response.FromValue(props, rawResp);
                h.ShareClient.Setup(c => c.GetPropertiesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(propResp);
                h.ShareClient.Setup(c => c.GetProperties(It.IsAny<CancellationToken>())).Returns(propResp);

                h.Container = new Mock<BlobContainerClient>(MockBehavior.Loose);
                h.Container.Setup(c => c.Uri).Returns(new Uri($"https://account.blob.core.windows.net/{ContainerNameStripped}"));
                h.Container.Setup(c => c.ExistsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(true, null));
                h.Container.Setup(c => c.Exists(It.IsAny<CancellationToken>())).Returns(Response.FromValue(true, null));

                Mock<BlobClient> metaBlob = new Mock<BlobClient>(MockBehavior.Loose);
                h.Container.Setup(c => c.GetBlobClient("meta/segments.json")).Returns(metaBlob.Object);

                if (metaBlobExists)
                {
                    string json = metaSegmentsJson ?? @"{""lastConsumable"":""2024-01-15T08:30:00Z""}";
                    byte[] bytes = Encoding.UTF8.GetBytes(json);
                    // Return a fresh stream on every invocation so repeat reads (e.g. caching tests)
                    // don't see an exhausted stream from the first call.
                    metaBlob.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                        .Returns(() => Task.FromResult(Response.FromValue(
                            BlobsModelFactory.BlobDownloadStreamingResult(content: new MemoryStream(bytes)),
                            (Response)null)));
                    metaBlob.Setup(b => b.DownloadStreaming(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
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
                    metaBlob.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                        .ThrowsAsync(notFound);
                    metaBlob.Setup(b => b.DownloadStreaming(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                        .Throws(notFound);
                }

                // Empty year listing so GetChanges returns immediately with no events. Specific tests
                // that need real years/segments override these via direct Container setup.
                h.Container.Setup(c => c.GetBlobsByHierarchyAsync(It.IsAny<GetBlobsByHierarchyOptions>(), It.IsAny<CancellationToken>()))
                    .Returns(EmptyAsyncPageable());
                h.Container.Setup(c => c.GetBlobsByHierarchy(It.IsAny<GetBlobsByHierarchyOptions>(), It.IsAny<CancellationToken>()))
                    .Returns(EmptySyncPageable());

                h.BlobServiceClient = new Mock<BlobServiceClient>(MockBehavior.Loose);
                h.BlobServiceClient.Setup(s => s.GetBlobContainerClient(ContainerNameStripped)).Returns(h.Container.Object);

                h.Client = new ShareChangeFeedClient(
                    h.BlobServiceClient.Object,
                    h.ShareClient.Object,
                    new Uri("https://account.file.core.windows.net"),
                    "myshare",
                    new ShareChangeFeedClientOptions { IncludeUnfinalizedEvents = includeUnfinalizedEvents });
                return h;
            }

            /// <summary>
            /// Sets up a snapshot meta.json blob at the path corresponding to <paramref name="snapshot"/>.
            /// </summary>
            public void SetupSnapshotMeta(
                string snapshot,
                long cvId,
                string status,
                DateTimeOffset snapshotTime,
                DateTimeOffset minLog,
                DateTimeOffset maxLog)
            {
                string path = SnapshotQueryHelper.SnapshotTimestampToPath(snapshot);
                Mock<BlobClient> metaBlob = new Mock<BlobClient>(MockBehavior.Loose);
                Container.Setup(c => c.GetBlobClient(path)).Returns(metaBlob.Object);

                string json = $@"{{
                    ""snapshotTimestamp"":""{snapshotTime:O}"",
                    ""cvId"": {cvId},
                    ""minLogWindowForNextSnapshot"":""{minLog:O}"",
                    ""maxLogWindowForCurrentSnapshot"":""{maxLog:O}"",
                    ""status"":""{status}""
                }}";
                byte[] bytes = Encoding.UTF8.GetBytes(json);
                metaBlob.Setup(b => b.DownloadStreamingAsync(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                    .Returns(() => Task.FromResult(Response.FromValue(
                        BlobsModelFactory.BlobDownloadStreamingResult(content: new MemoryStream(bytes)),
                        (Response)null)));
                metaBlob.Setup(b => b.DownloadStreaming(It.IsAny<BlobDownloadOptions>(), It.IsAny<CancellationToken>()))
                    .Returns(() => Response.FromValue(
                        BlobsModelFactory.BlobDownloadStreamingResult(content: new MemoryStream(bytes)),
                        (Response)null));
            }

            private static AsyncPageable<BlobHierarchyItem> EmptyAsyncPageable() => new AsyncPageableSingle(new BlobHierarchyItemPage(new List<BlobHierarchyItem>()));
            private static Pageable<BlobHierarchyItem> EmptySyncPageable() => new SyncPageableSingle(new BlobHierarchyItemPage(new List<BlobHierarchyItem>()));

            private class AsyncPageableSingle : AsyncPageable<BlobHierarchyItem>
            {
                private readonly Page<BlobHierarchyItem> _page;
                public AsyncPageableSingle(Page<BlobHierarchyItem> page) { _page = page; }
                public override async IAsyncEnumerable<Page<BlobHierarchyItem>> AsPages(string continuationToken = null, int? pageSizeHint = null)
                {
                    yield return _page;
                    await Task.CompletedTask;
                }
            }

            private class SyncPageableSingle : Pageable<BlobHierarchyItem>
            {
                private readonly Page<BlobHierarchyItem> _page;
                public SyncPageableSingle(Page<BlobHierarchyItem> page) { _page = page; }
                public override IEnumerable<Page<BlobHierarchyItem>> AsPages(string continuationToken = null, int? pageSizeHint = null)
                {
                    yield return _page;
                }
            }
        }
    }
}
