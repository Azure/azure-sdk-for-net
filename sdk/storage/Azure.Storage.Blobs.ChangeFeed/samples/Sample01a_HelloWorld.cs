// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Azure.Storage.Blobs.ChangeFeed.Models;
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

            // Get a new blob service client.
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            // Get a new change feed client.
            BlobChangeFeedClient changeFeedClient = blobServiceClient.GetChangeFeedClient();

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

            // Get a new blob service client.
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            // Get a new change feed client.
            BlobChangeFeedClient changeFeedClient = blobServiceClient.GetChangeFeedClient();
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

            // Get a new blob service client.
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            // Get a new change feed client.
            BlobChangeFeedClient changeFeedClient = blobServiceClient.GetChangeFeedClient();
            List<BlobChangeFeedEvent> changeFeedEvents = new List<BlobChangeFeedEvent>();

            IEnumerator<Page<BlobChangeFeedEvent>> enumerator = changeFeedClient
                .GetChanges()
                .AsPages(pageSizeHint: 10)
                .GetEnumerator();
            ;

            enumerator.MoveNext();

            foreach (BlobChangeFeedEvent changeFeedEvent in enumerator.Current.Values)
            {
                changeFeedEvents.Add(changeFeedEvent);
            }

            // get the change feed cursor.  The cursor is not required to get each page of events,
            // it is intended to be saved and used to resume iterating at a later date.
            string cursor = enumerator.Current.ContinuationToken;

            // Resume iterating from the pervious position with the cursor.
            foreach (BlobChangeFeedEvent changeFeedEvent in changeFeedClient.GetChanges(
                continuationToken: cursor))
            {
                changeFeedEvents.Add(changeFeedEvent);
            }
        }
    }
}
