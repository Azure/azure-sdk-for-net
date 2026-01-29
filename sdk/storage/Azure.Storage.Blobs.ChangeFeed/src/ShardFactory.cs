// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// Builds a Shard.
    /// </summary>
    internal class ShardFactory
    {
        private readonly ChunkFactory _chunkFactory;
        private readonly BlobContainerClient _containerClient;

        public ShardFactory(
            BlobContainerClient containerClient,
            ChunkFactory chunkFactory)
        {
            _containerClient = containerClient;
            _chunkFactory = chunkFactory;
        }

        /// <summary>
        /// Constructor for mocking.
        /// </summary>
        public ShardFactory() { }

#pragma warning disable CA1822 // Does not acces instance data can be marked static.
        public virtual async Task<Shard> BuildShard(
#pragma warning restore CA1822 // Can't mock static methods in MOQ.
            bool async,
            string shardPath,
            ShardCursor shardCursor = default)
        {
            // Models we'll need later
            Queue<BlobItem> chunks = new Queue<BlobItem>();
            long blockOffset = shardCursor?.BlockOffset ?? 0;
            long eventIndex = shardCursor?.EventIndex ?? 0;

            GetBlobsByHierarchyOptions options = new GetBlobsByHierarchyOptions
            {
                Prefix = shardPath,
            };

            // Get Chunks
            if (async)
            {
                await foreach (BlobHierarchyItem blobHierarchyItem in _containerClient.GetBlobsByHierarchyAsync(
                    options: options).ConfigureAwait(false))
                {
                    if (blobHierarchyItem.IsPrefix)
                        continue;

                    //Chunk chunk = new Chunk(_containerClient, blobHierarchyItem.Blob.Name);
                    chunks.Enqueue(blobHierarchyItem.Blob);
                }
            }
            else
            {
                foreach (BlobHierarchyItem blobHierarchyItem in _containerClient.GetBlobsByHierarchy(
                    options: options))
                {
                    if (blobHierarchyItem.IsPrefix)
                        continue;

                    chunks.Enqueue(blobHierarchyItem.Blob);
                }
            }

            long chunkIndex = 0;
            string currentChunkPath = shardCursor?.CurrentChunkPath;
            Chunk currentChunk = null;
            if (chunks.Count > 0) // Chunks can be empty right after hour flips.
            {
                // Fast forward to current Chunk
                if (!string.IsNullOrWhiteSpace(currentChunkPath))
                {
                    while (chunks.Count > 0)
                    {
                        if (chunks.Peek().Name == currentChunkPath)
                        {
                            break;
                        }
                        else
                        {
                            chunks.Dequeue();
                            chunkIndex++;
                        }
                    }
                    if (chunks.Count == 0)
                    {
                        throw new ArgumentException($"Chunk {currentChunkPath} not found.");
                    }
                }

                BlobItem currentChunkBlobItem = chunks.Dequeue();
                if (currentChunkBlobItem.Properties.ContentLength > blockOffset)
                {
                    // There are more events to read from current chunk.
                    currentChunk = await _chunkFactory.BuildChunk(
                        async,
                        currentChunkBlobItem.Name,
                        blockOffset,
                        eventIndex).ConfigureAwait(false);
                }
                else if (currentChunkBlobItem.Properties.ContentLength < blockOffset)
                {
                    // This shouldn't happen under normal circumstances, i.e. we couldn't read past the end of chunk.
                    throw new ArgumentException($"Cursor contains a blockOffset that is invalid. BlockOffset={blockOffset}");
                }
                else
                {
                    // Otherwise we ended at the end of the chunk and no events has been written since then. Check if new chunk was created in case of current chunk overflow.
                    if (chunks.Count > 0)
                    {
                        currentChunk = await _chunkFactory.BuildChunk(
                        async,
                        chunks.Dequeue().Name).ConfigureAwait(false);
                    }
                }
            }

            return new Shard(
                _containerClient,
                _chunkFactory,
                chunks,
                currentChunk,
                chunkIndex,
                shardPath);
        }
    }
}
