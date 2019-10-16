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
    public abstract class Page<T>
    {
        /// <summary>
        /// Gets the values in this <see cref="Page{T}"/>.
        /// </summary>
        public abstract IReadOnlyList<T> Values { get; }

        /// <summary>
        /// Gets the continuation token used to request the next
        /// <see cref="Page{T}"/>.  The continuation token may be null or
        /// empty when there are no more pages.
        /// </summary>
        public abstract string? ContinuationToken { get; }

        /// <summary>
        /// Gets the <see cref="Response"/> that provided this
        /// <see cref="Page{T}"/>.
        /// </summary>
        public abstract Response GetRawResponse();

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
        public override bool Equals(object? obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the <see cref="Page{T}"/>.
        /// </summary>
        /// <returns>Hash code for the <see cref="Page{T}"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();
    }
}
