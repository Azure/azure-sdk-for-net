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
        /// Initializes new instance of <see cref="MultiLineGeometry"/>.
        /// </summary>
        /// <param name="lineStrings"></param>
        public MultiLineGeometry(IEnumerable<LineGeometry> lineStrings): this(lineStrings, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="MultiLineGeometry"/>.
        /// </summary>
        /// <param name="lineStrings"></param>
        /// <param name="properties">The <see cref="GeometryProperties"/> associated with the geometry.</param>
        public MultiLineGeometry(IEnumerable<LineGeometry> lineStrings, GeometryProperties properties): base(properties)
        {
            Argument.AssertNotNull(lineStrings, nameof(lineStrings));

            Lines = lineStrings.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<LineGeometry> Lines { get; }
    }
}