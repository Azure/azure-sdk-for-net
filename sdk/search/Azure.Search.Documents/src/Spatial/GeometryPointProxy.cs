// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Proxy for a Microsoft.Spatial.GeometryPoint class.
    /// </summary>
    internal class GeometryPointProxy : GeometryProxy
    {
        private PropertyInfo _x;
        private PropertyInfo _y;
        private PropertyInfo _z;
        private PropertyInfo _m;

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
        public double X => GetPropertyValue<double>(ref _x, nameof(X));

        /// <summary>
        /// Gets the longitude.
        /// </summary>
        public double Y => GetPropertyValue<double>(ref _y, nameof(Y));

        /// <summary>
        /// Gets the nullable Z.
        /// </summary>
        public double? Z => GetPropertyValue<double?>(ref _z, nameof(Z));

        /// <summary>
        /// Gets the nullable M.
        /// </summary>
        public double? M => GetPropertyValue<double?>(ref _m, nameof(M));
    }
}
