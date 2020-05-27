// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Storage.Blobs.ChangeFeed.Models;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.ChangeFeed
{
    internal class ChangeFeedFactory
    {
        private readonly SegmentFactory _segmentFactory;

        public ChangeFeedFactory()
        {
            _segmentFactory = new SegmentFactory(
                new ShardFactory(
                    new ChunkFactory(
                        new LazyLoadingBlobStreamFactory(),
                        new AvroReaderFactory())));
        }

        public ChangeFeedFactory(SegmentFactory segmentFactory)
        {
            _segmentFactory = segmentFactory;
        }

        public async Task<ChangeFeed> BuildChangeFeed(
            bool async,
            BlobServiceClient blobServiceClient,
            DateTimeOffset? startTime = default,
            DateTimeOffset? endTime = default,
            string continuation = default)
        {
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(Constants.ChangeFeed.ChangeFeedContainerName);
            DateTimeOffset lastConsumable;
            Queue<string> years = new Queue<string>();
            Queue<string> segments = new Queue<string>();
            ChangeFeedCursor cursor = null;

            // Create cursor
            if (continuation != null)
            {
                cursor = JsonSerializer.Deserialize<ChangeFeedCursor>(continuation);
                ValidateCursor(containerClient, cursor);
                startTime = cursor.CurrentSegmentCursor.SegmentTime;
                endTime = cursor.EndTime;
            }
            // Round start and end time if we are not using the cursor.
            else
            {
                startTime = startTime.RoundDownToNearestHour();
                endTime = endTime.RoundUpToNearestHour();
            }

            // Check if Change Feed has been abled for this account.
            bool changeFeedContainerExists;

            if (async)
            {
                changeFeedContainerExists = await containerClient.ExistsAsync().ConfigureAwait(false);
            }
            else
            {
                changeFeedContainerExists = containerClient.Exists();
            }

            if (!changeFeedContainerExists)
            {
                throw new ArgumentException("Change Feed hasn't been enabled on this account, or is currently being enabled.");
            }

            // Get last consumable
            BlobClient blobClient = containerClient.GetBlobClient(Constants.ChangeFeed.MetaSegmentsPath);
            BlobDownloadInfo blobDownloadInfo;
            if (async)
            {
                blobDownloadInfo = await blobClient.DownloadAsync().ConfigureAwait(false);
            }
            else
            {
                blobDownloadInfo = blobClient.Download();
            }

            JsonDocument jsonMetaSegment;
            if (async)
            {
                jsonMetaSegment = await JsonDocument.ParseAsync(blobDownloadInfo.Content).ConfigureAwait(false);
            }
            else
            {
                jsonMetaSegment = JsonDocument.Parse(blobDownloadInfo.Content);
            }

            lastConsumable = jsonMetaSegment.RootElement.GetProperty("lastConsumable").GetDateTimeOffset();

            // Get year paths
            years = await GetYearPaths(async, containerClient).ConfigureAwait(false);

            // Dequeue any years that occur before start time
            if (startTime.HasValue)
            {
                while (years.Count > 0
                    && years.Peek().ToDateTimeOffset() < startTime.RoundDownToNearestYear())
                {
                    years.Dequeue();
                }
            }

            // There are no years.
            if (years.Count == 0)
            {
                return ChangeFeed.Empty();
            }

            while (segments.Count == 0 && years.Count > 0)
            {
                // Get Segments for year
                segments = await BlobChangeFeedExtensions.GetSegmentsInYear(
                    async: async,
                    containerClient: containerClient,
                    yearPath: years.Dequeue(),
                    startTime: startTime,
                    endTime: BlobChangeFeedExtensions.MinDateTime(lastConsumable, endTime))
                    .ConfigureAwait(false);
            }

            // We were on the last year, and there were no more segments.
            if (segments.Count == 0)
            {
                return ChangeFeed.Empty();
            }

            Segment currentSegment = await _segmentFactory.BuildSegment(
                async,
                containerClient,
                segments.Dequeue(),
                cursor?.CurrentSegmentCursor)
                .ConfigureAwait(false);

            return new ChangeFeed(
                containerClient,
                _segmentFactory,
                years,
                segments,
                currentSegment,
                lastConsumable,
                startTime,
                endTime);
        }

        private static void ValidateCursor(
            BlobContainerClient containerClient,
            ChangeFeedCursor cursor)
        {
            if (containerClient.Uri.ToString().GetHashCode() != cursor.UrlHash)
            {
                throw new ArgumentException("Cursor URL does not match container URL");
            }
        }

        internal static async Task<Queue<string>> GetYearPaths(
            bool async,
            BlobContainerClient containerClient)
        {
            List<string> list = new List<string>();

            if (async)
            {
                await foreach (BlobHierarchyItem blobHierarchyItem in containerClient.GetBlobsByHierarchyAsync(
                    prefix: Constants.ChangeFeed.SegmentPrefix,
                    delimiter: "/").ConfigureAwait(false))
                {
                    if (blobHierarchyItem.Prefix.Contains(Constants.ChangeFeed.InitalizationSegment))
                        continue;

                    list.Add(blobHierarchyItem.Prefix);
                }
            }
            else
            {
                foreach (BlobHierarchyItem blobHierarchyItem in containerClient.GetBlobsByHierarchy(
                prefix: Constants.ChangeFeed.SegmentPrefix,
                delimiter: "/"))
                {
                    if (blobHierarchyItem.Prefix.Contains(Constants.ChangeFeed.InitalizationSegment))
                        continue;

                    list.Add(blobHierarchyItem.Prefix);
                }
            }
            return new Queue<string>(list);
        }
    }
}
