// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace Azure
{
    /// <summary>
    /// A collection of values that may take multiple service requests to
    /// iterate over.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    public abstract class Pageable<T> : IEnumerable<T> where T : notnull
    {
        /// <summary>
        /// Gets a <see cref="CancellationToken"/> used for requests made while
        /// enumerating asynchronously.
        /// </summary>
        protected virtual CancellationToken CancellationToken { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pageable{T}"/>
        /// class for mocking.
        /// </summary>
        protected Pageable() =>
            CancellationToken = CancellationToken.None;

        /// <summary>
        /// Initializes a new instance of the <see cref="Pageable{T}"/>
        /// class.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used for requests made while
        /// enumerating asynchronously.
        /// </param>
        protected Pageable(CancellationToken cancellationToken) =>
            CancellationToken = cancellationToken;

        /// <summary>
        /// Enumerate the values a <see cref="Page{T}"/> at a time.  This may
        /// make multiple service requests.
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
        public abstract IEnumerable<Page<T>> AsPages(
            string? continuationToken = default,
            int? pageSizeHint = default);

        /// <summary>
        /// Creates a string representation of an <see cref="Pageable{T}"/>.
        /// </summary>
        /// <returns>
        /// A string representation of an <see cref="Pageable{T}"/>.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Enumerate the values in the collection.  This may make multiple service requests.
        /// </summary>
        public virtual IEnumerator<T> GetEnumerator()
        {
            foreach (Page<T> page in AsPages())
            {
                foreach (T value in page.Values)
                {
                    yield return value;
                }
            }
        }

        /// <summary>
        /// Check if two <see cref="Pageable{T}"/> instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the <see cref="Pageable{T}"/>.
        /// </summary>
        /// <returns>Hash code for the <see cref="Pageable{T}"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();
    }
}
