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
    /// <summary>
    ///     Defines methods for decoding of basic Avro types.
    /// </summary>
    public interface IDecoder : ISkipper
    {
        /// <summary>
        ///     Decodes a boolean value.
        /// </summary>
        /// <returns>Decoded value.</returns>
        bool DecodeBool();

        /// <summary>
        ///     Decodes an integer value.
        /// </summary>
        /// <returns>Decoded value.</returns>
        int DecodeInt();

        /// <summary>
        ///     Decodes a long value.
        /// </summary>
        /// <returns>Decoded value.</returns>
        long DecodeLong();

        /// <summary>
        ///     Decodes a float value.
        /// </summary>
        /// <returns>Decoded value.</returns>
        float DecodeFloat();

        /// <summary>
        ///     Decodes a double value.
        /// </summary>
        /// <returns>Decoded value.</returns>
        double DecodeDouble();

        /// <summary>
        ///     Decodes a byte array.
        /// </summary>
        /// <returns>Decoded value.</returns>
        byte[] DecodeByteArray();

        /// <summary>
        ///     Decodes a string value.
        /// </summary>
        /// <returns>Decoded value.</returns>
        string DecodeString();

        /// <summary>
        ///     Decodes a fixed byte array.
        /// </summary>
        /// <param name="size">The size of the array.</param>
        /// <returns>Decoded array.</returns>
        byte[] DecodeFixed(int size);

        /// <summary>
        ///     Decodes an array chunk.
        /// </summary>
        /// <returns>The size of the current chunk.</returns>
        int DecodeArrayChunk();

        /// <summary>
        ///     Decodes a map chunk.
        /// </summary>
        /// <returns>The size of the current chunk.</returns>
        int DecodeMapChunk();
    }
}
