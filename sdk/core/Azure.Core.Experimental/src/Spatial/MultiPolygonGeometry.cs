// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    /// Represents a geometry that is composed of multiple <see cref="PolygonGeometry"/>.
    /// </summary>
    public sealed class MultiPolygonGeometry : Geometry
    {
        /// <summary>
        /// Initializes new instance of <see cref="MultiPolygonGeometry"/>.
        /// </summary>
        /// <param name="polygons">The collection of inner polygons.</param>
        public MultiPolygonGeometry(IEnumerable<PolygonGeometry> polygons): this(polygons, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="MultiPolygonGeometry"/>.
        /// </summary>
        /// <param name="polygons">The collection of inner geometries.</param>
        /// <param name="properties">The <see cref="GeometryProperties"/> associated with the geometry.</param>
        public MultiPolygonGeometry(IEnumerable<PolygonGeometry> polygons, GeometryProperties properties): base(properties)
        {
            Argument.AssertNotNull(polygons, nameof(polygons));

            Polygons = polygons.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<PolygonGeometry> Polygons { get; }
    }
}