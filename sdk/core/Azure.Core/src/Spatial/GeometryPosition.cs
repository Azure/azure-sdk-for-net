// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public readonly struct GeometryPosition : IEquatable<GeometryPosition>
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
        /// Initializes a new instance of <see cref="GeometryPosition"/>.
        /// </summary>
        /// <param name="longitude">The longitude of the position.</param>
        /// <param name="latitude">The latitude of the position.</param>
        public GeometryPosition(double longitude, double latitude) : this(longitude, latitude, null)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <param name="altitude"></param>
        public GeometryPosition(double longitude, double latitude, double? altitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            Altitude = altitude;
        }


        /// <inheritdoc />
        public bool Equals(GeometryPosition other)
        {
            return Nullable.Equals(Altitude, other.Altitude) && Longitude.Equals(other.Longitude) && Latitude.Equals(other.Latitude);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is GeometryPosition other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode() => HashCodeBuilder.Combine(Longitude, Latitude, Altitude);

        /// <summary>
        ///
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(GeometryPosition left, GeometryPosition right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(GeometryPosition left, GeometryPosition right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Altitude == null)
            {
                return $"[{Longitude:G17}, {Latitude:G17}]";
            }

            return $"[{Longitude:G17}, {Latitude:G17}, {Altitude.Value:G17}]";
        }
    }
}