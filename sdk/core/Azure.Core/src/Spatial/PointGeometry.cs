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
        ///
        /// </summary>
        /// <param name="position"></param>
        public PointGeometry(GeometryPosition position): this(position, DefaultProperties)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="position"></param>
        /// <param name="properties"></param>
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