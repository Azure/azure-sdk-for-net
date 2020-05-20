// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public sealed class GeoPoint : Geometry
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="position"></param>
        public GeoPoint(GeoPosition position): this(position, null)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="position"></param>
        /// <param name="properties"></param>
        public GeoPoint(GeoPosition position, GeometryProperties? properties): base(properties)
        {
            Position = position;
        }

        /// <summary>
        ///
        /// </summary>
        public GeoPosition Position { get; }

        /// <inheritdoc />
        public override string ToString() => $"Point: {Position}";
    }
}