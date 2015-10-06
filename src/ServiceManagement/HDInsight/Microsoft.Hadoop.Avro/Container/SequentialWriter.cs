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

    /// <summary>
    ///     Represents a sequential writer of Avro objects.
    /// </summary>
    /// <typeparam name="T">The type of objects.</typeparam>
    public sealed class SequentialWriter<T> : IDisposable
    {
        private readonly IAvroWriter<T> writer;
        private readonly Dictionary<string, byte[]> metadata;
        private readonly int syncNumberOfObjects;
        private bool metadataWritten;
        private IAvroWriterBlock<T> current;

        /// <summary>
        /// Initializes a new instance of the <see cref="SequentialWriter{T}"/> class.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="syncNumberOfObjects">The sync number of objects.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="writer"/> is null.</exception>
        public SequentialWriter(IAvroWriter<T> writer, int syncNumberOfObjects)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (syncNumberOfObjects <= 0)
            {
                throw new ArgumentOutOfRangeException("syncNumberOfObjects");
            }

            this.writer = writer;
            this.metadata = new Dictionary<string, byte[]>();
            this.metadataWritten = false;
            this.current = writer.CreateBlock();
            this.syncNumberOfObjects = syncNumberOfObjects;
        }

        /// <summary>
        ///     Adds the metadata.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void AddMetadata(string key, byte[] value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            this.metadata.Add(key, value);
        }

        /// <summary>
        ///     Writes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Write(T value)
        {
            if (!this.metadataWritten)
            {
                this.writer.SetMetadata(this.metadata);
                this.metadataWritten = true;
            }

            this.current.Write(value);
            if (this.ShouldSync)
            {
                this.Sync();
            }
        }

        /// <summary>
        ///     Ends current block.
        /// </summary>
        /// <returns>Last position of the block.</returns>
        public long Sync()
        {
            var position = this.writer.WriteBlock(this.current);
            this.current.Dispose();
            this.current = this.writer.CreateBlock();
            return position;
        }

        /// <summary>
        ///     Flushes this instance.
        /// </summary>
        public void Flush()
        {
            this.Sync();
        }

        /// <summary>
        ///     Closes this instance.
        /// </summary>
        public void Close()
        {
            this.Flush();
            this.writer.Close();
        }

        /// <summary>
        ///     Releases unmanaged and (optionally) managed resources.
        /// </summary>
        public void Dispose()
        {
            this.Close();
            this.current.Dispose();
        }

        /// <summary>
        ///     Gets a value indicating whether [should sync].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [should sync]; otherwise, <c>false</c>.
        /// </value>
        private bool ShouldSync
        {
            get { return this.current.ObjectCount >= this.syncNumberOfObjects; }
        }
    }
}
