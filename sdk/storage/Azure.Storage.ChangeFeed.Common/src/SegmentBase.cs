// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.ChangeFeed.Common
{
    internal class SegmentBase<TEvent>
    {
        public DateTimeOffset DateTime { get; private set; }
        public string ManifestPath { get; private set; }
        private readonly List<ShardBase<TEvent>> _shards;
        private readonly HashSet<int> _finishedShards;
        private int _shardIndex;

        public SegmentBase(List<ShardBase<TEvent>> shards, int shardIndex, DateTimeOffset dateTime, string manifestPath)
        {
            _shards = shards;
            _shardIndex = shardIndex;
            DateTime = dateTime;
            ManifestPath = manifestPath;
            _finishedShards = new HashSet<int>();
        }

        public virtual SegmentCursor GetCursor()
        {
            List<ShardCursor> shardCursors = new List<ShardCursor>();
            foreach (ShardBase<TEvent> shard in _shards)
            {
                var shardCursor = shard.GetCursor();
                if (shardCursor != null) shardCursors.Add(shard.GetCursor());
            }
            return new SegmentCursor(
                segmentPath: ManifestPath,
                shardCursors: shardCursors,
                currentShardPath: _shards.Count > 0 ? _shards[_shardIndex].ShardPath : null);
        }

        public virtual async Task<List<TEvent>> GetPage(bool async, int? pageSize, CancellationToken cancellationToken = default)
        {
            List<TEvent> changeFeedEventList = new List<TEvent>();
            if (!HasNext()) return new List<TEvent>(capacity: 0);

            int i = 0;
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
                changeFeedEventList.Add(changeFeedEvent);

                if (!currentShard.HasNext()) _finishedShards.Add(_shardIndex);

                i++;
                _shardIndex++;
                if (_shardIndex >= _shards.Count) _shardIndex = 0;
                if (_finishedShards.Count == _shards.Count) break;
            }
            return changeFeedEventList;
        }

        public virtual bool HasNext() => _finishedShards.Count < _shards.Count;

        public SegmentBase() { }
    }
}
