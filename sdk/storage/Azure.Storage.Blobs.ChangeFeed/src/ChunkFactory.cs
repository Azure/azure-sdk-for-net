// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.ChangeFeed
{
    internal class ChunkFactory
    {
        private readonly LazyLoadingBlobStreamFactory _lazyLoadingBlobStreamFactory;
        private readonly AvroReaderFactory _avroReaderFactory;

        public ChunkFactory(
            LazyLoadingBlobStreamFactory lazyLoadingBlobStreamFactory,
            AvroReaderFactory avroReaderFactory)
        {
            _lazyLoadingBlobStreamFactory = lazyLoadingBlobStreamFactory;
            _avroReaderFactory = avroReaderFactory;
        }

        public virtual Chunk BuildChunk(
            BlobContainerClient containerClient,
            string chunkPath,
            long? blockOffset = default,
            long? eventIndex = default)
            => new Chunk(
                containerClient,
                _lazyLoadingBlobStreamFactory,
                _avroReaderFactory,
                chunkPath,
                blockOffset,
                eventIndex);

        /// <summary>
        /// Constructor for mocking.
        /// </summary>
        public ChunkFactory() { }
    }
}
