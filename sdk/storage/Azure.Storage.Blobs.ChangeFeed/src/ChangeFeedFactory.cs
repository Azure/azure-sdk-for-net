﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
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
            DateTimeOffset? startTime,
            DateTimeOffset? endTime,
            string continuation,
            bool async,
            CancellationToken cancellationToken)
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
                startTime = BlobChangeFeedExtensions.ToDateTimeOffset(cursor.CurrentSegmentCursor.SegmentPath).Value;
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
                changeFeedContainerExists = await _containerClient.ExistsAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            else
            {
                changeFeedContainerExists = _containerClient.Exists(cancellationToken: cancellationToken);
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
                blobDownloadInfo = await blobClient.DownloadAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            else
            {
                blobDownloadInfo = blobClient.Download(cancellationToken: cancellationToken);
            }

            JsonDocument jsonMetaSegment;
            if (async)
            {
                jsonMetaSegment = await JsonDocument.ParseAsync(
                    blobDownloadInfo.Content,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            else
            {
                jsonMetaSegment = JsonDocument.Parse(blobDownloadInfo.Content);
            }

            lastConsumable = jsonMetaSegment.RootElement.GetProperty("lastConsumable").GetDateTimeOffset();

            // Get year paths
            years = await GetYearPathsInternal(
                async,
                cancellationToken).ConfigureAwait(false);

            // Dequeue any years that occur before start time
            if (startTime.HasValue)
            {
                while (years.Count > 0
                    && BlobChangeFeedExtensions.ToDateTimeOffset(years.Peek()) < startTime.RoundDownToNearestYear())
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
                segments = await BlobChangeFeedExtensions.GetSegmentsInYearInternal(
                    containerClient: _containerClient,
                    yearPath: years.Dequeue(),
                    startTime: startTime,
                    endTime: BlobChangeFeedExtensions.MinDateTime(lastConsumable, endTime),
                    async: async,
                    cancellationToken: cancellationToken)
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
            if (containerClient.Uri.Host != cursor.UrlHost)
            {
                throw new ArgumentException("Cursor URL Host does not match container URL host.");
            }
            if (cursor.CursorVersion != 1)
            {
                throw new ArgumentException("Unsupported cursor version.");
            }
        }

        internal async Task<Queue<string>> GetYearPathsInternal(
            bool async,
            CancellationToken cancellationToken)
        {
            List<string> list = new List<string>();

            if (async)
            {
                await foreach (BlobHierarchyItem blobHierarchyItem in _containerClient.GetBlobsByHierarchyAsync(
                    prefix: Constants.ChangeFeed.SegmentPrefix,
                    delimiter: "/",
                    cancellationToken: cancellationToken).ConfigureAwait(false))
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
                delimiter: "/",
                cancellationToken: cancellationToken))
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
