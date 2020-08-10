// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using System.Threading;

namespace Azure.Storage.Blobs.ChangeFeed
{
    internal class ChangeFeed
    {
        /// <summary>
        /// BlobContainerClient for making List Blob requests and creating Segments.
        /// </summary>
        private readonly BlobContainerClient _containerClient;

        /// <summary>
        /// A <see cref="SegmentFactory"/> for creating new <see cref="Segment"/>s.
        /// </summary>
        private readonly SegmentFactory _segmentFactory;

        /// <summary>
        /// Queue of paths to years we haven't processed yet.
        /// </summary>
        private readonly Queue<string> _years;

        /// <summary>
        /// Paths to segments in the current year we haven't processed yet.
        /// </summary>
        private Queue<string> _segments;

        /// <summary>
        /// The Segment we are currently processing.
        /// </summary>
        private Segment _currentSegment;

        /// <summary>
        /// The latest time the Change Feed can safely be read from.
        /// </summary>
        public DateTimeOffset LastConsumable { get; private set; }

        /// <summary>
        /// User-specified start time.  If the start time occurs before Change Feed was enabled
        /// for this account, we will start at the beginning of the Change Feed.
        /// </summary>
        private DateTimeOffset? _startTime;

        /// <summary>
        /// User-specified end time.  If the end time occurs after _lastConsumable, we will
        /// end at _lastConsumable.
        /// </summary>
        private DateTimeOffset? _endTime;

        /// <summary>
        /// If this Change Feed has no events.
        /// </summary>
        private bool _empty;

        public ChangeFeed(
            BlobContainerClient containerClient,
            SegmentFactory segmentFactory,
            Queue<string> years,
            Queue<string> segments,
            Segment currentSegment,
            DateTimeOffset lastConsumable,
            DateTimeOffset? startTime,
            DateTimeOffset? endTime)
        {
            _containerClient = containerClient;
            _segmentFactory = segmentFactory;
            _years = years;
            _segments = segments;
            _currentSegment = currentSegment;
            LastConsumable = lastConsumable;
            _startTime = startTime;
            _endTime = endTime;
            _empty = false;
        }

        /// <summary>
        /// Constructor for mocking, and for creating a Change Feed with no Events.
        /// </summary>
        public ChangeFeed() { }

        // The last segment may still be adding chunks.
        public async Task<Page<BlobChangeFeedEvent>> GetPage(
            bool async,
            int pageSize = Constants.ChangeFeed.DefaultPageSize,
            CancellationToken cancellationToken = default)
        {
            if (!HasNext())
            {
                throw new InvalidOperationException("Change feed doesn't have any more events");
            }

            if (_currentSegment.DateTime >= _endTime)
            {
                return BlobChangeFeedEventPage.Empty();
            }

            if (pageSize > Constants.ChangeFeed.DefaultPageSize)
            {
                pageSize = Constants.ChangeFeed.DefaultPageSize;
            }

            // Get next page
            List<BlobChangeFeedEvent> blobChangeFeedEvents = new List<BlobChangeFeedEvent>();

            int remainingEvents = pageSize;
            while (blobChangeFeedEvents.Count < pageSize
                && HasNext())
            {
                List<BlobChangeFeedEvent> newEvents = await _currentSegment.GetPage(
                    async,
                    remainingEvents,
                    cancellationToken).ConfigureAwait(false);
                blobChangeFeedEvents.AddRange(newEvents);
                remainingEvents -= newEvents.Count;
                await AdvanceSegmentIfNecessary(
                    async,
                    cancellationToken).ConfigureAwait(false);
            }

            return new BlobChangeFeedEventPage(blobChangeFeedEvents, JsonSerializer.Serialize<ChangeFeedCursor>(GetCursor()));
        }

        public bool HasNext()
        {
            // [If Change Feed is empty], or [current segment is not finalized]
            // or ([segment count is 0] and [year count is 0] and [current segment doesn't have next])
            if (_empty
                || _segments.Count == 0
                    && _years.Count == 0
                    && !_currentSegment.HasNext())
            {
                return false;
            }

            if (_endTime.HasValue)
            {
                return _currentSegment.DateTime < _endTime;
            }

            return true;
        }

        internal ChangeFeedCursor GetCursor()
            => new ChangeFeedCursor(
                urlHash: BlobChangeFeedExtensions.ComputeMD5(_containerClient.Uri.AbsoluteUri),
                endDateTime: _endTime,
                currentSegmentCursor: _currentSegment.GetCursor());

        private async Task AdvanceSegmentIfNecessary(
            bool async,
            CancellationToken cancellationToken)
        {
            // If the current segment has more Events, we don't need to do anything.
            if (_currentSegment.HasNext())
            {
                return;
            }

            // If the current segment is completed, remove it
            if (_segments.Count > 0)
            {
                _currentSegment = await _segmentFactory.BuildSegment(
                    async,
                    _segments.Dequeue()).ConfigureAwait(false);
            }

            // If _segments is empty, refill it
            else if (_segments.Count == 0 && _years.Count > 0)
            {
                string yearPath = _years.Dequeue();

                // Get Segments for first year
                _segments = await BlobChangeFeedExtensions.GetSegmentsInYearInternal(
                    containerClient: _containerClient,
                    yearPath: yearPath,
                    startTime: _startTime,
                    endTime: _endTime,
                    async: async,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                if (_segments.Count > 0)
                {
                    _currentSegment = await _segmentFactory.BuildSegment(
                        async,
                        _segments.Dequeue())
                        .ConfigureAwait(false);
                }
            }
        }

        public static ChangeFeed Empty()
             => new ChangeFeed
             {
                 _empty = true
             };
    }
}
