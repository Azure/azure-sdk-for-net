// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public readonly struct Position : IEquatable<Position>
    {
        /// <summary>
        ///
        /// </summary>
        public double? Altitude { get; }

        /// <summary>
        ///
        /// </summary>
        public double Longitude { get; }

        /// <summary>
        ///
        /// </summary>
        public double Latitude { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        public Position(double longitude, double latitude) : this(longitude, latitude, null)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <param name="altitude"></param>
        public Position(double longitude, double latitude, double? altitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            Altitude = altitude;
        }


        /// <inheritdoc />
        public bool Equals(Position other)
        {
            return Nullable.Equals(Altitude, other.Altitude) && Longitude.Equals(other.Longitude) && Latitude.Equals(other.Latitude);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is Position other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode() => HashCodeBuilder.Combine(Longitude, Latitude, Altitude);

        /// <summary>
        ///
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Position left, Position right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Position left, Position right)
        {
            return !left.Equals(right);
        }
    }
}