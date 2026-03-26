// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.ChangeFeed.Common
{
    /// <summary>
    /// Factory that creates <see cref="ShardBase{TEvent}"/> instances by enumerating chunk blobs
    /// and optionally fast-forwarding to a cursor position.
    /// </summary>
    internal class ShardFactoryBase<TEvent>
    {
        private readonly ChunkFactoryBase<TEvent> _chunkFactory;
        private readonly BlobContainerClient _containerClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShardFactoryBase{TEvent}"/> class.
        /// </summary>
        /// <param name="containerClient">Container client for the change feed container.</param>
        /// <param name="chunkFactory">Factory used to build chunk readers.</param>
        public ShardFactoryBase(BlobContainerClient containerClient, ChunkFactoryBase<TEvent> chunkFactory)
        {
            _containerClient = containerClient;
            _chunkFactory = chunkFactory;
        }

        /// <summary>
        /// Constructor for mocking. Do not use directly.
        /// </summary>
        public ShardFactoryBase() { }

        /// <summary>
        /// Builds a shard by listing all chunk blobs under the shard path and positioning to the
        /// cursor offset if one is provided.
        /// </summary>
        /// <param name="async">Whether to use async APIs.</param>
        /// <param name="shardPath">Blob prefix of the shard directory.</param>
        /// <param name="shardCursor">Optional cursor to resume from a previous position.</param>
        /// <returns>A new <see cref="ShardBase{TEvent}"/> ready to read events.</returns>
#pragma warning disable CA1822
        public virtual async Task<ShardBase<TEvent>> BuildShard(bool async, string shardPath, ShardCursor shardCursor = default)
#pragma warning restore CA1822
        {
            Queue<BlobItem> chunks = new Queue<BlobItem>();
            long blockOffset = shardCursor?.BlockOffset ?? 0;
            long eventIndex = shardCursor?.EventIndex ?? 0;
            GetBlobsByHierarchyOptions options = new GetBlobsByHierarchyOptions { Prefix = shardPath };

            if (async)
            {
                await foreach (BlobHierarchyItem item in _containerClient.GetBlobsByHierarchyAsync(options: options).ConfigureAwait(false))
                {
                    if (item.IsPrefix) continue;
                    chunks.Enqueue(item.Blob);
                }
            }
            else
            {
                foreach (BlobHierarchyItem item in _containerClient.GetBlobsByHierarchy(options: options))
                {
                    if (item.IsPrefix) continue;
                    chunks.Enqueue(item.Blob);
                }
            }

            long chunkIndex = 0;
            string currentChunkPath = shardCursor?.CurrentChunkPath;
            ChunkBase<TEvent> currentChunk = null;
            if (chunks.Count > 0)
            {
                // Fast-forward past chunks that precede the cursor's current chunk path.
                if (!string.IsNullOrWhiteSpace(currentChunkPath))
                {
                    while (chunks.Count > 0)
                    {
                        if (chunks.Peek().Name == currentChunkPath) break;
                        chunks.Dequeue();
                        chunkIndex++;
                    }
                    if (chunks.Count == 0) throw new ArgumentException($"Chunk {currentChunkPath} not found.");
                }

                BlobItem currentChunkBlobItem = chunks.Dequeue();
                if (currentChunkBlobItem.Properties.ContentLength > blockOffset)
                {
                    currentChunk = await _chunkFactory.BuildChunk(async, currentChunkBlobItem.Name, blockOffset, eventIndex).ConfigureAwait(false);
                }
                else if (currentChunkBlobItem.Properties.ContentLength < blockOffset)
                {
                    throw new ArgumentException($"Cursor contains a blockOffset that is invalid. BlockOffset={blockOffset}");
                }
                else
                {
                    if (chunks.Count > 0)
                    {
                        currentChunk = await _chunkFactory.BuildChunk(async, chunks.Dequeue().Name).ConfigureAwait(false);
                    }
                }
            }

            return new ShardBase<TEvent>(_containerClient, _chunkFactory, chunks, currentChunk, chunkIndex, shardPath);
        }
    }
}
