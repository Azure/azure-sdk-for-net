// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Samples
{
    /// <summary>
    /// Basic Azure ChangeFeed Storage samples.
    /// </summary>
    public class Sample01b_HelloWorldAsync : SampleTest
    {
        /// <summary>
        /// Download every event in the change feed.
        /// </summary>
        [Test]
        public async Task ChangeFeedAsync()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a new change feed client.
            BlobChangeFeedClient changeFeedClient = new BlobChangeFeedClient(connectionString);

            #region Snippet:SampleSnippetsChangeFeed_GetAllEvents
            // Get all the events in the change feed.
            List<BlobChangeFeedEvent> changeFeedEvents = new List<BlobChangeFeedEvent>();
            await foreach (BlobChangeFeedEvent changeFeedEvent in changeFeedClient.GetChangesAsync())
            {
                changeFeedEvents.Add(changeFeedEvent);
            }
            #endregion
        }

        /// <summary>
        /// Download change feed events between a start and end time.
        /// </summary>
        [Test]
        public async Task ChangeFeedBetweenDatesAsync()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a new change feed client.
            BlobChangeFeedClient changeFeedClient = new BlobChangeFeedClient(connectionString);
            List<BlobChangeFeedEvent> changeFeedEvents = new List<BlobChangeFeedEvent>();

            #region Snippet:SampleSnippetsChangeFeed_GetEventsBetweenStartAndEndTime
            // Create the start and end time.  The change feed client will round start time down to
            // the nearest hour, and round endTime up to the next hour if you provide DateTimeOffsets
            // with minutes and seconds.
            DateTimeOffset startTime = new DateTimeOffset(2017, 3, 2, 15, 0, 0, TimeSpan.Zero);
            DateTimeOffset endTime = new DateTimeOffset(2020, 10, 7, 2, 0, 0, TimeSpan.Zero);

            // You can also provide just a start or end time.
            await foreach (BlobChangeFeedEvent changeFeedEvent in changeFeedClient.GetChangesAsync(
                start: startTime,
                end: endTime))
            {
                changeFeedEvents.Add(changeFeedEvent);
            }
            #endregion
        }

        /// <summary>
        /// You can use the change feed cursor to resume iterating throw the change feed
        /// at a later time.
        /// </summary>
        [Test]
        public async Task ChangeFeedResumeWithCursorAsync()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a new change feed client.
            BlobChangeFeedClient changeFeedClient = new BlobChangeFeedClient(connectionString);
            List<BlobChangeFeedEvent> changeFeedEvents = new List<BlobChangeFeedEvent>();

            #region Snippet:SampleSnippetsChangeFeed_ResumeWithCursor
            string continuationToken = null;
            await foreach (Page<BlobChangeFeedEvent> page in changeFeedClient.GetChangesAsync().AsPages(pageSizeHint: 10))
            {
                foreach (BlobChangeFeedEvent changeFeedEvent in page.Values)
                {
                    changeFeedEvents.Add(changeFeedEvent);
                }

                // Get the change feed continuation token.  The continuation token is not required to get each page of events,
                // it is intended to be saved and used to resume iterating at a later date.
                continuationToken = page.ContinuationToken;
                break;
            }

            // Resume iterating from the pervious position with the continuation token.
            await foreach (BlobChangeFeedEvent changeFeedEvent in changeFeedClient.GetChangesAsync(
                continuationToken: continuationToken))
            {
                changeFeedEvents.Add(changeFeedEvent);
            }
            #endregion
        }

        /// <summary>
        /// You can use the change feed cursor to periodically poll for new events.
        /// </summary>
        [Test]
        public async Task ChangeFeedPollForEventsWithCursor()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a new change feed client.
            BlobChangeFeedClient changeFeedClient = new BlobChangeFeedClient(connectionString);
            List<BlobChangeFeedEvent> changeFeedEvents = new List<BlobChangeFeedEvent>();

            #region Snippet:SampleSnippetsChangeFeed_PollForEventsWithCursor
            // Create the start time.  The change feed client will round start time down to
            // the nearest hour if you provide DateTimeOffsets
            // with minutes and seconds.
            DateTimeOffset startTime = DateTimeOffset.Now;

            // Create polling interval.
            TimeSpan pollingInterval = TimeSpan.FromMinutes(5);

            // Get initial set of events.
            IAsyncEnumerable<Page<BlobChangeFeedEvent>> pages = changeFeedClient.GetChangesAsync(start: startTime).AsPages();

            string continuationToken = null;
            while (true)
            {
                await foreach (Page<BlobChangeFeedEvent> page in pages)
                {
                    foreach (BlobChangeFeedEvent changeFeedEvent in page.Values)
                    {
                        changeFeedEvents.Add(changeFeedEvent);
                    }

                    // Get the change feed continuation token.  The continuation token is not required to get each page of events,
                    // it is intended to be saved and used to resume iterating at a later date.
                    // For the purpose of actively listening to events the continuation token from last page is used.
                    continuationToken = page.ContinuationToken;
                }

                // Wait before processing next batch of events.
                await Task.Delay(pollingInterval);

                // Resume from last continuation token and fetch latest set of events.
                pages = changeFeedClient.GetChangesAsync(continuationToken).AsPages();
            }
            #endregion
        }
    }
}
