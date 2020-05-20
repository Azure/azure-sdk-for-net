// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public sealed class GeoPolygon : Geometry
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="rings"></param>
        public GeoPolygon(IEnumerable<GeoLine> rings): this(rings, null)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="rings"></param>
        /// <param name="properties"></param>
        public GeoPolygon(IEnumerable<GeoLine> rings, GeometryProperties? properties): base(properties)
        {
            Rings = rings.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<GeoLine> Rings { get; }
    }
}