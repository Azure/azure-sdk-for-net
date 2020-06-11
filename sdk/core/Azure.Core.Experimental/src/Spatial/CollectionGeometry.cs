// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    /// Represents a geometry that is composed of multiple geometries.
    /// </summary>
    public sealed class CollectionGeometry : Geometry
    {
        /// <summary>
        /// Initializes new instance of <see cref="CollectionGeometry"/>.
        /// </summary>
        /// <param name="geometries">The collection of inner geometries.</param>
        public CollectionGeometry(IEnumerable<Geometry> geometries): this(geometries, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="CollectionGeometry"/>.
        /// </summary>
        /// <param name="geometries">The collection of inner geometries.</param>
        /// <param name="properties">The <see cref="GeometryProperties"/> associated with the geometry.</param>
        public CollectionGeometry(IEnumerable<Geometry> geometries, GeometryProperties properties): base(properties)
        {
            Argument.AssertNotNull(geometries, nameof(geometries));

            Geometries = geometries.ToArray();
        }

        /// <summary>
        /// Gets the list of <see cref="Geometry"/> geometry is composed of.
        /// </summary>
        public IReadOnlyList<Geometry> Geometries { get; }
    }
}