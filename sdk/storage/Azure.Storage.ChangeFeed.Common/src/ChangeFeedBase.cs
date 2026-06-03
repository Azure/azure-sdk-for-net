// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

namespace Azure.Storage.ChangeFeed.Common
{
    /// <summary>
    /// Core change feed reader that iterates through segments (time windows) in chronological order,
    /// producing pages of events. Supports cursor-based continuation and time-bounded queries.
    /// </summary>
    internal class ChangeFeedBase<TEvent> where TEvent : IChangeFeedEvent
    {
        private readonly BlobContainerClient _containerClient;
        private readonly SegmentFactoryBase<TEvent> _segmentFactory;
        private readonly Queue<string> _years;
        private Queue<string> _segments;
        private SegmentBase<TEvent> _currentSegment;
        private readonly ChangeFeedConfiguration<TEvent> _config;

        /// <summary>
        /// The last consumable timestamp reported by the service's meta/segments.json.
        /// Events after this time are not yet finalized and should not be read.
        /// </summary>
        public DateTimeOffset LastConsumable { get; private set; }

        private DateTimeOffset? _startTime;
        private DateTimeOffset? _endTime;
        private readonly bool _includeNonFinalizedEvents;

        /// <summary>
        /// When <c>true</c>, <see cref="_startTime"/>/<see cref="_endTime"/> bound only which
        /// segments are enumerated; no per-event <c>EventTime</c> filtering and no segment-boundary
        /// end gate are applied, so every row in the selected segments is produced. Set by the
        /// snapshot-range reader, which bounds the read by container version id instead.
        /// </summary>
        private readonly bool _disableEventTimeFilter;

        private bool _empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeFeedBase{TEvent}"/> class.
        /// </summary>
        /// <param name="containerClient">Container client for the change feed container.</param>
        /// <param name="segmentFactory">Factory used to build segment instances.</param>
        /// <param name="years">Queue of remaining year prefixes to scan for segments.</param>
        /// <param name="segments">Queue of remaining segment paths in the current year.</param>
        /// <param name="currentSegment">The segment currently being read.</param>
        /// <param name="lastConsumable">Last consumable timestamp from the service metadata.</param>
        /// <param name="startTime">Optional inclusive start time for the change feed window.</param>
        /// <param name="endTime">Optional exclusive end time for the change feed window.</param>
        /// <param name="config">Change feed configuration.</param>
        /// <param name="includeNonFinalizedEvents">
        /// Whether the producing run was reading past the finalized watermark. When <c>true</c>,
        /// emitted pages will not include a continuation token (resumption is not supported in
        /// this mode because non-finalized segments may change between reads).
        /// </param>
        /// <param name="disableEventTimeFilter">
        /// When <c>true</c>, <paramref name="startTime"/>/<paramref name="endTime"/> bound only
        /// which segments are enumerated; the per-event <c>EventTime</c> predicate and the
        /// segment-boundary end gate are not applied. Used by the snapshot-range reader.
        /// </param>
        public ChangeFeedBase(
            BlobContainerClient containerClient,
            SegmentFactoryBase<TEvent> segmentFactory,
            Queue<string> years,
            Queue<string> segments,
            SegmentBase<TEvent> currentSegment,
            DateTimeOffset lastConsumable,
            DateTimeOffset? startTime,
            DateTimeOffset? endTime,
            ChangeFeedConfiguration<TEvent> config,
            bool includeNonFinalizedEvents = false,
            bool disableEventTimeFilter = false)
        {
            _containerClient = containerClient;
            _segmentFactory = segmentFactory;
            _years = years;
            _segments = segments;
            _currentSegment = currentSegment;
            LastConsumable = lastConsumable;
            _startTime = startTime;
            _endTime = endTime;
            _config = config;
            _includeNonFinalizedEvents = includeNonFinalizedEvents;
            _disableEventTimeFilter = disableEventTimeFilter;
            _empty = false;
        }

        /// <summary>
        /// Constructor for mocking. Do not use directly.
        /// </summary>
        public ChangeFeedBase() { }

