// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public sealed class MultiPoint : Geometry
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="points"></param>
        public MultiPoint(IEnumerable<Point> points)
        {
            Points = points.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<Point> Points { get; }
    }
}