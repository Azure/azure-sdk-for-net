// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Proxy for a Microsoft.Spatial.GeometryPosition class.
    /// </summary>
    internal class GeometryPositionProxy : GeometryProxy
    {
        private static PropertyInfo s_xProperty;
        private static PropertyInfo s_yProperty;

        /// <summary>
        /// Creates a new instance of the <see cref="GeometryPositionProxy"/> class.
        /// </summary>
        /// <param name="value">The Microsoft.Spatial.GeometryPoint object to proxy.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public GeometryPositionProxy(object value) : base(value)
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

        /// <inheritdoc/>
        public override string ToString() => SpatialFormatter.EncodePoint(Y, X);
    }
}
