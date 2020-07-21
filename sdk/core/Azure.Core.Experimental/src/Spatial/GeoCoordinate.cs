// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Spatial
{
    /// <summary>
    /// Represents a position that is a part of geometry.
    /// </summary>
    public readonly struct GeoCoordinate : IEquatable<GeoCoordinate>
    {
        internal double C1 { get; }
        internal double C2 { get; }
        internal double? C3 { get; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public GeographyCoordinate AsGeographyCoordinate()
        {
            return new GeographyCoordinate(C1, C2, C3);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public GeometryCoordinate AsGeometryCoordinate()
        {
            return new GeometryCoordinate(C1, C2, C3);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="GeoCoordinate"/>.
        /// </summary>
        public GeoCoordinate(GeometryCoordinate geometryCoordinate) : this(geometryCoordinate.X, geometryCoordinate.Y, geometryCoordinate.Z)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="GeoCoordinate"/>.
        /// </summary>
        public GeoCoordinate(GeographyCoordinate geometryCoordinate) : this(geometryCoordinate.Latitude, geometryCoordinate.Longitude, geometryCoordinate.Altitude)
        {
        }

        internal GeoCoordinate(double c1, double c2, double? c3)
        {
            C1 = c1;
            C2 = c2;
            C3 = c3;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        public double this[int index] => index switch
        {
            0 => C1,
            1 => C2,
            2 when C3.HasValue => C3.Value,
#pragma warning disable CA1065
            _ => throw new ArgumentOutOfRangeException(nameof(index), index, $"Provided {nameof(index)} is out of range.")
#pragma warning restore CA1065
        };

        /// <inheritdoc />
        public bool Equals(GeoCoordinate other)
        {
            return Nullable.Equals(C3, other.C3) && C1.Equals(other.C1) && C2.Equals(other.C2);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is GeoCoordinate other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode() => HashCodeBuilder.Combine(C1, C2, C3);

        /// <summary>
        /// Determines whether two specified positions have the same value.
        /// </summary>
        /// <param name="left">The first position to compare.</param>
        /// <param name="right">The first position to compare.</param>
        /// <returns><c>true</c> if the value of <c>left</c> is the same as the value of <c>b</c>; otherwise, <c>false</c>.</returns>
        public static bool operator ==(GeoCoordinate left, GeoCoordinate right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two specified positions have the same value.
        /// </summary>
        /// <param name="left">The first position to compare.</param>
        /// <param name="right">The first position to compare.</param>
        /// <returns><c>false</c> if the value of <c>left</c> is the same as the value of <c>b</c>; otherwise, <c>true</c>.</returns>
        public static bool operator !=(GeoCoordinate left, GeoCoordinate right)
        {
            return !left.Equals(right);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            if (C3 == null)
            {
                return $"[{C1:G17}, {C2:G17}]";
            }

            return $"[{C1:G17}, {C2:G17}, {C3.Value:G17}]";
        }
    }
}