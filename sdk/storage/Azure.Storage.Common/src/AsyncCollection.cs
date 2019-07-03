﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

// TODO: #6807: Move these types into the Azure.Core package next release?

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
        protected virtual CancellationToken CancellationToken { get; private set; }

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
        public abstract IAsyncEnumerator<Response<T>> GetAsyncEnumerator(CancellationToken cancellationToken = default);

        /// <summary>
        /// Enumerate the values in the collection synchronously.  This may
        /// make mutliple service requests.
        /// </summary>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used for requests made while
        /// enumerating.
        /// </param>
        /// <returns>A sequence of values.</returns>
        protected abstract IEnumerator<Response<T>> GetEnumerator();

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

#pragma warning disable CA1815 // Override equals and operator equals on value types
#pragma warning disable CA2231 // Overload operator equals on overriding value type Equals
#pragma warning disable CA1066 // Type {0} should implement IEquatable<T> because it overrides Equals
    /// <summary>
    /// A single <see cref="Page{T}"/> of values from a request that may return
    /// zero or more <see cref="Page{T}"/>s of values.
    /// </summary>
    /// <typeparam name="T">The type of values.</typeparam>
    public readonly struct Page<T>
#pragma warning restore CA1066 // Type {0} should implement IEquatable<T> because it overrides Equals
#pragma warning restore CA2231 // Overload operator equals on overriding value type Equals
#pragma warning restore CA1815 // Override equals and operator equals on value types
    {
// TODO: Should this be Items instead of Values?
// - Probably not with Response.Values
// TODO: Should it be IEnumerable<T>?
        #pragma warning disable CA1819 // Properties should not return arrays
        /// <summary>
        /// Gets the values in this <see cref="Page{T}"/>.
        /// </summary>
        public T[] Values { get; }
        #pragma warning restore CA1819 // Properties should not return arrays

        // TODO: Should this be object instead of string?
        /// <summary>
        /// Gets the continuation token used to request the next
        /// <see cref="Page{T}"/>.  The continuation token may be null or
        /// empty when there are no more pages.
        /// </summary>
        public string ContinuationToken { get; }

        /// <summary>
        /// The <see cref="Response"/> that provided this <see cref="Page{T}"/>.
        /// </summary>
        private readonly Response _response;

        /// <summary>
        /// Gets the <see cref="Response"/> that provided this
        /// <see cref="Page{T}"/>.
        /// </summary>
        public Response GetRawResponse() => this._response;

        /// <summary>
        /// Creates a new <see cref="Page{T}"/>.
        /// </summary>
        /// <param name="values">
        /// The values in this <see cref="Page{T}"/>.
        /// </param>
        /// <param name="continuationToken">
        /// The continuation token used to request the next <see cref="Page{T}"/>.
        /// </param>
        /// <param name="response">
        /// The <see cref="Response"/> that provided this <see cref="Page{T}"/>.
        /// </param>
        public Page(T[] values, string continuationToken, Response response)
        {
            this.Values = values;
            this.ContinuationToken = continuationToken;
            this._response = response;
        }

        /// <summary>
        /// Creates a string representation of an <see cref="Page{T}"/>.
        /// </summary>
        /// <returns>
        /// A string representation of an <see cref="Page{T}"/>.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        /// Check if two <see cref="Page{T}"/> instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the <see cref="Page{T}"/>.
        /// </summary>
        /// <returns>Hash code for the <see cref="Page{T}"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();
    }
}
