// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Proxy for a Microsoft.Spatial.GeographyPolygon class.
    /// </summary>
    internal class GeographyPolygonProxy : GeographyProxy
    {
        private static PropertyInfo s_ringsProperty;
        private IReadOnlyList<GeographyLineStringProxy> _rings;

        /// <summary>
        /// Creates a new instance of the <see cref="GeographyPolygonProxy"/> class.
        /// </summary>
        /// <param name="value">The Microsoft.Spatial.GeographyPolygon object to proxy.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public GeographyPolygonProxy(object value) : base(value)
        {
        }

        /// <summary>
        /// Gets the collection of rings.
        /// </summary>
        public IReadOnlyList<GeographyLineStringProxy> Rings =>
            GetCollectionPropertyValue(
                ref s_ringsProperty,
                ref _rings,
                nameof(Rings),
                value => new GeographyLineStringProxy(value));

        /// <inheritdoc/>
        public override string ToString() => SpatialFormatter.EncodePolygon(this);
    }
}
