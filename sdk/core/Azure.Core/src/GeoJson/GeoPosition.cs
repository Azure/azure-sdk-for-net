// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.GeoJson
{
    /// <summary>
    ///
    /// </summary>
    public readonly struct GeoPosition : IEquatable<GeoPosition>
    {
        /// <summary>
        /// Gets the altitude of the position.
        /// </summary>
        public double? Altitude { get; }

        /// <summary>
        /// Gets the longitude of the position.
        /// </summary>
        public double Longitude { get; }

        /// <summary>
        /// Gets the latitude of the position.
        /// </summary>
        public double Latitude { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="GeoPosition"/>.
        /// </summary>
        /// <param name="longitude">The longitude of the position.</param>
        /// <param name="latitude">The latitude of the position.</param>
        public GeoPosition(double longitude, double latitude) : this(longitude, latitude, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="GeoPosition"/>.
        /// </summary>
        /// <param name="longitude">The longitude of the position.</param>
        /// <param name="latitude">The latitude of the position.</param>
        /// <param name="altitude">The altitude of the position.</param>
        public GeoPosition(double longitude, double latitude, double? altitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            Altitude = altitude;
        }

        /// <inheritdoc />
        public bool Equals(GeoPosition other)
        {
            return Nullable.Equals(Altitude, other.Altitude) && Longitude.Equals(other.Longitude) && Latitude.Equals(other.Latitude);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is GeoPosition other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode() => HashCodeBuilder.Combine(Longitude, Latitude, Altitude);

        /// <summary>
        /// Determines whether two specified positions have the same value.
        /// </summary>
        /// <param name="left">The first position to compare.</param>
        /// <param name="right">The first position to compare.</param>
        /// <returns><c>true</c> if the value of <c>left</c> is the same as the value of <c>b</c>; otherwise, <c>false</c>.</returns>
        public static bool operator ==(GeoPosition left, GeoPosition right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two specified positions have the same value.
        /// </summary>
        /// <param name="left">The first position to compare.</param>
        /// <param name="right">The first position to compare.</param>
        /// <returns><c>false</c> if the value of <c>left</c> is the same as the value of <c>b</c>; otherwise, <c>true</c>.</returns>
        public static bool operator !=(GeoPosition left, GeoPosition right)
        {
            return !left.Equals(right);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            if (Altitude == null)
            {
                return $"[{Longitude:G17}, {Latitude:G17}]";
            }

            return $"[{Longitude:G17}, {Latitude:G17}, {Altitude.Value:G17}]";
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        public double this[int index]
        {
            get
            {
                return index switch
                {
                    0 => Longitude,
                    1 => Latitude,
                    2 when Altitude != null => Altitude.Value,
#pragma warning disable CA1065 // We want to have a behavior similar to an array
                    _ => throw new IndexOutOfRangeException()
#pragma warning restore
                };
            }
        }

        /// <summary>
        ///
        /// </summary>
        public int Count => Altitude == null ? 2 : 3;
    }
}
