// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    /// Represents a line geometry that consists of multiple coordinates.
    /// </summary>
    public sealed class LineGeometry : Geometry
    {
        /// <summary>
        /// Initializes new instance of <see cref="LineGeometry"/>.
        /// </summary>
        /// <param name="positions">The collection of <see cref="GeometryPosition"/> that make up the line.</param>
        public LineGeometry(IEnumerable<GeometryPosition> positions): this(positions, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="LineGeometry"/>.
        /// </summary>
        /// <param name="positions">The collection of <see cref="GeometryPosition"/> that make up the line.</param>
        /// <param name="boundingBox">The <see cref="GeometryBoundingBox"/> to use.</param>
        /// <param name="additionalProperties">The set of additional properties associated with the <see cref="Geometry"/>.</param>
        public LineGeometry(IEnumerable<GeometryPosition> positions, GeometryBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> additionalProperties): base(boundingBox, additionalProperties)
        {
            Argument.AssertNotNull(positions, nameof(positions));

            Positions = positions.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<GeometryPosition> Positions { get; }
    }
}