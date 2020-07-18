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
        public CollectionGeometry(IEnumerable<Geometry> geometries): this(geometries, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="CollectionGeometry"/>.
        /// </summary>
        /// <param name="geometries">The collection of inner geometries.</param>
        /// <param name="boundingBox">The <see cref="GeometryBoundingBox"/> to use.</param>
        /// <param name="additionalProperties">The set of additional properties associated with the <see cref="Geometry"/>.</param>
        public CollectionGeometry(IEnumerable<Geometry> geometries, GeometryBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> additionalProperties): base(boundingBox, additionalProperties)
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