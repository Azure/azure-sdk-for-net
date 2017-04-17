// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// A single bucket of a range facet query result that reports the number of documents with a field value falling
    /// within a particular range.
    /// </summary>
    /// <typeparam name="T">
    /// A type that matches the type of the field to which the facet was applied. Valid types include
    /// <c cref="System.DateTimeOffset">DateTimeOffset</c>, <c cref="System.Double">Double</c>, and
    /// <c cref="System.Int64">Int64</c> (long in C#).
    /// </typeparam>
    public class RangeFacetResult<T> where T : struct
    {
        internal RangeFacetResult(long count, T? from, T? to)
        {
            this.From = from;
            this.To = to;
            this.Count = count;
        }

        /// <summary>
        /// Gets the approximate count of documents falling within the bucket described by this facet.
        /// </summary>
        public long Count { get; private set; }

        /// <summary>
        /// Gets a value indicating the inclusive lower bound of the facet's range, or null to indicate that there is
        /// no lower bound (i.e. -- for the first bucket).
        /// </summary>
        public T? From { get; private set; }

        /// <summary>
        /// Gets a value indicating the exclusive upper bound of the facet's range, or null to indicate that there is
        /// no upper bound (i.e. -- for the last bucket).
        /// </summary>
        public T? To { get; private set; }
    }
}
