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

    /// <summary>
    ///     Defines methods for skipping basic Avro types.
    /// </summary>
    public interface ISkipper : IDisposable
    {
        /// <summary>
        ///     Skips a boolean value from the underlying stream.
        /// </summary>
        void SkipBool();

        /// <summary>
        ///     Skips a double value from the underlying stream.
        /// </summary>
        void SkipDouble();

        /// <summary>
        ///     Skips a float value from the underlying stream.
        /// </summary>
        void SkipFloat();

        /// <summary>
        ///     Skips an integer value from the underlying stream.
        /// </summary>
        void SkipInt();

        /// <summary>
        ///     Skips a long value from the underlying stream.
        /// </summary>
        void SkipLong();

        /// <summary>
        ///     Skips a byte array from the underlying stream.
        /// </summary>
        void SkipByteArray();

        /// <summary>
        ///     Skips a string value from the underlying stream.
        /// </summary>
        void SkipString();

        /// <summary>
        ///     Skips a fixed value from the underlying stream.
        /// </summary>
        /// <param name="size">The size.</param>
        void SkipFixed(int size);
    }
}
