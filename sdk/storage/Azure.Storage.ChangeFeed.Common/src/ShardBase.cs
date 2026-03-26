// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.ChangeFeed.Common
{
    internal class ShardBase<TEvent>
    {
        private readonly BlobContainerClient _containerClient;
        private readonly ChunkFactoryBase<TEvent> _chunkFactory;
        private readonly Queue<BlobItem> _chunks;
        private ChunkBase<TEvent> _currentChunk;
        private long _chunkIndex;

        public virtual string ShardPath { get; }

        public virtual ShardCursor GetCursor()
            => _currentChunk == null ? null : new ShardCursor(_currentChunk.ChunkPath, _currentChunk.BlockOffset, _currentChunk.EventIndex);

        public virtual bool HasNext()
            => _chunks.Count > 0 || (_currentChunk != null && _currentChunk.HasNext());

        public virtual async Task<TEvent> Next(bool async, CancellationToken cancellationToken = default)
        {
            if (!HasNext()) throw new InvalidOperationException("Shard doesn't have any more events");
            TEvent changeFeedEvent = await _currentChunk.Next(async, cancellationToken).ConfigureAwait(false);
            if (!_currentChunk.HasNext() && _chunks.Count > 0)
            {
                _currentChunk = await _chunkFactory.BuildChunk(async, _chunks.Dequeue().Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                _chunkIndex++;
            }
            return changeFeedEvent;
        }

        public ShardBase(BlobContainerClient containerClient, ChunkFactoryBase<TEvent> chunkFactory, Queue<BlobItem> chunks, ChunkBase<TEvent> currentChunk, long chunkIndex, string shardPath)
        {
            _containerClient = containerClient;
            _chunkFactory = chunkFactory;
            _chunks = chunks;
            _currentChunk = currentChunk;
            _chunkIndex = chunkIndex;
            ShardPath = shardPath;
        }

        internal ShardBase() { }
    }
}
