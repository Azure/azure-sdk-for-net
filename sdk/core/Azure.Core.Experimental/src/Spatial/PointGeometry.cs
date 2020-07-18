// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Core.Spatial
{
    /// <summary>
    /// Represents a point geometry.
    /// </summary>
    public sealed class PointGeometry : Geometry
    {
        /// <summary>
        /// Initializes new instance of <see cref="PointGeometry"/>.
        /// </summary>
        /// <param name="position">The position of the point.</param>
        public PointGeometry(GeometryPosition position): this(position, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="PointGeometry"/>.
        /// </summary>
        /// <param name="position">The position of the point.</param>
        /// <param name="boundingBox">The <see cref="GeometryBoundingBox"/> to use.</param>
        /// <param name="additionalProperties">The set of additional properties associated with the <see cref="Geometry"/>.</param>
        public PointGeometry(GeometryPosition position, GeometryBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> additionalProperties): base(boundingBox, additionalProperties)
        {
            Position = position;
        }

        /// <summary>
        /// Gets position of the point.
        /// </summary>
        public GeometryPosition Position { get; }
    }
}
