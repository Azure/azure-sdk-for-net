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
    /// <summary>
    /// Represents a single shard within a change feed segment. A shard contains an ordered sequence of
    /// chunk (Avro) files that are read sequentially, automatically advancing to the next chunk when
    /// the current one is exhausted.
    /// </summary>
    internal class ShardBase<TEvent>
    {
        private readonly BlobContainerClient _containerClient;
        private readonly ChunkFactoryBase<TEvent> _chunkFactory;
        private readonly Queue<BlobItem> _chunks;
        private ChunkBase<TEvent> _currentChunk;
        private long _chunkIndex;

        /// <summary>
        /// Blob prefix path of this shard directory.
        /// </summary>
        public virtual string ShardPath { get; }

        /// <summary>
        /// Builds a cursor that captures the current read position within this shard.
        /// </summary>
        /// <returns>A <see cref="ShardCursor"/>, or null if no chunk is currently loaded.</returns>
        public virtual ShardCursor GetCursor()
            => _currentChunk == null ? null : new ShardCursor(_currentChunk.ChunkPath, _currentChunk.BlockOffset, _currentChunk.EventIndex);

        /// <summary>
        /// Returns true if there are more events in the current chunk or additional chunks remaining.
        /// </summary>
        public virtual bool HasNext()
            => _chunks.Count > 0 || (_currentChunk != null && _currentChunk.HasNext());

        /// <summary>
        /// Reads the next event from this shard, advancing to the next chunk if the current one is exhausted.
        /// </summary>
        /// <returns>The next typed change feed event.</returns>
        public virtual async Task<TEvent> Next(bool async, CancellationToken cancellationToken = default)
        {
            if (!HasNext()) throw new InvalidOperationException("Shard doesn't have any more events");
            TEvent changeFeedEvent = await _currentChunk.Next(async, cancellationToken).ConfigureAwait(false);
            // After reading, check if current chunk is exhausted; if so, advance to the next chunk in the queue.
            if (!_currentChunk.HasNext() && _chunks.Count > 0)
            {
                _currentChunk = await _chunkFactory.BuildChunk(async, _chunks.Dequeue().Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                _chunkIndex++;
            }
            return changeFeedEvent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShardBase{TEvent}"/> class.
        /// </summary>
        /// <param name="containerClient">Container client for the change feed container.</param>
        /// <param name="chunkFactory">Factory used to build new chunk readers as the shard advances.</param>
        /// <param name="chunks">Queue of remaining chunk blobs to process after the current one.</param>
        /// <param name="currentChunk">The chunk currently being read.</param>
        /// <param name="chunkIndex">Index of the current chunk within the shard.</param>
        /// <param name="shardPath">Blob prefix path of this shard.</param>
        public ShardBase(BlobContainerClient containerClient, ChunkFactoryBase<TEvent> chunkFactory, Queue<BlobItem> chunks, ChunkBase<TEvent> currentChunk, long chunkIndex, string shardPath)
        {
            _containerClient = containerClient;
            _chunkFactory = chunkFactory;
            _chunks = chunks;
            _currentChunk = currentChunk;
            _chunkIndex = chunkIndex;
            ShardPath = shardPath;
        }

        /// <summary>
        /// Constructor for mocking. Do not use directly.
        /// </summary>
        internal ShardBase() { }
    }
}
