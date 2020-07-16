// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public readonly struct GeometryCoordinate
    {
        /// <summary>
        /// Gets the altitude of the position.
        /// </summary>
        public double? Z { get; }

        /// <summary>
        /// Gets the longitude of the position.
        /// </summary>
        public double X { get; }

        /// <summary>
        /// Gets the latitude of the position.
        /// </summary>
        public double Y { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="GeoCoordinate"/>.
        /// </summary>
        /// <param name="x">The longitude of the position.</param>
        /// <param name="y">The latitude of the position.</param>
        public GeometryCoordinate(double x, double y) : this(x, y, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="GeoCoordinate"/>.
        /// </summary>
        /// <param name="x">The longitude of the position.</param>
        /// <param name="y">The latitude of the position.</param>
        /// <param name="z">The altitude of the position.</param>
        public GeometryCoordinate(double x, double y, double? z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <inheritdoc />
        public bool Equals(GeometryCoordinate other)
        {
            return Nullable.Equals(Z, other.Z) && X.Equals(other.X) && Y.Equals(other.Y);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is GeometryCoordinate other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode() => HashCodeBuilder.Combine(X, Y, Z);

        /// <summary>
        /// Determines whether two specified positions have the same value.
        /// </summary>
        /// <param name="left">The first position to compare.</param>
        /// <param name="right">The first position to compare.</param>
        /// <returns><c>true</c> if the value of <c>left</c> is the same as the value of <c>b</c>; otherwise, <c>false</c>.</returns>
        public static bool operator ==(GeometryCoordinate left, GeometryCoordinate right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two specified positions have the same value.
        /// </summary>
        /// <param name="left">The first position to compare.</param>
        /// <param name="right">The first position to compare.</param>
        /// <returns><c>false</c> if the value of <c>left</c> is the same as the value of <c>b</c>; otherwise, <c>true</c>.</returns>
        public static bool operator !=(GeometryCoordinate left, GeometryCoordinate right)
        {
            return !left.Equals(right);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            if (Z == null)
            {
                return $"X: {X:G}, Y: {Y:G}";
            }

            return $"X: {X:G}, Y: {Y:G}, Z: {Z.Value:G}";
        }
    }
}