// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Proxy for a <see cref="Azure.Core.GeoJson.GeoPosition"/> class.
    /// </summary>
    internal class GeoPositionProxy : GeoObjectProxy, IEquatable<GeoPositionProxy>
    {
        private static PropertyInfo s_latitudeProperty;
        private static PropertyInfo s_longitudeProperty;

        /// <summary>
        /// Creates a new instance of the <see cref="GeoPositionProxy"/> class.
        /// </summary>
        /// <param name="value">The <see cref="Azure.Core.GeoJson.GeoPosition"/> object to proxy.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public GeoPositionProxy(object value) : base(value)
        {
        }

        /// <summary>
        /// Gets the latitude.
        /// </summary>
        public double Latitude => GetPropertyValue<double>(ref s_latitudeProperty, nameof(Latitude));

        /// <summary>
        /// Gets the longitude.
        /// </summary>
        public double Longitude => GetPropertyValue<double>(ref s_longitudeProperty, nameof(Longitude));

        /// <summary>
        /// Determines whether the <paramref name="left"/> has the same values as the <paramref name="right"/>.
        /// </summary>
        /// <param name="left">The first <see cref="GeoPositionProxy"/> to compare.</param>
        /// <param name="right">The second <see cref="GeoPositionProxy"/> to compare.</param>
        /// <returns><c>true</c> if the <paramref name="left"/> has the same values as the <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        public static bool operator ==(GeoPositionProxy left, GeoPositionProxy right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether the <paramref name="left"/> has the same values as the <paramref name="right"/>.
        /// </summary>
        /// <param name="left">The first <see cref="GeoPositionProxy"/> to compare.</param>
        /// <param name="right">The second <see cref="GeoPositionProxy"/> to compare.</param>
        /// <returns><c>true</c> if the <paramref name="left"/> has the same values as the <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        public static bool operator !=(GeoPositionProxy left, GeoPositionProxy right)
        {
            if (left is null)
            {
                return right is { };
            }

            return !left.Equals(right);
        }

        /// <inheritdoc/>
        public bool Equals(GeoPositionProxy other) => Value.Equals(other?.Value);

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as GeoPositionProxy);

        /// <inheritdoc/>
        public override int GetHashCode() => Value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => SpatialFormatter.EncodePoint(Longitude, Latitude);
    }
}
