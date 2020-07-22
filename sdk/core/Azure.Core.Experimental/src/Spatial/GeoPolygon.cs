// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.GeoJson
{
    /// <summary>
    /// Represents a polygon consisting of outer ring and optional inner rings.
    /// </summary>
    public sealed class GeoPolygon : GeoObject
    {
        /// <summary>
        /// Initializes new instance of <see cref="GeoPolygon"/>.
        /// </summary>
        /// <param name="rings">The collection of rings that make up the polygon, first ring is the outer ring others are inner rings.</param>
        public GeoPolygon(IEnumerable<GeoLine> rings): this(rings, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoPolygon"/>.
        /// </summary>
        /// <param name="rings">The collection of rings that make up the polygon, first ring is the outer ring others are inner rings.</param>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="additionalProperties">The set of additional properties associated with the <see cref="GeoObject"/>.</param>
        public GeoPolygon(IEnumerable<GeoLine> rings, GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> additionalProperties): base(boundingBox, additionalProperties)
        {
            Argument.AssertNotNull(rings, nameof(rings));

            Rings = rings.ToArray();
        }

        /// <summary>
        /// Gets a set of rings that form the polygon.
        /// </summary>
        public IReadOnlyList<GeoLine> Rings { get; }
    }
}