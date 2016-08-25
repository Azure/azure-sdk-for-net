// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// A single bucket of a facet query result that reports the number of documents with a field falling within a
    /// particular range or having a particular value or interval.
    /// </summary>
    public class FacetResult
    {
        /// <summary>
        /// Initializes a new instance of the Facet class.
        /// </summary>
        public FacetResult()
        {
            // Do nothing.
        }

        /// <summary>
        /// Gets a value indicating the type of this facet.
        /// </summary>
        public FacetType Type
        {
            get
            {
                return (this.Value != null) ? FacetType.Value : FacetType.Range;
            }
        }

        /// <summary>
        /// Gets a value indicating the inclusive lower bound of the facet's range, or null to indicate that there is
        /// no lower bound (i.e. -- for the first bucket).
        /// </summary>
        [JsonProperty("from")]
        public object From { get; set; }

        /// <summary>
        /// Gets a value indicating the exclusive upper bound of the facet's range, or null to indicate that there is
        /// no upper bound (i.e. -- for the last bucket).
        /// </summary>
        [JsonProperty("to")]
        public object To { get; set; }

        /// <summary>
        /// Gets the value of the facet, or the inclusive lower bound if it's an interval facet.
        /// </summary>
        [JsonProperty("value")]
        public object Value { get; set; }

        /// <summary>
        /// Gets the approximate count of documents falling within the bucket described by this facet.
        /// </summary>
        [JsonProperty("count")]
        public long? Count { get; set; }

        /// <summary>
        /// Attempts to convert the facet to a range facet of the given type.
        /// </summary>
        /// <typeparam name="T">
        /// A type that matches the type of the field to which the facet was applied. Valid types include
        /// <c cref="System.DateTimeOffset">DateTimeOffset</c>, <c cref="System.Double">Double</c>, and
        /// <c cref="System.Int64">Int64</c> (long in C#).
        /// </typeparam>
        /// <returns>A new strongly-typed range facet instance.</returns>
        /// <exception cref="InvalidCastException">This instance is not a range facet of the given type.</exception>
        public RangeFacetResult<T> AsRangeFacetResult<T>() where T : struct
        {
            if (this.Type != FacetType.Range)
            {
                throw new InvalidCastException();
            }

            return new RangeFacetResult<T>(this.Count.GetValueOrDefault(), (T?)this.From, (T?)this.To);
        }

        /// <summary>
        /// Attempts to convert the facet to a value facet of the given type.
        /// </summary>
        /// <typeparam name="T">
        /// A type that matches the type of the field to which the facet was applied.
        /// </typeparam>
        /// <returns>A new strongly-typed value facet instance.</returns>
        /// <exception cref="InvalidCastException">This instance is not a value facet of the given type.</exception>
        public ValueFacetResult<T> AsValueFacetResult<T>()
        {
            if (this.Type != FacetType.Value)
            {
                throw new InvalidCastException();
            }

            return new ValueFacetResult<T>(this.Count.GetValueOrDefault(), (T)this.Value);
        }
    }
}
