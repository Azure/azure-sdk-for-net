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
    internal class ChangeFeedFactoryBase<TEvent> where TEvent : IChangeFeedEvent
    {
        private readonly SegmentFactoryBase<TEvent> _segmentFactory;
        private readonly BlobContainerClient _containerClient;
        private readonly ChangeFeedConfiguration<TEvent> _config;
        private readonly bool _includeNonFinalizedEvents;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeFeedFactoryBase{TEvent}"/> class,
        /// creating the full factory chain (Segment -> Shard -> Chunk -> Avro).
        /// </summary>
        /// <param name="containerClient">Container client for the change feed container.</param>
        /// <param name="maxTransferSize">Optional override for the chunk download block size.</param>
        /// <param name="config">Change feed configuration.</param>
        /// <param name="includeNonFinalizedEvents">
        /// When <c>true</c>, segment enumeration is not capped at the change feed's last consumable
        /// timestamp. Used by callers that opt in to reading from non-finalized segments. Defaults
        /// to <c>false</c> to preserve the historical behavior of capping at the watermark.
        /// </param>
        public ChangeFeedFactoryBase(
            BlobContainerClient containerClient,
            long? maxTransferSize,
            ChangeFeedConfiguration<TEvent> config,
            bool includeNonFinalizedEvents = false)
        {
            _containerClient = containerClient;
            _config = config;
            _includeNonFinalizedEvents = includeNonFinalizedEvents;
            _segmentFactory = new SegmentFactoryBase<TEvent>(
                _containerClient,
                new ShardFactoryBase<TEvent>(
                    _containerClient,
                    new ChunkFactoryBase<TEvent>(
                        _containerClient,
                        new AvroReaderFactory(),
                        maxTransferSize,
                        config,
                        allowModifications: includeNonFinalizedEvents)),
                config);
        }

        /// <summary>
        /// Initializes a new instance with an externally provided segment factory (used for testing).
        /// </summary>
        /// <param name="containerClient">Container client for the change feed container.</param>
        /// <param name="segmentFactory">Pre-built segment factory.</param>
        /// <param name="config">Change feed configuration.</param>
        /// <param name="includeNonFinalizedEvents">
        /// When <c>true</c>, segment enumeration is not capped at the change feed's last consumable
        /// timestamp.
        /// </param>
        public ChangeFeedFactoryBase(
            BlobContainerClient containerClient,
            SegmentFactoryBase<TEvent> segmentFactory,
            ChangeFeedConfiguration<TEvent> config,
            bool includeNonFinalizedEvents = false)
        {
            _containerClient = containerClient;
            _segmentFactory = segmentFactory;
            _config = config;
            _includeNonFinalizedEvents = includeNonFinalizedEvents;
        }

        /// <summary>
        /// Builds a change feed reader, either from scratch with a time window or by resuming from a serialized continuation token.
        /// </summary>
        /// <param name="startTime">Optional inclusive start time (ignored when resuming from a cursor).</param>
        /// <param name="endTime">Optional exclusive end time (ignored when resuming from a cursor).</param>
        /// <param name="continuation">Serialized continuation token from a previous page, or null for a fresh start.</param>
        /// <param name="async">Whether to use async APIs.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="disableEventTimeFilter">
        /// When <c>true</c>, <paramref name="startTime"/>/<paramref name="endTime"/> are used only
        /// to select which segments to enumerate; the per-event <c>EventTime</c> predicate and the
        /// segment-boundary end gate are not applied, so every row in the selected segments is
        /// produced. Used by the snapshot-range reader, which bounds the read by container version
        /// id rather than event time. Defaults to <c>false</c> (the time-window contract used by
        /// <c>GetChanges(start, end)</c> is unchanged).
        /// </param>
        /// <returns>A <see cref="ChangeFeedBase{TEvent}"/> positioned and ready to produce events.</returns>
        public Task<ChangeFeedBase<TEvent>> BuildChangeFeed(
            DateTimeOffset? startTime,
            DateTimeOffset? endTime,
            string continuation,
            bool async,
            CancellationToken cancellationToken,
            bool disableEventTimeFilter = false)
        {
            ChangeFeedCursor cursor = null;

            // Resume path: deserialize the cursor and extract the start/end times from it.
            if (continuation != null)
            {
                cursor = JsonSerializer.Deserialize<ChangeFeedCursor>(continuation);
                ValidateCursor(_containerClient, cursor);
                startTime = ChangeFeedExtensionsBase.ToDateTimeOffset(cursor.CurrentSegmentCursor.SegmentPath).Value;
                endTime = cursor.EndTime;
            }

            return BuildChangeFeedCore(cursor, startTime, endTime, async, cancellationToken, disableEventTimeFilter);
        }

        /// <summary>
        /// Builds a change feed reader resuming from a typed <see cref="ChangeFeedCursor"/>. The
        /// cursor's <see cref="ChangeFeedCursor.EndTime"/> and current segment path supply the
        /// time window, so callers do not pass <c>startTime</c>/<c>endTime</c> separately. This is
        /// the resume-only counterpart to the string-based overload and is used when the caller
        /// already holds a typed cursor (e.g. a snapshot envelope that nests one directly), so
        /// the cursor is not round-tripped through JSON on the way back in.
        /// </summary>
        /// <param name="cursor">Typed cursor captured from a previous page. Must not be null.</param>
        /// <param name="async">Whether to use async APIs.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="disableEventTimeFilter">See the string-based overload.</param>
        /// <returns>A <see cref="ChangeFeedBase{TEvent}"/> positioned and ready to produce events.</returns>
        public Task<ChangeFeedBase<TEvent>> BuildChangeFeed(
            ChangeFeedCursor cursor,
            bool async,
            CancellationToken cancellationToken,
            bool disableEventTimeFilter = false)
        {
            if (cursor == null)
                throw new ArgumentNullException(nameof(cursor));

            ValidateCursor(_containerClient, cursor);
            DateTimeOffset? startTime = ChangeFeedExtensionsBase.ToDateTimeOffset(cursor.CurrentSegmentCursor.SegmentPath).Value;
            DateTimeOffset? endTime = cursor.EndTime;

            return BuildChangeFeedCore(cursor, startTime, endTime, async, cancellationToken, disableEventTimeFilter);
        }

        /// <summary>
        /// Shared body for the string-based and typed-cursor <c>BuildChangeFeed</c> overloads.
        /// Runs the container existence check, derives the year/segment queues from the time
        /// window, and positions the first segment using the supplied cursor (if any).
        /// </summary>
        private async Task<ChangeFeedBase<TEvent>> BuildChangeFeedCore(
            ChangeFeedCursor cursor,
            DateTimeOffset? startTime,
            DateTimeOffset? endTime,
            bool async,
            CancellationToken cancellationToken,
            bool disableEventTimeFilter)
        {
            DateTimeOffset lastConsumable;
            Queue<string> years = new Queue<string>();
            Queue<string> segments = new Queue<string>();

            // No rounding is applied — raw user-provided times are passed directly to the
            // segment filter, which supports variable-length segments.

            bool changeFeedContainerExists;
            if (async)
                changeFeedContainerExists = await _containerClient.ExistsAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            else
                changeFeedContainerExists = _containerClient.Exists(cancellationToken: cancellationToken);

            if (!changeFeedContainerExists)
                throw new ArgumentException("Change Feed hasn't been enabled on this account, or is currently being enabled.");

            DateTimeOffset? lastConsumableNullable = await GetLastConsumableInternal(
                _containerClient,
                _config.MetaSegmentsPath,
                async,
                cancellationToken)
                .ConfigureAwait(false);

            if (lastConsumableNullable.HasValue)
            {
                lastConsumable = lastConsumableNullable.Value;
            }
            else if (_includeNonFinalizedEvents)
            {
                // No watermark exists yet (e.g. brand-new change feed). Caller opted in to
                // non-finalized events, so attempt to scan segments anyway.
                lastConsumable = DateTimeOffset.MinValue;
            }
            else
            {
                return ChangeFeedBase<TEvent>.Empty();
            }

            years = await GetYearPathsInternal(async, cancellationToken).ConfigureAwait(false);

            // Skip year prefixes that are entirely before the requested start time.
            if (startTime.HasValue)
            {
                while (years.Count > 0 && ChangeFeedExtensionsBase.ToDateTimeOffset(years.Peek()) < startTime.RoundDownToNearestYear())
                    years.Dequeue();
            }

            if (years.Count == 0) return ChangeFeedBase<TEvent>.Empty();

            // When _includeNonFinalizedEvents is true, do not cap segment enumeration at the
            // last consumable watermark — pass the user's endTime through directly.
            DateTimeOffset? effectiveEndTime = _includeNonFinalizedEvents
                ? endTime
                : ChangeFeedExtensionsBase.MinDateTime(lastConsumable, endTime);

            // Scan through years until we find one that contains matching segments within the time window.
            while (segments.Count == 0 && years.Count > 0)
            {
                segments = await ChangeFeedExtensionsBase.GetSegmentsInYearInternal(
                    containerClient: _containerClient, yearPath: years.Dequeue(),
                    startTime: startTime,
                    endTime: effectiveEndTime,
                    async: async,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }

            if (segments.Count == 0)
                return ChangeFeedBase<TEvent>.Empty();

            SegmentBase<TEvent> currentSegment = await _segmentFactory.BuildSegment(
                async,
                segments.Dequeue(),
                cursor?.CurrentSegmentCursor)
                .ConfigureAwait(false);

            return new ChangeFeedBase<TEvent>(
                _containerClient,
                _segmentFactory,
                years,
                segments,
                currentSegment,
                lastConsumable,
                startTime,
                endTime,
                _config,
                _includeNonFinalizedEvents,
                disableEventTimeFilter);
        }

        /// <summary>
        /// Validates that a deserialized cursor matches the current storage account and uses a
        /// supported cursor version.
        /// </summary>
        private static void ValidateCursor(
            BlobContainerClient containerClient,
            ChangeFeedCursor cursor)
        {
            if (!string.Equals(containerClient.Uri.Host, cursor.UrlHost, StringComparison.OrdinalIgnoreCase))
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
                await foreach (BlobHierarchyItem item in _containerClient.GetBlobsByHierarchyAsync(
                    options: options,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false))
                {
                    if (item.Prefix.Contains(_config.InitializationSegment))
                        continue;

                    list.Add(item.Prefix);
                }
            }
            else
            {
                foreach (BlobHierarchyItem item in _containerClient.GetBlobsByHierarchy(
                    options: options,
                    cancellationToken: cancellationToken))
                {
                    if (item.Prefix.Contains(_config.InitializationSegment))
                        continue;

                    list.Add(item.Prefix);
                }
            }
            return new Queue<string>(list);
        }

        /// <summary>
        /// Downloads and parses the meta/segments.json file to determine the last consumable timestamp.
        /// </summary>
        /// <returns>The last consumable <see cref="DateTimeOffset"/>, or null if the metadata blob does not exist.</returns>
        internal static async Task<DateTimeOffset?> GetLastConsumableInternal(
            BlobContainerClient containerClient,
            string metaSegmentsPath,
            bool async,
            CancellationToken cancellationToken)
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
                    jsonMetaSegment = await JsonDocument.ParseAsync(
                        blobDownloadInfo.Content,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
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
