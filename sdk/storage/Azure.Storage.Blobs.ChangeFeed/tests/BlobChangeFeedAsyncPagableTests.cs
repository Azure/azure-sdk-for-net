// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
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
    }
}
