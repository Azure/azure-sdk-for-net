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
        /// <param name="rings"></param>
        public PolygonGeometry(IEnumerable<LineGeometry> rings): this(rings, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="PolygonGeometry"/>.
        /// </summary>
        /// <param name="rings"></param>
        /// <param name="properties"></param>
        public PolygonGeometry(IEnumerable<LineGeometry> rings, GeometryProperties properties): base(properties)
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