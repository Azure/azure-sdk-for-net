// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.ChangeFeed.Models;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.ChangeFeed
{
    internal class Segment
    {
        /// <summary>
        /// If this Segment is finalized.
        /// </summary>
        public virtual bool Finalized { get; private set; }

        /// <summary>
        /// The time (to the nearest hour) associated with this Segment.
        /// </summary>
        public DateTimeOffset DateTime { get; private set; }

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
            bool finalized)
        {
            _shards = shards;
            _shardIndex = shardIndex;
            DateTime = dateTime;
            Finalized = finalized;
            _finishedShards = new HashSet<int>();
        }

        public virtual SegmentCursor GetCursor()
        {
            List<ShardCursor> shardCursors = new List<ShardCursor>();
            foreach (Shard shard in _shards)
            {
                shardCursors.Add(shard.GetCursor());
            }
            return new SegmentCursor(
                segmentDateTime: DateTime,
                shardCursors: shardCursors,
                shardIndex: _shardIndex);
        }

        public virtual async Task<List<BlobChangeFeedEvent>> GetPage(
            bool async,
            int? pageSize,
            CancellationToken cancellationToken = default)
        {
            List<BlobChangeFeedEvent> changeFeedEventList = new List<BlobChangeFeedEvent>();

            if (!HasNext())
            {
                throw new InvalidOperationException("Segment doesn't have any more events");
            }

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

        public virtual bool HasNext()
            => _finishedShards.Count < _shards.Count;

        /// <summary>
        /// Constructor for mocking.
        /// </summary>
        public Segment() { }
    }
}
