// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure
{
    /// <summary>
    /// A collection of values that may take multiple service requests to
    /// iterate over.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    public abstract class AsyncCollection<T> : IAsyncEnumerable<Response<T>>
    {
        /// <summary>
        /// Gets a <see cref="CancellationToken"/> used for requests made while
        /// enumerating asynchronously.
        /// </summary>
        protected virtual CancellationToken CancellationToken { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncCollection{T}"/>
        /// class for mocking.
        /// </summary>
        protected AsyncCollection() =>
            this.CancellationToken = CancellationToken.None;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncCollection{T}"/>
        /// class.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used for requests made while
        /// enumerating asynchronously.
        /// </param>
        protected AsyncCollection(CancellationToken cancellationToken) =>
            this.CancellationToken = cancellationToken;

        /// <summary>
        /// Enumerate the values a <see cref="Page{T}"/> at a time.  This may
        /// make mutliple service requests.
        /// </summary>
        /// <param name="continuationToken">
        /// A continuation token indicating where to resume paging or null to
        /// begin paging from the beginning.
        /// </param>
        /// <param name="pageSizeHint">
        /// The size of <see cref="Page{T}"/>s that should be requested (from
        /// service operations that support it).
        /// </param>
        /// <returns>
        /// An async sequence of <see cref="Page{T}"/>s.
        /// </returns>
        public abstract IAsyncEnumerable<Page<T>> ByPage(
            string continuationToken = default,
            int? pageSizeHint = default);

        /// <summary>
        /// Enumerate the values in the collection asynchronously.  This may
        /// make mutliple service requests.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used for requests made while
        /// enumerating asynchronously.
        /// </param>
        /// <returns>An async sequence of values.</returns>
        public virtual async IAsyncEnumerator<Response<T>> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            await foreach (Page<T> page in ByPage().ConfigureAwait(false).WithCancellation(cancellationToken))
            {
                foreach (T value in page.Values)
                {
                    yield return new Response<T>(page.GetRawResponse(), value);
                }
            }
        }

        /// <summary>
        /// Creates a string representation of an <see cref="AsyncCollection{T}"/>.
        /// </summary>
        /// <returns>
        /// A string representation of an <see cref="AsyncCollection{T}"/>.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        /// Check if two <see cref="AsyncCollection{T}"/> instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the <see cref="AsyncCollection{T}"/>.
        /// </summary>
        /// <returns>Hash code for the <see cref="Page{T}"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();
    }
}
