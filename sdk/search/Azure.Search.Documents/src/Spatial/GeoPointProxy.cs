// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Proxy for a <see cref="Azure.Core.GeoJson.GeoPoint"/> class.
    /// </summary>
    internal sealed class GeoPointProxy : GeoObjectProxy, IEquatable<GeoPointProxy>
    {
        private static PropertyInfo s_coordinatesProperty;

        /// <summary>
        /// Creates a new instance of the <see cref="GeoPointProxy"/> class.
        /// </summary>
        /// <param name="value">The <see cref="Azure.Core.GeoJson.GeoPoint"/> object to proxy.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public GeoPointProxy(object value) : base(value)
        {
        }

        /// <summary>
        /// Gets the coordinates.
        /// </summary>
        public GeoPositionProxy Coordinates => new(GetPropertyValue<Core.GeoJson.GeoPosition>(ref s_coordinatesProperty, nameof(Coordinates)));

        /// <summary>
        /// Determines whether the <paramref name="left"/> has the same values as the <paramref name="right"/> value.
        /// </summary>
        /// <param name="left">The first <see cref="GeoPointProxy"/> to compare.</param>
        /// <param name="right">The second <see cref="GeoPointProxy"/> to compare.</param>
        /// <returns><c>true</c> if the <paramref name="left"/> has the same values as the <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        public static bool operator ==(GeoPointProxy left, GeoPointProxy right)
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
        /// <param name="left">The first <see cref="GeoPointProxy"/> to compare.</param>
        /// <param name="right">The second <see cref="GeoPointProxy"/> to compare.</param>
        /// <returns><c>true</c> if the <paramref name="left"/> has the same values as the <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        public static bool operator !=(GeoPointProxy left, GeoPointProxy right)
        {
            if (left is null)
            {
                return right is { };
            }

            return !left.Equals(right);
        }

        /// <inheritdoc/>
        public bool Equals(GeoPointProxy other) => Value.Equals(other?.Value);

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as GeoPointProxy);

        /// <inheritdoc/>
        public override int GetHashCode() => Value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => SpatialFormatter.EncodePoint(Coordinates.Longitude, Coordinates.Latitude);
    }
}
