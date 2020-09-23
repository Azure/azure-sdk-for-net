// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Proxy for a Microsoft.Spatial.GeometryLineString class.
    /// </summary>
    internal class GeometryLineStringProxy : GeometryProxy
    {
        private static PropertyInfo s_pointsProperty;
        private IReadOnlyList<GeometryPointProxy> _points;

        /// <summary>
        /// Creates a new instance of the <see cref="GeometryLineStringProxy"/> class.
        /// </summary>
        /// <param name="value">The Microsoft.Spatial.GeometryLineString object to proxy.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public GeometryLineStringProxy(object value) : base(value)
        {
        }

        /// <summary>
        /// Gets the point collection.
        /// </summary>
        public IReadOnlyList<GeometryPointProxy> Points =>
            GetCollectionPropertyValue(
                ref s_pointsProperty,
                ref _points,
                nameof(Points),
                value => new GeometryPointProxy(value));
    }
}
