// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.ChangeFeed.Tests
{
    /// <summary>
    /// End-to-end live tests for <see cref="ShareChangeFeedClient"/>.
    /// These tests require a storage account with an Azure File Share that has
    /// change feed enabled and events already generated.
    /// </summary>
    public class ShareChangeFeedClientLiveTests : ShareChangeFeedTestBase
    {
        // TODO: Replace with a test environment property once one is available for share names.
        private const string TestShareName = "changefeed-test-share";

        public ShareChangeFeedClientLiveTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        /// <summary>
        /// Creates a <see cref="ShareChangeFeedClient"/> using shared key credentials directly.
        /// We construct the client without using an instrumented ShareClient to avoid the
        /// test framework's sync/async proxy interceptor on internal discovery calls.
        /// </summary>
        private ShareChangeFeedClient GetChangeFeedClient(string shareName = null)
        {
            return new ShareChangeFeedClient(
                new Uri(TestConfigDefault.FileServiceEndpoint),
                shareName ?? TestShareName,
                new StorageSharedKeyCredential(
                    TestConfigDefault.AccountName,
                    TestConfigDefault.AccountKey));
        }

        /// <summary>
        /// Creates a new Azure File Share with change feed enabled and returns a clean
        /// <see cref="ShareClient"/> for it. The <c>x-ms-file-enable-change-feed</c> header
        /// (not exposed by the base Files SDK) is injected via a one-shot pipeline policy
        /// scoped to the share-create PUT only; the returned client carries no custom header
        /// on subsequent operations.
        /// </summary>
        private async Task<ShareClient> CreateChangeFeedEnabledShareAsync()
        {
            string shareName = "changefeed-" + Recording.Random.NewGuid().ToString();

            ShareClientOptions creatorOptions = GetOptions();
            CustomRequestHeadersAndQueryParametersPolicy headerPolicy = new CustomRequestHeadersAndQueryParametersPolicy();
            headerPolicy.AddRequestHeader("x-ms-file-enable-change-feed", "true");
            creatorOptions.AddPolicy(headerPolicy, HttpPipelinePosition.PerCall);

            ShareServiceClient creatorService = InstrumentClient(
                new ShareServiceClient(
                    new Uri(TestConfigDefault.FileServiceEndpoint),
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConfigDefault.AccountKey),
                    creatorOptions));

            await creatorService.GetShareClient(shareName).CreateAsync();

            return GetShareServiceClient_SharedKey().GetShareClient(shareName);
        }

        /// <summary>
        /// Enumerates all change feed events and verifies at least one event is returned.
        /// </summary>
        [RecordedTest]
        //[Ignore("Requires a storage account with Files Change Feed enabled and pre-existing events")]
        public async Task GetChanges_ReturnsEvents()
        {
            ShareServiceClient shareServiceClient = GetShareServiceClient_SharedKey();
            await shareServiceClient.GetSharesAsync().ToListAsync();

            // Arrange
            ShareChangeFeedClient client = GetChangeFeedClient("changefeedtest");
            ShareClient shareClient = shareServiceClient.GetShareClient("changefeedtest");

            await shareClient.CreateSnapshotAsync();

            for (int i = 0; i < 2000; i++)
            {
                ShareDirectoryClient directoryClient = shareClient.GetDirectoryClient(Guid.NewGuid().ToString());
                await directoryClient.CreateAsync();
            }

            await shareClient.CreateSnapshotAsync();

            // Act
            List<ShareChangeFeedEvent> events = new List<ShareChangeFeedEvent>();

            if (IsAsync)
            {
                await foreach (ShareChangeFeedEvent e in client.GetChangesAsync())
                {
                    events.Add(e);
                }
            }
            else
            {
                foreach (ShareChangeFeedEvent e in client.GetChanges())
                {
                    events.Add(e);
                }
            }

            // Assert
            CollectionAssert.IsNotEmpty(events);
            foreach (ShareChangeFeedEvent e in events)
            {
                Assert.AreNotEqual(default(DateTimeOffset), e.EventTime);
                Assert.AreNotEqual(default(Guid), e.Id);
                Assert.IsNotNull(e.EventData);
            }
        }

        /// <summary>
        /// Enumerates change feed events within a specific time range and verifies
        /// all returned events fall within that range.
        /// </summary>
        [RecordedTest]
        [Ignore("Requires a storage account with Files Change Feed enabled and pre-existing events")]
        public async Task GetChanges_WithTimeRange_FiltersEvents()
        {
            // Arrange
            DateTimeOffset start = new DateTimeOffset(2026, 3, 27, 17, 39, 39, new TimeSpan(0));
            DateTimeOffset end = new DateTimeOffset(2026, 3, 27, 17, 40, 14, new TimeSpan(0));
            ShareChangeFeedClient client = GetChangeFeedClient("fileschangefeedshare");

            // Act
            List<ShareChangeFeedEvent> events = new List<ShareChangeFeedEvent>();

            if (IsAsync)
            {
                await foreach (ShareChangeFeedEvent e in client.GetChangesAsync(start, end))
                {
                    events.Add(e);
                }
            }
            else
            {
                foreach (ShareChangeFeedEvent e in client.GetChanges(start, end))
                {
                    events.Add(e);
                }
            }

            // Assert - all events should be within the requested range
            foreach (ShareChangeFeedEvent e in events)
            {
                Assert.GreaterOrEqual(e.EventTime, start, "Event time should be >= start (inclusive)");
                Assert.Less(e.EventTime, end, "Event time should be < end (exclusive)");
            }
        }

        /// <summary>
        /// Verifies that pagination works correctly by reading one page at a time
        /// and resuming with a continuation token. The page size hint is not guaranteed
        /// to be respected exactly (event-level time filtering may reduce the count),
        /// so we only assert that pages are non-empty and non-overlapping.
        /// </summary>
        [RecordedTest]
        [Ignore("Requires a storage account with Files Change Feed enabled and pre-existing events")]
        public async Task GetChanges_WithContinuationToken_ResumesCorrectly()
        {
            // Arrange
            ShareChangeFeedClient client = GetChangeFeedClient("fileschangefeedshare");

            // Act - read the first page
            HashSet<DateTimeOffset> firstPageEventTimes = new HashSet<DateTimeOffset>();
            string continuationToken = null;

            if (IsAsync)
            {
                await foreach (Page<ShareChangeFeedEvent> page in client.GetChangesAsync().AsPages(pageSizeHint: 10))
                {
                    foreach (ShareChangeFeedEvent e in page.Values)
                    {
                        firstPageEventTimes.Add(e.EventTime);
                    }
                    continuationToken = page.ContinuationToken;
                    if (firstPageEventTimes.Count >= 10) break;
                }
            }
            else
            {
                foreach (Page<ShareChangeFeedEvent> page in client.GetChanges().AsPages(pageSizeHint: 10))
                {
                    foreach (ShareChangeFeedEvent e in page.Values)
                    {
                        firstPageEventTimes.Add(e.EventTime);
                    }
                    continuationToken = page.ContinuationToken;
                    if (firstPageEventTimes.Count >= 10) break;
                }
            }

            CollectionAssert.IsNotEmpty(firstPageEventTimes, "First page should contain at least one event");

            // Act - resume from continuation token and read the next page
            HashSet<DateTimeOffset> secondPageEventTimes = new HashSet<DateTimeOffset>();
            if (continuationToken != null)
            {
                if (IsAsync)
                {
                    await foreach (Page<ShareChangeFeedEvent> page in client.GetChangesAsync(continuationToken).AsPages(pageSizeHint: 10))
                    {
                        foreach (ShareChangeFeedEvent e in page.Values)
                        {
                            secondPageEventTimes.Add(e.EventTime);
                        }
                        if (secondPageEventTimes.Count >= 10) break;
                    }
                }
                else
                {
                    foreach (Page<ShareChangeFeedEvent> page in client.GetChanges(continuationToken).AsPages(pageSizeHint: 10))
                    {
                        foreach (ShareChangeFeedEvent e in page.Values)
                        {
                            secondPageEventTimes.Add(e.EventTime);
                        }
                        if (secondPageEventTimes.Count >= 10) break;
                    }
                }

                // Assert - no overlap between first and second page
                CollectionAssert.IsEmpty(
                    firstPageEventTimes.Intersect(secondPageEventTimes),
                    "Resumed page should not contain events from the first page");
            }
        }

        /// <summary>
        /// Verifies that <see cref="ShareChangeFeedClient.GetLastConsumable"/> returns a valid timestamp.
        /// </summary>
        [RecordedTest]
        [Ignore("Requires a storage account with Files Change Feed enabled and pre-existing events")]
        public async Task GetLastConsumable_ReturnsTimestamp()
        {
            // Arrange
            ShareChangeFeedClient client = GetChangeFeedClient("fileschangefeedshare");

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
        [Ignore("Requires a storage account with Files Change Feed enabled and pre-existing events")]
        public async Task GetChanges_EventDataIsPopulated()
        {
            // Arrange
            ShareChangeFeedClient client = GetChangeFeedClient();

            // Act - get just a few events
            ShareChangeFeedEvent firstEvent = null;

            if (IsAsync)
            {
                await foreach (ShareChangeFeedEvent e in client.GetChangesAsync())
                {
                    firstEvent = e;
                    break;
                }
            }
            else
            {
                foreach (ShareChangeFeedEvent e in client.GetChanges())
                {
                    firstEvent = e;
                    break;
                }
            }

            // Assert
            Assert.IsNotNull(firstEvent, "Expected at least one event");
            Assert.AreNotEqual(default(ShareChangeFeedReasonType), firstEvent.Reason);
            Assert.AreNotEqual(default(ShareChangeFeedProtocol), firstEvent.Protocol);

            Assert.IsNotNull(firstEvent.EventData);
            Assert.IsNotNull(firstEvent.EventData.FileId, "FileId should be populated");
            // FileName or FullFilePath should be present for non-control events
            if (firstEvent.Reason != ShareChangeFeedReasonType.ControlEvent)
            {
                Assert.IsTrue(
                    !string.IsNullOrEmpty(firstEvent.EventData.FileName) ||
                    !string.IsNullOrEmpty(firstEvent.EventData.FullFilePath),
                    "FileName or FullFilePath should be populated for non-control events");
            }
        }

        /// <summary>
        /// Verifies that <see cref="ShareChangeFeedClientOptions.IncludeNonFinalizedEvents"/>
        /// allows reading events past the change feed's last consumable watermark.
        /// </summary>
        [Test]
        [Ignore("Requires non-finalized segments in the change feed, which cannot be reproduced deterministically in playback.")]
        public async Task GetChanges_IncludeNonFinalizedEvents_ReturnsEventsPastLastConsumable()
        {
            // Arrange - provision a fresh change-feed-enabled share and seed it with events.
            ShareClient shareClient = await CreateChangeFeedEnabledShareAsync();
            try
            {
                // Seed the change feed with directory-create events.
                for (int i = 0; i < 10; i++)
                {
                    await shareClient.GetDirectoryClient($"dir-{i}").CreateAsync();
                }
                // Give the service a moment to surface the new events into the non-finalized segment index.
                await Task.Delay(TimeSpan.FromSeconds(30));

                ShareChangeFeedClient tailing = new ShareChangeFeedClient(
                    new Uri(TestConfigDefault.FileServiceEndpoint),
                    shareClient.Name,
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConfigDefault.AccountKey),
                    new ShareChangeFeedClientOptions { IncludeNonFinalizedEvents = true });

                // Snapshot the current watermark. On a freshly-created share with no finalized
                // segments yet this will be null, in which case every event the tailing reader
                // returns is by definition past last consumable.
                DateTimeOffset? lastConsumable = IsAsync
                    ? await tailing.GetLastConsumableAsync()
                    : tailing.GetLastConsumable();

                // Act - tailing reader. Iterate via AsPages so we can also assert that no page
                // carries a continuation token (resumption is unsupported in non-finalized mode).
                List<ShareChangeFeedEvent> tailingEvents = new List<ShareChangeFeedEvent>();
                if (IsAsync)
                {
                    await foreach (Page<ShareChangeFeedEvent> page in tailing.GetChangesAsync().AsPages())
                    {
                        Assert.IsNull(page.ContinuationToken,
                            "Pages produced with IncludeNonFinalizedEvents=true must not carry a continuation token.");
                        tailingEvents.AddRange(page.Values);
                    }
                }
                else
                {
                    foreach (Page<ShareChangeFeedEvent> page in tailing.GetChanges().AsPages())
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
            finally
            {
                await shareClient.DeleteAsync();
            }
        }

        /// <summary>
        /// Verifies that GetChangesBetweenSnapshots returns events filtered by container version.
        /// </summary>
        [RecordedTest]
        [Ignore("Requires a storage account with Files Change Feed enabled, pre-existing events, and two snapshots taken")]
        public async Task GetChangesBetweenSnapshots_FiltersEvents()
        {
            ShareServiceClient shareServiceClient = GetShareServiceClient_SharedKey();
            IList<ShareItem> shares = await shareServiceClient.GetSharesAsync(ShareTraits.None, ShareStates.Snapshots).ToListAsync();
            List<ShareItem> snapshots = shares.Where(r => r.Name == "fileschangefeedshare").ToList();
            BlobContainerClient containerClient = GetBlobServiceClient_SharedKey().GetBlobContainerClient("fileschangefeed-2cf7b86c-ff27-4b4f-a49c-a5fa8ca1f15a");
            IList<BlobItem> changeFeedSnapshotsIList = await containerClient.GetBlobsAsync(new Blobs.Models.GetBlobsOptions { Prefix = "idx/snapshot/" }).ToListAsync();
            List<BlobItem> changeFeedSnapshots = changeFeedSnapshotsIList.ToList();
            // Arrange
            ShareChangeFeedClient client = GetChangeFeedClient("fileschangefeedshare");
            ShareClient shareClient = shareServiceClient.GetShareClient("fileschangefeedshare");

            // Arrange - these snapshot timestamps need to be set to real snapshot timestamps
            // from the test storage account.
            string beginSnapshot = snapshots[3].Snapshot;
            string endSnapshot = snapshots[10].Snapshot;

            // Act
            List<ShareChangeFeedEvent> events = new List<ShareChangeFeedEvent>();

            if (IsAsync)
            {
                await foreach (ShareChangeFeedEvent e in client.GetChangesBetweenSnapshotsAsync(
                    beginSnapshot, endSnapshot))
                {
                    events.Add(e);
                }
            }
            else
            {
                foreach (ShareChangeFeedEvent e in client.GetChangesBetweenSnapshots(
                    beginSnapshot, endSnapshot))
                {
                    events.Add(e);
                }
            }

            // Assert
            CollectionAssert.IsNotEmpty(events);
            // All events should have ContainerVersionNumber > 0 (filtered by cvId range)
            foreach (ShareChangeFeedEvent e in events)
            {
                Assert.Greater(e.ContainerVersionNumber, 0, "Events should have a positive container version number");
            }
        }
    }
}
