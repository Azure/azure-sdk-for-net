// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Avro.Container
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// Represents a stream Avro reader.
    /// </summary>
    /// <typeparam name="T">The type of Avro objects inside the input stream.</typeparam>
    internal sealed class StreamReader<T> : IAvroReader<T>
    {
        private readonly IAvroSerializer<T> serializer;
        private readonly Codec codec;
        private readonly Stream stream;
        private readonly IDecoder decoder;
        private readonly ObjectContainerHeader header;
        private IAvroReaderBlock<T> current;

        /// <summary>
        /// Initializes a new instance of the <see cref="StreamReader{T}"/> class for Avro records.
        /// </summary>
        /// <param name="readerSchema">The reader schema.</param>
        /// <param name="stream">The input stream.</param>
        /// <param name="leaveOpen">If set to <c>true</c> leaves the input stream open.</param>
        /// <param name="codecFactory">The codec factory.</param>
        public StreamReader(string readerSchema, Stream stream, bool leaveOpen, CodecFactory codecFactory)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            if (codecFactory == null)
            {
                throw new ArgumentNullException("codecFactory");
            }

            this.stream = stream;
            this.decoder = new BinaryDecoder(stream, leaveOpen);
            this.header = ObjectContainerHeader.Read(this.decoder);
            this.codec = codecFactory.Create(this.header.CodecName);
            this.serializer = (IAvroSerializer<T>)AvroSerializer.CreateGenericDeserializerOnly(this.header.Schema, readerSchema ?? this.header.Schema);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StreamReader{T}"/> class for static types.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="leaveOpen">If set to <c>true</c> leaves the input stream open.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="codecFactory">The codec factory.</param>
        public StreamReader(Stream stream, bool leaveOpen, AvroSerializerSettings settings, CodecFactory codecFactory)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            if (codecFactory == null)
            {
                throw new ArgumentNullException("codecFactory");
            }

            this.stream = stream;
            this.decoder = new BinaryDecoder(stream, leaveOpen);
            this.header = ObjectContainerHeader.Read(this.decoder);
            this.codec = codecFactory.Create(this.header.CodecName);
            this.serializer = AvroSerializer.CreateDeserializerOnly<T>(this.header.Schema, settings);
        }

        public TypeSchema Schema
        {
            get { return this.serializer.WriterSchema; }
        }

        public void Seek(long blockStartPosition)
        {
            this.stream.Position = blockStartPosition;
        }

        public IAvroReaderBlock<T> Current
        {
            get
            {
                return this.current;
            }
        }

        public bool MoveNext()
        {
            if (this.stream.Position == this.stream.Length)
            {
                return false;
            }

            int objectCount = this.decoder.DecodeInt();
            int blockSize = this.decoder.DecodeInt();
            this.current = new AvroBufferReaderBlock<T>(this.serializer, this.codec, this.decoder.DecodeFixed(blockSize), objectCount);
            var marker = this.decoder.DecodeFixed(this.header.SyncMarker.Length);
            if (!marker.SequenceEqual(this.header.SyncMarker))
            {
                throw new SerializationException("Synchronization marker defined in the header does not match the read one.");
            }
            return true;
        }

        public void Dispose()
        {
            this.decoder.Dispose();
        }
    }
}
