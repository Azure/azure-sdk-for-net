// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// A single bucket of a simple or interval facet query result that reports the number of documents with a field
    /// falling within a particular interval or having a specific value.
    /// </summary>
    /// <typeparam name="T">
    /// A type that matches the type of the field to which the facet was applied.
    /// </typeparam>
    public class ValueFacetResult<T>
    {
        internal ValueFacetResult(long count, T value)
        {
            this.Value = value;
            this.Count = count;
        }

        /// <summary>
        /// Gets the approximate count of documents falling within the bucket described by this facet.
        /// </summary>
        public long Count { get; private set; }

        /// <summary>
        /// Gets the value of the facet, or the inclusive lower bound if it's an interval facet.
        /// </summary>
        public T Value { get; private set; }
    }
}
