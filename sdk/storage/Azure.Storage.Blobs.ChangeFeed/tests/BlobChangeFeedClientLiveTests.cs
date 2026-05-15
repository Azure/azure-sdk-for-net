// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    /// <summary>
    /// End-to-end live tests for <see cref="BlobChangeFeedClient"/>.
    /// These tests require a storage account with Blob Change Feed enabled
    /// and events already generated.
    /// </summary>
    public class BlobChangeFeedClientLiveTests : ChangeFeedTestBase
    {
        public BlobChangeFeedClientLiveTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        /// <summary>
        /// Creates a <see cref="BlobChangeFeedClient"/> via the public extension on
        /// <see cref="BlobServiceClient"/>. Goes through the test framework's
        /// <see cref="RecordedTestBase.InstrumentClient{T}(T)"/> for sync/async parity.
        /// </summary>
        private BlobChangeFeedClient GetChangeFeedClient()
            => GetServiceClient_SharedKey().GetChangeFeedClient();

        /// <summary>
        /// Enumerates all change feed events and verifies at least one event is returned.
        /// </summary>
        [RecordedTest]
        [Ignore("Requires a storage account with Blob Change Feed enabled and pre-existing events")]
        public async Task GetChanges_ReturnsEvents()
        {
            // Arrange
            BlobChangeFeedClient client = GetChangeFeedClient();

            //BlobContainerClient containerClient = GetServiceClient_SharedKey().GetBlobContainerClient("test-container");
            //await containerClient.CreateAsync();
            //for (int i = 0; i < 2000; i++)
            //{
            //    await containerClient.UploadBlobAsync($"blob-{i}", BinaryData.FromString("data"));
            //}

            // Act
            List<BlobChangeFeedEvent> events = new List<BlobChangeFeedEvent>();

            if (IsAsync)
            {
                await foreach (BlobChangeFeedEvent e in client.GetChangesAsync())
                {
                    events.Add(e);
                }
            }
            else
            {
                foreach (BlobChangeFeedEvent e in client.GetChanges())
                {
                    events.Add(e);
                }
            }

            // Assert
            CollectionAssert.IsNotEmpty(events);
            foreach (BlobChangeFeedEvent e in events)
            {
                Assert.AreNotEqual(default(DateTimeOffset), e.EventTime);
                Assert.AreNotEqual(default(Guid), e.Id);
                Assert.IsNotNull(e.EventData);
            }
        }

        /// <summary>
        /// Enumerates change feed events within a specific time range and verifies
        /// all returned events fall within that range. Note that the Blobs change feed
        /// rounds the requested boundaries to the nearest hour, so we assert against
        /// the rounded window rather than the raw user-supplied bounds.
        /// </summary>
        [RecordedTest]
        [Ignore("Requires a storage account with Blob Change Feed enabled and pre-existing events")]
        public async Task GetChanges_WithTimeRange_FiltersEvents()
        {
            // Arrange
            DateTimeOffset start = DateTimeOffset.UtcNow.AddHours(-2);
            DateTimeOffset end = DateTimeOffset.UtcNow.AddHours(-1);
            DateTimeOffset roundedStart = new DateTimeOffset(start.Year, start.Month, start.Day, start.Hour, 0, 0, TimeSpan.Zero);
            DateTimeOffset roundedEnd = new DateTimeOffset(end.Year, end.Month, end.Day, end.Hour, 0, 0, TimeSpan.Zero).AddHours(1);
            BlobChangeFeedClient client = GetChangeFeedClient();

            // Act
            List<BlobChangeFeedEvent> events = new List<BlobChangeFeedEvent>();

            if (IsAsync)
            {
                await foreach (BlobChangeFeedEvent e in client.GetChangesAsync(start, end))
                {
                    events.Add(e);
                }
            }
            else
            {
                foreach (BlobChangeFeedEvent e in client.GetChanges(start, end))
                {
                    events.Add(e);
                }
            }

            // Assert - all events should fall within the hour-rounded range
            foreach (BlobChangeFeedEvent e in events)
            {
                Assert.GreaterOrEqual(e.EventTime, roundedStart, "Event time should be within the rounded window");
                Assert.LessOrEqual(e.EventTime, roundedEnd, "Event time should be within the rounded window");
            }
        }

        /// <summary>
        /// Verifies that pagination works correctly by reading one page at a time
        /// and resuming with a continuation token. The page size hint is not guaranteed
        /// to be respected exactly, so we only assert that pages are non-empty and
        /// non-overlapping.
        /// </summary>
        [RecordedTest]
        [Ignore("Requires a storage account with Blob Change Feed enabled and pre-existing events")]
        public async Task GetChanges_WithContinuationToken_ResumesCorrectly()
        {
            // Arrange
            BlobChangeFeedClient client = GetChangeFeedClient();

            // Act - read the first page
            HashSet<Guid> firstPageEventIds = new HashSet<Guid>();
            string continuationToken = null;

            if (IsAsync)
            {
                await foreach (Page<BlobChangeFeedEvent> page in client.GetChangesAsync().AsPages(pageSizeHint: 10))
                {
                    foreach (BlobChangeFeedEvent e in page.Values)
                    {
                        firstPageEventIds.Add(e.Id);
                    }
                    continuationToken = page.ContinuationToken;
                    if (firstPageEventIds.Count >= 10) break;
                }
            }
            else
            {
                foreach (Page<BlobChangeFeedEvent> page in client.GetChanges().AsPages(pageSizeHint: 10))
                {
                    foreach (BlobChangeFeedEvent e in page.Values)
                    {
                        firstPageEventIds.Add(e.Id);
                    }
                    continuationToken = page.ContinuationToken;
                    if (firstPageEventIds.Count >= 10) break;
                }
            }

            CollectionAssert.IsNotEmpty(firstPageEventIds, "First page should contain at least one event");

            // Act - resume from continuation token and read the next page
            HashSet<Guid> secondPageEventIds = new HashSet<Guid>();
            if (continuationToken != null)
            {
                if (IsAsync)
                {
                    await foreach (Page<BlobChangeFeedEvent> page in client.GetChangesAsync(continuationToken).AsPages(pageSizeHint: 10))
                    {
                        foreach (BlobChangeFeedEvent e in page.Values)
                        {
                            secondPageEventIds.Add(e.Id);
                        }
                        if (secondPageEventIds.Count >= 10) break;
                    }
                }
                else
                {
                    foreach (Page<BlobChangeFeedEvent> page in client.GetChanges(continuationToken).AsPages(pageSizeHint: 10))
                    {
                        foreach (BlobChangeFeedEvent e in page.Values)
                        {
                            secondPageEventIds.Add(e.Id);
                        }
                        if (secondPageEventIds.Count >= 10) break;
                    }
                }

                // Assert - no overlap between first and second page
                CollectionAssert.IsEmpty(
                    firstPageEventIds.Intersect(secondPageEventIds),
                    "Resumed page should not contain events from the first page");
            }
        }

        /// <summary>
        /// Verifies that <see cref="BlobChangeFeedClient.GetLastConsumable"/> returns a valid timestamp.
        /// </summary>
        [RecordedTest]
        [Ignore("Requires a storage account with Blob Change Feed enabled and pre-existing events")]
        public async Task GetLastConsumable_ReturnsTimestamp()
        {
            // Arrange
            BlobChangeFeedClient client = GetChangeFeedClient();

            // Act
            DateTimeOffset? lastConsumable = IsAsync
                ? await client.GetLastConsumableAsync()
                : client.GetLastConsumable();

            // Assert
            Assert.IsNotNull(lastConsumable, "Last consumable timestamp should not be null when change feed has data");
            Assert.Greater(lastConsumable.Value, DateTimeOffset.MinValue);
        }

        /// <summary>
        /// Verifies that event data fields are populated correctly for returned events.
        /// </summary>
        [RecordedTest]
        [Ignore("Requires a storage account with Blob Change Feed enabled and pre-existing events")]
        public async Task GetChanges_EventDataIsPopulated()
        {
            // Arrange
            BlobChangeFeedClient client = GetChangeFeedClient();

            // Act - get just the first event
            BlobChangeFeedEvent firstEvent = null;

            if (IsAsync)
            {
                await foreach (BlobChangeFeedEvent e in client.GetChangesAsync())
                {
                    firstEvent = e;
                    break;
                }
            }
            else
            {
                foreach (BlobChangeFeedEvent e in client.GetChanges())
                {
                    firstEvent = e;
                    break;
                }
            }

            // Assert
            Assert.IsNotNull(firstEvent, "Expected at least one event");
            Assert.AreNotEqual(default(BlobChangeFeedEventType), firstEvent.EventType);
            Assert.IsFalse(string.IsNullOrEmpty(firstEvent.Subject), "Subject (blob URI) should be populated");

            Assert.IsNotNull(firstEvent.EventData);
            Assert.AreNotEqual(default(BlobOperationName), firstEvent.EventData.BlobOperationName);
            Assert.AreNotEqual(default(Guid), firstEvent.EventData.RequestId);
        }

        /// <summary>
        /// Verifies that <see cref="BlobChangeFeedClientOptions.IncludeNonFinalizedEvents"/>
        /// allows reading events past the change feed's last consumable watermark.
        /// </summary>
        [Test]
        [Ignore("Requires non-finalized segments in the change feed, which cannot be reproduced deterministically in playback.")]
        public async Task GetChanges_IncludeNonFinalizedEvents_ReturnsEventsPastLastConsumable()
        {
            // Arrange - provision a fresh container under a change-feed-enabled account and seed it with events.
            //await using DisposingContainer test = await GetTestContainerAsync();
            //BlobContainerClient container = test.Container;

            //for (int i = 0; i < 10; i++)
            //{
            //    await container.UploadBlobAsync($"blob-{i}", BinaryData.FromString("data"));
            //}

            //// Give the service a moment to surface the new events into the non-finalized segment index.
            //await Task.Delay(TimeSpan.FromSeconds(30));

            BlobChangeFeedClient tailing = new BlobChangeFeedClient(
                new Uri(TestConfigDefault.BlobServiceEndpoint),
                new StorageSharedKeyCredential(
                    TestConfigDefault.AccountName,
                    TestConfigDefault.AccountKey),
                options: null,
                changeFeedOptions: new BlobChangeFeedClientOptions { IncludeNonFinalizedEvents = true });

            // Snapshot the current watermark. If the account has no finalized segments yet
            // this will be null, in which case every event the tailing reader returns is
            // by definition past last consumable.
            DateTimeOffset? lastConsumable = IsAsync
                ? await tailing.GetLastConsumableAsync()
                : tailing.GetLastConsumable();

            // Act - tailing reader. Iterate via AsPages so we can also assert that no page
            // carries a continuation token (resumption is unsupported in non-finalized mode).
            List<BlobChangeFeedEvent> tailingEvents = new List<BlobChangeFeedEvent>();
            if (IsAsync)
            {
                await foreach (Page<BlobChangeFeedEvent> page in tailing.GetChangesAsync().AsPages())
                {
                    Assert.IsNull(page.ContinuationToken,
                        "Pages produced with IncludeNonFinalizedEvents=true must not carry a continuation token.");
                    tailingEvents.AddRange(page.Values);
                }
            }
            else
            {
                foreach (Page<BlobChangeFeedEvent> page in tailing.GetChanges().AsPages())
                {
                    Assert.IsNull(page.ContinuationToken,
                        "Pages produced with IncludeNonFinalizedEvents=true must not carry a continuation token.");
                    tailingEvents.AddRange(page.Values);
                }
            }

            // Assert - tailing reader surfaces non-finalized events past the watermark.
            CollectionAssert.IsNotEmpty(tailingEvents, "Tailing reader should surface events from the non-finalized segment.");
            if (lastConsumable.HasValue)
            {
                Assert.IsTrue(
                    tailingEvents.Any(e => e.EventTime > lastConsumable.Value),
                    "Tailing reader should return at least one event with EventTime > LastConsumable.");
            }
        }
    }
}
