// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Azure.Storage.Internal.Avro;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// Creates AvroReaders.  Allows us to inject mock AvroReaders in
    /// the Chunk unit tests.
    /// </summary>
    internal class AvroReaderFactory
    {
        /// <summary>
        /// Builds an <see cref="AvroReader"/> from a data stream.
        /// </summary>
        public virtual AvroReader BuildAvroReader(Stream dataStream)
            => new AvroReader(dataStream);

        /// <summary>
        /// Builds an <see cref="AvroReader"/> from a data stream and head stream, resuming
        /// from the specified block offset and event index.
        /// </summary>
        public virtual AvroReader BuildAvroReader(
            Stream dataStream,
            Stream headStream,
            long blockOffset,
            long eventIndex)
            => new AvroReader(
                dataStream,
                headStream,
                blockOffset,
                eventIndex);
    }
}
