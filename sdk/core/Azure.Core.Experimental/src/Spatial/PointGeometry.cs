// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        public PointGeometry(GeometryPosition position): this(position, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="PointGeometry"/>.
        /// </summary>
        /// <param name="position">The position of the point.</param>
        /// <param name="properties">The <see cref="GeometryProperties"/> associated with the geometry.</param>
        public PointGeometry(GeometryPosition position, GeometryProperties properties): base(properties)
        {
            Position = position;
        }

        /// <summary>
        /// Gets position of the point.
        /// </summary>
        public GeometryPosition Position { get; }
    }
}
