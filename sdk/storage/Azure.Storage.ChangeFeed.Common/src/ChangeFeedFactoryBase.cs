// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.ChangeFeed.Common
{
    /// <summary>
    /// Top-level factory that orchestrates the construction of a <see cref="ChangeFeedBase{TEvent}"/>,
    /// handling cursor deserialization, time rounding, year/segment enumeration, and the full factory hierarchy.
    /// </summary>
    internal class ChangeFeedFactoryBase<TEvent>
    {
        private readonly SegmentFactoryBase<TEvent> _segmentFactory;
        private readonly BlobContainerClient _containerClient;
        private readonly ChangeFeedConfiguration<TEvent> _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeFeedFactoryBase{TEvent}"/> class,
        /// creating the full factory chain (Segment -> Shard -> Chunk -> Avro).
        /// </summary>
        /// <param name="containerClient">Container client for the change feed container.</param>
        /// <param name="maxTransferSize">Optional override for the chunk download block size.</param>
        /// <param name="config">Change feed configuration.</param>
        public ChangeFeedFactoryBase(BlobContainerClient containerClient, long? maxTransferSize, ChangeFeedConfiguration<TEvent> config)
        {
            _containerClient = containerClient;
            _config = config;
            _segmentFactory = new SegmentFactoryBase<TEvent>(
                _containerClient,
                new ShardFactoryBase<TEvent>(
                    _containerClient,
                    new ChunkFactoryBase<TEvent>(
                        _containerClient,
                        new LazyLoadingBlobStreamFactory(),
                        new AvroReaderFactory(),
                        maxTransferSize,
                        config)),
                config);
        }

        /// <summary>
        /// Initializes a new instance with an externally provided segment factory (used for testing).
        /// </summary>
        /// <param name="containerClient">Container client for the change feed container.</param>
        /// <param name="segmentFactory">Pre-built segment factory.</param>
        /// <param name="config">Change feed configuration.</param>
        public ChangeFeedFactoryBase(BlobContainerClient containerClient, SegmentFactoryBase<TEvent> segmentFactory, ChangeFeedConfiguration<TEvent> config)
        {
            _containerClient = containerClient;
            _segmentFactory = segmentFactory;
            _config = config;
        }

        /// <summary>
        /// Builds a change feed reader, either from scratch with a time window or by resuming from a continuation token.
        /// </summary>
        /// <param name="startTime">Optional inclusive start time (ignored when resuming from a cursor).</param>
        /// <param name="endTime">Optional exclusive end time (ignored when resuming from a cursor).</param>
        /// <param name="continuation">Serialized continuation token from a previous page, or null for a fresh start.</param>
        /// <param name="async">Whether to use async APIs.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A <see cref="ChangeFeedBase{TEvent}"/> positioned and ready to produce events.</returns>
        public async Task<ChangeFeedBase<TEvent>> BuildChangeFeed(DateTimeOffset? startTime, DateTimeOffset? endTime, string continuation, bool async, CancellationToken cancellationToken)
        {
            DateTimeOffset lastConsumable;
            Queue<string> years = new Queue<string>();
            Queue<string> segments = new Queue<string>();
            ChangeFeedCursor cursor = null;

            // Resume path: deserialize the cursor and extract the start/end times from it.
            if (continuation != null)
            {
                cursor = JsonSerializer.Deserialize<ChangeFeedCursor>(continuation);
                ValidateCursor(_containerClient, cursor);
                startTime = ChangeFeedExtensionsBase.ToDateTimeOffset(cursor.CurrentSegmentCursor.SegmentPath).Value;
                endTime = cursor.EndTime;
            }
            else
            {
                // Fresh start: round the requested time window to align with segment boundaries.
                startTime = startTime.RoundDownToNearestInterval(_config.TimeWindowInterval);
                endTime = endTime.RoundUpToNearestInterval(_config.TimeWindowInterval);
            }

            bool changeFeedContainerExists;
            if (async)
                changeFeedContainerExists = await _containerClient.ExistsAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            else
                changeFeedContainerExists = _containerClient.Exists(cancellationToken: cancellationToken);

            if (!changeFeedContainerExists)
                throw new ArgumentException("Change Feed hasn't been enabled on this account, or is currently being enabled.");

            DateTimeOffset? lastConsumableNullable = await GetLastConsumableInternal(_containerClient, _config.MetaSegmentsPath, async, cancellationToken).ConfigureAwait(false);
            if (lastConsumableNullable.HasValue)
                lastConsumable = lastConsumableNullable.Value;
            else
                return ChangeFeedBase<TEvent>.Empty();

            years = await GetYearPathsInternal(async, cancellationToken).ConfigureAwait(false);

            // Skip year prefixes that are entirely before the requested start time.
            if (startTime.HasValue)
            {
                while (years.Count > 0 && ChangeFeedExtensionsBase.ToDateTimeOffset(years.Peek()) < startTime.RoundDownToNearestYear())
                    years.Dequeue();
            }

            if (years.Count == 0) return ChangeFeedBase<TEvent>.Empty();

            // Scan through years until we find one that contains matching segments within the time window.
            while (segments.Count == 0 && years.Count > 0)
            {
                segments = await ChangeFeedExtensionsBase.GetSegmentsInYearInternal(
                    containerClient: _containerClient, yearPath: years.Dequeue(), startTime: startTime,
                    endTime: ChangeFeedExtensionsBase.MinDateTime(lastConsumable, endTime), async: async, cancellationToken: cancellationToken).ConfigureAwait(false);
            }

            if (segments.Count == 0) return ChangeFeedBase<TEvent>.Empty();

            SegmentBase<TEvent> currentSegment = await _segmentFactory.BuildSegment(async, segments.Dequeue(), cursor?.CurrentSegmentCursor).ConfigureAwait(false);

            return new ChangeFeedBase<TEvent>(_containerClient, _segmentFactory, years, segments, currentSegment, lastConsumable, startTime, endTime, _config);
        }

        /// <summary>
        /// Validates that a deserialized cursor matches the current storage account and uses a supported version.
        /// </summary>
        private static void ValidateCursor(BlobContainerClient containerClient, ChangeFeedCursor cursor)
        {
            if (containerClient.Uri.Host != cursor.UrlHost)
                throw new ArgumentException("Cursor URL Host does not match container URL host.");
            if (cursor.CursorVersion != 1)
                throw new ArgumentException("Unsupported cursor version.");
        }

        /// <summary>
        /// Lists year-level prefixes under the segment path, filtering out the initialization segment.
        /// </summary>
        /// <returns>A queue of year path prefixes in chronological order.</returns>
        internal async Task<Queue<string>> GetYearPathsInternal(bool async, CancellationToken cancellationToken)
        {
            List<string> list = new List<string>();
            GetBlobsByHierarchyOptions options = new GetBlobsByHierarchyOptions { Prefix = _config.SegmentPrefix, Delimiter = "/" };

            if (async)
            {
                await foreach (BlobHierarchyItem item in _containerClient.GetBlobsByHierarchyAsync(options: options, cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    if (item.Prefix.Contains(_config.InitializationSegment)) continue;
                    list.Add(item.Prefix);
                }
            }
            else
            {
                foreach (BlobHierarchyItem item in _containerClient.GetBlobsByHierarchy(options: options, cancellationToken: cancellationToken))
                {
                    if (item.Prefix.Contains(_config.InitializationSegment)) continue;
                    list.Add(item.Prefix);
                }
            }
            return new Queue<string>(list);
        }

        /// <summary>
        /// Downloads and parses the meta/segments.json file to determine the last consumable timestamp.
        /// </summary>
        /// <returns>The last consumable <see cref="DateTimeOffset"/>, or null if the metadata blob does not exist.</returns>
        internal static async Task<DateTimeOffset?> GetLastConsumableInternal(BlobContainerClient containerClient, string metaSegmentsPath, bool async, CancellationToken cancellationToken)
        {
            BlobClient blobClient = containerClient.GetBlobClient(metaSegmentsPath);
            BlobDownloadStreamingResult blobDownloadInfo;
            try
            {
                if (async)
                    blobDownloadInfo = await blobClient.DownloadStreamingAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
                else
                    blobDownloadInfo = blobClient.DownloadStreaming(cancellationToken: cancellationToken);
            }
            catch (RequestFailedException e) when (e.ErrorCode == BlobErrorCode.BlobNotFound)
            {
                return null;
            }

            JsonDocument jsonMetaSegment = null;
            try
            {
                if (async)
                    jsonMetaSegment = await JsonDocument.ParseAsync(blobDownloadInfo.Content, cancellationToken: cancellationToken).ConfigureAwait(false);
                else
                    jsonMetaSegment = JsonDocument.Parse(blobDownloadInfo.Content);

                return jsonMetaSegment.RootElement.GetProperty("lastConsumable").GetDateTimeOffset();
            }
            finally
            {
                jsonMetaSegment?.Dispose();
            }
        }
    }
}
