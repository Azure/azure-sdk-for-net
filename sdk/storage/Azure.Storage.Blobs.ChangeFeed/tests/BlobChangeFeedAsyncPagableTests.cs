// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    public class BlobChangeFeedAsyncPagableTests : ChangeFeedTestBase
    {
        public BlobChangeFeedAsyncPagableTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        /// <summary>
        /// Verifies that calling <see cref="AsyncPageable{T}.AsPages"/> with a non-null continuation
        /// token throws — callers must use <see cref="BlobChangeFeedClient.GetChangesAsync(string)"/>
        /// instead. This is the documented contract; the pageable cannot validate the token.
        /// </summary>
        [Test]
        public void AsyncAsPages_NonNullContinuationToken_Throws()
        {
            BlobChangeFeedClient client = new BlobChangeFeedClient(
                new Uri("https://account.blob.core.windows.net?sv=2024-01-01&ss=b&srt=sco&sig=fakesig"));
            AsyncPageable<BlobChangeFeedEvent> pageable = client.GetChangesAsync();

            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await foreach (Page<BlobChangeFeedEvent> _ in pageable.AsPages(continuationToken: "any-token")) { }
            });
        }

        /// <summary>
        /// Enumerating <see cref="BlobChangeFeedClient.GetChangesAsync()"/> with an already-cancelled
        /// token must throw <see cref="OperationCanceledException"/> promptly instead of running the
        /// pageable to completion. The mocked container throws when the cancelled token reaches its
        /// first internal I/O call (<c>ExistsAsync</c>), proving the token is threaded through
        /// <c>AsPages</c> rather than being replaced with <c>default</c>.
        /// </summary>
        [Test]
        public void AsyncGetChanges_AlreadyCancelledToken_ThrowsPromptly()
        {
            Mock<BlobContainerClient> container = new Mock<BlobContainerClient>(MockBehavior.Loose);
            container.Setup(c => c.Uri).Returns(new Uri("https://account.blob.core.windows.net/$blobchangefeed"));
            container.Setup(c => c.ExistsAsync(It.Is<CancellationToken>(t => t.IsCancellationRequested)))
                .ThrowsAsync(new OperationCanceledException());
            container.Setup(c => c.ExistsAsync(It.Is<CancellationToken>(t => !t.IsCancellationRequested)))
                .ReturnsAsync(Response.FromValue(true, null));

            BlobChangeFeedClient client = new BlobChangeFeedClient(container.Object);

            using CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();

            Assert.CatchAsync<OperationCanceledException>(async () =>
            {
                await foreach (BlobChangeFeedEvent _ in client.GetChangesAsync().WithCancellation(cts.Token))
                { }
            });
        }
    }
}
