// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Spatial
{
    /// <summary>
    /// Represents information about the coordinate range of the <see cref="Geometry"/>.
    /// </summary>
    public readonly struct GeometryBoundingBox : IEquatable<GeometryBoundingBox>
    {
        /// <summary>
        /// The westmost value of <see cref="Geometry"/> coordinates.
        /// </summary>
        public double West { get; }

        /// <summary>
        /// The southmost value of <see cref="Geometry"/> coordinates.
        /// </summary>
        public double South { get; }

        /// <summary>
        /// The eastmost value of <see cref="Geometry"/> coordinates.
        /// </summary>
        public double East { get; }

        /// <summary>
        /// The northmost value of <see cref="Geometry"/> coordinates.
        /// </summary>
        public double North { get; }

        /// <summary>
        /// The minimum altitude value of <see cref="Geometry"/> coordinates.
        /// </summary>
        public double? MinAltitude { get; }

        /// <summary>
        /// The maximum altitude value of <see cref="Geometry"/> coordinates.
        /// </summary>
        public double? MaxAltitude { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="GeometryBoundingBox"/>.
        /// </summary>
        public GeometryBoundingBox(double west, double south, double east, double north) : this(west, south, east, north, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="GeometryBoundingBox"/>.
        /// </summary>
        public GeometryBoundingBox(double west, double south, double east, double north, double? minAltitude, double? maxAltitude)
        {
            West = west;
            South = south;
            East = east;
            North = north;
            MinAltitude = minAltitude;
            MaxAltitude = maxAltitude;
        }

        /// <inheritdoc />
        public bool Equals(GeometryBoundingBox other)
        {
            return West.Equals(other.West) &&
                   South.Equals(other.South) &&
                   East.Equals(other.East) &&
                   North.Equals(other.North) &&
                   Nullable.Equals(MinAltitude, other.MinAltitude) &&
                   Nullable.Equals(MaxAltitude, other.MaxAltitude);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is GeometryBoundingBox other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCodeBuilder.Combine(West, South, East, North, MinAltitude, MaxAltitude);
        }
    }
}