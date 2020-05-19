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
        public GeoPoint(GeoPosition position)
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