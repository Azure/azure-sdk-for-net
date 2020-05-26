// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    /// Represents a geometry that is composed of multiple <see cref="LineGeometry"/>.
    /// </summary>
    public sealed class MultiLineGeometry : Geometry
    {
        /// <summary>
        /// Initializes new instance of <see cref="MultiLineGeometry"/>.
        /// </summary>
        /// <param name="lines">The collection of inner lines.</param>
        public MultiLineGeometry(IEnumerable<LineGeometry> lines): this(lines, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="MultiLineGeometry"/>.
        /// </summary>
        /// <param name="lines">The collection of inner lines.</param>
        /// <param name="properties">The <see cref="GeometryProperties"/> associated with the geometry.</param>
        public MultiLineGeometry(IEnumerable<LineGeometry> lines, GeometryProperties properties): base(properties)
        {
            Argument.AssertNotNull(lines, nameof(lines));

            Lines = lines.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<LineGeometry> Lines { get; }
    }
}