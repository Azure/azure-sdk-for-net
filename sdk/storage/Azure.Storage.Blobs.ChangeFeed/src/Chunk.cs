// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.ChangeFeed.Models;
using Azure.Storage.Internal.Avro;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// Chunk.
    /// </summary>
    internal class Chunk : IDisposable
    {
        /// <summary>
        /// Blob Client for downloading the Chunk.
        /// </summary>
        private readonly BlobClient _blobClient;

        /// <summary>
        /// Avro Reader to parser the Events.
        /// </summary>
        private readonly AvroReader _avroReader;

        /// <summary>
        /// Data stream.
        /// </summary>
        private readonly Stream _dataStream;

        /// <summary>
        /// Avro head stream.
        /// </summary>
        private readonly Stream _headStream;

        /// <summary>
        /// The byte offset of the beginning of the current
        /// Block.
        /// </summary>
        public virtual long BlockOffset { get; private set; }

        /// <summary>
        /// The index of the Event within the current block.
        /// </summary>
        public virtual long EventIndex { get; private set; }

        public Chunk(
            BlobContainerClient containerClient,
            LazyLoadingBlobStreamFactory lazyLoadingBlobStreamFactory,
            AvroReaderFactory avroReaderFactory,
            string chunkPath,
            long? blockOffset = default,
            long? eventIndex = default)
        {
            _blobClient = containerClient.GetBlobClient(chunkPath);
            BlockOffset = blockOffset ?? 0;
            EventIndex = eventIndex ?? 0;

            _dataStream = lazyLoadingBlobStreamFactory.BuildLazyLoadingBlobStream(
                _blobClient,
                offset: BlockOffset,
                blockSize: Constants.ChangeFeed.ChunkBlockDownloadSize);

            // We aren't starting from the beginning of the Chunk
            if (BlockOffset != 0)
            {
                _headStream = lazyLoadingBlobStreamFactory.BuildLazyLoadingBlobStream(
                    _blobClient,
                    offset: 0,
                    blockSize: 3 * Constants.KB);

                _avroReader = avroReaderFactory.BuildAvroReader(
                    _dataStream,
                    _headStream,
                    BlockOffset,
                    EventIndex);
            }
            else
            {
                _avroReader = avroReaderFactory.BuildAvroReader(_dataStream);
            }
        }

        public virtual bool HasNext()
            => _avroReader.HasNext();

        public virtual async Task<BlobChangeFeedEvent> Next(
            bool async,
            CancellationToken cancellationToken = default)
        {
            Dictionary<string, object> result;

            if (!HasNext())
            {
                return null;
            }

            result = (Dictionary<string, object>)await _avroReader.Next(async, cancellationToken).ConfigureAwait(false);
            BlockOffset = _avroReader.BlockOffset;
            EventIndex = _avroReader.ObjectIndex;
            return new BlobChangeFeedEvent(result);
        }

        public void Dispose()
        {
            _dataStream.Dispose();
            _headStream.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Constructor for mocking.  Do not use.
        /// </summary>
        internal Chunk() { }
    }
}
