// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public sealed class GeoMultiLineString : Geometry
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="lineStrings"></param>
        public GeoMultiLineString(IEnumerable<GeoLineString> lineStrings): this(lineStrings, null)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lineStrings"></param>
        /// <param name="properties"></param>
        public GeoMultiLineString(IEnumerable<GeoLineString> lineStrings, GeometryProperties? properties): base(properties)
        {
            LineStrings = lineStrings.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<GeoLineString> LineStrings { get; }
    }
}