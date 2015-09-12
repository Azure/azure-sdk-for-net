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
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a writer around Avro object container.
    /// </summary>
    /// <typeparam name="T">The type of objects inside the container.</typeparam>
    public interface IAvroWriter<T> : IDisposable
    {
        /// <summary>
        /// Sets the metadata.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        void SetMetadata(IDictionary<string, byte[]> metadata);

        /// <summary>
        /// Creates a block asynchronously. The block should be disposed by the user
        /// when it is not used anymore.
        /// </summary>
        /// <returns>A task returning a new block.</returns>
        Task<IAvroWriterBlock<T>> CreateBlockAsync();

        /// <summary>
        /// Creates a block. The block should be disposed by the user
        /// when it is not used anymore.
        /// </summary>
        /// <returns>A new block.</returns>
        IAvroWriterBlock<T> CreateBlock();

        /// <summary>
        /// Writes the block asynchronously.
        /// </summary>
        /// <param name="block">The block.</param>
        /// <returns>Task containing the position of the written block.</returns>
        Task<long> WriteBlockAsync(IAvroWriterBlock<T> block);

        /// <summary>
        /// Writes the block.
        /// </summary>
        /// <param name="block">The block.</param>
        /// <returns>The position of the written block.</returns>
        long WriteBlock(IAvroWriterBlock<T> block);

        /// <summary>
        /// Closes this instance.
        /// </summary>
        void Close();
    }
}
