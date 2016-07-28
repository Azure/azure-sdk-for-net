// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿
namespace Microsoft.Azure.Batch
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An enumerator which exposes an asynchronous mechanism for iteration.
    /// 
    /// Enumerator instances are not threadsafe.
    /// 
    /// Each enumerator fetches the collection from the server. 
    /// As a consequence, each enumerator can see different data (collection size, contents, etc.).
    /// 
    /// Care should be taken to avoid multiple retrievals of the data from the server via casual use of foreach/ForeachAsync and other collection operations.
    /// 
    /// </summary>
    /// <typeparam name="T">The type of the enumerator.</typeparam>
    public interface IPagedEnumerator<T> : IDisposable
    {
        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        T Current { get;}

        /// <summary>
        /// Begins an asynchronous call to advance the enumerator to the next element of the collection.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        Task<bool> MoveNextAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Begins an asynchronous call to set the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task ResetAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
