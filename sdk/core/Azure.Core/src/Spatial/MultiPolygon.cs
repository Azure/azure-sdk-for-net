// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public sealed class MultiPolygon : Geometry
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="polygons"></param>
        public MultiPolygon(IEnumerable<Polygon> polygons)
        {
            Polygons = polygons.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<Polygon> Polygons { get; }
    }
}