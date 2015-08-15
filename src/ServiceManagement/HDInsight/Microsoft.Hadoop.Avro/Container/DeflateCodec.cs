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
    ///     Deflate compression codec.
    /// </summary>
    internal sealed class DeflateCodec : Codec
    {
        public static readonly string CodecName = "deflate";

        /// <summary>
        ///     Initializes a new instance of the <see cref="DeflateCodec" /> class.
        /// </summary>
        public DeflateCodec() : base(CodecName)
        {
        }

        public override Stream GetCompressedStreamOver(Stream decompressed)
        {
            if (decompressed == null)
            {
                throw new ArgumentNullException("decompressed");
            }

            return new CompressionStream(decompressed);
        }

        public override Stream GetDecompressedStreamOver(Stream compressed)
        {
            if (compressed == null)
            {
                throw new ArgumentNullException("compressed");
            }

            return new DecompressionStream(compressed);
        }
    }
}
