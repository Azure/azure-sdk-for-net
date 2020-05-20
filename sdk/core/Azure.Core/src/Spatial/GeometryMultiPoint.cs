// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public sealed class GeometryMultiPoint : Geometry
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="points"></param>
        public GeometryMultiPoint(IEnumerable<PointGeometry> points): this(points, null)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="points"></param>
        /// <param name="properties"></param>
        public GeometryMultiPoint(IEnumerable<PointGeometry> points, GeometryProperties? properties): base(properties)
        {
            Points = points.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<PointGeometry> Points { get; }
    }
}