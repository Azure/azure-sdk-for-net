// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using System.Collections.Generic;

    public partial class FacetResult
    {
        private const string FromKey = "from";
        private const string ToKey = "to";
        private const string ValueKey = "value";

        /// <summary>
        /// Initializes a new instance of the FacetResult class. This constructor is intended to be used for test purposes, since the
        /// properties of this class are immutable.
        /// </summary>
        /// <param name="from">A value indicating the inclusive lower bound of the facet's range, or null to indicate that there is no
        /// lower bound (i.e. -- for the first bucket).</param>
        /// <param name="to">A value indicating the exclusive upper bound of the facet's range, or null to indicate that there is no
        /// upper bound (i.e. -- for the last bucket).</param>
        /// <param name="value">The value of the facet, or the inclusive lower bound if it's an interval facet.</param>
        /// <param name="count">The approximate count of documents falling within the bucket described by this facet.</param>
        public FacetResult(object from, object to, object value, long? count) : this(new Dictionary<string, object>(), count)
        {
            AdditionalProperties[FromKey] = from;
            AdditionalProperties[ToKey] = to;
            AdditionalProperties[ValueKey] = value;
        }

        /// <summary>
        /// Gets a value indicating the type of this facet.
        /// </summary>
        public FacetType Type => (Value != null) ? FacetType.Value : FacetType.Range;

        /// <summary>
        /// Gets a value indicating the inclusive lower bound of the facet's range, or null to indicate that there is
        /// no lower bound (i.e. -- for the first bucket).
        /// </summary>
        public object From => GetValueOrNull(FromKey);

        /// <summary>
        /// Gets a value indicating the exclusive upper bound of the facet's range, or null to indicate that there is
        /// no upper bound (i.e. -- for the last bucket).
        /// </summary>
        public object To => GetValueOrNull(ToKey);

        /// <summary>
        /// Gets the value of the facet, or the inclusive lower bound if it's an interval facet.
        /// </summary>
        public object Value => GetValueOrNull(ValueKey);

        /// <summary>
        /// Attempts to convert the facet to a range facet of the given type.
        /// </summary>
        /// <typeparam name="T">
        /// A type that matches the type of the field to which the facet was applied. Valid types include
        /// <see cref="System.DateTimeOffset" />, <see cref="System.Double" />, and
        /// <see cref="System.Int64" /> (long in C#, int64 in F#).
        /// </typeparam>
        /// <returns>A new strongly-typed range facet instance.</returns>
        /// <exception cref="InvalidCastException">This instance is not a range facet of the given type.</exception>
        public RangeFacetResult<T> AsRangeFacetResult<T>() where T : struct
        {
            if (Type != FacetType.Range)
            {
                throw new InvalidCastException();
            }

            return new RangeFacetResult<T>(Count.GetValueOrDefault(), (T?)From, (T?)To);
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
            if (Type != FacetType.Value)
            {
                throw new InvalidCastException();
            }

            return new ValueFacetResult<T>(Count.GetValueOrDefault(), (T)Value);
        }

        private object GetValueOrNull(string key) => AdditionalProperties.TryGetValue(key, out object value) ? value : null;
    }
}
