// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public sealed class GeoLine : Geometry
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="positions"></param>
        public GeoLine(IEnumerable<GeoPosition> positions): this(positions, null)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="positions"></param>
        /// <param name="properties"></param>
        public GeoLine(IEnumerable<GeoPosition> positions, GeometryProperties? properties): base(properties)
        {
            Positions = positions.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<GeoPosition> Positions { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"LineString: {Positions.Count} points";
        }
    }
}