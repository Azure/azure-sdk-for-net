// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Proxy for a Microsoft.Spatial.GeometryPoint class.
    /// </summary>
    internal class GeometryPointProxy : GeometryProxy, IEquatable<GeometryPointProxy>
    {
        private static PropertyInfo s_xProperty;
        private static PropertyInfo s_yProperty;

        /// <summary>
        /// Creates a new instance of the <see cref="GeometryPointProxy"/> class.
        /// </summary>
        /// <param name="value">The Microsoft.Spatial.GeometryPoint object to proxy.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public GeometryPointProxy(object value) : base(value)
        {
        }

        /// <summary>
        /// Gets the latitude.
        /// </summary>
        public double X => GetPropertyValue<double>(ref s_xProperty, nameof(X));

        /// <summary>
        /// Gets the longitude.
        /// </summary>
        public double Y => GetPropertyValue<double>(ref s_yProperty, nameof(Y));

        /// <summary>
        /// Determines whether the <paramref name="left"/> has the same values as the <paramref name="right"/> value.
        /// </summary>
        /// <param name="left">The first <see cref="GeometryPointProxy"/> to compare.</param>
        /// <param name="right">The second <see cref="GeometryPointProxy"/> to compare.</param>
        /// <returns><c>true</c> if the <paramref name="left"/> has the same values as the <paramref name="right"/> value; otherwise, <c>false</c>.</returns>
        public static bool operator ==(GeometryPointProxy left, GeometryPointProxy right)
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
        /// <param name="left">The first <see cref="GeometryPointProxy"/> to compare.</param>
        /// <param name="right">The second <see cref="GeometryPointProxy"/> to compare.</param>
        /// <returns><c>true</c> if the <paramref name="left"/> has the same values as the <paramref name="right"/> value; otherwise, <c>false</c>.</returns>
        public static bool operator !=(GeometryPointProxy left, GeometryPointProxy right)
        {
            if (left is null)
            {
                return right is { };
            }

            return !left.Equals(right);
        }

        /// <inheritdoc/>
        public bool Equals(GeometryPointProxy other) => Value.Equals(other?.Value);

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as GeometryPointProxy);

        /// <inheritdoc/>
        public override int GetHashCode() => Value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => SpatialFormatter.EncodePoint(Y, X);
    }
}
