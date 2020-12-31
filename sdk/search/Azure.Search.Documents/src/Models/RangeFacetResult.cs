// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// A single bucket of a range facet query result that reports the number
    /// of documents with a field value falling within a particular range.
    /// </summary>
    /// <typeparam name="T">
    /// A type that matches the type of the field to which the facet was
    /// applied. Valid types include <see cref="DateTimeOffset"/>,
    /// <see cref="Double"/>, and <see cref="Int64"/>.
    /// </typeparam>
    public class RangeFacetResult<T> where T : struct
    {
        /// <summary>
        /// Gets the approximate count of documents falling within the bucket
        /// described by this facet.
        /// </summary>
        public long Count { get; }

        /// <summary>
        /// Gets a value indicating the inclusive lower bound of the facet's
        /// range, or <c>null</c> to indicate that there is no lower bound
        /// (for the first bucket).
        /// </summary>
        public T? From { get; }

        /// <summary>
        /// Gets a value indicating the exclusive upper bound of the facet's
        /// range, or <c>null</c> to indicate that there is no upper bound
        /// (for the last bucket).
        /// </summary>
        public T? To { get; }

        /// <summary>
        /// Creates a new instance of the RangeFacetResult class.
        /// </summary>
        /// <param name="count">
        /// The approximate count of documents falling within the bucket
        /// described by this facet.
        /// </param>
        /// <param name="from">
        /// A value indicating the inclusive lower bound of the facet's range,
        /// or <c>null</c> to indicate that there is no lower bound (for the
        /// first bucket).
        /// </param>
        /// <param name="to">
        /// A value indicating the exclusive upper bound of the facet's range,
        /// or <c>null</c> to indicate that there is no upper bound (for the
        /// last bucket).
        /// </param>
        public RangeFacetResult(long count, T? from, T? to)
        {
            From = from;
            To = to;
            Count = count;
        }
    }
}
