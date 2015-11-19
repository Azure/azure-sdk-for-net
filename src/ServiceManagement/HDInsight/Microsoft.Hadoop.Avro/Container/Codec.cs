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
    ///     Base class for compression codecs.
    /// </summary>
    public abstract class Codec
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Codec"/> class.
        /// </summary>
        /// <param name="name">The name of the codec.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if the name is null or empty.</exception>
        protected Codec(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            this.Name = name;
        }

        /// <summary>
        ///     Gets the name of the codec.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Wraps a non-compressed stream with the compressed one.
        /// </summary>
        /// <param name="uncompressed">Uncompressed stream.</param>
        /// <returns>Compressed stream.</returns>
        public abstract Stream GetCompressedStreamOver(Stream uncompressed);

        /// <summary>
        /// Wraps a compressed stream with the non-compressed one.
        /// </summary>
        /// <param name="compressed">Compressed Stream.</param>
        /// <returns>Non-compressed stream.</returns>
        public abstract Stream GetDecompressedStreamOver(Stream compressed);

        /// <summary>
        /// Gets the default deflate codec.
        /// </summary>
        public static Codec Deflate
        {
            get { return new DeflateCodec(); }
        }

        /// <summary>
        /// Gets the default null codec.
        /// </summary>
        public static Codec Null
        {
            get { return new NullCodec(); }
        }
    }
}
