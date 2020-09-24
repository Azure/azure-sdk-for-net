// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Proxy for a Microsoft.Spatial.GeometryPolygon class.
    /// </summary>
    internal class GeometryPolygonProxy : GeometryProxy
    {
        private static PropertyInfo s_ringsProperty;
        private IReadOnlyList<GeometryLineStringProxy> _rings;

        /// <summary>
        /// Creates a new instance of the <see cref="GeometryPolygonProxy"/> class.
        /// </summary>
        /// <param name="value">The Microsoft.Spatial.GeometryPolygon object to proxy.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public GeometryPolygonProxy(object value) : base(value)
        {
        }

        /// <summary>
        /// Gets the collection of rings.
        /// </summary>
        public IReadOnlyList<GeometryLineStringProxy> Rings =>
            GetCollectionPropertyValue(
                ref s_ringsProperty,
                ref _rings,
                nameof(Rings),
                value => new GeometryLineStringProxy(value));

        /// <inheritdoc/>
        public override string ToString() => SpatialFormatter.EncodePolygon(this);
    }
}
