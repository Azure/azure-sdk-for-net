// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Proxy for a <see cref="Azure.Core.GeoJson.GeoLineString"/> class.
    /// </summary>
    internal sealed class GeoLineStringProxy : GeoObjectProxy
    {
        private static PropertyInfo s_coordinatesProperty;
        private IReadOnlyList<GeoPositionProxy> _coordinates;

        /// <summary>
        /// Creates a new instance of the <see cref="GeoLineStringProxy"/> class.
        /// </summary>
        /// <param name="value">The <see cref="Azure.Core.GeoJson.GeoLineString"/> object to proxy.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public GeoLineStringProxy(object value) : base(value)
        {
        }

        /// <summary>
        /// Gets the proxy for <see cref="Azure.Core.GeoJson.GeoLineString.Coordinates"/> collection.
        /// </summary>
        public IReadOnlyList<GeoPositionProxy> Coordinates =>
            GetCollectionPropertyValue(
                ref s_coordinatesProperty,
                ref _coordinates,
                nameof(Coordinates));

        /// <inheritdoc/>
        public override string ToString() => SpatialFormatter.EncodePolygon(this);
    }
}
