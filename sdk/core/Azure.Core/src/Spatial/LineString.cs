// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public sealed class LineString : Geometry
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="positions"></param>
        public LineString(IEnumerable<Position> positions)
        {
            Positions = positions.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<Position> Positions { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"LineString: {Positions.Count} points";
        }
    }
}