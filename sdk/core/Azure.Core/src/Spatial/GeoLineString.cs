// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public sealed class GeoLineString : Geometry
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="positions"></param>
        public GeoLineString(IEnumerable<GeoPosition> positions)
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