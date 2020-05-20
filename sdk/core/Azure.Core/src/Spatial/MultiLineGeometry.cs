// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public sealed class MultiLineGeometry : Geometry
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="lineStrings"></param>
        public MultiLineGeometry(IEnumerable<LineGeometry> lineStrings): this(lineStrings, null)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lineStrings"></param>
        /// <param name="properties"></param>
        public MultiLineGeometry(IEnumerable<LineGeometry> lineStrings, GeometryProperties? properties): base(properties)
        {
            Lines = lineStrings.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<LineGeometry> Lines { get; }
    }
}