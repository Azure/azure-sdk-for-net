// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    /// <summary>
    /// Mocked unit tests for <see cref="BlobChangeFeedClient"/> public operations
    /// (GetLastConsumable, GetChanges) without hitting the service. The client is
    /// constructed via its internal <see cref="BlobChangeFeedClient(BlobContainerClient, BlobChangeFeedClientOptions)"/>
    /// overload so a mocked container can be injected directly.
    /// </summary>
    public class BlobChangeFeedClientMockedTests : ChangeFeedTestBase
    {
        public BlobChangeFeedClientMockedTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        [Test]
        public async Task GetLastConsumable_HappyPath_ReturnsTimestamp()
        {
            DateTimeOffset expected = new DateTimeOffset(2024, 1, 15, 8, 30, 0, TimeSpan.Zero);
            Harness h = Harness.Create(metaSegmentsJson: $@"{{""lastConsumable"":""{expected:O}""}}");

            DateTimeOffset? actual = IsAsync
                ? await h.Client.GetLastConsumableAsync()
                : h.Client.GetLastConsumable();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task GetLastConsumable_BlobNotFound_ReturnsNull()
        {
            Harness h = Harness.Create(metaBlobExists: false);

            DateTimeOffset? actual = IsAsync
                ? await h.Client.GetLastConsumableAsync()
                : h.Client.GetLastConsumable();

            Assert.IsNull(actual);
        }

        [Test]
        public void GetLastConsumable_MalformedJson_Throws()
        {
            Harness h = Harness.Create(metaSegmentsJson: "{not valid json");

            if (IsAsync)
                Assert.CatchAsync<System.Text.Json.JsonException>(async () => await h.Client.GetLastConsumableAsync());
            else
                Assert.Catch<System.Text.Json.JsonException>(() => h.Client.GetLastConsumable());
        }

        [Test]
        public async Task GetChanges_FlagOff_NoMetadata_ReturnsEmpty()
        {
            Harness h = Harness.Create(metaBlobExists: false, includeNonFinalizedEvents: false);

            List<BlobChangeFeedEvent> collected = new List<BlobChangeFeedEvent>();
            if (IsAsync)
            {
                await foreach (BlobChangeFeedEvent e in h.Client.GetChangesAsync())
                    collected.Add(e);
            }
            else
            {
                foreach (BlobChangeFeedEvent e in h.Client.GetChanges())
                    collected.Add(e);
            }

            Assert.IsEmpty(collected);
        }

        /// <summary>
        /// Wires <see cref="BlobChangeFeedClient"/> together with a mocked
        /// <see cref="BlobContainerClient"/> so end-to-end pipelines can be exercised
        /// without service traffic.
        /// </summary>
        private class Harness
        {
            public Mock<BlobContainerClient> Container { get; private set; }
            public BlobChangeFeedClient Client { get; private set; }

            public static Harness Create(
                bool metaBlobExists = true,
                string metaSegmentsJson = null,
                bool includeNonFinalizedEvents = false)
            {
                Harness h = new Harness();

                h.Container = new Mock<BlobContainerClient>(MockBehavior.Loose);
                h.Container.Setup(c => c.Uri).Returns(new Uri("https://account.blob.core.windows.net/$blobchangefeed"));
                h.Container.Setup(c => c.ExistsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(true, null));
                h.Container.Setup(c => c.Exists(It.IsAny<CancellationToken>())).Returns(Response.FromValue(true, null));

                Mock<BlobClient> metaBlob = new Mock<BlobClient>(MockBehavior.Loose);
                h.Container.Setup(c => c.GetBlobClient("meta/segments.json")).Returns(metaBlob.Object);

                if (metaBlobExists)
                {
                    string json = metaSegmentsJson ?? @"{""lastConsumable"":""2024-01-15T08:30:00Z""}";
                    byte[] bytes = Encoding.UTF8.GetBytes(json);
                    // Return a fresh stream on every invocation so repeat reads don't see an exhausted stream.
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

                // Empty year listing so GetChanges returns immediately with no events.
                h.Container.Setup(c => c.GetBlobsByHierarchyAsync(It.IsAny<GetBlobsByHierarchyOptions>(), It.IsAny<CancellationToken>()))
                    .Returns(EmptyAsyncPageable());
                h.Container.Setup(c => c.GetBlobsByHierarchy(It.IsAny<GetBlobsByHierarchyOptions>(), It.IsAny<CancellationToken>()))
                    .Returns(EmptySyncPageable());

                h.Client = new BlobChangeFeedClient(
                    h.Container.Object,
                    new BlobChangeFeedClientOptions { IncludeNonFinalizedEvents = includeNonFinalizedEvents });
                return h;
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
