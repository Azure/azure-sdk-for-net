// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Samples
{
    /// <summary>
    /// Basic Azure ChangeFeed Storage samples.
    /// </summary>
    public class Sample01a_HelloWorld : SampleTest
    {
        /// <summary>
        /// Download every event in the change feed.
        /// </summary>
        [Test]
        public void ChangeFeed()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a new change feed client.
            BlobChangeFeedClient changeFeedClient = new BlobChangeFeedClient(connectionString);

            // Get all the events in the change feed.
            List<BlobChangeFeedEvent> changeFeedEvents = new List<BlobChangeFeedEvent>();
            foreach (BlobChangeFeedEvent changeFeedEvent in changeFeedClient.GetChanges())
            {
                changeFeedEvents.Add(changeFeedEvent);
            }
        }

        /// <summary>
        /// Download change feed events between a start and end time.
        /// </summary>
        [Test]
        public void ChangeFeedBetweenDates()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a new change feed client.
            BlobChangeFeedClient changeFeedClient = new BlobChangeFeedClient(connectionString);
            List<BlobChangeFeedEvent> changeFeedEvents = new List<BlobChangeFeedEvent>();

            // Create the start and end time.  The change feed client will round start time down to
            // the nearest hour, and round endTime up to the next hour if you provide DateTimeOffsets
            // with minutes and seconds.
            DateTimeOffset startTime = new DateTimeOffset(2017, 3, 2, 15, 0, 0, TimeSpan.Zero);
            DateTimeOffset endTime = new DateTimeOffset(2020, 10, 7, 2, 0, 0, TimeSpan.Zero);

            // You can also provide just a start or end time.
            foreach (BlobChangeFeedEvent changeFeedEvent in changeFeedClient.GetChanges(
                start: startTime,
                end: endTime))
            {
                changeFeedEvents.Add(changeFeedEvent);
            }
        }

        /// <summary>
        /// You can use the change feed cursor to resume iterating throw the change feed
        /// at a later time.
        /// </summary>
        [Test]
        public void ChangeFeedResumeWithCursor()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a new change feed client.
            BlobChangeFeedClient changeFeedClient = new BlobChangeFeedClient(connectionString);
            List<BlobChangeFeedEvent> changeFeedEvents = new List<BlobChangeFeedEvent>();

            string continuationToken = null;
            foreach (Page<BlobChangeFeedEvent> page in changeFeedClient.GetChanges().AsPages(pageSizeHint: 10))
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

            // Resume iterating from the pervious position with the cursor.
            foreach (BlobChangeFeedEvent changeFeedEvent in changeFeedClient.GetChanges(
                continuationToken: continuationToken))
            {
                changeFeedEvents.Add(changeFeedEvent);
            }
        }

        /// <summary>
        /// You can use the change feed cursor to periodically poll for new events.
        /// </summary>
        [Test]
        public void ChangeFeedPollForEventsWithCursor()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a new change feed client.
            BlobChangeFeedClient changeFeedClient = new BlobChangeFeedClient(connectionString);
            List<BlobChangeFeedEvent> changeFeedEvents = new List<BlobChangeFeedEvent>();

            // Create the start time.  The change feed client will round start time down to
            // the nearest hour if you provide DateTimeOffsets
            // with minutes and seconds.
            DateTimeOffset startTime = DateTimeOffset.Now;

            // Create polling interval.
            TimeSpan pollingInterval = TimeSpan.FromMinutes(5);

            // Get initial set of events.
            IEnumerable<Page<BlobChangeFeedEvent>> pages = changeFeedClient.GetChanges(start: startTime).AsPages();

            string continuationToken = null;
            while (true)
            {
                foreach (Page<BlobChangeFeedEvent> page in pages)
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
                Thread.Sleep(pollingInterval);

                // Resume from last continuation token and fetch latest set of events.
                pages = changeFeedClient.GetChanges(continuationToken).AsPages();
            }
        }
    }
}
