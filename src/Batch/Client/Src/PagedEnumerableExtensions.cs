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

﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch
{
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for working with sequences that
    /// implement <see cref="IPagedEnumerable{T}"/>.
    /// </summary>
    public static class PagedEnumerableExtensions
    {
        /// <summary>
        /// Iterates over an <see cref="IPagedEnumerable{T}"/> sequence, invoking an asynchronous delegate for each element.
        /// </summary>
        /// <param name="source">The <see cref="IPagedEnumerable{T}"/> to iterate over.</param>
        /// <param name="body">The asynchronous delegate to execute for each element in <paramref name="source"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the iteration operation. The task
        /// completes when iteration is complete.</returns>
        /// <remarks>This method processes elements sequentially, not concurrently.  That is, for each element in the
        /// sequence, the method awaits the asynchronous delegate before processing the next element.</remarks>
        public static async Task ForEachAsync<T>(this IPagedEnumerable<T> source, Func<T, Task> body, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (source == null)
            {
                throw new ArgumentNullException("source") ;
            }
            if (body == null)
            {
                throw new ArgumentNullException("body");
            }

            await source.ForEachAsync((t, ct) => body(t), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Iterates over an <see cref="IPagedEnumerable{T}"/> sequence, invoking an asynchronous delegate for each element.
        /// </summary>
        /// <param name="source">The <see cref="IPagedEnumerable{T}"/> to iterate over.</param>
        /// <param name="body">The asynchronous delegate to execute for each element in <paramref name="source"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the iteration operation. The task
        /// completes when iteration is complete.</returns>
        /// <remarks>This method processes elements sequentially, not concurrently.  That is, for each element in the
        /// sequence, the method awaits the asynchronous delegate before processing the next element.</remarks>
        public static async Task ForEachAsync<T>(this IPagedEnumerable<T> source, Func<T, CancellationToken, Task> body, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (body == null)
            {
                throw new ArgumentNullException("body");
            }

            using (IPagedEnumerator<T> enumerator = source.GetPagedEnumerator())
            {
                while (await enumerator.MoveNextAsync(cancellationToken).ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    await body(enumerator.Current, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Iterates over an <see cref="IPagedEnumerable{T}"/> sequence, invoking a synchronous delegate for each element.
        /// </summary>
        /// <param name="source">The <see cref="IPagedEnumerable{T}"/> to iterate over.</param>
        /// <param name="body">The delegate to execute for each element in <paramref name="source"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> that represents the iteration operation. The task
        /// completes when iteration is complete.</returns>
        /// <remarks>This method processes elements sequentially, not concurrently.  That is, for each element in the
        /// sequence, the method completes execution of the delegate before processing the next element.</remarks>
        public static async Task ForEachAsync<T>(this IPagedEnumerable<T> source, Action<T> body, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (body == null)
            {
                throw new ArgumentNullException("body");
            }
            
            using (IPagedEnumerator<T> enumerator = source.GetPagedEnumerator())
            {
                while (await enumerator.MoveNextAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    body(enumerator.Current);
                }
            }
        }

        /// <summary>
        /// Creates a <see cref="List{T}" /> from an <see cref="IPagedEnumerable{T}"/>.
        /// </summary>
        /// <param name="source">The <see cref="IPagedEnumerable{T}"/> to create a list from.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous operation. The result
        /// of the task is a <see cref="List{T}" /> containing all elements of the source sequence.</returns>
        public static async Task<List<T>> ToListAsync<T>(this IPagedEnumerable<T> source, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
  
            List<T> results = new List<T>();
            
            await source.ForEachAsync(item => results.Add(item), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);

            return results;
        }
    }
}
