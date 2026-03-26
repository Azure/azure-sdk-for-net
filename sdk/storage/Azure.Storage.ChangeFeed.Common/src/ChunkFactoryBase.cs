// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Internal.Avro;

namespace Azure.Storage.ChangeFeed.Common
{
    internal class ChunkFactoryBase<TEvent>
    {
        private readonly LazyLoadingBlobStreamFactory _lazyLoadingBlobStreamFactory;
        private readonly AvroReaderFactory _avroReaderFactory;
        private readonly BlobContainerClient _containerClient;
        private readonly long? _maxTransferSize;
        private readonly ChangeFeedConfiguration<TEvent> _config;

        public ChunkFactoryBase(BlobContainerClient containerClient, LazyLoadingBlobStreamFactory lazyLoadingBlobStreamFactory, AvroReaderFactory avroReaderFactory, long? maxTransferSize, ChangeFeedConfiguration<TEvent> config)
        {
            _containerClient = containerClient;
            _lazyLoadingBlobStreamFactory = lazyLoadingBlobStreamFactory;
            _avroReaderFactory = avroReaderFactory;
            _maxTransferSize = maxTransferSize;
            _config = config;
        }

        internal async virtual Task<ChunkBase<TEvent>> BuildChunk(bool async, string chunkPath, long blockOffset = 0, long eventIndex = 0, CancellationToken cancellationToken = default)
        {
            BlobClient blobClient = _containerClient.GetBlobClient(chunkPath);
            AvroReader avroReader;
            Stream dataStream = _lazyLoadingBlobStreamFactory.BuildLazyLoadingBlobStream(blobClient, offset: blockOffset, blockSize: _maxTransferSize ?? _config.ChunkBlockDownloadSize);

            if (blockOffset != 0)
            {
                Stream headStream = _lazyLoadingBlobStreamFactory.BuildLazyLoadingBlobStream(blobClient, offset: 0, blockSize: 3 * Constants.KB);
                avroReader = _avroReaderFactory.BuildAvroReader(dataStream, headStream, blockOffset, eventIndex);
            }
            else
            {
                avroReader = _avroReaderFactory.BuildAvroReader(dataStream);
            }

            await avroReader.Initalize(async, cancellationToken).ConfigureAwait(false);
            return new ChunkBase<TEvent>(avroReader, blockOffset, eventIndex, chunkPath, _config.EventParser);
        }

        public ChunkFactoryBase() { }
    }
}
