// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Azure.Storage.Internal.Avro;

namespace Azure.Storage.ChangeFeed.Common
{
    /// <summary>
    /// Factory that creates <see cref="AvroReader"/> instances for parsing Avro-formatted chunk files.
    /// This indirection exists so that unit tests can inject a mocked <see cref="AvroReader"/> via Moq
    /// (all methods are <c>virtual</c>). The Blob Change Feed package has an identical factory class.
    /// </summary>
    internal class AvroReaderFactory
    {
        /// <summary>
        /// Creates an Avro reader that reads from the beginning of a data stream.
        /// </summary>
        /// <param name="dataStream">Stream containing the full Avro file.</param>
        /// <returns>A new <see cref="AvroReader"/>.</returns>
        public virtual AvroReader BuildAvroReader(Stream dataStream)
            => new AvroReader(dataStream);

        /// <summary>
        /// Creates an Avro reader that resumes reading from a specific block offset, using a separate
        /// head stream to read the Avro header and schema from the beginning of the file.
        /// </summary>
        /// <param name="dataStream">Stream positioned at <paramref name="blockOffset"/> for reading event data.</param>
        /// <param name="headStream">Stream positioned at offset 0 for reading the Avro header/schema.</param>
        /// <param name="blockOffset">Byte offset of the Avro block to resume from.</param>
        /// <param name="eventIndex">Event index within the block to resume from.</param>
        /// <returns>A new <see cref="AvroReader"/> positioned for resumption.</returns>
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
