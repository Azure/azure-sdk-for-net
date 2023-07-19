// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// A single bucket of a simple or interval facet query result that reports
    /// the number of documents with a field falling within a particular
    /// interval or having a specific value.
    /// </summary>
    /// <typeparam name="T">
    /// A type that matches the type of the field to which the facet was
    /// applied.
    /// </typeparam>
    public class ValueFacetResult<T>
    {
        /// <summary>
        /// Gets the approximate count of documents falling within the bucket
        /// described by this facet.
        /// </summary>
        public long Count { get; }

        /// <summary>
        /// Gets the value of the facet, or the inclusive lower bound if it's
        /// an interval facet.
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Creates a new instance of the ValueFacetResult class.
        /// </summary>
        /// <param name="count">
        /// The approximate count of documents falling within the bucket
        /// described by this facet.
        /// </param>
        /// <param name="value">
        /// The value of the facet, or the inclusive lower bound if it's an
        /// interval facet.
        /// </param>
        public ValueFacetResult(long count, T value)
        {
            Value = value;
            Count = count;
        }
    }
}
