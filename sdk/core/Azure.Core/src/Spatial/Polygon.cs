// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public sealed class Polygon : Geometry
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="rings"></param>
        public Polygon(IEnumerable<LineString> rings)
        {
            Rings = rings.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<LineString> Rings { get; }
    }
}