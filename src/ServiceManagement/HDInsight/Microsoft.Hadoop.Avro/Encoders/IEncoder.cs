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
namespace Microsoft.Hadoop.Avro
{
    using System;
    using System.IO;

    /// <summary>
    ///     Defines methods for encoding of basic Avro types.
    /// </summary>
    public interface IEncoder : IDisposable
    {
        /// <summary>
        ///     Encodes a boolean value.
        /// </summary>
        /// <param name="value">Value to encode.</param>
        void Encode(bool value);

        /// <summary>
        ///     Encodes an integer value.
        /// </summary>
        /// <param name="value">Value to encode.</param>
        void Encode(int value);

        /// <summary>
        ///     Encodes a long value.
        /// </summary>
        /// <param name="value">Value to encode.</param>
        void Encode(long value);

        /// <summary>
        ///     Encodes a float value.
        /// </summary>
        /// <param name="value">Value to encode.</param>
        void Encode(float value);

        /// <summary>
        ///     Encodes a double value.
        /// </summary>
        /// <param name="value">Value to encode.</param>
        void Encode(double value);

        /// <summary>
        ///     Encodes a byte array as <i>bytes</i> Avro type.
        /// </summary>
        /// <param name="value">Value to encode.</param>
        void Encode(byte[] value);

        /// <summary>
        ///     Encodes a string value.
        /// </summary>
        /// <param name="value">Value to encode.</param>
        void Encode(string value);

        /// <summary>
        ///     Encodes a byte array as <i>fixed</i> Avro type.
        /// </summary>
        /// <param name="value">The value.</param>
        void EncodeFixed(byte[] value);

        /// <summary>
        ///     Encodes an array chunk of <paramref name="size"/>.
        /// </summary>
        /// <param name="size">The chunk size.</param>
        void EncodeArrayChunk(int size);

        /// <summary>
        ///     Encodes a map chunk of <paramref name="size"/>.
        /// </summary>
        /// <param name="size">Chunk size.</param>
        void EncodeMapChunk(int size);

        /// <summary>
        ///     Encodes a stream as <i>bytes</i> Avro type.
        /// </summary>
        /// <param name="stream">The stream.</param>
        void Encode(Stream stream);

        /// <summary>
        ///     Clears all buffers for this encoder and causes any buffered data to be written to 
        ///     the underlying stream/device.
        /// </summary>
        void Flush();
    }
}
