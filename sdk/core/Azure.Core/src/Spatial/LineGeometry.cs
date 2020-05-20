// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public sealed class LineGeometry : Geometry
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="positions"></param>
        public LineGeometry(IEnumerable<PositionGeometry> positions): this(positions, null)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="positions"></param>
        /// <param name="properties"></param>
        public LineGeometry(IEnumerable<PositionGeometry> positions, GeometryProperties? properties): base(properties)
        {
            Positions = positions.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<PositionGeometry> Positions { get; }
    }
}