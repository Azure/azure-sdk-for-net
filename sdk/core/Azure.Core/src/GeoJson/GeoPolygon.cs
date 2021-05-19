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
        /// <param name="positions">The positions that make up the outer ring of the polygon.</param>
        public GeoPolygon(IEnumerable<GeoPosition> positions): this(new[] { new GeoLinearRing(positions) }, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoPolygon"/>.
        /// </summary>
        /// <param name="rings">The collection of rings that make up the polygon, first ring is the outer ring others are inner rings.</param>
        public GeoPolygon(IEnumerable<GeoLinearRing> rings): this(rings, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoPolygon"/>.
        /// </summary>
        /// <param name="rings">The collection of rings that make up the polygon, first ring is the outer ring others are inner rings.</param>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="customProperties">The set of custom properties associated with the <see cref="GeoObject"/>.</param>
        public GeoPolygon(IEnumerable<GeoLinearRing> rings, GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> customProperties): base(boundingBox, customProperties)
        {
            Argument.AssertNotNull(rings, nameof(rings));

            Rings = rings.ToArray();
        }

        /// <summary>
        /// Gets a set of rings that form the polygon.
        /// </summary>
        public IReadOnlyList<GeoLinearRing> Rings { get; }

        /// <summary>
        /// Returns the outer right of the polygon
        /// </summary>
        public GeoLinearRing OuterRing => Rings[0];

        /// <summary>
        /// Returns a view over the coordinates array that forms this geometry.
        /// </summary>
        public GeoArray<GeoArray<GeoPosition>> Coordinates => new GeoArray<GeoArray<GeoPosition>>(this);

        /// <inheritdoc />
        public override GeoObjectType Type { get; } = GeoObjectType.Polygon;
    }
}