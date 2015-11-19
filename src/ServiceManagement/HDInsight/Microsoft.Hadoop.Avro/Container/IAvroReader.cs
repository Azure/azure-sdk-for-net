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
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// Represents a reader around Avro object container.
    /// </summary>
    /// <typeparam name="T">The type of objects inside the container.</typeparam>
    public interface IAvroReader<out T> : IDisposable
    {
        /// <summary>
        /// Gets the schema of the underlying stream.
        /// </summary>
        TypeSchema Schema { get; }

        /// <summary>
        /// Positions the reader to the absolute position.
        /// </summary>
        /// <param name="blockStartPosition">The block start position.</param>
        void Seek(long blockStartPosition);

        /// <summary>
        /// Moves to the next block.
        /// </summary>
        /// <returns>True if the next block exists.</returns>
        bool MoveNext();

        /// <summary>
        /// Gets current block.
        /// </summary>
        IAvroReaderBlock<T> Current
        {
            get;
        }
    }
}
