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
    using System.IO;

    /// <summary>
    /// Represents Avro writer block.
    /// </summary>
    /// <typeparam name="T">Type of encoded objects.</typeparam>
    internal sealed class AvroBufferWriterBlock<T> : IAvroWriterBlock<T>
    {
        private readonly IAvroSerializer<T> serializer;
        private readonly Stream buffer;
        private readonly Stream compressed;
        private readonly IEncoder encoder;
        private int objectCount;

        public AvroBufferWriterBlock(IAvroSerializer<T> serializer, Codec codec)
        {
            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }
            if (codec == null)
            {
                throw new ArgumentNullException("codec");
            }

            this.serializer = serializer;
            this.buffer = new MemoryStream();
            this.compressed = codec.GetCompressedStreamOver(this.buffer);
            this.encoder = new BufferedBinaryEncoder(this.compressed);
            this.objectCount = 0;
        }

        public long ObjectCount
        {
            get { return this.objectCount; }
        }

        public void Write(T @object)
        {
            this.serializer.Serialize(this.encoder, @object);
            ++this.objectCount;
        }

        public void Flush()
        {
            this.encoder.Flush();
            this.compressed.Flush();
            this.compressed.Seek(0, SeekOrigin.Begin);
        }

        public Stream Content
        {
            get { return this.compressed; }
        }

        public void Dispose()
        {
            this.encoder.Dispose();
            this.compressed.Dispose();
            this.buffer.Dispose();
        }
    }
}
