// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs.ChangeFeed.Models;
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
            Queue<string> chunks = new Queue<string>();
            long chunkIndex = shardCursor?.ChunkIndex ?? 0;
            long blockOffset = shardCursor?.BlockOffset ?? 0;
            long eventIndex = shardCursor?.EventIndex ?? 0;

            // Get Chunks
            if (async)
            {
                await foreach (BlobHierarchyItem blobHierarchyItem in _containerClient.GetBlobsByHierarchyAsync(
                    prefix: shardPath).ConfigureAwait(false))
                {
                    if (blobHierarchyItem.IsPrefix)
                        continue;

                    //Chunk chunk = new Chunk(_containerClient, blobHierarchyItem.Blob.Name);
                    chunks.Enqueue(blobHierarchyItem.Blob.Name);
                }
            }
            else
            {
                foreach (BlobHierarchyItem blobHierarchyItem in _containerClient.GetBlobsByHierarchy(
                    prefix: shardPath))
                {
                    if (blobHierarchyItem.IsPrefix)
                        continue;

                    //Chunk chunk = new Chunk(_containerClient, blobHierarchyItem.Blob.Name);
                    chunks.Enqueue(blobHierarchyItem.Blob.Name);
                }
            }

            // Fast forward to current Chunk
            if (chunkIndex > 0)
            {
                for (int i = 0; i < chunkIndex; i++)
                {
                    chunks.Dequeue();
                }
            }

            Chunk currentChunk = _chunkFactory.BuildChunk(
                chunks.Dequeue(),
                blockOffset,
                eventIndex);

            return new Shard(
                _containerClient,
                _chunkFactory,
                chunks,
                currentChunk,
                chunkIndex);
        }
    }
}
