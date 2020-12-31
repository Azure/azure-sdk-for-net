// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Proxy for a Microsoft.Spatial.GeographyPoint class.
    /// </summary>
    internal class GeographyPointProxy : GeographyProxy, IEquatable<GeographyPointProxy>
    {
        private static PropertyInfo s_latitudeProperty;
        private static PropertyInfo s_longitudeProperty;

        /// <summary>
        /// Creates a new instance of the <see cref="GeographyPointProxy"/> class.
        /// </summary>
        /// <param name="value">The Microsoft.Spatial.GeographyPoint object to proxy.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public GeographyPointProxy(object value) : base(value)
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
        /// Determines whether the <paramref name="left"/> has the same values as the <paramref name="right"/> value.
        /// </summary>
        /// <param name="left">The first <see cref="GeographyPointProxy"/> to compare.</param>
        /// <param name="right">The second <see cref="GeographyPointProxy"/> to compare.</param>
        /// <returns><c>true</c> if the <paramref name="left"/> has the same values as the <paramref name="right"/> value; otherwise, <c>false</c>.</returns>
        public static bool operator ==(GeographyPointProxy left, GeographyPointProxy right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether the <paramref name="left"/> has the same values as the <paramref name="right"/> value.
        /// </summary>
        /// <param name="left">The first <see cref="GeographyPointProxy"/> to compare.</param>
        /// <param name="right">The second <see cref="GeographyPointProxy"/> to compare.</param>
        /// <returns><c>true</c> if the <paramref name="left"/> has the same values as the <paramref name="right"/> value; otherwise, <c>false</c>.</returns>
        public static bool operator !=(GeographyPointProxy left, GeographyPointProxy right)
        {
            if (left is null)
            {
                return right is { };
            }

            return !left.Equals(right);
        }

        /// <inheritdoc/>
        public bool Equals(GeographyPointProxy other) => Value.Equals(other?.Value);

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as GeographyPointProxy);

        /// <inheritdoc/>
        public override int GetHashCode() => Value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => SpatialFormatter.EncodePoint(Longitude, Latitude);
    }
}
