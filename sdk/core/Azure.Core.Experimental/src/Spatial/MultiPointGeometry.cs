// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    /// Represents a geometry that is composed of multiple <see cref="PointGeometry"/>.
    /// </summary>
    public sealed class MultiPointGeometry : Geometry
    {
        /// <summary>
        /// Initializes new instance of <see cref="MultiPointGeometry"/>.
        /// </summary>
        /// <param name="points">The collection of inner points.</param>
        public MultiPointGeometry(IEnumerable<PointGeometry> points): this(points, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="MultiPointGeometry"/>.
        /// </summary>
        /// <param name="points">The collection of inner points.</param>
        /// <param name="properties">The <see cref="GeometryProperties"/> associated with the geometry.</param>
        public MultiPointGeometry(IEnumerable<PointGeometry> points, GeometryProperties properties): base(properties)
        {
            Argument.AssertNotNull(points, nameof(points));

            Points = points.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<PointGeometry> Points { get; }
    }
}