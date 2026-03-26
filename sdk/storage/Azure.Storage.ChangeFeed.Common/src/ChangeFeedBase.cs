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
    internal class ChangeFeedBase<TEvent>
    {
        private readonly BlobContainerClient _containerClient;
        private readonly SegmentFactoryBase<TEvent> _segmentFactory;
        private readonly Queue<string> _years;
        private Queue<string> _segments;
        private SegmentBase<TEvent> _currentSegment;
        private readonly ChangeFeedConfiguration<TEvent> _config;
        public DateTimeOffset LastConsumable { get; private set; }
        private DateTimeOffset? _startTime;
        private DateTimeOffset? _endTime;
        private bool _empty;

        public ChangeFeedBase(BlobContainerClient containerClient, SegmentFactoryBase<TEvent> segmentFactory, Queue<string> years, Queue<string> segments, SegmentBase<TEvent> currentSegment, DateTimeOffset lastConsumable, DateTimeOffset? startTime, DateTimeOffset? endTime, ChangeFeedConfiguration<TEvent> config)
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
            _empty = false;
        }

        public ChangeFeedBase() { }

        public async Task<Page<TEvent>> GetPage(bool async, int pageSize, CancellationToken cancellationToken = default)
        {
            if (!HasNext()) throw new InvalidOperationException("Change feed doesn't have any more events");
            if (_currentSegment.DateTime >= _endTime) return ChangeFeedEventPageBase<TEvent>.Empty();

            int defaultPageSize = _config?.DefaultPageSize ?? 5000;
            if (pageSize > defaultPageSize) pageSize = defaultPageSize;

            List<TEvent> events = new List<TEvent>();
            int remainingEvents = pageSize;
            while (events.Count < pageSize && HasNext())
            {
                List<TEvent> newEvents = await _currentSegment.GetPage(async, remainingEvents, cancellationToken).ConfigureAwait(false);
                events.AddRange(newEvents);
                remainingEvents -= newEvents.Count;
                await AdvanceSegmentIfNecessary(async, cancellationToken).ConfigureAwait(false);
            }

            return new ChangeFeedEventPageBase<TEvent>(events, JsonSerializer.Serialize<ChangeFeedCursor>(GetCursor()));
        }

        public bool HasNext()
        {
            if (_empty || _segments.Count == 0 && _years.Count == 0 && !_currentSegment.HasNext()) return false;
            if (_endTime.HasValue) return _currentSegment.DateTime < _endTime;
            return true;
        }

        internal ChangeFeedCursor GetCursor()
            => new ChangeFeedCursor(
                urlHost: _containerClient.Uri.Host,
                endDateTime: _endTime,
                currentSegmentCursor: _currentSegment.GetCursor());

        private async Task AdvanceSegmentIfNecessary(bool async, CancellationToken cancellationToken)
        {
            if (_currentSegment.HasNext()) return;

            if (_segments.Count > 0)
            {
                _currentSegment = await _segmentFactory.BuildSegment(async, _segments.Dequeue()).ConfigureAwait(false);
            }
            else if (_segments.Count == 0 && _years.Count > 0)
            {
                string yearPath = _years.Dequeue();
                _segments = await ChangeFeedExtensionsBase.GetSegmentsInYearInternal(
                    containerClient: _containerClient, yearPath: yearPath, startTime: _startTime, endTime: _endTime, async: async, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (_segments.Count > 0)
                {
                    _currentSegment = await _segmentFactory.BuildSegment(async, _segments.Dequeue()).ConfigureAwait(false);
                }
            }
        }

        public static ChangeFeedBase<TEvent> Empty() => new ChangeFeedBase<TEvent> { _empty = true };
    }
}
