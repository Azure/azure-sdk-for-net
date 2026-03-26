// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.ChangeFeed.Common
{
    internal class ShardFactoryBase<TEvent>
    {
        private readonly ChunkFactoryBase<TEvent> _chunkFactory;
        private readonly BlobContainerClient _containerClient;

        public ShardFactoryBase(BlobContainerClient containerClient, ChunkFactoryBase<TEvent> chunkFactory)
        {
            _containerClient = containerClient;
            _chunkFactory = chunkFactory;
        }

        public ShardFactoryBase() { }

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
