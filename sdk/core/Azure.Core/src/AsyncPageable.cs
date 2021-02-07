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
    /// <example>
    /// Example of enumerating an AsyncPageable using the <c> async foreach </c> loop:
    /// <code snippet="Snippet:AsyncPageable">
    /// // call a service method, which returns AsyncPageable&lt;T&gt;
    /// AsyncPageable&lt;SecretProperties&gt; allSecretProperties = client.GetPropertiesOfSecretsAsync();
    ///
    /// await foreach (SecretProperties secretProperties in allSecretProperties)
    /// {
    ///     Console.WriteLine(secretProperties.Name);
    /// }
    /// </code>
    /// or using a while loop:
    /// <code snippet="Snippet:AsyncPageableLoop">
    /// // call a service method, which returns AsyncPageable&lt;T&gt;
    /// AsyncPageable&lt;SecretProperties&gt; allSecretProperties = client.GetPropertiesOfSecretsAsync();
    ///
    /// IAsyncEnumerator&lt;SecretProperties&gt; enumerator = allSecretProperties.GetAsyncEnumerator();
    /// try
    /// {
    ///     while (await enumerator.MoveNextAsync())
    ///     {
    ///         SecretProperties secretProperties = enumerator.Current;
    ///         Console.WriteLine(secretProperties.Name);
    ///     }
    /// }
    /// finally
    /// {
    ///     await enumerator.DisposeAsync();
    /// }
    /// </code>
    /// </example>
    public abstract class AsyncPageable<T> : IAsyncEnumerable<T> where T : notnull
    {
        /// <summary>
        /// Gets a <see cref="CancellationToken"/> used for requests made while
        /// enumerating asynchronously.
        /// </summary>
        protected virtual CancellationToken CancellationToken { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncPageable{T}"/>
        /// class for mocking.
        /// </summary>
        protected AsyncPageable() =>
            CancellationToken = CancellationToken.None;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncPageable{T}"/>
        /// class.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used for requests made while
        /// enumerating asynchronously.
        /// </param>
        protected AsyncPageable(CancellationToken cancellationToken) =>
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
        public abstract IAsyncEnumerable<Page<T>> AsPages(
            string? continuationToken = default,
            int? pageSizeHint = default);

        /// <summary>
        /// Enumerate the values in the collection asynchronously.  This may
        /// make multiple service requests.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used for requests made while
        /// enumerating asynchronously.
        /// </param>
        /// <returns>An async sequence of values.</returns>
        public virtual async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            await foreach (Page<T> page in AsPages().ConfigureAwait(false).WithCancellation(cancellationToken))
            {
                foreach (T value in page.Values)
                {
                    yield return value;
                }
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="Pageable{T}"/> using the provided pages.
        /// </summary>
        /// <param name="pages">The pages of values to list as part of net new pageable instance.</param>
        /// <returns>A new instance of <see cref="Pageable{T}"/></returns>
#pragma warning disable CA1000 // Do not declare static members on generic types
        public static AsyncPageable<T> FromPages(IEnumerable<Page<T>> pages)
#pragma warning restore CA1000 // Do not declare static members on generic types
        {
            return new StaticPageable(pages);
        }

        /// <summary>
        /// Creates a string representation of an <see cref="AsyncPageable{T}"/>.
        /// </summary>
        /// <returns>
        /// A string representation of an <see cref="AsyncPageable{T}"/>.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string? ToString() => base.ToString();

        /// <summary>
        /// Check if two <see cref="AsyncPageable{T}"/> instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the <see cref="AsyncPageable{T}"/>.
        /// </summary>
        /// <returns>Hash code for the <see cref="Page{T}"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        private class StaticPageable: AsyncPageable<T>
        {
            private readonly IEnumerable<Page<T>> _pages;

            public StaticPageable(IEnumerable<Page<T>> pages)
            {
                _pages = pages;
            }

#pragma warning disable 1998 // async function without await
            public override async IAsyncEnumerable<Page<T>> AsPages(string? continuationToken = default, int? pageSizeHint = default)
#pragma warning restore 1998
            {
                foreach (var page in _pages)
                {
                    yield return page;
                }
            }
        }
    }
}
