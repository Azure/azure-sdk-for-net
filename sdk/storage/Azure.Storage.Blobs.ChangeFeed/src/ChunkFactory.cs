// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Azure.Storage.Internal.Avro;

namespace Azure.Storage.Blobs.ChangeFeed
{
    internal class ChunkFactory
    {
        private readonly LazyLoadingBlobStreamFactory _lazyLoadingBlobStreamFactory;
        private readonly AvroReaderFactory _avroReaderFactory;
        private readonly BlobContainerClient _containerClient;

        public ChunkFactory(
            BlobContainerClient containerClient,
            LazyLoadingBlobStreamFactory lazyLoadingBlobStreamFactory,
            AvroReaderFactory avroReaderFactory)
        {
            _containerClient = containerClient;
            _lazyLoadingBlobStreamFactory = lazyLoadingBlobStreamFactory;
            _avroReaderFactory = avroReaderFactory;
        }

        internal virtual Chunk BuildChunk(
            string chunkPath,
            long blockOffset = 0,
            long eventIndex = 0)
        {
            BlobClient blobClient = _containerClient.GetBlobClient(chunkPath);
            AvroReader avroReader;

            Stream dataStream = _lazyLoadingBlobStreamFactory.BuildLazyLoadingBlobStream(
                blobClient,
                offset: blockOffset,
                blockSize: Constants.ChangeFeed.ChunkBlockDownloadSize);

            // We aren't starting from the beginning of the Chunk
            if (blockOffset != 0)
            {
                Stream headStream = _lazyLoadingBlobStreamFactory.BuildLazyLoadingBlobStream(
                blobClient,
                offset: 0,
                blockSize: Constants.ChangeFeed.LazyLoadingBlobStreamBlockSize);

                avroReader = _avroReaderFactory.BuildAvroReader(
                    dataStream,
                    headStream,
                    blockOffset,
                    eventIndex);
            }
            else
            {
                avroReader = _avroReaderFactory.BuildAvroReader(dataStream);
            }

            return new Chunk(
                avroReader,
                blockOffset,
                eventIndex);
        }

        /// <summary>
        /// Constructor for mocking.
        /// </summary>
        public ChunkFactory() { }
    }
}
