// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage
{
    /// <summary>
    /// Abstract the Storage pattern for async iteration
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal abstract class StorageAsyncCollection<T> : AsyncCollection<T>, IEnumerable<Response<T>>
    {
        // for mocking
        protected StorageAsyncCollection()
            : base()
        {
        }

        protected StorageAsyncCollection(CancellationToken cancellationToken)
            : base(cancellationToken)
        {
        }

        /// <summary>
        /// Get the next <see cref="Page{T}"/> in an
        /// <see cref="AsyncCollection{T}"/>.
        /// </summary>
        /// <remarks>
        /// This is all you need to implement when providng a new
        /// <see cref="AsyncCollection{T}"/>.
        /// </remarks>
        /// <param name="continuationToken">
        /// Continuation token indicating where to begin enumerating.
        /// </param>
        /// <param name="pageHintSize"></param>
        /// <param name="isAsync">
        /// Whether to fetch the next page asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>The next <see cref="Page{T}"/> of values.</returns>
        protected abstract Task<Page<T>> GetNextPageAsync(
            string continuationToken,
            int? pageHintSize,
            bool isAsync,
            CancellationToken cancellationToken);

        /// <summary>
        /// Determine if the iteration can continue.
        /// </summary>
        /// <param name="continuationToken">
        /// The next continuation token provided with the last
        /// <see cref="Page{T}"/>.
        /// </param>
        /// <returns>
        /// True if the iteration can continue, false otherwise.
        /// </returns>
        protected virtual bool CanContinue(string continuationToken) =>
            !String.IsNullOrEmpty(continuationToken);

        /// <summary>
        /// Enumerate the values a <see cref="Page{T}"/> at a time.  This may
        /// make mutliple service requests.
        /// </summary>
        /// <param name="continuationToken">
        /// A continuation token indicating where to resume paging or null to
        /// begin paging from the beginning.
        /// </param>
        /// <param name="pageHintSize">
        /// The size of <see cref="Page{T}"/>s that should be requested (from
        /// service operations that support it).
        /// </param>
        /// <returns>
        /// An async sequence of <see cref="Page{T}"/>s.
        /// </returns>
        public override async IAsyncEnumerable<Page<T>> ByPage(
            string continuationToken = default,
            int? pageHintSize = default)
        {
            do
            {
                var page = await this.GetNextPageAsync(
                    continuationToken,
                    pageHintSize,
                    isAsync: true,
                    cancellationToken: this.CancellationToken)
                    .ConfigureAwait(false);
                continuationToken = page.ContinuationToken;
                yield return page;
            } while (this.CanContinue(continuationToken));
        }

        /// <summary>
        /// Enumerate the values in the collection asynchronously.  This may
        /// make mutliple service requests.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used for requests made while
        /// enumerating asynchronously.
        /// </param>
        /// <returns>An async sequence of values.</returns>
        public override async IAsyncEnumerator<Response<T>> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            // This is the only method that takes its own CancellationToken, but
            // we'll still use the original CancellationToken if one wasn't passed.
            if (cancellationToken == default)
            {
                cancellationToken = this.CancellationToken;
            }

            string continuationToken = null;
            do
            {
                var page = await this.GetNextPageAsync(
                    continuationToken,
                    null,
                    isAsync: true,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
                continuationToken = page.ContinuationToken;
                foreach (var item in page.Values)
                {
                    yield return new Response<T>(page.GetRawResponse(), item);
                }
            } while (this.CanContinue(continuationToken));
        }

        /// <summary>
        /// Enumerate the values in the collection synchronously.  This may
        /// make mutliple service requests.
        /// </summary>
        /// <returns>A sequence of values.</returns>
        protected IEnumerator<Response<T>> GetEnumerator()
        {
            string continuationToken = null;
            do
            {
                var page = this.GetNextPageAsync(
                    continuationToken,
                    null,
                    isAsync: false,
                    cancellationToken: this.CancellationToken)
                    .EnsureCompleted();
                continuationToken = page.ContinuationToken;
                foreach (var item in page.Values)
                {
                    yield return new Response<T>(page.GetRawResponse(), item);
                }
            } while (this.CanContinue(continuationToken));
        }

        IEnumerator<Response<T>> IEnumerable<Response<T>>.GetEnumerator() => this.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
