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
        public MultiLineGeometry(IEnumerable<LineGeometry> lines): this(lines, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="MultiLineGeometry"/>.
        /// </summary>
        /// <param name="lines">The collection of inner lines.</param>
        /// <param name="boundingBox">The <see cref="GeometryBoundingBox"/> to use.</param>
        /// <param name="additionalProperties">The set of additional properties associated with the <see cref="Geometry"/>.</param>
        public MultiLineGeometry(IEnumerable<LineGeometry> lines, GeometryBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> additionalProperties): base(boundingBox, additionalProperties)
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