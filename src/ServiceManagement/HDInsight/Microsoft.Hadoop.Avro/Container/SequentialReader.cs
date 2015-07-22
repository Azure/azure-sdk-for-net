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
    ///     Represents a sequential reader of Avro objects.
    /// </summary>
    /// <typeparam name="T">The type of objects.</typeparam>
    public sealed class SequentialReader<T> : IDisposable
    {
        private readonly IAvroReader<T> reader;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SequentialReader{T}" /> class.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="reader"/> is null.</exception>
        public SequentialReader(IAvroReader<T> reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            this.reader = reader;
        }

        /// <summary>
        /// Gets the objects.
        /// </summary>
        public IEnumerable<T> Objects
        {
            get
            {
                while (this.reader.MoveNext())
                {
                    using (var block = this.reader.Current)
                    {
                        foreach (var record in block.Objects)
                        {
                            yield return record;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.reader.Dispose();
        }
    }
}