        /// <summary>
        /// Reads the next page of events from the change feed, advancing through segments as needed.
        /// </summary>
        /// <param name="async">Whether to use async APIs.</param>
        /// <param name="pageSize">Requested number of events (capped by <see cref="ChangeFeedConfiguration{TEvent}.DefaultPageSize"/>).</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A page of events with a serialized continuation token.</returns>
        public async Task<Page<TEvent>> GetPage(
            bool async,
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            if (!HasNext())
                throw new InvalidOperationException("Change feed doesn't have any more events");

            // In snapshot mode the enumerated segment set is already bounded by the log window;
            // skipping the boundary segment here would drop the segment whose bucket DateTime
            // equals endTime — exactly the degenerate same-minute window the snapshot reader hits.
            if (!_disableEventTimeFilter && _currentSegment.DateTime >= _endTime)
                return ChangeFeedEventPageBase<TEvent>.Empty();

            int defaultPageSize = _config?.DefaultPageSize ?? 5000;

            if (pageSize > defaultPageSize)
                pageSize = defaultPageSize;

            List<TEvent> events = new List<TEvent>();
            int remainingEvents = pageSize;
            // Loop across segment boundaries: when one segment is exhausted, advance to the next
            // and continue filling the page until the requested size is reached or no segments remain.
            while (events.Count < pageSize && HasNext())
            {
                // Snapshot mode reads every row in the selected segments and filters by
                // container version id downstream, so suppress the per-event time predicate.
                List<TEvent> newEvents = await _currentSegment.GetPage(
                    async,
                    remainingEvents,
                    _disableEventTimeFilter ? null : _startTime,
                    _disableEventTimeFilter ? null : _endTime,
                    cancellationToken)
                    .ConfigureAwait(false);

                events.AddRange(newEvents);
                remainingEvents = pageSize - events.Count;

                await AdvanceSegmentIfNecessary(async, cancellationToken).ConfigureAwait(false);
            }

            // When IncludeNonFinalizedEvents is enabled the read is intrinsically unstable —
            // segments past the finalized watermark may grow, shrink, or appear/disappear
            // between calls — so resuming from a captured position would silently miss or
            // duplicate events. Suppress the continuation token in that mode so callers
            // cannot persist a position that we cannot honor.
            string continuationToken = _includeNonFinalizedEvents
                ? null
                : JsonSerializer.Serialize<ChangeFeedCursor>(GetCursor());

            return new ChangeFeedEventPageBase<TEvent>(events, continuationToken);
        }

        /// <summary>
        /// Returns true if there are more events to read, considering remaining segments, years, and the end time.
        /// </summary>
        public bool HasNext()
        {
            if (_empty || _segments.Count == 0 && _years.Count == 0 && !_currentSegment.HasNext())
                return false;

            // Snapshot mode relies solely on the enumerated segment set (already bounded by the
            // log window) to terminate; applying the end gate here would skip the boundary
            // segment when the begin/end log windows fall in the same minute bucket.
            if (_endTime.HasValue && !_disableEventTimeFilter)
                return _currentSegment.DateTime < _endTime;

            return true;
        }

        /// <summary>
        /// Builds a cursor capturing the current position in the change feed.
        /// </summary>
        internal ChangeFeedCursor GetCursor()
            => new ChangeFeedCursor(
                urlHost: _containerClient.Uri.Host,
                endDateTime: _endTime,
                currentSegmentCursor: _currentSegment.GetCursor());

        /// <summary>
        /// Advances to the next segment if the current one is exhausted, loading segments from the next year if needed.
        /// </summary>
        private async Task AdvanceSegmentIfNecessary(bool async, CancellationToken cancellationToken)
        {
            if (_currentSegment.HasNext())
                return;

            if (_segments.Count > 0)
            {
                _currentSegment = await _segmentFactory.BuildSegment(async, _segments.Dequeue()).ConfigureAwait(false);
            }
            else if (_segments.Count == 0 && _years.Count > 0)
            {
                string yearPath = _years.Dequeue();
                _segments = await ChangeFeedExtensionsBase.GetSegmentsInYearInternal(
                    containerClient:
                    _containerClient,
                    yearPath: yearPath,
                    startTime: _startTime,
                    endTime: _endTime,
                    async: async,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                if (_segments.Count > 0)
                {
                    _currentSegment = await _segmentFactory.BuildSegment(async, _segments.Dequeue()).ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Creates an empty change feed instance that immediately reports no events available.
        /// Used when the change feed container does not exist or no segments match the time window.
        /// </summary>
        /// <returns>An empty <see cref="ChangeFeedBase{TEvent}"/>.</returns>
        public static ChangeFeedBase<TEvent> Empty() => new ChangeFeedBase<TEvent> { _empty = true };
    }
}
