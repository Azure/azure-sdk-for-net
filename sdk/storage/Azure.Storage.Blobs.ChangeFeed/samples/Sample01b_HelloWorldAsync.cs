// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Blobs.ChangeFeed.Models;
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

            // Get a new blob service client.
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            // Get a new change feed client.
            BlobChangeFeedClient changeFeedClient = blobServiceClient.GetChangeFeedClient();

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

            // Get a new blob service client.
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            // Get a new change feed client.
            BlobChangeFeedClient changeFeedClient = blobServiceClient.GetChangeFeedClient();
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

            // Get a new blob service client.
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            // Get a new change feed client.
            BlobChangeFeedClient changeFeedClient = blobServiceClient.GetChangeFeedClient();
            List<BlobChangeFeedEvent> changeFeedEvents = new List<BlobChangeFeedEvent>();

            #region Snippet:SampleSnippetsChangeFeed_ResumeWithCursor
            IAsyncEnumerator<Page<BlobChangeFeedEvent>> enumerator = changeFeedClient
                .GetChangesAsync()
                .AsPages(pageSizeHint: 10)
                .GetAsyncEnumerator();

            await enumerator.MoveNextAsync();

            foreach (BlobChangeFeedEvent changeFeedEvent in enumerator.Current.Values)
            {
                changeFeedEvents.Add(changeFeedEvent);
            }

            // get the change feed cursor.  The cursor is not required to get each page of events,
            // it is intended to be saved and used to resume iterating at a later date.
            string cursor = enumerator.Current.ContinuationToken;

            // Resume iterating from the pervious position with the cursor.
            await foreach (BlobChangeFeedEvent changeFeedEvent in changeFeedClient.GetChangesAsync(
                continuationToken: cursor))
            {
                changeFeedEvents.Add(changeFeedEvent);
            }
            #endregion
        }
    }
}
