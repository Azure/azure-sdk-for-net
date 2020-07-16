// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Spatial
{
    /// <summary>
    /// Represents information about the geographic coordinate range of the <see cref="GeoObject"/>.
    /// </summary>
    public readonly struct GeometryBoundingBox : IEquatable<GeographyBoundingBox>
    {
        /// <summary>
        /// The westmost value of <see cref="GeoObject"/> coordinates.
        /// </summary>
        public double MinX { get; }

        /// <summary>
        /// The southmost value of <see cref="GeoObject"/> coordinates.
        /// </summary>
        public double MinY { get; }

        /// <summary>
        /// The eastmost value of <see cref="GeoObject"/> coordinates.
        /// </summary>
        public double MaxX { get; }

        /// <summary>
        /// The northmost value of <see cref="GeoObject"/> coordinates.
        /// </summary>
        public double MaxY { get; }

        /// <summary>
        /// The minimum altitude value of <see cref="GeoObject"/> coordinates.
        /// </summary>
        public double? MinZ { get; }

        /// <summary>
        /// The maximum altitude value of <see cref="GeoObject"/> coordinates.
        /// </summary>
        public double? MaxZ { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="GeoBoundingBox"/>.
        /// </summary>
        public GeometryBoundingBox(double minX, double minY, double maxX, double maxY) : this(minX, minY, null, maxX, maxY, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="GeoBoundingBox"/>.
        /// </summary>
        public GeometryBoundingBox(double minX, double minY, double? minZ, double maxX, double maxY, double? maxZ)
        {
            MinX = minX;
            MinY = minY;
            MaxX = maxX;
            MaxY = maxY;
            MinZ = minZ;
            MaxZ = maxZ;
        }

        /// <inheritdoc />
        public bool Equals(GeographyBoundingBox other)
        {
            return MinX.Equals(other.West) &&
                   MinY.Equals(other.South) &&
                   MaxX.Equals(other.East) &&
                   MaxY.Equals(other.North) &&
                   Nullable.Equals(MinZ, other.MinAltitude) &&
                   Nullable.Equals(MaxZ, other.MaxAltitude);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is GeoBoundingBox other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCodeBuilder.Combine(MinX, MinY, MaxX, MaxY, MinZ, MaxZ);
        }
    }
}