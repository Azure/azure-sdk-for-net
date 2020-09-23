// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Adapter for a Microsoft.Spatial.GeometryPoint class.
    /// </summary>
    internal class GeometryPointAdapter : GeometryAdapter
    {
        private PropertyInfo _x;
        private PropertyInfo _y;
        private PropertyInfo _z;
        private PropertyInfo _m;

        /// <summary>
        /// Creates a new instance of the <see cref="GeometryPointAdapter"/> class.
        /// </summary>
        /// <param name="value">The Microsoft.Spatial.GeometryPoint object to adapt.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public GeometryPointAdapter(object value) : base(value)
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
