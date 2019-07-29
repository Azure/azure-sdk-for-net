// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure
{
    /// <summary>
    /// A single <see cref="Page{T}"/> of values from a request that may return
    /// zero or more <see cref="Page{T}"/>s of values.
    /// </summary>
    /// <typeparam name="T">The type of values.</typeparam>
    public readonly struct Page<T>
    {
        /// <summary>
        /// Gets the values in this <see cref="Page{T}"/>.
        /// </summary>
        public IReadOnlyList<T> Values { get; }

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
        public Page(IReadOnlyList<T> values, string continuationToken, Response response)
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
