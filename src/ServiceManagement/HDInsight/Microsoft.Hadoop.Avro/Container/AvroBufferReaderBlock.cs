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
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Represents Avro reader block.
    /// </summary>
    /// <typeparam name="T">Type of encoded objects.</typeparam>
    internal sealed class AvroBufferReaderBlock<T> : IAvroReaderBlock<T>
    {
        private readonly IAvroSerializer<T> serializer;
        private readonly Codec codec;
        private readonly int objectCount;
        private readonly byte[] rawBlock;

        public AvroBufferReaderBlock(IAvroSerializer<T> serializer, Codec codec, byte[] rawBlock, int objectCount)
        {
            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }
            if (codec == null)
            {
                throw new ArgumentNullException("codec");
            }
            if (rawBlock == null)
            {
                throw new ArgumentNullException("rawBlock");
            }
            if (objectCount < 0)
            {
                throw new ArgumentOutOfRangeException("objectCount");
            }

            this.serializer = serializer;
            this.codec = codec;
            this.rawBlock = rawBlock;
            this.objectCount = objectCount;
        }

        public IEnumerable<T> Objects
        {
            get
            {
                int remainingObjects = this.objectCount;
                using (var buffer = new MemoryStream(this.rawBlock))
                using (var decompressedBuffer = this.codec.GetDecompressedStreamOver(buffer))
                using (var decoder = new BufferedBinaryDecoder(decompressedBuffer))
                {
                    while (remainingObjects != 0)
                    {
                        remainingObjects--;
                        yield return this.serializer.Deserialize(decoder);
                    }
                }
            }
        }

        public void Dispose()
        {
        }
    }
}
