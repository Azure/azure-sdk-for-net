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
    /// Represents an Avro block for writing.
    /// </summary>
    /// <typeparam name="T">The type of objects inside the block.</typeparam>
    public interface IAvroWriterBlock<in T> : IDisposable
    {
        /// <summary>
        /// Gets the number of Avro objects in the block.
        /// </summary>
        long ObjectCount { get; }

        /// <summary>
        /// Writes the specified object to the block.
        /// </summary>
        /// <param name="obj">The object.</param>
        void Write(T obj);

        /// <summary>
        /// Flushes buffered data.
        /// </summary>
        void Flush();

        /// <summary>
        /// Gets the content of the block as a stream.
        /// </summary>
        Stream Content { get; }
    }
}
