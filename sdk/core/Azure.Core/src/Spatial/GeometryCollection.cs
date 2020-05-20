// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    /// Represents a geometry that is composed of multiple geometries.
    /// </summary>
    public sealed class GeometryCollection : Geometry
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="geometries"></param>
        public GeometryCollection(IEnumerable<Geometry> geometries): this(geometries, null)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="geometries"></param>
        /// <param name="properties"></param>
        public GeometryCollection(IEnumerable<Geometry> geometries, GeometryProperties? properties): base(properties)
        {
            Geometries = geometries.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<Geometry> Geometries { get; }
    }
}