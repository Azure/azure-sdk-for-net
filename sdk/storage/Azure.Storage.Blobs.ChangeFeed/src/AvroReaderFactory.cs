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
        public virtual AvroReader BuildAvroReader(Stream dataStream)
            => new AvroReader(dataStream);

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
