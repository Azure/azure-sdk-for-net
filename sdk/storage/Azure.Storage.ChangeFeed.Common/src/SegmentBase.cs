// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.ChangeFeed.Common
{
    /// <summary>
    /// Represents a single time-window segment of the change feed. A segment contains multiple shards
    /// that are read in round-robin order to distribute events evenly across pages.
    /// </summary>
    internal class SegmentBase<TEvent> where TEvent : IChangeFeedEvent
    {
        /// <summary>
        /// The timestamp that this segment covers.
        /// </summary>
        public DateTimeOffset DateTime { get; private set; }

        /// <summary>
        /// Blob path of the segment manifest JSON file.
        /// </summary>
        public string ManifestPath { get; private set; }

        private readonly List<ShardBase<TEvent>> _shards;
        private readonly HashSet<int> _finishedShards;
        private int _shardIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentBase{TEvent}"/> class.
        /// </summary>
        /// <param name="shards">The list of shards in this segment.</param>
        /// <param name="shardIndex">The shard index to start reading from (used when resuming).</param>
        /// <param name="dateTime">The timestamp of this segment.</param>
        /// <param name="manifestPath">Blob path of the segment manifest.</param>
        public SegmentBase(List<ShardBase<TEvent>> shards, int shardIndex, DateTimeOffset dateTime, string manifestPath)
        {
            _shards = shards;
            _shardIndex = shardIndex;
            DateTime = dateTime;
            ManifestPath = manifestPath;
            _finishedShards = new HashSet<int>();
        }

        /// <summary>
        /// Builds a cursor capturing the current read position across all shards in this segment.
        /// </summary>
        /// <returns>A <see cref="SegmentCursor"/> for this segment.</returns>
        public virtual SegmentCursor GetCursor()
        {
            List<ShardCursor> shardCursors = new List<ShardCursor>();
            foreach (ShardBase<TEvent> shard in _shards)
            {
                ShardCursor shardCursor = shard.GetCursor();
                if (shardCursor != null) shardCursors.Add(shard.GetCursor());
            }
            return new SegmentCursor(
                segmentPath: ManifestPath,
                shardCursors: shardCursors,
                currentShardPath: _shards.Count > 0 ? _shards[_shardIndex].ShardPath : null);
        }

        /// <summary>
        /// Reads up to <paramref name="pageSize"/> events from this segment's shards.
        /// </summary>
        /// <param name="async">Whether to use async APIs.</param>
        /// <param name="pageSize">Maximum number of events to return.</param>
        /// <param name="startTime">Optional inclusive start time for event-level filtering.</param>
        /// <param name="endTime">Optional exclusive end time for event-level filtering.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A list of events read from the segment's shards.</returns>
        public virtual async Task<List<TEvent>> GetPage(
            bool async,
            int? pageSize,
            DateTimeOffset? startTime,
            DateTimeOffset? endTime,
            CancellationToken cancellationToken = default)
        {
            List<TEvent> changeFeedEventList = new List<TEvent>();
            if (!HasNext()) return new List<TEvent>(capacity: 0);

            int i = 0;
            // Round-robin across shards: read one event per shard, then advance to the next shard,
            // wrapping around to index 0 after the last shard, skipping any that are exhausted.
            while (i < pageSize && _shards.Count > 0)
            {
                if (_finishedShards.Contains(_shardIndex))
                {
                    _shardIndex++;
                    if (_shardIndex == _shards.Count) _shardIndex = 0;
                    continue;
                }

                ShardBase<TEvent> currentShard = _shards[_shardIndex];
                TEvent changeFeedEvent = await currentShard.Next(async, cancellationToken).ConfigureAwait(false);

                if (!currentShard.HasNext()) _finishedShards.Add(_shardIndex);

                _shardIndex++;
                if (_shardIndex >= _shards.Count) _shardIndex = 0;

                // Filter by event time — skip events outside the requested window.
                if (startTime.HasValue && changeFeedEvent.EventTime < startTime.Value)
                {
                    if (_finishedShards.Count == _shards.Count) break;
                    continue;
                }
                if (endTime.HasValue && changeFeedEvent.EventTime >= endTime.Value)
                {
                    if (_finishedShards.Count == _shards.Count) break;
                    continue;
                }

                changeFeedEventList.Add(changeFeedEvent);
                i++;
                if (_finishedShards.Count == _shards.Count) break;
            }
            return changeFeedEventList;
        }

        /// <summary>
        /// Returns true if any shard in this segment still has unread events.
        /// </summary>
        public virtual bool HasNext() => _finishedShards.Count < _shards.Count;

        /// <summary>
        /// Constructor for mocking. Do not use directly.
        /// </summary>
        public SegmentBase() { }
    }
}
