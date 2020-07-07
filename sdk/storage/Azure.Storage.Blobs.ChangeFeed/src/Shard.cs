// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.ChangeFeed.Models;
using System.Threading;

namespace Azure.Storage.Blobs.ChangeFeed
{
    internal class Shard
    {
        /// <summary>
        /// Container Client for listing Chunks.
        /// </summary>
        private readonly BlobContainerClient _containerClient;

        /// <summary>
        /// ChunkFactory.
        /// </summary>
        private readonly ChunkFactory _chunkFactory;

        /// <summary>
        /// Queue of the paths to Chunks we haven't processed.
        /// </summary>
        private readonly Queue<string> _chunks;

        /// <summary>
        /// The Chunk we are currently processing.
        /// </summary>
        private Chunk _currentChunk;

        /// <summary>
        /// The index of the Chunk we are processing.
        /// </summary>
        private long _chunkIndex;

        /// <summary>
        /// Gets the <see cref="ShardCursor"/> for this Shard.
        /// </summary>
        public virtual ShardCursor GetCursor()
            => new ShardCursor(
                _chunkIndex,
                _currentChunk.BlockOffset,
                _currentChunk.EventIndex);

        /// <summary>
        /// If this Shard has a next event.
        /// </summary>
        public virtual bool HasNext()
            => _chunks.Count > 0 || _currentChunk.HasNext();

        /// <summary>
        /// Gets the next <see cref="BlobChangeFeedEvent"/>.
        /// </summary>
        public virtual async Task<BlobChangeFeedEvent> Next(
            bool async,
            CancellationToken cancellationToken = default)
        {
            if (!HasNext())
            {
                throw new InvalidOperationException("Shard doesn't have any more events");
            }

            BlobChangeFeedEvent changeFeedEvent;

            changeFeedEvent = await _currentChunk.Next(async, cancellationToken).ConfigureAwait(false);

            // Remove currentChunk if it doesn't have another event.
            if (!_currentChunk.HasNext() && _chunks.Count > 0)
            {
                _currentChunk = _chunkFactory.BuildChunk(
                    _chunks.Dequeue());
                _chunkIndex++;
            }
            return changeFeedEvent;
        }

        /// <summary>
        /// Constructor for use by <see cref="ShardFactory.BuildShard(bool, string, ShardCursor)"/>.
        /// </summary>
        public Shard(
            BlobContainerClient containerClient,
            ChunkFactory chunkFactory,
            Queue<string> chunks,
            Chunk currentChunk,
            long chunkIndex)
        {
            _containerClient = containerClient;
            _chunkFactory = chunkFactory;
            _chunks = chunks;
            _currentChunk = currentChunk;
            _chunkIndex = chunkIndex;
        }

        /// <summary>
        /// Constructor for mocking.
        /// </summary>
        internal Shard() { }
    }
}
