// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    /// Represents a polygon consisting of outer ring and optional inner rings.
    /// </summary>
    public sealed class PolygonGeometry : Geometry
    {
        /// <summary>
        /// Initializes new instance of <see cref="PolygonGeometry"/>.
        /// </summary>
        /// <param name="rings">The collection of rings that make up the polygon, first ring is the outer ring others are inner rings.</param>
        public PolygonGeometry(IEnumerable<LineGeometry> rings): this(rings, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="PolygonGeometry"/>.
        /// </summary>
        /// <param name="rings">The collection of rings that make up the polygon, first ring is the outer ring others are inner rings.</param>
        /// <param name="boundingBox">The <see cref="GeometryBoundingBox"/> to use.</param>
        /// <param name="additionalProperties">The set of additional properties associated with the <see cref="Geometry"/>.</param>
        public PolygonGeometry(IEnumerable<LineGeometry> rings, GeometryBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> additionalProperties): base(boundingBox, additionalProperties)
        {
            Argument.AssertNotNull(rings, nameof(rings));

            Rings = rings.ToArray();
        }

        /// <summary>
        /// Gets a set of rings that form the polygon.
        /// </summary>
        public IReadOnlyList<LineGeometry> Rings { get; }
    }
}