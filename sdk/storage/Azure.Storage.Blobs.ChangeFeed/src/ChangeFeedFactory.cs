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
        private readonly BlobContainerClient _containerClient;

        public ChangeFeedFactory(
            BlobServiceClient blobServiceClient)
        {
            _containerClient = blobServiceClient.GetBlobContainerClient(Constants.ChangeFeed.ChangeFeedContainerName);
            _segmentFactory = new SegmentFactory(
                _containerClient,
                new ShardFactory(
                    _containerClient,
                    new ChunkFactory(
                        _containerClient,
                        new LazyLoadingBlobStreamFactory(),
                        new AvroReaderFactory())));
        }

        public ChangeFeedFactory(
            BlobContainerClient containerClient,
            SegmentFactory segmentFactory)
        {
            _containerClient = containerClient;
            _segmentFactory = segmentFactory;
        }

        public async Task<ChangeFeed> BuildChangeFeed(
            bool async,
            DateTimeOffset? startTime = default,
            DateTimeOffset? endTime = default,
            string continuation = default)
        {
            DateTimeOffset lastConsumable;
            Queue<string> years = new Queue<string>();
            Queue<string> segments = new Queue<string>();
            ChangeFeedCursor cursor = null;

            // Create cursor
            if (continuation != null)
            {
                cursor = JsonSerializer.Deserialize<ChangeFeedCursor>(continuation);
                ValidateCursor(_containerClient, cursor);
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
                changeFeedContainerExists = await _containerClient.ExistsAsync().ConfigureAwait(false);
            }
            else
            {
                changeFeedContainerExists = _containerClient.Exists();
            }

            if (!changeFeedContainerExists)
            {
                throw new ArgumentException("Change Feed hasn't been enabled on this account, or is currently being enabled.");
            }

            // Get last consumable
            BlobClient blobClient = _containerClient.GetBlobClient(Constants.ChangeFeed.MetaSegmentsPath);
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
            years = await GetYearPaths(async).ConfigureAwait(false);

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
                    containerClient: _containerClient,
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
                segments.Dequeue(),
                cursor?.CurrentSegmentCursor)
                .ConfigureAwait(false);

            return new ChangeFeed(
                _containerClient,
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

        internal async Task<Queue<string>> GetYearPaths(
            bool async)
        {
            List<string> list = new List<string>();

            if (async)
            {
                await foreach (BlobHierarchyItem blobHierarchyItem in _containerClient.GetBlobsByHierarchyAsync(
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
                foreach (BlobHierarchyItem blobHierarchyItem in _containerClient.GetBlobsByHierarchy(
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
