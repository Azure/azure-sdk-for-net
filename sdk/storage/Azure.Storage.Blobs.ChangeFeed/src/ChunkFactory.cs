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

        public virtual Chunk BuildChunk(
            string chunkPath,
            long? blockOffset = default,
            long? eventIndex = default)
        {
            BlobClient blobClient = _containerClient.GetBlobClient(chunkPath);
            blockOffset ??= 0;
            eventIndex ??= 0;
            AvroReader avroReader;

            Stream dataStream = _lazyLoadingBlobStreamFactory.BuildLazyLoadingBlobStream(
                blobClient,
                offset: blockOffset.Value,
                blockSize: Constants.ChangeFeed.ChunkBlockDownloadSize);

            // We aren't starting from the beginning of the Chunk
            if (blockOffset != 0)
            {
                Stream headStream = _lazyLoadingBlobStreamFactory.BuildLazyLoadingBlobStream(
                blobClient,
                offset: 0,
                blockSize: 3 * Constants.KB);

                avroReader = _avroReaderFactory.BuildAvroReader(
                    dataStream,
                    headStream,
                    blockOffset.Value,
                    eventIndex.Value);
            }
            else
            {
                avroReader = _avroReaderFactory.BuildAvroReader(dataStream);
            }

            return new Chunk(
                avroReader,
                blockOffset.Value,
                eventIndex.Value);
        }

        /// <summary>
        /// Constructor for mocking.
        /// </summary>
        public ChunkFactory() { }
    }
}
