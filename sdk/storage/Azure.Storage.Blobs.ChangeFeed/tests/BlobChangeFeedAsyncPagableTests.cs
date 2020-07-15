// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.ChangeFeed.Models;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    public class BlobChangeFeedAsyncPagableTests : ChangeFeedTestBase
    {
        public BlobChangeFeedAsyncPagableTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [Ignore("")]
        public async Task Test()
        {
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobChangeFeedClient blobChangeFeedClient = service.GetChangeFeedClient();
            AsyncPageable<BlobChangeFeedEvent> blobChangeFeedAsyncPagable
                = blobChangeFeedClient.GetChangesAsync();
            IList<BlobChangeFeedEvent> list = await blobChangeFeedAsyncPagable.ToListAsync();
            foreach (BlobChangeFeedEvent e in list)
            {
                Console.WriteLine(e);
            }
        }

        [Test]
        [Ignore("")]
        public async Task PageSizeTest()
        {
            int pageSize = 100;
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobChangeFeedClient blobChangeFeedClient = service.GetChangeFeedClient();
            IAsyncEnumerator<Page<BlobChangeFeedEvent>> asyncEnumerator
                = blobChangeFeedClient.GetChangesAsync().AsPages(pageSizeHint: pageSize).GetAsyncEnumerator();
            List<int> pageSizes = new List<int>();
            while (await asyncEnumerator.MoveNextAsync())
            {
                pageSizes.Add(asyncEnumerator.Current.Values.Count);
            }

            // All pages except the last should have a count == pageSize.
            for (int i = 0; i < pageSizes.Count - 1; i++)
            {
                Assert.AreEqual(pageSize, pageSizes[i]);
            }
        }

        [Test]
        [Ignore("")]
        public async Task CursorTest()
        {
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobChangeFeedClient blobChangeFeedClient = service.GetChangeFeedClient();
            AsyncPageable<BlobChangeFeedEvent> blobChangeFeedAsyncPagable
                = blobChangeFeedClient.GetChangesAsync();
            IAsyncEnumerable<Page<BlobChangeFeedEvent>> asyncEnumerable = blobChangeFeedAsyncPagable.AsPages(pageSizeHint: 500);
            Page<BlobChangeFeedEvent> page = await asyncEnumerable.FirstAsync();
            foreach (BlobChangeFeedEvent changeFeedEvent in page.Values)
            {
                Console.WriteLine(changeFeedEvent);
            }

            Console.WriteLine("break");

            string continuation = page.ContinuationToken;

            AsyncPageable<BlobChangeFeedEvent> cursorBlobChangeFeedAsyncPagable
                = blobChangeFeedClient.GetChangesAsync(continuation);

            IList<BlobChangeFeedEvent> list = await cursorBlobChangeFeedAsyncPagable.ToListAsync();
            foreach (BlobChangeFeedEvent e in list)
            {
                Console.WriteLine(e);
            }

        }
    }
}
