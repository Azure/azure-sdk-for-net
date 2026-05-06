// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Internal.Avro;

namespace Azure.Storage.ChangeFeed.Common
{
    /// <summary>
    /// Factory that creates <see cref="ChunkBase{TEvent}"/> instances, handling stream setup and Avro reader
    /// initialization for both fresh reads and cursor-based resumption.
    /// </summary>
    internal class ChunkFactoryBase<TEvent> where TEvent : IChangeFeedEvent
    {
        private readonly AvroReaderFactory _avroReaderFactory;
        private readonly BlobContainerClient _containerClient;
        private readonly long? _maxTransferSize;
        private readonly ChangeFeedConfiguration<TEvent> _config;
        private readonly bool _allowModifications;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChunkFactoryBase{TEvent}"/> class.
        /// </summary>
        /// <param name="containerClient">Container client for the change feed container.</param>
        /// <param name="avroReaderFactory">Factory for creating Avro readers.</param>
        /// <param name="maxTransferSize">Optional override for the download buffer size.</param>
        /// <param name="config">Change feed configuration.</param>
        /// <param name="allowModifications">
        /// Value passed to <see cref="BlobOpenReadOptions"/>'s <c>AllowModifications</c> when opening
        /// chunk streams. Set to <c>true</c> only when the consumer has opted in to non-finalized
        /// events, since finalized chunks are immutable and a mid-read modification indicates a
        /// real fault.
        /// </param>
        public ChunkFactoryBase(
            BlobContainerClient containerClient,
            AvroReaderFactory avroReaderFactory,
            long? maxTransferSize,
            ChangeFeedConfiguration<TEvent> config,
            bool allowModifications = false)
        {
            _containerClient = containerClient;
            _avroReaderFactory = avroReaderFactory;
            _maxTransferSize = maxTransferSize;
            _config = config;
            _allowModifications = allowModifications;
        }

        /// <summary>
        /// Builds a chunk reader for the specified Avro file, optionally resuming from a block offset.
        /// </summary>
        /// <param name="async">Whether to use async APIs.</param>
        /// <param name="chunkPath">Blob path of the chunk Avro file.</param>
        /// <param name="blockOffset">Byte offset to resume from (0 for a fresh read).</param>
        /// <param name="eventIndex">Event index within the block to resume from.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A new <see cref="ChunkBase{TEvent}"/> positioned at the specified offset.</returns>
        internal async virtual Task<ChunkBase<TEvent>> BuildChunk(
            bool async,
            string chunkPath,
            long blockOffset = 0,
            long eventIndex = 0,
            CancellationToken cancellationToken = default)
        {
            BlobClient blobClient = _containerClient.GetBlobClient(chunkPath);
            AvroReader avroReader;

            BlobOpenReadOptions dataOptions = new BlobOpenReadOptions(allowModifications: _allowModifications)
            {
                Position = blockOffset,
                BufferSize = (int)(_maxTransferSize ?? _config.ChunkBlockDownloadSize),
            };

            Stream dataStream = async
                ? await blobClient.OpenReadAsync(dataOptions, cancellationToken).ConfigureAwait(false)
                : blobClient.OpenRead(dataOptions, cancellationToken);

            if (blockOffset != 0)
            {
                // When resuming mid-block, two streams are needed: a "head" stream reads from offset 0
                // to parse the Avro header/schema, while the "data" stream reads from blockOffset for the actual events.
                BlobOpenReadOptions headOptions = new BlobOpenReadOptions(allowModifications: _allowModifications)
                {
                    Position = 0,
                    BufferSize = (int)_config.AvroHeaderDownloadSize,
                };

                Stream headStream = async
                    ? await blobClient.OpenReadAsync(headOptions, cancellationToken).ConfigureAwait(false)
                    : blobClient.OpenRead(headOptions, cancellationToken);

                avroReader = _avroReaderFactory.BuildAvroReader(dataStream, headStream, blockOffset, eventIndex);
            }
            else
            {
                avroReader = _avroReaderFactory.BuildAvroReader(dataStream);
            }

            await avroReader.Initalize(async, cancellationToken).ConfigureAwait(false);

            return new ChunkBase<TEvent>(
                avroReader,
                blockOffset,
                eventIndex,
                chunkPath,
                _config.EventParser);
        }

        /// <summary>
        /// Constructor for mocking. Do not use directly.
        /// </summary>
        public ChunkFactoryBase() { }
    }
}
