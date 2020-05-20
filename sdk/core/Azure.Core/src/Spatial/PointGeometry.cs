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
        public PointGeometry(PositionGeometry position): this(position, null)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="position"></param>
        /// <param name="properties"></param>
        public PointGeometry(PositionGeometry position, GeometryProperties? properties): base(properties)
        {
            Position = position;
        }

        /// <summary>
        ///
        /// </summary>
        public PositionGeometry Position { get; }

        /// <inheritdoc />
        public override string ToString() => $"Point: {Position}";
    }
}