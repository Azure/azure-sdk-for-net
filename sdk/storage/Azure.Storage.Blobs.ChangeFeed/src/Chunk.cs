// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.ChangeFeed.Models;
using Azure.Storage.Internal.Avro;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// Chunk.
    /// </summary>
    internal class Chunk
    {
        /// <summary>
        /// Avro Reader to parser the Events.
        /// </summary>
        private readonly AvroReader _avroReader;

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
            AvroReader avroReader,
            long blockOffset,
            long eventIndex)
        {
            _avroReader = avroReader;
            BlockOffset = blockOffset;
            EventIndex = eventIndex;
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

        /// <summary>
        /// Constructor for mocking.  Do not use.
        /// </summary>
        internal Chunk() { }
    }
}
