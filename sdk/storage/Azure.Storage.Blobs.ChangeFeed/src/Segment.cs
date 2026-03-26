// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// Represents a single hourly segment of the Change Feed, containing one or more Shards.
    /// </summary>
    internal class Segment
    {
        /// <summary>
        /// The time (to the nearest hour) associated with this Segment.
        /// </summary>
        public virtual DateTimeOffset DateTime { get; private set; }

        /// <summary>
        /// The path of manifest associated with this Segment.
        /// </summary>
        public virtual string ManifestPath { get; private set; }

        /// <summary>
        /// The Shards associated with this Segment.
        /// </summary>
        private readonly List<Shard> _shards;

        /// <summary>
        /// The Shards we have finished reading from.
        /// </summary>
        private readonly HashSet<int> _finishedShards;

        /// <summary>
        /// The index of the Shard we will return the next event from.
        /// </summary>
        private int _shardIndex;

        public Segment(
            List<Shard> shards,
            int shardIndex,
            DateTimeOffset dateTime,
            string manifestPath)
        {
            _shards = shards;
            _shardIndex = shardIndex;
            DateTime = dateTime;
            ManifestPath = manifestPath;
            _finishedShards = new HashSet<int>();
        }

        /// <summary>
        /// Gets the <see cref="SegmentCursor"/> representing the current position within this Segment.
        /// </summary>
        public virtual SegmentCursor GetCursor()
        {
            List<ShardCursor> shardCursors = new List<ShardCursor>();
            foreach (Shard shard in _shards)
            {
                var shardCursor = shard.GetCursor();
                if (shardCursor != null)
                {
                    shardCursors.Add(shard.GetCursor());
                }
            }
            return new SegmentCursor(
                segmentPath: ManifestPath,
                shardCursors: shardCursors,
                currentShardPath: _shards.Count > 0 ? _shards[_shardIndex].ShardPath : null);
        }

        /// <summary>
        /// Gets the next batch of events by round-robining across shards, up to <paramref name="pageSize"/> events.
        /// </summary>
        public virtual async Task<List<BlobChangeFeedEvent>> GetPage(
            bool async,
            int? pageSize,
            CancellationToken cancellationToken = default)
        {
            List<BlobChangeFeedEvent> changeFeedEventList = new List<BlobChangeFeedEvent>();

            if (!HasNext())
            {
                return new List<BlobChangeFeedEvent>(capacity: 0);
            }

            // Round-robin across shards: read one event per shard, wrap around, skip finished shards.
            int i = 0;
            while (i < pageSize && _shards.Count > 0)
            {
                // If this Shard is finished, skip it.
                if (_finishedShards.Contains(_shardIndex))
                {
                    _shardIndex++;

                    if (_shardIndex == _shards.Count)
                    {
                        _shardIndex = 0;
                    }

                    continue;
                }

                Shard currentShard = _shards[_shardIndex];

                BlobChangeFeedEvent changeFeedEvent = await currentShard.Next(async, cancellationToken).ConfigureAwait(false);

                changeFeedEventList.Add(changeFeedEvent);

                // If the current shard is completed, remove it from _shards
                if (!currentShard.HasNext())
                {
                    _finishedShards.Add(_shardIndex);
                }

                i++;
                _shardIndex++;
                if (_shardIndex >= _shards.Count)
                {
                    _shardIndex = 0;
                }

                // If all the Shards are finished, we need to break out early.
                if (_finishedShards.Count == _shards.Count)
                {
                    break;
                }
            }

            return changeFeedEventList;
        }

        /// <summary>
        /// Returns true if this Segment has more events to return.
        /// </summary>
        public virtual bool HasNext()
            => _finishedShards.Count < _shards.Count;

        /// <summary>
        /// Constructor for mocking.
        /// </summary>
        public Segment() { }
    }
}
