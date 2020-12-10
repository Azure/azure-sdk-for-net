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

        /// <summary>
        /// This test checks if tail of the change feed can be listened to.
        /// To setup recording have an account where changes are generated quite frequently (i.e. every 1 minute).
        /// This test runs long in recording mode as it waits multiple times for events.
        /// </summary>
        /// <returns></returns>
        [Test]
        [PlaybackOnly("Changefeed E2E tests require previously generated events")]
        public async Task TestTailEvents()
        {
            // Uncomment when recording.
            //DateTimeOffset startTime = DateTimeOffset.Now;

            // Update and uncomment after recording.
            DateTimeOffset startTime = new DateTimeOffset(2020, 8, 10, 16, 00, 00, TimeSpan.Zero);

            TimeSpan pollInterval = Mode == RecordedTestMode.Playback ? TimeSpan.Zero : TimeSpan.FromMinutes(3);

            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobChangeFeedClient blobChangeFeedClient = service.GetChangeFeedClient();
            Page<BlobChangeFeedEvent> lastPage = null;
            ISet<string> EventIdsPart1 = new HashSet<string>();
            ISet<string> EventIdsPart2 = new HashSet<string>();
            ISet<string> EventIdsPart3 = new HashSet<string>();

            // Part 1
            AsyncPageable<BlobChangeFeedEvent> blobChangeFeedAsyncPagable = blobChangeFeedClient.GetChangesAsync(start: startTime);
            IAsyncEnumerable<Page<BlobChangeFeedEvent>> asyncEnumerable = blobChangeFeedAsyncPagable.AsPages();
            await foreach (var page in asyncEnumerable)
            {
                lastPage = page;
                foreach (var evt in page.Values)
                {
                    EventIdsPart1.Add(evt.Id.ToString());
                }
            }

            CollectionAssert.IsNotEmpty(EventIdsPart1);

            await Task.Delay(pollInterval);

            // Part 2
            blobChangeFeedAsyncPagable = blobChangeFeedClient.GetChangesAsync(lastPage.ContinuationToken);
            asyncEnumerable = blobChangeFeedAsyncPagable.AsPages();
            await foreach (var page in asyncEnumerable)
            {
                lastPage = page;
                foreach (var evt in page.Values)
                {
                    EventIdsPart2.Add(evt.Id.ToString());
                }
            }

            CollectionAssert.IsNotEmpty(EventIdsPart2);

            await Task.Delay(pollInterval);

            // Part 3
            blobChangeFeedAsyncPagable = blobChangeFeedClient.GetChangesAsync(lastPage.ContinuationToken);
            asyncEnumerable = blobChangeFeedAsyncPagable.AsPages();
            await foreach (var page in asyncEnumerable)
            {
                lastPage = page;
                foreach (var evt in page.Values)
                {
                    EventIdsPart3.Add(evt.Id.ToString());
                }
            }

            CollectionAssert.IsNotEmpty(EventIdsPart3);

            // Assert events are not duplicated
            CollectionAssert.IsEmpty(EventIdsPart1.Intersect(EventIdsPart2));
            CollectionAssert.IsEmpty(EventIdsPart1.Intersect(EventIdsPart3));
            CollectionAssert.IsEmpty(EventIdsPart2.Intersect(EventIdsPart3));
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

        /// <summary>
        /// This test requires an account with changefeed where multiple shards has been created.
        /// However. Some shards should be empty. Easiest way to set this up is to have just one blob and keep modifying it.
        /// Changes related to same blobName are guaranteed to end up in same shard.
        /// </summary>
        /// <returns></returns>
        [Test]
        [PlaybackOnly("Changefeed E2E tests require previously generated events")]
        public async Task ResumeFromTheMiddleOfTheChunkWithSomeEmptyShards()
        {
            // This is hardcoded for playback stability. Feel free to modify but make sure recordings match.
            DateTimeOffset startTime = new DateTimeOffset(2020, 8, 5, 17, 00, 00, TimeSpan.Zero);
            DateTimeOffset endTime = new DateTimeOffset(2020, 8, 5, 17, 15, 00, TimeSpan.Zero);
            int expectedNonEmptyShards = 1;

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

            var currentSegmentCursor = (JsonSerializer.Deserialize(continuation, typeof(ChangeFeedCursor)) as ChangeFeedCursor).CurrentSegmentCursor;
            Assert.AreEqual(expectedNonEmptyShards, currentSegmentCursor.ShardCursors.Count);
            Assert.IsNotNull(currentSegmentCursor.ShardCursors.Find(x => x.BlockOffset > 0), "Making sure we actually finish some shard in the middle of chunk, if this fails play with test data to make it pass");

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
            currentSegmentCursor = (JsonSerializer.Deserialize(continuation, typeof(ChangeFeedCursor)) as ChangeFeedCursor).CurrentSegmentCursor;
            Assert.AreEqual(expectedNonEmptyShards, currentSegmentCursor.ShardCursors.Count);
            Assert.IsNotNull(currentSegmentCursor.ShardCursors.Find(x => x.BlockOffset > 0), "Making sure we actually finish some shard in the middle of chunk, if this fails play with test data to make it pass");

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

        /// <summary>
        /// This test requires an account with changefeed where multiple shards has been created all with events.
        /// Easiest way to set this up is to modify lot of random blobs (i.e. with names that contain GUIDs).
        /// </summary>
        /// <returns></returns>
        [Test]
        [PlaybackOnly("Changefeed E2E tests require previously generated events")]
        public async Task ResumeFromTheMiddleOfTheChunkWithManyNonEmptyShards()
        {
            // This is hardcoded for playback stability. Feel free to modify but make sure recordings match.
            DateTimeOffset startTime = new DateTimeOffset(2020, 8, 5, 17, 00, 00, TimeSpan.Zero);
            DateTimeOffset endTime = new DateTimeOffset(2020, 8, 5, 17, 15, 00, TimeSpan.Zero);
            int expectedShardCount = 3;

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

            var currentSegmentCursor = (JsonSerializer.Deserialize(continuation, typeof(ChangeFeedCursor)) as ChangeFeedCursor).CurrentSegmentCursor;
            Assert.AreEqual(currentSegmentCursor.ShardCursors.Count, expectedShardCount);
            Assert.IsNotNull(currentSegmentCursor.ShardCursors.Find(x => x.BlockOffset > 0), "Making sure we actually finish some shard in the middle of chunk, if this fails play with test data to make it pass");

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
            currentSegmentCursor = (JsonSerializer.Deserialize(continuation, typeof(ChangeFeedCursor)) as ChangeFeedCursor).CurrentSegmentCursor;
            Assert.AreEqual(currentSegmentCursor.ShardCursors.Count, expectedShardCount);
            Assert.IsNotNull(currentSegmentCursor.ShardCursors.Find(x => x.BlockOffset > 0), "Making sure we actually finish some shard in the middle of chunk, if this fails play with test data to make it pass");

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

        [Test]
        [PlaybackOnly("Changefeed E2E tests require previously generated events")]
        public async Task ResumeFromEndInThePastYieldsEmptyResult()
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
            IAsyncEnumerable<Page<BlobChangeFeedEvent>> asyncEnumerable = blobChangeFeedAsyncPagable.AsPages(pageSizeHint: 50);
            Page<BlobChangeFeedEvent> lastPage = null;
            await foreach (Page<BlobChangeFeedEvent> page in asyncEnumerable)
            {
                foreach (BlobChangeFeedEvent e in page.Values)
                {
                    AllEventIds.Add(e.Id.ToString());
                }
                lastPage = page;
            }

            string continuation = lastPage.ContinuationToken;

            // Act
            blobChangeFeedAsyncPagable = blobChangeFeedClient.GetChangesAsync(continuation);
            IList<BlobChangeFeedEvent> tail = await blobChangeFeedAsyncPagable.ToListAsync();

            // Assert
            Assert.AreEqual(0, tail.Count);
            Assert.Greater(AllEventIds.Count, 0);
        }

        [Test]
        [PlaybackOnly("Changefeed E2E tests require previously generated events")]
        public async Task ImmediateResumeFromEndOfCurrentHourYieldsEmptyResult()
        {
            // Uncomment when recording.
            //DateTimeOffset startTime = DateTimeOffset.Now;

            // Update and uncomment after recording.
            DateTimeOffset startTime = new DateTimeOffset(2020, 8, 11, 21, 00, 00, TimeSpan.Zero);

            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobChangeFeedClient blobChangeFeedClient = service.GetChangeFeedClient();

            // Collect all events within range
            AsyncPageable<BlobChangeFeedEvent> blobChangeFeedAsyncPagable
                = blobChangeFeedClient.GetChangesAsync(
                    start: startTime);
            ISet<string> AllEventIds = new HashSet<string>();
            IAsyncEnumerable<Page<BlobChangeFeedEvent>> asyncEnumerable = blobChangeFeedAsyncPagable.AsPages(pageSizeHint: 50);
            Page<BlobChangeFeedEvent> lastPage = null;
            await foreach (Page<BlobChangeFeedEvent> page in asyncEnumerable)
            {
                foreach (BlobChangeFeedEvent e in page.Values)
                {
                    AllEventIds.Add(e.Id.ToString());
                }
                lastPage = page;
            }

            string continuation = lastPage.ContinuationToken;

            // Act
            blobChangeFeedAsyncPagable = blobChangeFeedClient.GetChangesAsync(continuation);
            IList<BlobChangeFeedEvent> tail = await blobChangeFeedAsyncPagable.ToListAsync();

            // Assert
            Assert.AreEqual(0, tail.Count);
            Assert.Greater(AllEventIds.Count, 0);
        }

        /// <summary>
        /// To setup account for this test have a steady stream of events (i.e. some changes every 1 minute) that covers at least from an hour before start time
        /// to an hour after end time.
        /// </summary>
        /// <returns></returns>
        [Test]
        [PlaybackOnly("Changefeed E2E tests require previously generated events")]
        public async Task TestAlreadyRoundedBoundaries()
        {
            // This is hardcoded for playback stability. Feel free to modify but make sure recordings match.
            DateTimeOffset startTime = new DateTimeOffset(2020, 8, 5, 16, 00, 00, TimeSpan.Zero);
            DateTimeOffset endTime = new DateTimeOffset(2020, 8, 5, 18, 00, 00, TimeSpan.Zero);

            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobChangeFeedClient blobChangeFeedClient = service.GetChangeFeedClient();

            // Collect all events within range
            AsyncPageable<BlobChangeFeedEvent> blobChangeFeedAsyncPagable
                = blobChangeFeedClient.GetChangesAsync(
                    start: startTime,
                    end: endTime);
            var eventList = new List<BlobChangeFeedEvent>(await blobChangeFeedAsyncPagable.ToListAsync());

            // Assert
            Assert.Greater(eventList.Count, 1);
            Assert.IsNull(eventList.Find(e => e.EventTime < startTime.AddMinutes(-15)), "No event 15 minutes before start is present");
            Assert.IsNull(eventList.Find(e => e.EventTime > endTime.AddMinutes(15)), "No event 15 minutes after end is present");
            Assert.IsNotNull(eventList.Find(e => e.EventTime < startTime.AddMinutes(15)), "There is some event 15 minutes after start");
            Assert.IsNotNull(eventList.Find(e => e.EventTime > endTime.AddMinutes(-15)), "There is some event 15 minutes before end");
        }

        /// <summary>
        /// To setup account for this test have a steady stream of events (i.e. some changes every 1 minute) that covers at least from an hour before start time
        /// to an hour after end time.
        /// </summary>
        [Test]
        [PlaybackOnly("Changefeed E2E tests require previously generated events")]
        public async Task TestNonRoundedBoundaries()
        {
            // This is hardcoded for playback stability. Feel free to modify but make sure recordings match.
            DateTimeOffset startTime = new DateTimeOffset(2020, 8, 5, 16, 24, 00, TimeSpan.Zero);
            DateTimeOffset endTime = new DateTimeOffset(2020, 8, 5, 18, 35, 00, TimeSpan.Zero);
            DateTimeOffset roundedStartTime = new DateTimeOffset(2020, 8, 5, 16, 00, 00, TimeSpan.Zero);
            DateTimeOffset roundedEndTime = new DateTimeOffset(2020, 8, 5, 19, 00, 00, TimeSpan.Zero);

            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobChangeFeedClient blobChangeFeedClient = service.GetChangeFeedClient();

            // Collect all events within range
            AsyncPageable<BlobChangeFeedEvent> blobChangeFeedAsyncPagable
                = blobChangeFeedClient.GetChangesAsync(
                    start: startTime,
                    end: endTime);
            var eventList = new List<BlobChangeFeedEvent>(await blobChangeFeedAsyncPagable.ToListAsync());

            // Assert
            Assert.Greater(eventList.Count, 1);
            Assert.IsNull(eventList.Find(e => e.EventTime < roundedStartTime.AddMinutes(-15)), "No event 15 minutes before start is present");
            Assert.IsNull(eventList.Find(e => e.EventTime > roundedEndTime.AddMinutes(15)), "No event 15 minutes after end is present");
            Assert.IsNotNull(eventList.Find(e => e.EventTime < roundedStartTime.AddMinutes(15)), "There is some event 15 minutes after start");
            Assert.IsNotNull(eventList.Find(e => e.EventTime > roundedEndTime.AddMinutes(-15)), "There is some event 15 minutes before end");
        }

        [Test]
        [PlaybackOnly("Changefeed E2E tests require previously generated events")]
        public async Task CursorFormatTest()
        {
            // This is hardcoded for playback stability. Feel free to modify but make sure recordings match.
            DateTimeOffset startTime = new DateTimeOffset(2020, 7, 30, 23, 00, 00, TimeSpan.Zero);
            DateTimeOffset endTime = new DateTimeOffset(2020, 7, 30, 23, 15, 00, TimeSpan.Zero);

            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobChangeFeedClient blobChangeFeedClient = service.GetChangeFeedClient();

            // Iterate over first two pages
            var blobChangeFeedAsyncPagable = blobChangeFeedClient.GetChangesAsync(
                    start: startTime,
                    end: endTime);
            IAsyncEnumerable<Page<BlobChangeFeedEvent>> asyncEnumerable = blobChangeFeedAsyncPagable.AsPages(pageSizeHint: 50);
            Page<BlobChangeFeedEvent> lastPage = null;
            int pages = 0;
            await foreach (Page<BlobChangeFeedEvent> page in asyncEnumerable)
            {
                foreach (BlobChangeFeedEvent e in page.Values)
                {
                    Console.WriteLine(e);
                }
                pages++;
                lastPage = page;
                if (pages > 2)
                {
                    break;
                }
            }

            // Act
            string continuation = lastPage.ContinuationToken;

            // Verify
            // You may need to update expected values when re-recording
            var cursor = (JsonSerializer.Deserialize(continuation, typeof(ChangeFeedCursor)) as ChangeFeedCursor);
            Assert.AreEqual(new DateTimeOffset(2020, 7, 31, 00, 00, 00, TimeSpan.Zero), cursor.EndTime);
            Assert.AreEqual(1, cursor.CursorVersion);
            Assert.AreEqual("emilydevtest.blob.core.windows.net", cursor.UrlHost);
            var currentSegmentCursor = cursor.CurrentSegmentCursor;
            Assert.AreEqual("idx/segments/2020/07/30/2300/meta.json", currentSegmentCursor.SegmentPath);
            Assert.AreEqual("log/00/2020/07/30/2300/", currentSegmentCursor.CurrentShardPath);
            Assert.AreEqual(1, currentSegmentCursor.ShardCursors.Count);
            var shardCursor = currentSegmentCursor.ShardCursors.First();
            Assert.AreEqual("log/00/2020/07/30/2300/00000.avro", shardCursor.CurrentChunkPath);
            Assert.AreEqual(96253, shardCursor.BlockOffset);
            Assert.AreEqual(0, shardCursor.EventIndex);
        }
    }
}
