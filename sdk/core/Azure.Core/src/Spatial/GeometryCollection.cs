// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public sealed class GeometryCollection : Geometry
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="geometries"></param>
        public GeometryCollection(IEnumerable<Geometry> geometries)
        {
            Geometries = geometries.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<Geometry> Geometries { get; }
    }
}