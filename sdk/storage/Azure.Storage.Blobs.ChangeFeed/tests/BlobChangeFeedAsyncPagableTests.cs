// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    /// <summary>
    /// For recording these tests it's good to use an account where changefeed has been enabled and some live events are steadily generated.
    /// For example one can create simple Azure Function that runs every minutes and manipulates few blobs.
    /// </summary>
    public class BlobChangeFeedAsyncPagableTests : ChangeFeedTestBase
    {
        public BlobChangeFeedAsyncPagableTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [Ignore("For debugging larger Change Feeds locally")]
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
        [Ignore("For debugging larger Change Feeds locally")]
        public async Task TestHistorical()
        {
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobChangeFeedClient blobChangeFeedClient = service.GetChangeFeedClient();
            AsyncPageable<BlobChangeFeedEvent> blobChangeFeedAsyncPagable
                = blobChangeFeedClient.GetChangesAsync(start: DateTime.Now.AddHours(-2), end: DateTime.Now.AddHours(-1));
            IList<BlobChangeFeedEvent> list = await blobChangeFeedAsyncPagable.ToListAsync();
            foreach (BlobChangeFeedEvent e in list)
            {
                Console.WriteLine(e);
            }
        }

        [Test]
        [Ignore("For debugging larger Change Feeds locally")]
        public async Task TestLastHour()
        {
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobChangeFeedClient blobChangeFeedClient = service.GetChangeFeedClient();
            AsyncPageable<BlobChangeFeedEvent> blobChangeFeedAsyncPagable
                = blobChangeFeedClient.GetChangesAsync(start: DateTime.Now, end: DateTime.Now);
            IList<BlobChangeFeedEvent> list = await blobChangeFeedAsyncPagable.ToListAsync();
            foreach (BlobChangeFeedEvent e in list)
            {
                Console.WriteLine(e);
            }
        }

        [Test]
        [Ignore("For debugging larger Change Feeds locally")]
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
        [Ignore("For debugging larger Change Feeds locally")]
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

        [Test]
        [PlaybackOnly("Changefeed E2E tests require previously generated events")]
        public async Task CanReadTillEnd()
        {
            // Uncomment when recording.
            //DateTimeOffset startTime = DateTimeOffset.Now;

            // Update and uncomment after recording.
            DateTimeOffset startTime = new DateTimeOffset(2020, 7, 31, 19, 00, 00, TimeSpan.Zero);

            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobChangeFeedClient blobChangeFeedClient = service.GetChangeFeedClient();
            AsyncPageable<BlobChangeFeedEvent> blobChangeFeedAsyncPagable
                = blobChangeFeedClient.GetChangesAsync(startTime);
            IList<BlobChangeFeedEvent> list = await blobChangeFeedAsyncPagable.ToListAsync();

            CollectionAssert.IsNotEmpty(list);
        }

        [Test]
        [PlaybackOnly("Changefeed E2E tests require previously generated events")]
        public async Task ResumeFromTheMiddleOfTheChunk()
        {
            // This is hardcoded for playback stability. Feel free to modify but make sure recordings match.
            DateTimeOffset startTime = new DateTimeOffset(2020, 7, 30, 23, 00, 00, TimeSpan.Zero);
            DateTimeOffset endTime = new DateTimeOffset(2020, 7, 30, 23, 15, 00, TimeSpan.Zero);

            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobChangeFeedClient blobChangeFeedClient = service.GetChangeFeedClient();

            // Collect all events within range
            AsyncPageable<BlobChangeFeedEvent> blobChangeFeedAsyncPagable
                = blobChangeFeedClient.GetChangesAsync(
                    start: startTime,
                    end: endTime);
            ISet<string> AllEventIds = new HashSet<string>();
            await foreach (BlobChangeFeedEvent e in blobChangeFeedAsyncPagable)
            {
                AllEventIds.Add(e.Id.ToString());
            }

            // Iterate over first two pages
            ISet<string> EventIdsPart1 = new HashSet<string>();
            blobChangeFeedAsyncPagable = blobChangeFeedClient.GetChangesAsync(
                    start: startTime,
                    end: endTime);
            IAsyncEnumerable<Page<BlobChangeFeedEvent>> asyncEnumerable = blobChangeFeedAsyncPagable.AsPages(pageSizeHint: 50);
            Page<BlobChangeFeedEvent> lastPage = null;
            int pages = 0;
            await foreach (Page<BlobChangeFeedEvent> page in asyncEnumerable)
            {
                foreach (BlobChangeFeedEvent e in page.Values)
                {
                    EventIdsPart1.Add(e.Id.ToString());
                }
                pages++;
                lastPage = page;
                if (pages > 2)
                {
                    break;
                }
            }

            string continuation = lastPage.ContinuationToken;

            long blockOffset = (JsonSerializer.Deserialize(continuation, typeof(ChangeFeedCursor)) as ChangeFeedCursor).CurrentSegmentCursor.ShardCursors.First().BlockOffset;
            Assert.Greater(blockOffset, 0, "Making sure we actually finish in the middle of chunk, if this fails play with test data to make it pass");

            // Iterate over next two pages
            ISet<string> EventIdsPart2 = new HashSet<string>();
            blobChangeFeedAsyncPagable = blobChangeFeedClient.GetChangesAsync(continuation);
            asyncEnumerable = blobChangeFeedAsyncPagable.AsPages(pageSizeHint: 50);
            lastPage = null;
            pages = 0;
            await foreach (Page<BlobChangeFeedEvent> page in asyncEnumerable)
            {
                foreach (BlobChangeFeedEvent e in page.Values)
                {
                    EventIdsPart2.Add(e.Id.ToString());
                }
                pages++;
                lastPage = page;
                if (pages > 2)
                {
                    break;
                }
            }

            continuation = lastPage.ContinuationToken;
            blockOffset = (JsonSerializer.Deserialize(continuation, typeof(ChangeFeedCursor)) as ChangeFeedCursor).CurrentSegmentCursor.ShardCursors.First().BlockOffset;
            Assert.Greater(blockOffset, 0, "Making sure we actually finish in the middle of chunk, if this fails play with test data to make it pass");

            // Iterate over remaining
            ISet<string> EventIdsTail = new HashSet<string>();
            AsyncPageable<BlobChangeFeedEvent> cursorBlobChangeFeedAsyncPagable
                = blobChangeFeedClient.GetChangesAsync(continuation);

            IList<BlobChangeFeedEvent> list = await cursorBlobChangeFeedAsyncPagable.ToListAsync();
            foreach (BlobChangeFeedEvent e in list)
            {
                EventIdsTail.Add(e.Id.ToString());
            }

            ISet<string> AllEventIdsFromResumingIteration = new HashSet<string>();
            AllEventIdsFromResumingIteration.UnionWith(EventIdsPart1);
            AllEventIdsFromResumingIteration.UnionWith(EventIdsPart2);
            AllEventIdsFromResumingIteration.UnionWith(EventIdsTail);

            Assert.Greater(AllEventIds.Count, 0);
            Assert.Greater(EventIdsPart1.Count, 0);
            Assert.Greater(EventIdsPart2.Count, 0);
            Assert.Greater(EventIdsTail.Count, 0);
            Assert.AreEqual(AllEventIds.Count, EventIdsPart1.Count + EventIdsPart2.Count + EventIdsTail.Count);
            CollectionAssert.AreEqual(AllEventIds, AllEventIdsFromResumingIteration);
        }
    }
}
