// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public sealed class PointGeometry : Geometry
    {
        /// <summary>
        /// Initializes new instance of <see cref="PointGeometry"/>.
        /// </summary>
        /// <param name="position"></param>
        public PointGeometry(GeometryPosition position): this(position, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="PointGeometry"/>.
        /// </summary>
        /// <param name="position"></param>
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