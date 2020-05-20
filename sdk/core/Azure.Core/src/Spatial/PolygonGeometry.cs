// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public sealed class PolygonGeometry : Geometry
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="rings"></param>
        public PolygonGeometry(IEnumerable<LineGeometry> rings): this(rings, null)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="rings"></param>
        /// <param name="properties"></param>
        public PolygonGeometry(IEnumerable<LineGeometry> rings, GeometryProperties? properties): base(properties)
        {
            Rings = rings.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<LineGeometry> Rings { get; }
    }
}